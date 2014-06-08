<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateFolderInstall.ascx.cs" Inherits="TG.Umb.DateFolder.DateFolderInstall" %>

<asp:Panel ID="Panel1" runat="server" >

    <asp:Panel ID="Panel3" runat="server" >
    </asp:Panel>
<br />
<asp:CheckBox ID="cbMove" runat="server" Text="Move existing content to DateFolders" />
<br />
<br />
<asp:Button ID="Button1" runat="server" Text="Ok" OnClick="Button1_Click" />
</asp:Panel>
<asp:Panel ID="Panel2" runat="server" Visible="false">
Package installed !
</asp:Panel>
   
