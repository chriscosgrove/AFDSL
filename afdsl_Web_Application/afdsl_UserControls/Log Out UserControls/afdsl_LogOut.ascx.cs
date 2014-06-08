using afdsl.BusinessLayer.afdsl.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace afdsl_Web_Application.afdsl_UserControls.Log_Out_UserControls
{
    public partial class afdsl_LogOut : System.Web.UI.UserControl
    {
        bool LoggedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
        afdsl_Member memberClass = new afdsl_Member();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoggedIn)
            {
                pnlLogOut.Visible = true;
                pnlLogIn.Visible = false;
                getUserName();
            }
            else
            {
                pnlLogOut.Visible = false;
                pnlLogIn.Visible = true;
            }
        }

        public void getUserName()
        {
            try
            {
                var webUser = System.Web.Security.Membership.GetUser(); 
                memberClass.member_UserName = webUser.UserName;
                lblUserName.Text = memberClass.member_UserName;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                memberClass = null;
            }
        }

        protected void LogOut(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/Home.aspx");
        }
    }
}