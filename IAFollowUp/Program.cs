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

            //--> Load dlls on new Thread
            System.ComponentModel.BackgroundWorker bw = new System.ComponentModel.BackgroundWorker();
            bw.RunWorkerAsync();
            bw.DoWork += (sender2, e2) =>
            {
                DevExpress.XtraGrid.GridControl gridControl1 = new DevExpress.XtraGrid.GridControl();
                DevExpress.XtraGrid.Views.Grid.GridView gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();

                gridControl1.BeginInit();
                gridView1.BeginInit();
                gridView1.EndInit();
                gridControl1.EndInit();
                gridView1.Dispose();
                gridControl1.Dispose();
            };
            //<--

            if (!AppVer.IsLatestVersion()) //check version
                return;

            Migration.migrationMode = false;
            if (Migration.migrationMode == true)
            {
                OnlyForMigration frmMig = new OnlyForMigration();
                if (frmMig.ShowDialog() == DialogResult.OK)
                {
                    Migration.email = frmMig.EmailAddr;
                }
            }

            Login frmLogin = new Login();
            frmLogin.ShowDialog();

            if (frmLogin.LoggedIn)
            {
                Application.Run(new MainMenu(frmLogin.user, frmLogin.role));
            }
        }
    }
}
