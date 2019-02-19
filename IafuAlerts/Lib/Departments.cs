﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IafuAlerts
{
    public class Departments
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Departments()
        {
        }

        public Departments(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name] " +
                              "FROM [dbo].[Departments] " +
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

        public static List<Departments> GetSqlDepartmentsList()
        {
            List<Departments> ret = new List<Departments>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name] " +
                              "FROM [dbo].[Departments] " +
                              "ORDER BY Name ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Departments() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString() });
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

                
        public static bool Insert(string deptName) //INSERT [dbo].[Departments]
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Audit] ([Name]) VALUES " +
                           "(@Name) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);


                cmd.Parameters.AddWithValue("@Name", deptName);

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
            sqlConn.Close();

            return ret;
        }

    }
}
