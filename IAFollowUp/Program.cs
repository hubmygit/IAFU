using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IAFollowUp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!AppVer.IsLatestVersion()) //check version
                return;

            Login frmLogin = new Login();
            frmLogin.ShowDialog();

            if (frmLogin.LoggedIn)
            {
                Application.Run(new MainMenu(frmLogin.user, frmLogin.role));
            }
        }
    }
}
