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
    public partial class DraftAttachments : Form
    {
        public DraftAttachments()
        {
            InitializeComponent();
        }

        public DraftAttachments(int detailId, int placeholderId, int userId)
        {
            InitializeComponent();

            //DraftId = givenId;
            DetailId = detailId;
            PlaceholderId = placeholderId;
            UserId = userId;

            string[] fileNames = getSavedAttachments(DetailId, PlaceholderId, UserId);

            foreach (string thisFileName in fileNames)
            {
                lvAttachedFiles.Items.Add(new ListViewItem(thisFileName));
            }
            AttCnt = fileNames.Length;
        }

        //int DraftId;

        int DetailId;
        int PlaceholderId;
        int UserId;

        public int AttCnt;
        public bool success = false;

        public void makeReadOnly()
        {
            btnAddFiles.Enabled = false;
            btnRemoveAll.Enabled = false;
            btnRemoveFile.Enabled = false;
            btnSave.Enabled = false;
        }

        public static string[] getSavedAttachments(int tableDetId, int tablePhId, int tableUsrId)
        {
            List<string> ret = new List<string>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Name FROM [dbo].[Activity_AttachmentsDrafts] WHERE DetailId = @detId AND isnull(PlaceholderId, 0) = @phId AND UserId = @usrId ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detId", tableDetId);
                cmd.Parameters.AddWithValue("@phId", tablePhId);
                cmd.Parameters.AddWithValue("@usrId", tableUsrId);

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

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Add Files";
            ofd.Multiselect = true; //array of files
            ofd.ShowDialog();

            //Add Files into listView...
            addFilesIntoListView(lvAttachedFiles, ofd.FileNames);
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

                    string SelectSt = "SELECT [FileContents] FROM [dbo].[Activity_AttachmentsDrafts] WHERE DetailId = @detId AND isnull(PlaceholderId, 0) = @phId AND UserId = @usrId AND Name = @Filename";

                    SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
                    try
                    {
                        sqlConn.Open();

                        cmd.Parameters.AddWithValue("@detId", DetailId);
                        cmd.Parameters.AddWithValue("@phId", PlaceholderId);
                        cmd.Parameters.AddWithValue("@usrId", UserId);
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

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (lvAttachedFiles.SelectedItems.Count > 0)
            {
                lvAttachedFiles.SelectedItems[0].Remove();
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            lvAttachedFiles.Items.Clear();
        }

        LvFileInfo saveAttachmentLocally(int detId, int phId, int usrId, string Filename)
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
            string SelectSt = "SELECT [Name], [FileContents] FROM [dbo].[Activity_AttachmentsDrafts] WHERE DetailId = @detId AND isnull(PlaceholderId, 0) = @phId AND UserId = @usrId and Name = @Filename ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detId", detId);
                cmd.Parameters.AddWithValue("@phId", phId);
                cmd.Parameters.AddWithValue("@usrId", usrId);

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

        private bool InsertIntoTable_AttachedFiles(int dId, int pId, string fileName, byte[] fileBytes) //INSERT [dbo].[Activity_AttachmentsDrafts]
        {
            bool ret = false;

            if (dId > 0 && fileName.Trim().Length > 0)
            {
                SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
                string InsSt = "INSERT INTO [dbo].[Activity_AttachmentsDrafts] (Name, FileContents, DetailId, PlaceholderId, UserId, InsDate) VALUES " +
                     "(@Filename, @FileCont, @dId, @pId, @uId, getdate() ) ";

                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                    cmd.Parameters.AddWithValue("@dId", dId);

                    if (pId > 0)
                    {
                        cmd.Parameters.AddWithValue("@pId", pId);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@pId", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@uId", UserInfo.userDetails.Id);
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

        public static bool InsertDraftsAttachedFilesFromActivity(int aId, int dId, int pId) //INSERT [dbo].[Activity_AttachmentsDrafts]
        {
            bool ret = false;

            if (aId > 0 && dId > 0)
            {
                SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
                string InsSt = "INSERT INTO [dbo].[Activity_AttachmentsDrafts] (DetailId, PlaceholderId, UserId, Name, FileContents, InsDate) " +
                     "SELECT @dId, @pId, @uId, Name, FileContents, getdate() as InsDate FROM [dbo].[FIDetail_Activity_Attachments] WHERE ActivityId = @aId";

                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                    cmd.Parameters.AddWithValue("@aId", aId);

                    cmd.Parameters.AddWithValue("@dId", dId);

                    if (pId > 0)
                    {
                        cmd.Parameters.AddWithValue("@pId", pId);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@pId", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@uId", UserInfo.userDetails.Id);
                    
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

        public static bool Delete_SampleFiles(int given_dId, int given_pId, int given_uId)
        {
            bool ret = false;

            if (given_dId > 0 && given_uId > 0)
            {
                SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
                string InsSt = "DELETE FROM [dbo].[Activity_AttachmentsDrafts] WHERE DetailId = @dId AND isnull(PlaceholderId, 0) = @pId AND UserId = @uId ";
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                    cmd.Parameters.AddWithValue("@dId", given_dId);
                    cmd.Parameters.AddWithValue("@pId", given_pId);
                    cmd.Parameters.AddWithValue("@uId", given_uId);
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


        private void btnSave_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.OK;
            //success = true;    

            Save();
        }


        public void Save() //....
        {
            if (AttCnt == 0 && lvAttachedFiles.Items.Count == 0)
            {
                Close();
                return;
            }

            //int Id = DraftId;
            int detId = DetailId;
            int phId = PlaceholderId;
            int usrId = UserId;

            List<ListViewItem> newLvItems = new List<ListViewItem>();

            foreach (ListViewItem lvi in lvAttachedFiles.Items)
            {
                if (lvi.SubItems.Count == 1) //only filename into lv -> from db
                {
                    LvFileInfo lvfi = saveAttachmentLocally(DetailId, PlaceholderId, UserId, lvi.SubItems[0].Text);

                    newLvItems.Add(new ListViewItem(new string[] { lvfi.FileName, lvfi.FilePath }));
                }
                else //path and filename into lv -> from local dir : ok
                {
                    newLvItems.Add(lvi);
                }
            }

            //delete sample files
            Delete_SampleFiles(detId, phId, usrId); //delete from db

            bool IsOk = false;

            //update old records
            //insert attachments into db - IsCurrent = 1
            foreach (ListViewItem lvi in newLvItems)
            {
                byte[] attFileBytes = File.ReadAllBytes(lvi.SubItems[1].Text);

                if (!InsertIntoTable_AttachedFiles(detId, phId, lvi.SubItems[0].Text, attFileBytes))
                {
                    MessageBox.Show("File save failed: " + lvi.SubItems[0].Text);
                }
                else
                {
                    IsOk = true;
                }
            }

            success = true;

            AttCnt = lvAttachedFiles.Items.Count;
            if (AttCnt > 0 && IsOk)
            {
                MessageBox.Show("File(s) attached successfully!");
            }

            Close();
        }

    }
}
