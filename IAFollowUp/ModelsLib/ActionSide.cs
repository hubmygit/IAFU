using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{

    public class ActionSide
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ActionSide()
        {
        }

        public ActionSide(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name] " +
                              "FROM [dbo].[Action_Side] " +
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
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        public static List<ActionSide> GetSqlActionSideList()
        {
            List<ActionSide> ret = new List<ActionSide>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name] " +
                              "FROM [dbo].[Action_Side] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new ActionSide() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString() });
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


    //public enum ActionSide
    //{
    //    Auditors = 1,
    //    Auditees = 2,
    //    None = 3
    //}


}
