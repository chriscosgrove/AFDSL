using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using AjaxControlToolkit;
using afdsl.BusinessLayer.afdsl.Helper;
using afdsl.BusinessLayer.afdsl.Linq_Classes;

namespace afdsl_Web_Application.afdsl_UserControls.NewsLetter_UserControls
{   
    public partial class afdsl_NewsLetter_SignUp : System.Web.UI.UserControl
    {
        afdsl_MailFunctions mailClass = new afdsl_MailFunctions();
        NewsLetter newsLetterClass = new NewsLetter();

        string incorrectEmailError = "The Email you have entered is incorrect.";
        string fillInFields = "The text field is Empty, Please fill in the field correctly.";
        string UserAlreadyExistsError = "Email is already Subscribed to AFDSL.";

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlNewLetter.Visible = true;
            pnlSentNewsLetter.Visible = false;
        }

        protected void lnkButnNewsLtr_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                bool isValid = mailClass.isCorrectEmail(txtEmail.Text);

                if (isValid)
                {
                    bool UserExistsCms = UserExistCms(email);

                    if (UserExistsCms)
                    {
                        int FK_userTable = newsLetterClass.getFkFromEmail(email);
                        newsLetterClass.UpadateCustomTableNewsLetter(FK_userTable);
                        newsLetterClass.addNewsLetter(email, FK_userTable);
                        setViewPanels(false, true);
                    }
                    else
                    {
                        bool UserExistsNewsLetter = UserExistNewsLetter(email);

                        if (UserExistsNewsLetter)
                        {
                            lblerror.Text = UserAlreadyExistsError;
                        }
                        else
                        {
                            newsLetterClass.addNewsLetter(email);
                            setViewPanels(false, true);
                        }
                    }
                }
                else
                {
                    lblerror.Text = incorrectEmailError;
                }
            }
            else
            {
                lblerror.Text = fillInFields;
            }
        }

        private bool UserExistNewsLetter(string email)
        {
            bool UserInNewsletterTable = newsLetterClass.isEmailExistInNewsLetter(email);
            bool isValid;

            if (UserInNewsletterTable)
            {
                isValid = true;
                return isValid;
            }
            else
            {
                isValid = false;
                return isValid;
            }
        }

        private bool UserExistCms(string email)
        {
            bool UserInNewsletterTable = newsLetterClass.isUserSubscribedNewsLetter(email);
            bool isValid;

            if (UserInNewsletterTable)
            {
                isValid = true;
                return isValid;
            }
            else
            {
                isValid = false;
                return isValid;
            }
        }

        private void setViewPanels(bool NewsLetterPanel, bool SentNewsLetterPanel )
        {
            pnlNewLetter.Visible = NewsLetterPanel;
            pnlSentNewsLetter.Visible = SentNewsLetterPanel;
        }
    }
}


                    ////check if the user is in the database 
                    //bool ExistsInNL = UserExistNewsLetter(email);

                    //if (ExistsInNL)
                    //{
                    //    //User already exists so set error
                    //    lblerror.Text = UserAlreadyExistsError;
                    //}
                    //else
                    //{
                    //    // email does not exist so set place new data in database

                    //}
                    //// check if the user is in the new table 