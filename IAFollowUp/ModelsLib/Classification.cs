using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class Classification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decision Decision { get; set; }

        public Classification()
        {

        }

        public Classification(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [DecisionId] " + 
                              "FROM [dbo].[Classification] " +
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
                    Decision = new Decision(Convert.ToInt32(reader["DecisionId"].ToString()));
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        public static List<Classification> GetSqlClassificationList()
        {
            List<Classification> ret = new List<Classification>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [DecisionId] " +
                              "FROM [dbo].[Classification] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Classification()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Name = reader["Name"].ToString(),
                        Decision = new Decision(Convert.ToInt32(reader["DecisionId"].ToString()))
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