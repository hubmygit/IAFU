﻿using System;
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


        private static void Ins_ChLog(ChangeLog givenLog)
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

        public static void Insert_Attachments() //attachments
        {
            ChangeLog chLog = new ChangeLog();
            chLog.Section = "Attachments";
            chLog.Tbl_Id = 0;
            chLog.AppUsers_Id = UserInfo.userDetails.Id;
            chLog.Dt = DateTime.Now;
            chLog.ExecStatement = "UPDATE";
            chLog.TableName = "Audit_Attachments";

            chLog.FieldName = "All";
            chLog.OldValue = "Audit_Attachments_Log";
            chLog.NewValue = "Audit_Attachments";
            chLog.FieldNameToShow = "Attachments";

            Ins_ChLog(chLog);
        }

        public static void Insert(Audit oldRec, Audit newRec, string section)
        {
            ChangeLog chLog = new ChangeLog();
            chLog.Section = section;
            chLog.Tbl_Id = oldRec.Id;
            //tml.TM_Status_Id = null;
            chLog.AppUsers_Id = UserInfo.userDetails.Id;
            chLog.Dt = DateTime.Now;
            chLog.ExecStatement = "UPDATE";
            if (newRec.IsDeleted == true)
            {
                chLog.ExecStatement = "DELETE";
            }
            chLog.TableName = "Audit";

            List<ChLogFields> FieldsToCheck = new List<ChLogFields>();

            FieldsToCheck.Add(new ChLogFields() { FieldName = "Year", FieldNameToShow = "Year" });
            FieldsToCheck.Add(new ChLogFields() { FieldName = "Company", FieldNameToShow = "Company" }); //obj
            FieldsToCheck.Add(new ChLogFields() { FieldName = "AuditType", FieldNameToShow = "Audit Type" }); //obj
            FieldsToCheck.Add(new ChLogFields() { FieldName = "Title", FieldNameToShow = "Title" });
            FieldsToCheck.Add(new ChLogFields() { FieldName = "ReportDt", FieldNameToShow = "Report Date" });
            FieldsToCheck.Add(new ChLogFields() { FieldName = "Auditor1", FieldNameToShow = "Auditor 1" }); //obj
            FieldsToCheck.Add(new ChLogFields() { FieldName = "Auditor2", FieldNameToShow = "Auditor 2" }); //obj
            FieldsToCheck.Add(new ChLogFields() { FieldName = "Supervisor", FieldNameToShow = "Supervisor" }); //obj
            FieldsToCheck.Add(new ChLogFields() { FieldName = "AuditNumber", FieldNameToShow = "Audit Number" });
            FieldsToCheck.Add(new ChLogFields() { FieldName = "IASentNumber", FieldNameToShow = "IA Sent Number" });
            FieldsToCheck.Add(new ChLogFields() { FieldName = "AuditRating", FieldNameToShow = "Audit Rating" }); //obj
            FieldsToCheck.Add(new ChLogFields() { FieldName = "IsDeleted", FieldNameToShow = "Deletion Flag" });
            FieldsToCheck.Add(new ChLogFields() { FieldName = "IsCompleted", FieldNameToShow = "Completed Flag" });

            //FieldsToCheck.Add(new TmLogFields() { FieldName = "ClassIds", FieldNameToShow = "Κλάσεις", FieldType = "List<int>" });

            foreach (ChLogFields chlf in FieldsToCheck)
            {
                object objOld = oldRec.GetType().GetProperty(chlf.FieldName).GetValue(oldRec, null);
                object objNew = newRec.GetType().GetProperty(chlf.FieldName).GetValue(newRec, null);
                string strOld = "";
                string strNew = "";

                //if (chlf.FieldType == "List<int>")
                //{
                //    if (objOld != null)
                //    {
                //        strOld = String.Join(",", ((List<int>)objOld).ToArray());
                //    }
                //    if (objNew != null)
                //    {
                //        strNew = String.Join(",", ((List<int>)objNew).ToArray());
                //    }

                //    if (strOld != strNew)
                //    {
                //        chLog.FieldName = chlf.FieldName;
                //        chLog.OldValue = strOld;
                //        chLog.NewValue = strNew;
                //        chLog.FieldNameToShow = chlf.FieldNameToShow;

                //        Ins_TMLog(chLog);
                //    }
                //}
                //else
                //{

                if (objOld != null)
                {
                    if (objOld.GetType() == typeof(Companies))
                    {
                        strOld = ((Companies)objOld).Name.ToString();
                    }
                    else if (objOld.GetType() == typeof(AuditTypes))
                    {
                        strOld = ((AuditTypes)objOld).Name.ToString();
                    }
                    else if (objOld.GetType() == typeof(Users))
                    {
                        if (chlf.FieldName == "Auditor1")
                        {
                            strOld = ((Users)objOld).FullName.ToString();
                        }
                        else if (chlf.FieldName == "Auditor2" && ((Users)objOld).Id > 0)
                        {
                            strOld = ((Users)objOld).FullName.ToString();
                        }
                        else if (chlf.FieldName == "Supervisor" && ((Users)objOld).Id > 0)
                        {
                            strOld = ((Users)objOld).FullName.ToString();
                        }
                    }
                    else if (objOld.GetType() == typeof(AuditRating) && ((AuditRating)objOld).Id > 0)
                    {
                        strOld = ((AuditRating)objOld).Name.ToString();
                    }
                    else
                    {
                        strOld = objOld.ToString();
                    }                    
                }

                if (objNew != null)
                {
                    if (objNew.GetType() == typeof(Companies))
                    {
                        strNew = ((Companies)objNew).Name.ToString();
                    }
                    else if (objNew.GetType() == typeof(AuditTypes))
                    {
                        strNew = ((AuditTypes)objNew).Name.ToString();
                    }
                    else if (objNew.GetType() == typeof(Users))
                    {
                        if (chlf.FieldName == "Auditor1")
                        {
                            strNew = ((Users)objNew).FullName.ToString();
                        }
                        else if (chlf.FieldName == "Auditor2" && ((Users)objNew).Id > 0)
                        {
                            strNew = ((Users)objNew).FullName.ToString();
                        }
                        else if (chlf.FieldName == "Supervisor" && ((Users)objNew).Id > 0)
                        {
                            strNew = ((Users)objNew).FullName.ToString();
                        }
                    }
                    else if (objNew.GetType() == typeof(AuditRating) && ((AuditRating)objNew).Id > 0)
                    {
                        strNew = ((AuditRating)objNew).Name.ToString();
                    }
                    else
                    {
                        strNew = objNew.ToString();
                    }
                }


                if (strOld != strNew)
                {
                    chLog.FieldName = chlf.FieldName;
                    chLog.OldValue = strOld;
                    chLog.NewValue = strNew;
                    chLog.FieldNameToShow = chlf.FieldNameToShow;

                    Ins_ChLog(chLog);
                }
                //}

            }
        }

    }

    public class ChLogFields
    {
        public string FieldName { get; set; }
        public string FieldNameToShow { get; set; }
        public string FieldType { get; set; }
        //public int MandatoryGroup { get; set; }
    }
}
