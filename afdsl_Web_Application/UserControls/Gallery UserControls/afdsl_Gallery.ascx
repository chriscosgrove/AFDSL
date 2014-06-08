<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="afdsl_Gallery.ascx.cs" Inherits="afdsl_Web_Application.afdsl_UserControls.Gallery_UserControls.afdsl_Gallery" %>
    <asp:Repeater Visible="true" runat="server" ID="rptGalleryItems">
        <ItemTemplate>
            <div class="galleryItem five columns">

                <a href="<%# Eval("afdsl_gallerySrc") %>" title="<%# Eval("afdsl_galleryTitle") %>" data-lightbox-gallery="gallery"><img src="<%# Eval("afdsl_galleryThumb") %>" alt="<%# Eval("afdsl_galleryAltTag") %>" width="300" height="180" /></a>
<%--                <a class="fancybox" rel="group" href="<%# Eval("afdsl_gallerySrc") %>"><img src="<%# Eval("afdsl_gallerySrc") %>" alt="<%# Eval("afdsl_galleryAltTag") %>" title="<%# Eval("afdsl_galleryTitle") %>" data-id="<%# Eval("afdsl_galleryid") %>" data-creator=" <%# Eval("afdsl_galeryCreatorName") %>" width="280" height="180" /></a>--%>
            </div>
        </ItemTemplate>
    </asp:Repeater>
