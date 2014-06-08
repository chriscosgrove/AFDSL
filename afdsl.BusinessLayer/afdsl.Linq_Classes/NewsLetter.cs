using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using afdsl.DataLayer.Entity_FrameWork;

namespace afdsl.BusinessLayer.afdsl.Linq_Classes
{
    public class NewsLetter 
    {
        afdsl_ModelContainer1 afdslContainer = new afdsl_ModelContainer1();
        afdsl_Newsletter afdsl_NewsletterRow = new afdsl_Newsletter();
        cmsMember cmsMember = new cmsMember();

        public bool isUserSubscribedNewsLetter(string email)
        {
            var CmsMemberRow = (from x in afdslContainer.cmsMembers where x.Email == email select x).FirstOrDefault();
            bool Exists;

            if (CmsMemberRow != null)
            {
                Exists = true;
                return Exists;
            }
            else
            {
                Exists = false;
                return Exists;
            }
        }

        public bool isEmailExistInNewsLetter(string email)
        {
            var CmsMemberRow = (from x in afdslContainer.afdsl_Newsletter where x.Email == email select x).FirstOrDefault();
            bool Exists;

            if (CmsMemberRow != null)
            {
                Exists = true;
                return Exists;
            }
            else
            {
                Exists = false;
                return Exists;
            }
        }


        public int getFkFromEmail(string email)
        {
            try
            {
                var CmsMemberRow = (from x in afdslContainer.cmsMembers where x.Email == email select x).FirstOrDefault();

                if (CmsMemberRow == null)
                {
                    return 0;
                }
                else
                {
                   int FKNotNull;
                   return FKNotNull = CmsMemberRow.FK_User_Table ?? default(int);
                }                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void addNewsLetter(string email)
        {
            try
            {
                afdsl_NewsletterRow.Email = email;
                afdslContainer.afdsl_Newsletter.Add(afdsl_NewsletterRow);
                afdslContainer.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void addNewsLetter(string email, int FK_UserTable)
        {
            try
            {
                afdsl_NewsletterRow.Email = email;
                afdsl_NewsletterRow.FK_UserTable = FK_UserTable;
                afdslContainer.afdsl_Newsletter.Add(afdsl_NewsletterRow);
                afdslContainer.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpadateCustomTableNewsLetter(int FK_User)
        {
            var cmsCustom_User = (from x in afdslContainer.afdsl_Custom_User_Table where x.Id == FK_User select x).First();

            if (cmsCustom_User != null)
            {
                cmsCustom_User.email_SignUp = true;
                afdslContainer.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
