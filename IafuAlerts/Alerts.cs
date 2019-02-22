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
            NoAction15D();
            /*
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
            */
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
    }
}
