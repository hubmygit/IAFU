﻿using System;
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
        public static bool IsLegal(Action action, Audit audit = null) //int? auditor1 = null, int? auditor2 = null, int? supervisor = null, bool? isPublished = null)
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

                return true;
            }

            switch (action)
            {
                case Action.Audit_Create:
                    {
                        //Any auditor can create audit
                        ret = true;
                        break;
                    }
                case Action.Audit_View:
                    {
                        //Any auditor can view audits
                        //ret = true;

                        if (audit.IsDeleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The audit has been deleted!");
                        }

                        break;
                    }
                case Action.Audit_Edit:
                    {
                        //Only Auditor1, 2, Supervisor can edit this audit
                        //if (UserInfo.userDetails.Id == auditor1 || UserInfo.userDetails.Id == auditor2 || UserInfo.userDetails.Id == supervisor) // || UserInfo.roleDetails.IsAdmin
                        if (UserInfo.userDetails.Id == audit.Auditor1.Id || UserInfo.userDetails.Id == audit.Auditor2.Id || UserInfo.userDetails.Id == audit.Supervisor.Id)
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
                        if (UserInfo.userDetails.Id == audit.Auditor1.Id || UserInfo.userDetails.Id == audit.Auditor2.Id || UserInfo.userDetails.Id == audit.Supervisor.Id)
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
                        if (UserInfo.userDetails.Id == audit.Auditor1.Id || UserInfo.userDetails.Id == audit.Auditor2.Id || UserInfo.userDetails.Id == audit.Supervisor.Id)
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
                        if (UserInfo.userDetails.Id == audit.Auditor1.Id || UserInfo.userDetails.Id == audit.Auditor2.Id || UserInfo.userDetails.Id == audit.Supervisor.Id)
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


                //-----------------------------------
                case Action.Header_Create:
                    {
                        //Only Auditor1, 2, Supervisor can create new header referring to this audit
                        if (UserInfo.userDetails.Id == audit.Auditor1.Id || UserInfo.userDetails.Id == audit.Auditor2.Id || UserInfo.userDetails.Id == audit.Supervisor.Id)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                        }
                        break;
                    }
                case Action.Header_View:
                    {
                        /*
                        //Only Auditor1, 2, Supervisor - unpublished && All - published, can view new header referring to this audit
                        if (UserInfo.userDetails.Id == audit.Auditor1.Id || UserInfo.userDetails.Id == audit.Auditor2.Id || UserInfo.userDetails.Id == audit.Supervisor.Id || isPublished == true) // || UserInfo.roleDetails.IsAdmin
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        */
                        break;
                    }

                //case Action.Audit_Create:
                //    {
                //        break;
                //    }
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
