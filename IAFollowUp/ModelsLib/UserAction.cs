using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public enum Action
    {
        None,

        Audit_Create,
        Audit_View,
        Audit_Edit,
        Audit_Delete,
        Audit_Attach,
        Audit_Finalize,

        Header_Create,
        Header_View,
        Header_Edit,
        Header_Delete,

        Detail_Create,
        Detail_View,
        Detail_Edit,
        Detail_Delete
    }

    public class UserAction
    {
        public static bool IsLegal(Action action, Audit audit = null, FIHeader header = null, FIDetail detail = null) 
        {
            bool ret = false;
            //bool showMessage = true;

            if (UserInfo.roleDetails.IsAdmin)
            {
                if (action == Action.Audit_Delete && audit.IsDeleted)
                {
                    MessageBox.Show("The audit has already been deleted!");
                }

                if (action == Action.Audit_Finalize && audit.IsCompleted)
                {
                    MessageBox.Show("The audit has already been finalized!");
                }

                if (action == Action.Header_Delete && header.IsDeleted)
                {
                    MessageBox.Show("The header has already been deleted!");
                }

                return true;
            }

            AuditOwners auditOwners = new AuditOwners(audit.Auditor1, audit.Auditor2, audit.Supervisor);
            bool isUserAuditOwner = auditOwners.IsUser_AuditOwner();

            switch (action)
            {
                //---------- Audit ---------->
                case Action.Audit_Create:
                    {
                        //Any auditor can create audit
                        ret = true;
                        break;
                    }
                case Action.Audit_View:
                    {
                        //Any auditor can view audits
                        ret = true;                                               
                        break;
                    }
                case Action.Audit_Edit:
                    {
                        //Only Auditor1, 2, Supervisor can edit this audit
                        //if (UserInfo.userDetails.Id == audit.Auditor1.Id || UserInfo.userDetails.Id == audit.Auditor2.Id || UserInfo.userDetails.Id == audit.Supervisor.Id)
                        if(isUserAuditOwner)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                        }

                        if (audit.IsDeleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The audit has been deleted!");
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The Audit has been Finalized!");
                        }

                        if (audit.AreAllDetailsOfAuditPublished() == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("All Details have been Published!");
                        }

                        if (audit.AreAllDetailsOfAuditFinalized() == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("All Details have been Finalized!");
                        }

                        break;
                    }
                case Action.Audit_Attach:
                    {
                        //Only Auditor1, 2, Supervisor can attach Audit Report
                        if (isUserAuditOwner)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            //don't show Message
                        }

                        if (audit.IsDeleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            //don't show Message
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            //don't show Message
                        }

                        break;
                    } 
                case Action.Audit_Delete:
                    {
                        //Only Auditor1, 2, Supervisor can delete this audit
                        if (isUserAuditOwner)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                        }

                        if (audit.IsDeleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The audit has already been deleted!");
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The Audit has been Finalized!");
                        }

                        if (audit.AreAllDetailsOfAuditPublished() == false)
                        //if (header.FIDetails.Exists(i => i.IsPublished == true) == false) //esto kai ena na einai published
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("All Details have been Published!");
                        }

                        if (audit.AreAllDetailsOfAuditFinalized() == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("All Details have been Finalized!");
                        }

                        break;
                    }                
                case Action.Audit_Finalize:
                    {
                        //Only Auditor1, 2, Supervisor can finalize this audit
                        if (isUserAuditOwner)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                        }

                        if (audit.IsDeleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The audit has already been deleted!");
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The audit has already been finalized!");
                        }

                        break;
                    }
                //<---------- Audit ----------

                //---------- Header ---------->
                case Action.Header_View:
                    {
                        //checking users and isPublished into select function
                        ret = true;
                        break;
                    }                                                                         
                case Action.Header_Create:
                    {
                        //Only Auditor1, 2, Supervisor can create new header referring to this audit
                        if (isUserAuditOwner)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                        }
                                               
                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The Audit has been Finalized!");
                        }

                        if (audit.AreAllDetailsOfAuditPublished() == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("All Details have been Published!");
                        }

                        if (audit.AreAllDetailsOfAuditFinalized() == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("All Details have been Finalized!");
                        }

                        break;
                    }
                case Action.Header_Edit: 
                    {
                        if (isUserAuditOwner)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The Audit has been Finalized!");
                        }
                        
                        //exartatai poio header thelei!
                        if(header.FIDetails.Exists(i => i.IsPublished == true) == false) //esto kai ena na einai published
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("At least one Detail of this Header has been Published!");
                        }

                        if (header.FIDetails.Exists(i => i.IsFinalized == true) == false) //esto kai ena na einai finalized
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("At least one Detail of this Header has been Finalized!");
                        }

                        break;
                    }                                        
                case Action.Header_Delete: 
                    {
                        if (isUserAuditOwner)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The Audit has been Finalized!");
                        }

                        //exartatai poio header thelei!
                        if (header.FIDetails.Exists(i => i.IsPublished == true) == false) //esto kai ena na einai published
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("At least one Detail of this Header has been Published!");
                        }

                        if (header.FIDetails.Exists(i => i.IsFinalized == true) == false) //esto kai ena na einai finalized
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("At least one Detail of this Header has been Finalized!");
                        }

                        break;
                    }
                //<---------- Header ----------

                //---------- Detail ---------->
                case Action.Detail_View:
                    {
                        //checking users and isPublished into select function
                        ret = true;
                        break;
                    }
                case Action.Detail_Create:
                    {
                        //Only Auditor1, 2, Supervisor can create new header referring to this audit
                        if (isUserAuditOwner)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The Audit has been Finalized!");
                        }

                        //sto idio header
                        if (header.FIDetails.Exists(i => i.IsPublished == true) == false) //esto kai ena na einai published
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("At least one Detail of this Header has been Published!");
                        }

                        //sto idio header
                        if (header.FIDetails.Exists(i => i.IsFinalized == true) == false) //esto kai ena na einai finalized
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("At least one Detail of this Header has been Finalized!");
                        }

                        break;
                    }
                case Action.Detail_Edit:
                    {
                        //Only Auditor1, 2, Supervisor can create new header referring to this audit
                        if (isUserAuditOwner)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                        }


                        //######################################################


                        break;
                    }
                //<---------- Detail ----------

                default:
                    {
                        //...
                        ret = false;
                        break;
                    }
            }

            //if (ret == false && showMessage == true)
            //{
            //    MessageBox.Show("You are not authorized to perform this action!");
            //}

            return ret;
        }
    }
}
