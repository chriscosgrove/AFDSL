<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="afdsl_Login.ascx.cs" Inherits="afdsl_Web_Application.afdsl_UserControls.Login_UserControls.afdsl_Login" %>

<div class="sixteen columns">
    <h1>Welcome to Acoustic Fire Door solutions!
    </h1>
    <div class="eight columns loginIntro">
        <h5>Simply fill in the form on the page to access all of our official news and exclusive features, such as access to the AFDSL Blog, content and Certificates...</h5>
    </div>
</div>

<div class="six columns LoginWidget">
    <div class="registerInputs">
        <!-- Start Username -->
        <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ToolTip="Enter username" CssClass="required" ID="txtUsername" runat="server" ClientIDMode="Static" />
        <!-- End Username -->
    </div>
    <div class="registerInputs">
        <!-- Start Password -->
        <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ToolTip="Enter a password" CssClass="required" ID="txtPassword" TextMode="Password" runat="server" ClientIDMode="Static" />
        <!-- End Password -->
    </div>
    <div class="sixteen columns ">
        <asp:Button CssClass="Button buttonLogin" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
    <div class="sixteen columns ">
        <asp:LinkButton ID="lnkbtnFrgtPasswrd" runat="server" OnClick="lnkbtnFrgtPasswrd_Click" CssClass="forgotPasswordLink">Forgot Password?</asp:LinkButton>
    </div>
    <asp:Panel ID="pnlForgotPassword" runat="server">
        <div class="sixteen columns registerInputs ">
            <span>Enter Email:</span>
            <asp:TextBox ID="txtEmailForgotPassword" ToolTip="Enter Email:" runat="server"></asp:TextBox>
        </div>
        <div class="sixteen columns">
            <asp:Button CssClass="Button buttonLogin" ID="btnForgotPassword" runat="server" Text="Send Email" OnClick="btnForgotPassword_Click" />
        </div>
    </asp:Panel>
    <div class="sixteen columns LoginErrorContainer">
        <asp:Label runat="server" CssClass="LoginError" ID="lblerror">
        </asp:Label>
    </div>
</div>
<div class="sixteen columns LoginWidget CookieLogin">
    <div class="five columns">
        Only AFDSL users are allowed access to this web service. If you do not have a AFDSL username and password then you may be committing an offence by trying to gain access to this site.
    We use cookies to give you the best possible experience in AFDSL. Learn more about this on our <a href="/cookie-policy.aspx">cookie page</a>
    </div>
</div>
