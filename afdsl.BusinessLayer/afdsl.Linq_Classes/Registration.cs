using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using afdsl.BusinessLayer.afdsl.Member;
using afdsl.DataLayer.Entity_FrameWork;

namespace afdsl.BusinessLayer.afdsl.Linq_Classes
{
    public class Registration
    {
        afdsl_Custom_User_Table Member_Row = new afdsl_Custom_User_Table();
        cmsMember cms_Member = new cmsMember();
        afdsl_ModelContainer1 afdsl_Model = new afdsl_ModelContainer1();
        

        public void register_Custom_User(bool NewsLetterSignUp, Guid Guid_Number)
        {
            try
            {
                Member_Row.email_SignUp = NewsLetterSignUp;
                Member_Row.created_Date = DateTime.Now;
                Member_Row.Guid = Guid_Number;
                Member_Row.email_Confirmation = false;
                afdsl_Model.afdsl_Custom_User_Table.Add(Member_Row);
                afdsl_Model.SaveChanges();
                UpdateCmsMember();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                afdsl_Model = null;
                cms_Member = null;
                Member_Row = null;
            }
        }

        public void UpdateCmsMember()
        {
            cms_Member = (from x in afdsl_Model.cmsMembers select x).OrderByDescending(x => x.nodeId).First();
            Member_Row = (from x in afdsl_Model.afdsl_Custom_User_Table select x).OrderByDescending(x => x.Id).First();


            cms_Member.FK_User_Table = Member_Row.Id;

            afdsl_Model.SaveChanges();
        }
    }
}
