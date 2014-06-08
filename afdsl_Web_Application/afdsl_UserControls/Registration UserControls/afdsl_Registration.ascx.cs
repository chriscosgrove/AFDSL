using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using afdsl.BusinessLayer.afdsl.Member;
using System.Text.RegularExpressions;
using umbraco.cms.businesslogic.member;
using umbraco.BusinessLogic;
using afdsl.BusinessLayer.afdsl.Helper;
using afdsl.BusinessLayer.afdsl.Linq_Classes;

namespace afdsl_Web_Application.afdsl_UserControls.Registration_UserControls
{
    public partial class afdsl_Registration : System.Web.UI.UserControl
    {
        afdsl_Member memberClass = new afdsl_Member();
        afdsl_MailFunctions afdsl_helper = new afdsl_MailFunctions();
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Registration registrationClass = new Registration();
        Guid guid_Number = Guid.NewGuid();

        bool LoggedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoggedIn)
            {
                Response.Redirect("/Home.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try 
            {
                register_WebUser();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                 memberClass = null;
                 afdsl_helper = null;
                 regex = null;
                 registrationClass = null;
            }
        }

        public void register_WebUser()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    lblerror.Text = "Fill in all of the fields please";
                }
                else
                {
                    Match match = regex.Match(txtEmail.Text);
                    memberClass.member_UserName = txtUsername.Text;
                    memberClass.member_EmailAddress = txtConfirmEmail.Text;
                    memberClass.member_Password = txtConfirmPassword.Text;
                    memberClass.member_MembersGroup = "Active";
                    memberClass.member_MembersType = "SiteMember";
                    afdsl_helper.afdsl_FilePath = Server.MapPath("/Email_Templates/Registration/Registration_Template.html");
                    memberClass.member_NewsLetterSignUp = chkSignUp.Checked;

                    if (match.Success)
                    {
                        if (Membership.GetUserNameByEmail(txtEmail.Text) == null && Membership.GetUser(txtUsername.Text) == null)
                        {
                            if (txtPassword.Text == txtConfirmPassword.Text)
                            {
                                if (txtEmail.Text == txtConfirmEmail.Text)
                                {
                                    var _memberType = MemberType.GetByAlias(memberClass.member_MembersType);
                                    var _memberGroup = MemberGroup.GetByName(memberClass.member_MembersGroup);

                                    var _member = Member.MakeNew(memberClass.member_UserName, _memberType, new User(0));
                                    _member.Password = !string.IsNullOrEmpty(memberClass.member_Password) ? memberClass.member_Password : string.Empty;
                                    _member.Email = !string.IsNullOrEmpty(memberClass.member_EmailAddress) ? memberClass.member_EmailAddress : string.Empty;
                                    _member.AddGroup(_memberGroup.Id);
                                    _member.Save();
                                    _member.XmlGenerate(new System.Xml.XmlDocument());

                                    string BaseUrl = HttpContext.Current.Request.Url.Host;
                                    string email_Body = afdsl_helper.populateResistrationEmailTemplate(afdsl_helper.afdsl_FilePath, memberClass.member_UserName, BaseUrl, guid_Number.ToString());
                                    //afdsl_helper.SendMail("contact@afdsl.net", txtEmail.Text, "Email Registration", email_Body);
                                    registrationClass.register_Custom_User(memberClass.member_NewsLetterSignUp, guid_Number);
                                    Response.Redirect("/thanks-for-registering.aspx", false);
                                }
                                else
                                {
                                    lblerror.Text = "Email addresses do not match";
                                }
                            }
                            else
                            {
                                lblerror.Text = "Passwords do not match";
                            }
                        }
                        else
                        {
                            lblerror.Text = "The User already exists";
                        }
                    }
                    else
                    {
                        lblerror.Text = "The Email address is not a valid";
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }
    }
}