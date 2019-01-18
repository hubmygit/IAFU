using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class ActivityDescription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsIaAction { get; set; }

        public ActivityDescription()
        {
        }
        public ActivityDescription(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [IsIaAction] " +
                              "FROM [dbo].[Activity_Descriptions] " +
                              "WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    Name = reader["Name"].ToString();
                    IsIaAction = Convert.ToBoolean(reader["IsIaAction"].ToString());
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        public static List<ActivityDescription> GetSqlActivityDescriptionList()
        {
            List<ActivityDescription> ret = new List<ActivityDescription>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [IsIaAction] " +
                              "FROM [dbo].[Activity_Descriptions] ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new ActivityDescription() {
                                                        Id = Convert.ToInt32(reader["Id"].ToString()),
                                                        Name = reader["Name"].ToString(),
                                                        IsIaAction = Convert.ToBoolean(reader["IsIaAction"].ToString())
                                                      });
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }


    }
}
