<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="afdsl_Registration.ascx.cs" Inherits="afdsl_Web_Application.afdsl_UserControls.Registration_UserControls.afdsl_Registration" %>

<div class="ten columns">
    <h1 class="registrationHeading">Register With Acouctic Fire Door Solutions</h1>
    <h5>We are fully certified and licensed producers of acoustic and fire safety doors. With our certification we are able to supply internationally. Sign up for an user account and gain full acces to our certificates.</h5>
</div>
<div class="seven columns">
    <div class="registerInputs">
    <!-- Start Username -->
    <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
    <asp:TextBox ToolTip="Enter username" CssClass="required" ID="txtUsername" runat="server" ClientIDMode="Static" />
    <!-- End Username -->
    </div>
    <div class="registerInputs">
    <!-- Start Email -->
    <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
    <asp:TextBox ToolTip="Enter email" CssClass="required email" ID="txtEmail" runat="server" ClientIDMode="Static" />
    <!-- End Email -->
    </div>
    <div class="registerInputs">
    <!-- Start Confirm Email -->
    <asp:Label ID="lblConfirmEmail" runat="server" Text="Confirm Email: "></asp:Label>
    <asp:TextBox ToolTip="Confirm email" CssClass="required" ID="txtConfirmEmail" runat="server" ClientIDMode="Static" />
    <!-- End Confirm Email -->
    </div>
    <div class="registerInputs">
    <!-- Start Password -->
    <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
    <asp:TextBox ToolTip="Enter a password" CssClass="required" ID="txtPassword" TextMode="Password" runat="server" ClientIDMode="Static" />
    <!-- End Password -->
    </div>
    <div class="registerInputs">
    <!-- Start Confirm Password -->
    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password: "></asp:Label>
    <asp:TextBox ToolTip="Confirm password" CssClass="required" ID="txtConfirmPassword" TextMode="Password" runat="server" ClientIDMode="Static" />
    <!-- End Confirm Password -->
    </div>
    <div class="registerInputs checkBox thirteen columns">
    <!-- Start Sign up check box  -->
    <asp:Label ID="Label1" runat="server" Text="    Sign up for the AFDSL Newsletter, which delivers links to the most popular articles, blogs, and multimedia features via e-mail to your inbox. Just check the box below and submit."></asp:Label>
    <!-- End Sign up check box -->
    </div>
    <div class="registerInputs">
        <asp:CheckBox ID="chkSignUp" runat="server" />
    </div>
    <div class="registerButton fourteen columns">
        <asp:Button CssClass="Button" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
    <div class="sixteen columns" style="margin-top:40px">
        <asp:Label ID="lblerror" runat="server"></asp:Label>
    </div>

</div>

<div class="seven columns">
    <img class="loginDoor" src="/Web_Assets/Images/afdsl_LoginDoor.png" />
</div>


