using afdsl.DataLayer.Entity_FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace afdsl.BusinessLayer.afdsl.Linq_Classes
{
    public class User_details
    {
        afdsl_Custom_User_Table Member_Row = new afdsl_Custom_User_Table();
        cmsMember cms_Member = new cmsMember();
        afdsl_ModelContainer1 afdsl_Model = new afdsl_ModelContainer1();
        bool valid;

        #region'Is functions'
        public bool isUserConfirmed(string username)
        {
            var userRow_CmsTable = (from x in afdsl_Model.cmsMembers where x.LoginName == username select x).First();
            var userRow_CustomTable = (from x in afdsl_Model.afdsl_Custom_User_Table where x.Id == userRow_CmsTable.FK_User_Table select x).First();

            if (userRow_CustomTable.email_Confirmation == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsMatchUserDetails(string username, Guid user_Guid)
        {
            var userRow_CustomTable = (from x in afdsl_Model.afdsl_Custom_User_Table where x.Guid == user_Guid select x).First();
            var userRow_CmsTable = (from x in afdsl_Model.cmsMembers where x.FK_User_Table == userRow_CustomTable.Id select x).First();

            if (userRow_CmsTable.LoginName == username)
            {
                userRow_CustomTable.email_Confirmation = true;
                afdsl_Model.SaveChanges();
                valid = true;
                return valid;
            }
            else
            {
                valid = false;
                return valid;
            }
        }

        public bool isUserByEmail(string emailAddress)
        {
            var userRow_CmsTable = (from x in afdsl_Model.cmsMembers where x.Email == emailAddress select x);
            if (userRow_CmsTable.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region'Get functions'
        public cmsMember getCmsMemberUserByEmail(string emailAddress)
        {
            var userRow_CmsTable = (from x in afdsl_Model.cmsMembers where x.Email == emailAddress select x).First();
            return userRow_CmsTable;
        }

        public afdsl_Custom_User_Table getUserCustomMember(int id)
        {
            var userRow_CmsTable = (from x in afdsl_Model.afdsl_Custom_User_Table where x.Id == id select x).First();
            return userRow_CmsTable;
        }

        #endregion


        #region'Update functions'

        public string HashPassword(string password)
        {
            HMACSHA1 hash = new HMACSHA1();

            hash.Key = Encoding.Unicode.GetBytes(password);

            string encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));

            return encodedPassword;
        }
        #endregion


    }
}
