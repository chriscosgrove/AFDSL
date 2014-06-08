<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="afdsl_Confirm_Email.ascx.cs" Inherits="afdsl_Web_Application.afdsl_UserControls.Registration_UserControls.afdsl_Confirm_Email" %>

<div class="ten columns">
    <h1 class="registrationHeading">Confirm your email to access all AFDSL's features
    </h1>
    <h5>Click the confirm button below to activate your account</h5>
</div>
<div class="registerButton fourteen columns">
    <asp:Button CssClass="Button" ID="btnSubmit" runat="server" Text="Confirm" OnClick="btnSubmit_Click" />
    <asp:Label ID="lblerror" runat="server"></asp:Label>
</div>
