using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class Placeholders
    {
        public int Id { get; set; }
        public Companies Company { get; set; }
        public Departments Department { get; set; }

        public Placeholders()
        {
        }

        public Placeholders(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [DepartmentId], [CompanyId] " +
                              "FROM [dbo].[Placeholders] " +
                              "WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    Company = new Companies(Convert.ToInt32(reader["CompanyId"].ToString()));
                    Department = new Departments(Convert.ToInt32(reader["DepartmentId"].ToString()));
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        public static List<Placeholders> GetSqlPlaceholdersList()
        {
            List<Placeholders> ret = new List<Placeholders>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [DepartmentId], [CompanyId] " +
                              "FROM [dbo].[Placeholders] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Placeholders()
                        {
                            Id = Convert.ToInt32(reader["Id"].ToString()),
                            Company = new Companies(Convert.ToInt32(reader["CompanyId"].ToString())),
                            Department = new Departments(Convert.ToInt32(reader["DepartmentId"].ToString()))
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
