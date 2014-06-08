using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco.cms.businesslogic.member;
using afdsl.BusinessLayer.afdsl.Linq_Classes;
using System.Web.Security;

namespace afdsl_Web_Application.afdsl_UserControls.Reset_Password
{
    public partial class afdsl_Reset_Password_Confirm : System.Web.UI.UserControl
    {
        User_details userClass = new User_details();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["guid"]) || !string.IsNullOrEmpty(Request.QueryString["username"]))
            {
                Guid guid = new Guid(Request.QueryString["guid"]);
                string username = Request.QueryString["username"];

                bool IsValid = userClass.IsMatchUserDetails(username, guid);

                if (IsValid)
                {
                    if (txtPassword.Text == txtConfirmNewPasword.Text)
                    {
                        
                        Member member = Member.GetMemberFromLoginName(username);
                        member.ChangePassword(userClass.HashPassword(txtConfirmNewPasword.Text));
                        member.Save();

                        FormsAuthentication.SetAuthCookie(username, false);
                        Response.Redirect("/home.aspx");
                    }
                    else 
                    {
                        //Passwords are incorrect
                    }
                }
                else
                {
                    //User is not valid or password has expired
                }
            }
        }
    }
}