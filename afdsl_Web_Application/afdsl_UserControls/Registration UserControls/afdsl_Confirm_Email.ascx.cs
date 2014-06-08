using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using afdsl.BusinessLayer.afdsl.Linq_Classes;
using System.Web.Security;

namespace afdsl_Web_Application.afdsl_UserControls.Registration_UserControls
{
    public partial class afdsl_Confirm_Email : System.Web.UI.UserControl
    {
        User_details userdetails_Class = new User_details();
        bool IsValid = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            bool LoggedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (LoggedIn)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["guid"]) || !string.IsNullOrEmpty(Request.QueryString["username"]))
            {
                Guid guid = new Guid(Request.QueryString["guid"]);
                string username = Request.QueryString["username"];
                IsValid = userdetails_Class.IsMatchUserDetails(username, guid);

                if (IsValid)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    Response.Redirect("/home.aspx");
                }
                else
                {
                    lblerror.Text = "Email Confirmation expired, Please contact AFDSL for further information.";
                }
            }
        }
    }
}