using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IafuAlerts
{
    public partial class Alerts : Form
    {
        public Alerts()
        {
            InitializeComponent();
        }

        private void Alerts_Load(object sender, EventArgs e)
        {            
            string[] args = Environment.GetCommandLineArgs();

            if (args.Count(i => i.ToUpper().Trim(new char[] { ' ', '-', '/' }) == "MTMONTH") > 0)
            {
                ExpireInM();
                Application.Exit();
            }
            else if (args.Count(i => i.ToUpper().Trim(new char[] { ' ', '-', '/' }) == "MTEXP") > 0)
            {
                Expired();
                Application.Exit();
            }
            else if (args.Count(i => i.ToUpper().Trim(new char[] { ' ', '-', '/' }) == "IAEXP15") > 0)
            {
                ExpireIn15D();
                Application.Exit();
            }
            else if (args.Count(i => i.ToUpper().Trim(new char[] { ' ', '-', '/' }) == "IANOACT") > 0)
            {
                NoAction15D();
                Application.Exit();
            }
            else if (args.Count(i => i.ToUpper().Trim(new char[] { ' ', '-', '/' }) == "FAILEDEMAIL") > 0)
            {
                FailedEmails();
                Application.Exit();
            }

        }

        private void ExpireInM() //MTMONTH
        {
            Output.WriteToFile("STARTING...");
            Output.WriteToFile("* Expire In Month *");

            List<AlertObject> alertObjectList = Notifications.NotifExpireIn1M();

            Output.WriteToFile("Details to send: " + alertObjectList.Count.ToString());

            if (alertObjectList.Count > 0)
            {
                List<List<AlertObject>> alertGroupedObjectList = alertObjectList.GroupBy(i => i.User.Id).Select(g => g.ToList()).ToList();
                
                foreach (List<AlertObject> alObjList in alertGroupedObjectList)
                {
                    int cnt = alObjList.Count;
                    string email = alObjList[0].User.getEmail();

                    Output.WriteToFile("Details To MT User " + alObjList[0].User.Id.ToString() + ": " + cnt.ToString());

                    AlertEmails alert = new AlertEmails(1);

                    EmailProperties emailProps = new EmailProperties();
                    emailProps.RecipientsTo = new List<Recipient> { new Recipient() { FullName = alObjList[0].User.FullName, Email = email } };
                    emailProps.RecipientsCC = new List<Recipient>();
                    emailProps.RecipientsBcc = new List<Recipient>();
                    emailProps.Subject = alert.EmailSubject;
                    emailProps.Body = alert.EmailBody.Replace("@", cnt.ToString());

                    if (Email.Send(emailProps))
                    {
                        //MessageBox.Show("Email(s) sent!");
                        Output.WriteToFile("Email(s) sent!");
                    }
                    else
                    {
                        //MessageBox.Show("Emails have not been sent!");
                        Output.WriteToFile("Emails have not been sent!", true);
                    }
                }
            }

            Output.WriteToFile("COMPLETED...");
        }

        private void Expired() //MTEXP
        {
            Output.WriteToFile("STARTING...");
            Output.WriteToFile("* Expired *");

            List<AlertObject> alertObjectList = Notifications.NotifExpired();

            Output.WriteToFile("Details to send: " + alertObjectList.Count.ToString());

            if (alertObjectList.Count > 0)
            {
                List<List<AlertObject>> alertGroupedObjectList = alertObjectList.GroupBy(i => i.User.Id).Select(g => g.ToList()).ToList();

                foreach (List<AlertObject> alObjList in alertGroupedObjectList)
                {
                    int cnt = alObjList.Count;
                    string email = alObjList[0].User.getEmail();

                    Output.WriteToFile("Details To MT User " + alObjList[0].User.Id.ToString() + ": " + cnt.ToString());

                    AlertEmails alert = new AlertEmails(2);

                    EmailProperties emailProps = new EmailProperties();
                    emailProps.RecipientsTo = new List<Recipient> { new Recipient() { FullName = alObjList[0].User.FullName, Email = email } };
                    emailProps.RecipientsBcc = new List<Recipient>();
                    List<Users> ccUsers = Owners_GM.GetOwnerGMUsersList(alObjList[0].Placeholder.Id);
                    ccUsers.Add(Users.getCAE());

                    List<Recipient> ccRec = new List<Recipient>();
                    foreach (Users usr in ccUsers)
                    {
                        ccRec.Add(new Recipient() { FullName = usr.FullName, Email = usr.getEmail() });
                    }

                    emailProps.RecipientsCC = ccRec;

                    emailProps.Subject = alert.EmailSubject;
                    emailProps.Body = alert.EmailBody.Replace("@", cnt.ToString());

                    if (Email.Send(emailProps))
                    {
                        //MessageBox.Show("Email(s) sent!");
                        Output.WriteToFile("Email(s) sent!");
                    }
                    else
                    {
                        //MessageBox.Show("Emails have not been sent!");
                        Output.WriteToFile("Emails have not been sent!", true);
                    }
                }

            }

            Output.WriteToFile("COMPLETED...");
        }

        private void ExpireIn15D() //IAEXP15
        {
            Output.WriteToFile("STARTING...");
            Output.WriteToFile("* Expire In 15 Days *");

            List<AlertObject> alertObjectList = Notifications.NotifExpireIn15D();

            Output.WriteToFile("All distinct Details: " + alertObjectList.Count.ToString());

            List<Users> usrList = new List<Users>(); //alertObj.Auditor1

            foreach (AlertObject alertObj in alertObjectList)
            {
                if (alertObj.Auditor1.Id > 0 && usrList.Exists(i => i.Id == alertObj.Auditor1.Id) == false)
                {
                    usrList.Add(alertObj.Auditor1);
                }

                if (alertObj.Auditor2.Id > 0 && usrList.Exists(i => i.Id == alertObj.Auditor2.Id) == false)
                {
                    usrList.Add(alertObj.Auditor2);
                }
            }

            foreach (Users usr in usrList)
            {
                List<AlertObject> usrAlerts = alertObjectList.Where(i => i.Auditor1.Id == usr.Id || i.Auditor2.Id == usr.Id).ToList();

                int cnt = usrAlerts.Count;
                string email = usr.getEmail();

                Output.WriteToFile("Details to Auditor " + usr.Id.ToString() + ": " + cnt.ToString());

                AlertEmails alert = new AlertEmails(3);

                EmailProperties emailProps = new EmailProperties();
                emailProps.RecipientsTo = new List<Recipient> { new Recipient() { FullName = usr.FullName, Email = email } };
                emailProps.RecipientsCC = new List<Recipient>();
                emailProps.RecipientsBcc = new List<Recipient>();
                emailProps.Subject = alert.EmailSubject;
                emailProps.Body = alert.EmailBody.Replace("@", cnt.ToString());

                if (Email.Send(emailProps))
                {
                    //MessageBox.Show("Email(s) sent!");
                    Output.WriteToFile("Email(s) sent!");
                }
                else
                {
                    //MessageBox.Show("Emails have not been sent!");
                    Output.WriteToFile("Emails have not been sent!", true);
                }
            }

            Output.WriteToFile("COMPLETED...");
        }

        private void NoAction15D() //IANOACT
        {
            Output.WriteToFile("STARTING...");
            Output.WriteToFile("* No Action In 15 Days *");

            List<AlertObject> alertObjectList = Notifications.NotifNoAction15D();

            Output.WriteToFile("All (not distinct) Details: " + alertObjectList.Count.ToString());

            if (alertObjectList.Count > 0)
            {
                Users cae = Users.getCAE();
                string email = cae.getEmail();

                List<List<AlertObject>> alertGroupedObjectList = alertObjectList.GroupBy(i => i.User.Id).Select(g => g.ToList()).ToList();

                foreach (List<AlertObject> alObjList in alertGroupedObjectList)
                {
                    int cnt = alObjList.Count;

                    Output.WriteToFile("Details To Auditor " + alObjList[0].User.Id.ToString() + ": " + cnt.ToString());

                    AlertEmails alert = new AlertEmails(4);

                    EmailProperties emailProps = new EmailProperties();
                    emailProps.RecipientsTo = new List<Recipient> { new Recipient() { FullName = cae.FullName, Email = email } };
                    emailProps.RecipientsCC = new List<Recipient>();
                    emailProps.RecipientsBcc = new List<Recipient>();
                    emailProps.Subject = alert.EmailSubject;
                    emailProps.Body = alert.EmailBody.Replace("@1", cnt.ToString()).Replace("@2", alObjList[0].User.FullName);

                    if (Email.Send(emailProps))
                    {
                        //MessageBox.Show("Email(s) sent!");
                        Output.WriteToFile("Email(s) sent!");
                    }
                    else
                    {
                        //MessageBox.Show("Emails have not been sent!");
                        Output.WriteToFile("Emails have not been sent!", true);
                    }
                }
            }

            Output.WriteToFile("COMPLETED...");
        }

        private void FailedEmails() //FAILEDEMAIL
        {
            Output.WriteToFile("STARTING...");
            Output.WriteToFile("* Failed Emails *");

            List<AlertEmails> lostEmails = Notifications.getFailedEmails(); 

            Output.WriteToFile("Emails to send: " + lostEmails.Count.ToString());

            foreach (AlertEmails thisEmail in lostEmails)
            {
                Output.WriteToFile("Id: " + thisEmail.Id);

                EmailProperties emailProps = new EmailProperties();
                emailProps.RecipientsTo = new List<Recipient>();
                emailProps.RecipientsCC = new List<Recipient>();

                List<string> recipientAddresses = thisEmail.Name.Split(';').ToList();
                List<Recipient> addresses = new List<Recipient>();
                foreach (string str in recipientAddresses)
                {
                    addresses.Add(new Recipient() { Email = str });
                }

                emailProps.RecipientsBcc = addresses;
                emailProps.Subject = thisEmail.EmailSubject;
                emailProps.Body = thisEmail.EmailBody;

                if (Email.Send(emailProps))
                {
                    Output.WriteToFile("Email(s) sent!");

                    Output.WriteToFile("Updating flags.");
                    if (Notifications.updateFailedEmailsTable(thisEmail.Id) == false)
                    {
                        Output.WriteToFile("Error while updating flags.");
                    }
                }
                else
                {
                    Output.WriteToFile("Emails have not been sent!", true);
                }
            }

            Output.WriteToFile("COMPLETED...");
        }

        private void btnExpireInM_Click(object sender, EventArgs e)
        {
            ExpireInM();
        }

        private void btnExpired_Click(object sender, EventArgs e)
        {
            Expired();
        }

        private void btnExpireIn15D_Click(object sender, EventArgs e)
        {
            ExpireIn15D();
        }

        private void btnNoAction15D_Click(object sender, EventArgs e)
        {
            NoAction15D();
        }

        private void btnFailedEmails_Click(object sender, EventArgs e)
        {
            FailedEmails();
        }
        
        private void btnOpenLog_Click(object sender, EventArgs e)
        {
            var directory = new System.IO.DirectoryInfo(Application.StartupPath + "\\Logs");

            if (directory.GetFiles("*.txt").Length > 0)
            {
                var myFile = directory.GetFiles("*.txt")
                             .OrderByDescending(f => f.LastWriteTime)
                             .First();

                System.Diagnostics.Process.Start(myFile.FullName);
            }
            else
            {
                MessageBox.Show("There are no log files!");
            }
            

        }

        private void btnTestExpireInM_Click(object sender, EventArgs e)
        {
            //Output.WriteToFile("* Expire In Month *");
            List<AlertObject> alertObjectList = Notifications.NotifExpireIn1M();
            BindingList<CheckResults> ChResBList = new BindingList<CheckResults>();
            if (alertObjectList.Count > 0)
            {
                List<List<AlertObject>> alertGroupedObjectList = alertObjectList.GroupBy(i => i.User.Id).Select(g => g.ToList()).ToList();
                foreach (List<AlertObject> alObjList in alertGroupedObjectList)
                {                    
                    string FullName = alObjList[0].User.FullName;
                    string Email = alObjList[0].User.getEmail();
                    int Cnt = alObjList.Count;

                    ChResBList.Add(new CheckResults() { fullName = FullName, email = Email, cnt = Cnt });
                }
            }

            CheckResults01 frmCheckRes = new CheckResults01(ChResBList);
            frmCheckRes.ShowDialog();
        }

        private void btnTestExpired_Click(object sender, EventArgs e)
        {
            //Output.WriteToFile("* Expired *");
            List<AlertObject> alertObjectList = Notifications.NotifExpired();
            BindingList<CheckResults> ChResBList = new BindingList<CheckResults>();
            if (alertObjectList.Count > 0)
            {
                List<List<AlertObject>> alertGroupedObjectList = alertObjectList.GroupBy(i => i.User.Id).Select(g => g.ToList()).ToList();
                foreach (List<AlertObject> alObjList in alertGroupedObjectList)
                {
                    string FullName = alObjList[0].User.FullName;
                    string Email = alObjList[0].User.getEmail();
                    int Cnt = alObjList.Count;

                    CheckResults chRes = new CheckResults() { fullName = FullName, email = Email, cnt = Cnt };

                    List<Users> ccUsers = Owners_GM.GetOwnerGMUsersList(alObjList[0].Placeholder.Id);
                    ccUsers.Add(Users.getCAE());

                    List<Recipient> ccRec = new List<Recipient>();
                    foreach (Users usr in ccUsers)
                    {
                        ccRec.Add(new Recipient() { FullName = usr.FullName, Email = usr.getEmail() });
                    }

                    chRes.ccfullNames = string.Join(",", ccRec.Select(i => i.FullName));
                    chRes.ccEmails = string.Join(",", ccRec.Select(i => i.Email));

                    ChResBList.Add(chRes);
                }
            }

            CheckResults01 frmCheckRes = new CheckResults01(ChResBList);
            frmCheckRes.ShowDialog();
        }

        private void btnTestFailedEmails_Click(object sender, EventArgs e)
        {
            //Output.WriteToFile("* Failed Emails *");
            List<AlertEmails> lostEmails = Notifications.getFailedEmails();
            BindingList<CheckResults> ChResBList = new BindingList<CheckResults>();
            foreach (AlertEmails thisEmail in lostEmails)
            {
                CheckResults chRes = new CheckResults() { ccEmails = thisEmail.Name, body = thisEmail.EmailBody, cnt = 1 };
                ChResBList.Add(chRes);
            }

            CheckResults01 frmCheckRes = new CheckResults01(ChResBList);
            frmCheckRes.ShowDialog();
        }

    }

    public class CheckResults
    {
        public string fullName { get; set; }
        public string email { get; set; }
        public int cnt { get; set; }
        public string ccfullNames { get; set; }
        public string ccEmails { get; set; }
        public string body { get; set; }
    }
}
