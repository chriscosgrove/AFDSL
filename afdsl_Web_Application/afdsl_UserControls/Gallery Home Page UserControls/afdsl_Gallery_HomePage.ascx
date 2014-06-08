<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="afdsl_Gallery_HomePage.ascx.cs" Inherits="afdsl_Web_Application.afdsl_UserControls.Gallery_Home_Page_UserControls.afdsl_Gallery_HomePage" %>

<div class="slideshow five columns">
    <asp:Repeater Visible="true" runat="server" ID="rptGalleryHomeItems">
        <ItemTemplate>
            <img src="<%# Eval("afdsl_galleryThumb") %>" alt="<%# Eval("afdsl_galleryAltTag") %>" width="294" height="314" />

        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="viewMore">
    <h3>Gallery</h3>
    <h4><a href="/gallery.aspx">View More</a></h4>
</div>

