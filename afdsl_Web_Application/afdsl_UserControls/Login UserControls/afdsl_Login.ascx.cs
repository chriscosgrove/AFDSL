using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using afdsl.BusinessLayer.afdsl;
using System.Web.Security;
using afdsl.BusinessLayer.afdsl.Member;
using afdsl.BusinessLayer.afdsl.Linq_Classes;
using afdsl.BusinessLayer.afdsl.Helper;

namespace afdsl_Web_Application.afdsl_UserControls.Login_UserControls
{
    public partial class afdsl_Login : System.Web.UI.UserControl
    {
        afdsl_Member memberClass = new afdsl_Member();
        User_details userClass = new User_details();
        afdsl_MailFunctions emailClass = new afdsl_MailFunctions();
       
        bool LoggedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                pnlForgotPassword.Visible = false;
            }
            if (LoggedIn)
            {
                Response.Redirect("/Home.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool validUser = ValidateUser();
            if (validUser)
            {
                Response.Redirect("/Home.aspx");
            }
        }

        public bool ValidateUser()
        {
            bool valid;
            memberClass.member_UserName = txtUsername.Text;
            memberClass.member_Password = txtPassword.Text;
            try
            {
                if (!string.IsNullOrEmpty(memberClass.member_UserName) && !string.IsNullOrEmpty(memberClass.member_Password))
                {
                    bool isValid = System.Web.Security.Membership.ValidateUser(memberClass.member_UserName, txtPassword.Text);

                    if (isValid)
                    {
                        var webUser = Membership.GetUser(memberClass.member_UserName);
                        bool isConfirmed = userClass.isUserConfirmed(webUser.UserName);

                        if (isConfirmed)
                        {
                            FormsAuthentication.SetAuthCookie(memberClass.member_UserName, false);
                            valid = true;
                            return valid;
                        }
                        else
                        {
                            lblerror.Text = "Please confirm your email address";
                            valid = false;
                            return valid;
                        }
                    }
                    else
                    {
                        lblerror.Text = "Invalid User, Please try another Login.";
                        valid = false;
                        return valid;
                    }
                }
                else
                {
                    valid = false;
                    return valid;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                memberClass = null;
            }
        }

        protected void lnkbtnFrgtPasswrd_Click(object sender, EventArgs e)
        {
            pnlForgotPassword.Visible = true;
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmailForgotPassword.Text))
            {
                bool isValid = emailClass.isCorrectEmail(txtEmailForgotPassword.Text);

                if (isValid)
                {
                    bool isUser = userClass.isUserByEmail(txtEmailForgotPassword.Text);
                    if (isUser)
                    {
                        string BaseUrl = HttpContext.Current.Request.Url.Host;

                        var webCmsUser = userClass.getCmsMemberUserByEmail(txtEmailForgotPassword.Text);
                        int webCmsFK;
                        webCmsFK = webCmsUser.FK_User_Table ?? default(int);
                        var webCustomUser = userClass.getUserCustomMember(webCmsFK);

                        memberClass.member_UserName = webCmsUser.LoginName;
                        memberClass.member_EmailAddress = txtEmailForgotPassword.Text;
                        emailClass.afdsl_FilePath = Server.MapPath("/Email_Templates/Forgot_Password/Password_Template.html");
                       
                        string email_Body = emailClass.populateForgotPasswordEmailTemplate(emailClass.afdsl_FilePath, memberClass.member_UserName, BaseUrl, webCustomUser.Guid.ToString());
                        emailClass.SendMail("contact@afdsl.net", txtEmailForgotPassword.Text , "Forgot Password", email_Body);
                    }
                    else
                    {
                        lblerror.Text = "The email is not registered with AFDSL";
                    }
                }
                else
                {
                    lblerror.Text = "The Email you entered is incorrect";
                }
            }
            else 
            {
                lblerror.Text = "You have not filled in the email field.";
            }
        }
    }
}