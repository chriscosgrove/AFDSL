<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="afdsl_Gallery.ascx.cs" Inherits="afdsl_Web_Application.afdsl_UserControls.Gallery_UserControls.afdsl_Gallery" %>
<asp:Panel runat="server" ID="pnlGalleryPage">
    <asp:Repeater Visible="true" runat="server" ID="rptGalleryItems">
        <ItemTemplate>
            <div class="galleryItem five columns">
                <a href="<%# Eval("afdsl_gallerySrc") %>" title="<%# Eval("afdsl_galleryTitle") %>" data-lightbox-gallery="gallery">
                    <img src="<%# Eval("afdsl_galleryThumb") %>" alt="<%# Eval("afdsl_galleryAltTag") %>" width="300" height="180" /></a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Panel>