<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="afdsl_Certificates.ascx.cs" Inherits="afdsl_Web_Application.afdsl_UserControls.afdsl_Certificates" %>
<div class="news-tab" data-tab="tab5">
    <asp:Repeater Visible="true" runat="server" ID="rptBlogItems">
        <ItemTemplate>
		<div class="one-third column certificates_Item">
            <a href='<%# Eval("afdsl_Url") %>'>
			<img class="" src="/Web_Assets/Images/afdsl_PdfIcon.png"/>
            <h4><%# Eval("afdsl_CertificateTitle") %></h4>
            <h5><%# Eval("afdsl_datePosted") %></h5>
            </a>
		</div>
        </ItemTemplate>
    </asp:Repeater>

</div>
