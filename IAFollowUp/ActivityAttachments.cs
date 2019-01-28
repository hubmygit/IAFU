using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public partial class ActivityAttachments : Form
    {
        public ActivityAttachments()
        {
            InitializeComponent();
        }

        public ActivityAttachments(int givenId)
        {
            InitializeComponent();

            ActivityId = givenId;
            string[] fileNames = getSavedAttachments(ActivityId);

            foreach (string thisFileName in fileNames)
            {
                lvAttachedFiles.Items.Add(new ListViewItem(thisFileName));
            }
            AttCnt = fileNames.Length;
        }

        int ActivityId;
        public int AttCnt;
        public bool success = false;
                
        public static string[] getSavedAttachments(int tableId)
        {
            List<string> ret = new List<string>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Name FROM [dbo].[FIDetail_Activity_Attachments] WHERE ActivityId = " + tableId.ToString();

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ret.Add(reader["Name"].ToString().Trim());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret.ToArray();
        }

        void addFilesIntoListView(ListView myListView, string[] fileNames)
        {
            bool exists = false;

            if (fileNames is null)
            {
                MessageBox.Show("File not found. \r\nPlease choose a file stored on your local disk!");
                return;
            }

            foreach (string thisFile in fileNames)
            {
                exists = false;
                System.IO.FileInfo newFile = new System.IO.FileInfo(thisFile);

                foreach (ListViewItem lvi in myListView.Items)
                {
                    if (lvi.SubItems[0].Text.ToUpper() == newFile.Name.ToUpper())
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists)
                {
                    MessageBox.Show("File '" + newFile.Name + "' is already attached");
                    continue;
                }

                ListViewItem lvItem = new ListViewItem(new string[] { newFile.Name, newFile.FullName });
                myListView.Items.Add(lvItem);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (lvAttachedFiles.SelectedItems.Count > 0)
            {
                string lvPath = "";

                if (lvAttachedFiles.SelectedItems[0].SubItems.Count == 1) //only filename from database into lv
                //if (CountSampleFiles(extraDataId) > 0) //select 
                {
                    string ext = "";
                    string tempPath = Path.GetTempPath(); //C:\Users\hkylidis\AppData\Local\Temp\
                    string tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(lvAttachedFiles.SelectedItems[0].SubItems[0].Text) + "~" + Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
                    try
                    {
                        if (!Directory.Exists(tempPath))
                        {
                            MessageBox.Show("Error. Please check your privileges on " + tempPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The following error occurred: " + ex.Message);
                        return;
                    }

                    SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

                    string SelectSt = "SELECT [FileContents] FROM [dbo].[FIDetail_Activity_Attachments] WHERE ActivityId = @ActivityId AND Name = @Filename";

                    SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
                    try
                    {
                        sqlConn.Open();

                        cmd.Parameters.AddWithValue("@ActivityId", ActivityId);
                        cmd.Parameters.AddWithValue("@Filename", lvAttachedFiles.SelectedItems[0].SubItems[0].Text);

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string fname = lvAttachedFiles.SelectedItems[0].SubItems[0].Text;
                            ext = fname.Substring(fname.LastIndexOf("."));
                            lvPath = tempFile + ext;
                            //decrypt files
                            byte[] fileCont = (byte[])reader["FileContents"];
                            byte[] decrFileCont = CryptoFuncs.DecryptBytesFromBytes_Aes(fileCont);
                            File.WriteAllBytes(tempFile + ext, decrFileCont);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The following error occurred: " + ex.Message);
                        return;
                    }
                }
                else //path and filename from local dir into lv
                //insert || update -> update ??? mixed files, check... 
                {
                    lvPath = lvAttachedFiles.SelectedItems[0].SubItems[1].Text;
                }

                System.Diagnostics.Process.Start(lvPath);
            }
        }
        
        LvFileInfo saveAttachmentLocally(int Id, string Filename)
        {
            LvFileInfo ret = new LvFileInfo();
            string tempPath = Path.GetTempPath(); //C:\Users\hkylidis\AppData\Local\Temp\
            try
            {
                if (!Directory.Exists(tempPath))
                {
                    MessageBox.Show("Error. Please check your privileges on " + tempPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
                return ret;
            }

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Name], [FileContents] FROM [dbo].[FIDetail_Activity_Attachments] WHERE ActivityId = @Id and Name = @Filename ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Filename", Filename);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string realFileName = reader["Name"].ToString().Trim();
                    //string tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + "~" + realFileName);
                    //temp file -> attachment name with temp name and tilda 'tmp123~ΦΕΚ123.pdf'
                    string tempFile = Path.Combine(tempPath, realFileName);
                    try
                    {
                        //decrypt files
                        byte[] fileCont = (byte[])reader["FileContents"];
                        byte[] decrFileCont = CryptoFuncs.DecryptBytesFromBytes_Aes(fileCont);
                        File.WriteAllBytes(tempFile, decrFileCont);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occured while saving temporarilly the attached file: '" + realFileName +
                            "'\r\n\r\n\r\nDetails:\r\n" + ex.Message);
                        try
                        {
                            tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + "~" + realFileName);
                            //decrypt files
                            byte[] fileCont = (byte[])reader["FileContents"];
                            byte[] decrFileCont = CryptoFuncs.DecryptBytesFromBytes_Aes(fileCont);
                            File.WriteAllBytes(tempFile, decrFileCont);

                            MessageBox.Show("Caution! File will be saved as: " + tempFile);
                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show("Caution! File " + realFileName + " will not be saved!\r\n" + ex2.Message);
                        }

                    }

                    ret = new LvFileInfo { FileName = realFileName, FilePath = tempFile };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
                return ret;
            }

            return ret;
        }

        private bool InsertIntoTable_AttachedFiles(int Id, string fileName, byte[] fileBytes) //INSERT [dbo].[FIDetail_Activity_Attachments]
        {
            bool ret = false;

            if (Id > 0 && fileName.Trim().Length > 0)
            {
                SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
                string InsSt = "INSERT INTO [dbo].[FIDetail_Activity_Attachments] (Name, FileContents, ActivityId, UsersId, InsDate) VALUES " +
                     "(@Filename, @FileCont, @Id, @UsersId, getdate() ) ";

                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@UsersId", UserInfo.userDetails.Id);
                    cmd.Parameters.AddWithValue("@Filename", fileName);

                    //encrypt files
                    if (fileBytes.Length <= 0)
                    {
                        MessageBox.Show("File Is Empty!");
                        return false;
                    }

                    byte[] encrFileCont = CryptoFuncs.EncryptBytesToBytes_Aes(fileBytes);
                    cmd.Parameters.Add("@FileCont", SqlDbType.VarBinary).Value = encrFileCont;

                    cmd.CommandType = CommandType.Text;
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        ret = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }

            return ret;
        }

        public static bool InsertActivityAttachedFilesFromDrafts(int actId, int detId, int phId) //INSERT [dbo].[FIDetail_Activity_Attachments]
        {
            bool ret = false;

            if (actId > 0 && detId > 0)
            {
                SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
                string InsSt = "INSERT INTO [dbo].[FIDetail_Activity_Attachments] (ActivityId, Name, FileContents, UsersId, InsDate) " +
                     "SELECT @actId as ActivityId, [Name], [FileContents], @usrId as UsersId, getdate() as InsDate " + 
                     "FROM [dbo].[Activity_AttachmentsDrafts] WHERE detailId = @detId and isnull(placeholderId, 0) = @phId and userId = @usrId ";

                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                    cmd.Parameters.AddWithValue("@actId", actId);
                    cmd.Parameters.AddWithValue("@usrId", UserInfo.userDetails.Id);
                    cmd.Parameters.AddWithValue("@detId", detId);
                    cmd.Parameters.AddWithValue("@phId", phId);
                    
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        ret = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }

            return ret;
        }

        private bool Delete_SampleFiles(int given_ActivityId)
        {
            bool ret = false;

            if (given_ActivityId > 0)
            {
                SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
                string InsSt = "DELETE FROM [dbo].[FIDetail_Activity_Attachments] WHERE ActivityId = @Id ";
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                    cmd.Parameters.AddWithValue("@Id", given_ActivityId);
                    cmd.CommandType = CommandType.Text;
                    //int rowsAffected = cmd.ExecuteNonQuery();

                    cmd.ExecuteNonQuery();

                    //if (rowsAffected > 0)
                    //{
                    ret = true;
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }

            return ret;
        }


    }
}
