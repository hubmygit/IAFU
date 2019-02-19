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
                ExpireIn1M();

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
        }

        private void ExpireIn1M() //MTMONTH
        {
            Output.WriteToFile("STARTING...");

            List<AlertObject> alertObjectList = Notifications.NotifExpireIn1M();

            Output.WriteToFile("Details to send: " + alertObjectList.Count.ToString());

            if (alertObjectList.Count > 0)
            {
                List<List<AlertObject>> alertGroupedObjectList = alertObjectList.GroupBy(i => i.User.Id).Select(g => g.ToList()).ToList();
                
                foreach (List<AlertObject> alObjList in alertGroupedObjectList)
                {
                    int cnt = alObjList.Count;
                    string email = alObjList[0].User.getEmail();

                    Output.WriteToFile("Details To User " + alObjList[0].User.Id.ToString() + " :" + cnt.ToString());

                    EmailProperties emailProps = new EmailProperties();
                    emailProps.Recipients = new List<Recipient> { new Recipient() { FullName = alObjList[0].User.FullName, Email = email } };
                    emailProps.Subject = "INTERNAL AUDIT FOLLOW UP NOTIFICATION MESSAGE";
                    emailProps.Body = "Υπενθύμιση για ύπαρξη x ενεργειών ευθύνης σας που λήγουν μέσα στον τρέχοντα μήνα.";
                    //emailProp.Body = actDescr.EmailBody.Replace("@", cnt.ToString());
                }
            }

            Output.WriteToFile("COMPLETED...");
        }

        private void Expired() //MTEXP
        {
        }

        private void ExpireIn15D() //IAEXP15
        {
        }

        private void NoAction15D() //IANOACT
        {
        }
    }
}
