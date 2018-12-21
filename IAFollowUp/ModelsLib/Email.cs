﻿using System;
using System.Collections.Generic;
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

            //EmailParams emailParams = new EmailParams();
            ExchangeService service = new ExchangeService();

            try
            {
                service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
            }
            catch (Exception ex)
            {
                ret = false;
                MessageBox.Show("ERROR:" + ex.Message);
            }

            //service.Credentials = new WebCredentials(emailParams.UserName, emailParams.Password, emailParams.Domain);
            //service.AutodiscoverUrl(emailParams.EmailAddress);

            EmailMessage email = new EmailMessage(service);
            email.Importance = Importance.High;
            email.Subject = emailProp.Subject;
            email.Body = new MessageBody(BodyType.Text, emailProp.Body); 

            foreach (Recipient rec in emailProp.Recipients)
            {
                //email.ToRecipients.Add(rec.Email);
                email.BccRecipients.Add(rec.Email);
            }

            try
            {
                email.SendAndSaveCopy();
            }
            catch (Exception ex)
            {
                ret = false;
                MessageBox.Show("Exception occured: " + ex.Message + " \r\n {0}", ex.ToString());
            }

            return ret;
        }

    }
}