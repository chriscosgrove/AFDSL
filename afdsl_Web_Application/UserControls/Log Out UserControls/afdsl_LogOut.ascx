<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="afdsl_LogOut.ascx.cs" Inherits="afdsl_Web_Application.afdsl_UserControls.Log_Out_UserControls.afdsl_LogOut" %>
<asp:Panel runat="server" ID="pnlLogIn">
    <div class="header_login_Links">
        <img src="/Web_Assets/Images/sign_In_Icon.png" /><h4 id="login"><a href="/members/login-area.aspx">Login</a></h4>
    </div>
    <div class="header_login_Links ">
        <img src="/Web_Assets/Images/sign_Up_Icon.png" /><h4><a href="/members/registration-area.aspx">Sign Up</a></h4>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlLogOut">
    <div class="header_login_Links">
        <img class="logOutPosition" src="/Web_Assets/Images/afdsl_logout.png" /><h4><asp:LinkButton ID="hypLogOut" runat="server" OnClick="LogOut">Log Out</asp:LinkButton></h4>
    </div>
    <div class="header_login_Links ">
        <h4>Hi, <asp:Label runat="server" ID="lblUserName"></asp:Label></h4>
    </div>
</asp:Panel>
