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

        //auditors----->
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
        Detail_Delete,
        //Detail_Publish,
        Detail_Finalize,
        //auditors<-----

        //auditees----->
        FI_View,
        Activity_View,
        Activity_MTinformIA,
        Activity_MTreplyIA,
        Activity_IAreturnMT,
        Activity_IAacceptMT,
        Activity_MTdelegateDT,
        Activity_MTreplyDT,
        Activity_DTreplyMT,
        Activity_MTextendIA,
        Activity_IAextendMT,
        Activity_IAjudgeMT

        //auditees<-----
    }

    public class UserAction
    {
        public static bool IsLegal(Action action, Audit audit = null, FIHeader header = null, FIDetail detail = null, int auditeeRole = 0, int auditeePh = 0)
        {
            bool ret = false;
            //bool showMessage = true;

            if (UserInfo.roleDetails.IsAdmin)
            {
                if (action == Action.Audit_Delete && audit.IsDeleted)
                {
                    MessageBox.Show("The audit has already been deleted!");
                    return false;
                }

                if (action == Action.Audit_Finalize && audit.IsCompleted)
                {
                    MessageBox.Show("The audit has already been finalized!");
                    return false;
                }

                if (action == Action.Header_Delete && header.IsDeleted)
                {
                    MessageBox.Show("The header has already been deleted!");
                    return false;
                }

                if (action == Action.Detail_Delete && detail.IsDeleted)
                {
                    MessageBox.Show("The detail has already been deleted!");
                    return false;
                }

                /*if (action == Action.Detail_Publish)
                {
                    //if (detail.IsPublished)
                    if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsPublished == true) == true)) //esto kai ena na einai published
                    {
                        MessageBox.Show("Details have already been published!");
                        return false;
                    }

                    //etsi ki alliws ta deleted den ginontai publish
                    //if (detail.IsDeleted)
                    //{
                    //    MessageBox.Show("The detail has been deleted!");
                    //    return false;
                    //}
                    
                }
                */

                return true;
            }

            AuditOwners auditOwners; // = new AuditOwners(audit.Auditor1, audit.Auditor2, audit.Supervisor);
            bool isUserAuditOwner = false; // = auditOwners.IsUser_AuditOwner();
            if (audit != null)
            {
                auditOwners = new AuditOwners(audit.Auditor1, audit.Auditor2, audit.Supervisor);
                isUserAuditOwner = auditOwners.IsUser_AuditOwner();
            }

            //FIDetailOwners detailOwners = new FIDetailOwners(detail.Owners);
            //bool isUserDetailOwner = detailOwners.IsUser_DetailOwner();

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
                        if (isUserAuditOwner)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        if (audit.IsDeleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The audit has been deleted!");
                            break;
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The Audit has been Finalized!");
                            break;
                        }

                        //if (audit.AreAllDetailsOfAuditPublished() == false)
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsPublished == true) == true) == false) //esto kai ena na einai published apo olo to audit
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Published!");
                            break;
                        }

                        //if (audit.AreAllDetailsOfAuditFinalized() == false)
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsFinalized == true) == true) == false) //esto kai ena na einai finalized apo olo to audit
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Finalized!");
                            break;
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
                            break;
                        }

                        if (audit.IsDeleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            //don't show Message
                            break;
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            //don't show Message
                            break;
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
                            break;
                        }

                        if (audit.IsDeleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The audit has already been deleted!");
                            break;
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The Audit has been Finalized!");
                            break;
                        }

                        //if (audit.AreAllDetailsOfAuditPublished() == false)
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsPublished == true) == true) == false) //esto kai ena na einai published
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Published!");
                            break;
                        }

                        //if (audit.AreAllDetailsOfAuditFinalized() == false)
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsFinalized == true) == true) == false) //esto kai ena na einai finalized
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Finalized!");
                            break;
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
                            break;
                        }

                        if (audit.IsDeleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The audit has already been deleted!");
                            break;
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The audit has already been finalized!");
                            break;
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
                            break;
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The Audit has been Finalized!");
                            break;
                        }

                        //if (audit.AreAllDetailsOfAuditPublished() == false)
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsPublished == true) == true) == false) //esto kai ena na einai published
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Published!");
                            break;
                        }

                        //if (audit.AreAllDetailsOfAuditFinalized() == false)
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsFinalized == true) == true) == false) //esto kai ena na einai finalized
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Finalized!");
                            break;
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
                            break;
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The Audit has been Finalized!");
                            break;
                        }

                        //exartatai poio header thelei!
                        //if(header.FIDetails.Exists(i => i.IsPublished == true) == false) //esto kai ena na einai published
                        //olo to audit!!!!!Ginontai ola publish
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsPublished == true) == true) == false) //esto kai ena na einai published apo olo to audit
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Published!");
                            break;
                        }

                        //if (header.FIDetails.Exists(i => i.IsFinalized == true) == false) //esto kai ena na einai finalized
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsFinalized == true) == true) == false) //esto kai ena na einai finalized apo olo to audit
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Finalized!");
                            break;
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
                            break;
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The Audit has been Finalized!");
                            break;
                        }

                        //exartatai poio header thelei!
                        //if (header.FIDetails.Exists(i => i.IsPublished == true) == false) //esto kai ena na einai published
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsPublished == true) == true) == false) //esto kai ena na einai published apo olo to audit
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Published!");
                            break;
                        }

                        //if (header.FIDetails.Exists(i => i.IsFinalized == true) == false) //esto kai ena na einai finalized
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsFinalized == true) == true) == false) //esto kai ena na einai finalized apo olo to audit
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Finalized!");
                            break;
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
                            break;
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The Audit has been Finalized!");
                            break;
                        }

                        //sto idio header
                        //if (header.FIDetails.Exists(i => i.IsPublished == true) == false) //esto kai ena na einai published
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsPublished == true) == true) == false) //esto kai ena na einai published

                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Published!");
                            break;
                        }

                        //sto idio header
                        //if (header.FIDetails.Exists(i => i.IsFinalized == true) == false) //esto kai ena na einai finalized
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsFinalized == true) == true) == false) //esto kai ena na einai finalized
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Finalized!");
                            break;
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
                            break;
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The Audit has been Finalized!");
                            break;
                        }

                        //if (detail.IsPublished == false) //checking this detail not all details of this header(??)
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsPublished == true) == true) == false) //esto kai ena na einai published
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Published!");
                            break;
                        }

                        //if (detail.IsFinalized == false) //checking this detail not all details of this header(??)
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsFinalized == true) == true) == false) //esto kai ena na einai finalized
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Finalized!");
                            break;
                        }

                        break;
                    }
                case Action.Detail_Delete:
                    {
                        if (isUserAuditOwner)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        if (audit.IsCompleted == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("The Audit has been Finalized!");
                            break;
                        }

                        //if (detail.IsPublished == false) //checking this detail not all details of this header(??)
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsPublished == true) == true) == false) //esto kai ena na einai published

                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Published!");
                            break;
                        }

                        //if (detail.IsFinalized == false) //checking this detail not all details of this header(??)
                        if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsFinalized == true) == true) == false) //esto kai ena na einai finalized
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("Details have been Finalized!");
                            break;
                        }

                        break;
                    }
                /*
            case Action.Detail_Publish:
                {
                    if (isUserAuditOwner)
                    {
                        ret = true;
                    }
                    else
                    {
                        ret = false;
                        MessageBox.Show("You are not authorized to perform this action!");
                        break;
                    }

                    if (audit.IsCompleted == true)
                    {
                        ret = true;
                    }
                    else
                    {
                        ret = false;
                        MessageBox.Show("You have to finalize the Audit before publication!");
                        break;
                    }


                    //## estw kai mia eggrafi published se olo to audit ##
                    //if (detail.IsPublished == false) //checking this detail *and all* details of this header(??)
                    if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsPublished == true) == true) == false) //esto kai ena na einai published

                    {
                        ret = true;
                    }
                    else
                    {
                        ret = false;
                        MessageBox.Show("Details have been Published!");
                        break;
                    }

                    //## estw kai mia eggrafi finalized se olo to audit ##
                    //if (detail.IsFinalized == false) //checking this detail *and all* details of this header(??)
                    if (audit.FIHeaders.Exists(i => i.FIDetails.Exists(j => j.IsFinalized == true) == true) == false) //esto kai ena na einai finalized
                    {
                        ret = true;
                    }
                    else
                    {
                        ret = false;
                        MessageBox.Show("Details have been Finalized!");
                        break;
                    }

                    break;
                }
                */
                case Action.Detail_Finalize:
                    {
                        //if (isUserAuditOwner)
                        //{
                        //    ret = true;
                        //}
                        //else
                        //{
                        //    ret = false;
                        //    MessageBox.Show("You are not authorized to perform this action!");
                        //}



                        break;
                    }
                //<---------- Detail ----------

                //---------- FI / Activity ---------->
                case Action.FI_View:
                    {
                        //checking what users see, into select function
                        ret = true;
                        break;
                    }

                case Action.Activity_View:
                    {
                        //checking what users see, into select function
                        ret = true;
                        break;
                    }

                case Action.Activity_MTinformIA:
                    {
                        if (auditeeRole == 2) //MT
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        if (detail.Placeholders.Exists(i => i.Id == auditeePh)) //My placeholder
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        //on which side is the ball!
                        ActionSide actionSide = FIDetailActivity.getActionSide_forAuditees(detail.Id, auditeePh);
                        if (actionSide.Id == 2) //auditee for this placeholder
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You can not perform this action! Actions are not currently on your side.");
                            break;
                        }

                        break;
                    }

                case Action.Activity_MTreplyIA:
                    {
                        if (auditeeRole == 2) //MT
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        if (detail.Placeholders.Exists(i => i.Id == auditeePh)) //My placeholder
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        //on which side is the ball!
                        ActionSide actionSide = FIDetailActivity.getActionSide_forAuditees(detail.Id, auditeePh);
                        if (actionSide.Id == 2) //auditee for this placeholder
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You can not perform this action! Actions are not currently on your side.");
                            break;
                        }

                        break;
                    }

                case Action.Activity_IAreturnMT:
                    {
                        //on which side is the ball! for all placeholders -- all detail owners answered
                        AuditOwners auditorOwners = FIDetail.getAuditOwners(detail.Id);
                        if (auditorOwners.IsUser_AuditOwner())
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        //on which side is the ball!
                        ActionSide actionSide = FIDetailActivity.getActionSide_forAuditors(detail);

                        if (actionSide.Id == 1) //IA for all placeholders
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You can not perform this action! Actions are not currently on your side.");
                            break;
                        }

                        if (detail.IsFinalized == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You can not perform this action! Detail is finalized.");
                            break;
                        }

                        break;
                    }

                case Action.Activity_IAacceptMT:
                    {
                        //on which side is the ball! for all placeholders -- all detail owners answered
                        AuditOwners auditorOwners = FIDetail.getAuditOwners(detail.Id);
                        if (auditorOwners.IsUser_AuditOwner())
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        //on which side is the ball!
                        ActionSide actionSide = FIDetailActivity.getActionSide_forAuditors(detail);

                        if (actionSide.Id == 1) //IA for all placeholders
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You can not perform this action! Actions are not currently on your side.");
                            break;
                        }

                        if (detail.IsFinalized == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You can not perform this action! Detail is finalized.");
                            break;
                        }

                        break;
                    }

                case Action.Activity_IAjudgeMT:
                    {
                        //on which side is the ball! for all placeholders -- all detail owners answered
                        AuditOwners auditorOwners = FIDetail.getAuditOwners(detail.Id);
                        if (auditorOwners.IsUser_AuditOwner())
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        if (detail.IsFinalized == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You can not perform this action! Detail is finalized.");
                            break;
                        }
                        
                        //on which side is the ball!
                        ActionSide actionSide = FIDetailActivity.getActionSide_forAuditors(detail);

                        if (actionSide.Id == 1) //IA for all placeholders
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You can not perform this action! Actions are not currently on your side.");
                            break;
                        }

                        //check if this auditor has already answered
                        if (FIDetailVoting.HasAlreadyVoted(detail.Id, UserInfo.userDetails.Id) == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You can not perform this action! You have already decided.");
                            break;
                        }
                        
                        break;
                    }

                case Action.Activity_MTdelegateDT:
                    {
                        if (auditeeRole == 2) //MT
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        if (detail.Placeholders.Exists(i => i.Id == auditeePh)) //My placeholder
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        //on which side is the ball!
                        ActionSide actionSide = FIDetailActivity.getActionSide_forAuditees(detail.Id, auditeePh);
                        if (actionSide.Id == 2) //auditee for this placeholder
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You can not perform this action! Actions are not currently on your side.");
                            break;
                        }

                        break;
                    }
                case Action.Activity_MTreplyDT:
                    {
                        if (auditeeRole == 2) //MT
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        if (detail.Placeholders.Exists(i => i.Id == auditeePh)) //My placeholder
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        //on which side is the ball!
                        ActionSide actionSide = FIDetailActivity.getActionSide_forAuditees(detail.Id, auditeePh);
                        if (actionSide.Id == 2) //auditee for this placeholder
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You can not perform this action! Actions are not currently on your side.");
                            break;
                        }

                        break;
                    }
                case Action.Activity_DTreplyMT:
                    {
                        if (auditeeRole == 3) //DT
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        if (detail.Placeholders.Exists(i => i.Id == auditeePh)) //My placeholder
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        //on which side is the ball!
                        ActionSide actionSide = FIDetailActivity.getActionSide_forAuditees(detail.Id, auditeePh);
                        if (actionSide.Id == 2) //auditee for this placeholder
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You can not perform this action! Actions are not currently on your side.");
                            break;
                        }

                        break;
                    }
                case Action.Activity_MTextendIA:
                    {
                        if (auditeeRole == 2) //MT
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        if (detail.Placeholders.Exists(i => i.Id == auditeePh)) //My placeholder
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        //on which side is the ball!
                        ActionSide actionSide = FIDetailActivity.getActionSide_forAuditees(detail.Id, auditeePh);
                        if (actionSide.Id == 2) //auditee for this placeholder
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You can not perform this action! Actions are not currently on your side.");
                            break;
                        }

                        break;
                    }
                case Action.Activity_IAextendMT:
                    {
                        AuditOwners auditorOwners = FIDetail.getAuditOwners(detail.Id);
                        if (auditorOwners.IsUser_AuditOwner())
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You are not authorized to perform this action!");
                            break;
                        }

                        if (detail.IsFinalized == false)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("You can not perform this action! Detail is finalized.");
                            break;
                        }

                        break;
                    }

                //<---------- FI / Activity ----------

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
