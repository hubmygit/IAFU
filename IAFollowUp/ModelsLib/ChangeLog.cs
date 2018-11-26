using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class ChangeLog
    {
        public int Tbl_Id { get; set; }
        public int AppUsers_Id { get; set; }
        public DateTime Dt { get; set; }
        public string ExecStatement { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string FieldNameToShow { get; set; }
        public string Section { get; set; }

        //other fields - refs
        //public string FullName { get; set; }
        //public string TMNo { get; set; }
        //public string TMName { get; set; }
        //public string Status { get; set; }


        public static void Ins_ChLog(ChangeLog givenLog)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[ChangeLog] " +
                           "([Tbl_Id], [AppUsers_Id], [Dt], [ExecStatement], [TableName], [FieldName], [FieldNameToShow], [OldValue], [NewValue], [Section]) " +
                           "VALUES " +
                           "(@Tbl_Id, @AppUsers_Id, @Dt, @ExecStatement, @TableName, @FieldName, @FieldNameToShow, @OldValue, @NewValue, @Section) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Tbl_Id", givenLog.Tbl_Id);
                
                cmd.Parameters.AddWithValue("@AppUsers_Id", givenLog.AppUsers_Id);
                cmd.Parameters.AddWithValue("@Dt", givenLog.Dt);
                cmd.Parameters.AddWithValue("@ExecStatement", givenLog.ExecStatement);
                cmd.Parameters.AddWithValue("@TableName", givenLog.TableName);
                cmd.Parameters.AddWithValue("@FieldName", givenLog.FieldName);
                cmd.Parameters.AddWithValue("@FieldNameToShow", givenLog.FieldNameToShow);
                cmd.Parameters.AddWithValue("@OldValue", givenLog.OldValue);
                cmd.Parameters.AddWithValue("@NewValue", givenLog.NewValue);
                cmd.Parameters.AddWithValue("@Section", givenLog.Section);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);

            }
            sqlConn.Close();
        }
    }
}
