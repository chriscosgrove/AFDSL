<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="afdsl_Reset_Password_Confirm.ascx.cs" Inherits="afdsl_Web_Application.afdsl_UserControls.Reset_Password.afdsl_Reset_Password_Confirm" %>


<div class="thirteen columns LoginWidget">
    <div class="registerInputs">
        <div class="passwordFields">
            <asp:Label ID="lblPassword" runat="server" Text="New Password: "></asp:Label>
            <asp:TextBox ToolTip="Enter a new password" CssClass="required" ID="txtPassword" TextMode="Password" runat="server" ClientIDMode="Static" />
        </div>
        <div class="passwordFields">
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm New Password: "></asp:Label>
            <asp:TextBox ToolTip="Confirm your new password" CssClass="required" ID="txtConfirmNewPasword" TextMode="Password" runat="server" ClientIDMode="Static" />
        </div>
        <div class="passwordFields">
            <asp:Button CssClass="Button buttonLogin" ID="btnForgotPassword" runat="server" Text="Submit" OnClick="btnForgotPassword_Click" />
        </div>
    </div>
</div>
