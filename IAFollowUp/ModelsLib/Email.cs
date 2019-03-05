﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Data;

namespace IAFollowUp
{
    public class Email
    {

        public static bool SendBcc(EmailProperties emailProp) //string subject, string body) //List<Recipient> Recipients)
        {
            bool ret = true;

            EmailParams emailParams = new EmailParams();
            ExchangeService service = new ExchangeService();

            try
            {
                service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
            }
            catch (Exception ex)
            {
                //ret = false;
                MessageBox.Show("Exchange Service error: " + ex.Message);

                saveFailedEmails(emailProp);
                return false;
            }

            try
            {
                service.Credentials = new WebCredentials(emailParams.UserName, emailParams.Password, emailParams.Domain);
                service.AutodiscoverUrl(emailParams.EmailAddress);
            }
            catch (Exception ex)
            {
                //ret = false;
                MessageBox.Show("ERROR [Exchange Service]: " + ex.Message);

                saveFailedEmails(emailProp);
                return false;
            }

            EmailMessage email = new EmailMessage(service);
            email.Importance = Importance.High;
            email.Subject = emailProp.Subject;
            email.Body = new MessageBody(BodyType.Text, emailProp.Body + "\r\n\r\n This message has been generated by the Internal Audit Follow Up Server. Please do not reply."); 

            foreach (Recipient rec in emailProp.Recipients)
            {
                //email.ToRecipients.Add(rec.Email);
                email.BccRecipients.Add(rec.Email);
            }

            if (Migration.migrationMode)
            {
                email.BccRecipients.Clear();

                email.BccRecipients.Add(Migration.email);
            }

            try
            {
                email.SendAndSaveCopy();
            }
            catch (Exception ex)
            {
                //ret = false;
                MessageBox.Show("Exception occured [Exchange Service]: " + ex.Message + " \r\n {0}", ex.ToString());
                saveFailedEmails(emailProp);
                return false;
            }

            return ret;
        }

        public static void saveFailedEmails(EmailProperties failedEmailProperties)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[FailedEmails] ([Addresses],[Subject],[Body],[InsDt],[InsUserId],[Isactive]) VALUES " + 
                           "(encryptByPassPhrase(@passPhrase, convert(varchar(7800), @Addresses)), @Subject, " +
                           "encryptByPassPhrase(@passPhrase, convert(varchar(7800), @Body)), getdate(), @userId, 1 ) ";
            try
            {
                sqlConn.Open();
                
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                string allEmailAddresses = String.Join(";", failedEmailProperties.Recipients.Select(i => i.Email).ToArray());

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@Addresses", allEmailAddresses);
                cmd.Parameters.AddWithValue("@Subject", failedEmailProperties.Subject);
                cmd.Parameters.AddWithValue("@Body", failedEmailProperties.Body);
                cmd.Parameters.AddWithValue("@userId", UserInfo.userDetails.Id);

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
