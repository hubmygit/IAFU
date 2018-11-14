using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class UserAuthorization
    {

        public void ArrangeMenuItems(Role role, MenuStrip menuStrip)
        {
            if (role.IsAuditor) //Tag: 1
            {
                foreach (ToolStripItem tsi in menuStrip.Items)
                {
                    if (tsi.Tag != null && tsi.Tag.ToString() == "1")
                    {
                        tsi.Visible = true;
                    }

                    //foreach (ToolStripDropDownItem tsdi in ((ToolStripDropDownItem)tsi).DropDownItems)
                    //{
                    //    if(tsdi.Tag.ToString() == "1")
                    //    {
                    //        tsdi.Visible = true;
                    //    }
                    //}
                }
            }

            if (role.IsAuditee) //Tag: 2
            {
                foreach (ToolStripItem tsi in menuStrip.Items)
                {
                    if (tsi.Tag != null && tsi.Tag.ToString() == "2")
                    {
                        tsi.Visible = true;
                    }
                }
            }

            if (role.IsAdmin) //Tag: 3
            {
                foreach (ToolStripItem tsi in menuStrip.Items)
                {
                    if (tsi.Tag != null && tsi.Tag.ToString() == "3")
                    {
                        tsi.Visible = true;
                    }
                }
            }

        }

    }
}
