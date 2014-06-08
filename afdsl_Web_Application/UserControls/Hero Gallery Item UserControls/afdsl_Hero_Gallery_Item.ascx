<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="afdsl_Hero_Gallery_Item.ascx.cs" Inherits="afdsl_Web_Application.afdsl_UserControls.Hero_Gallery_Item_UserControls.afdsl_Hero_Gallery_Item" %>

<asp:Repeater Visible="true" runat="server" ID="rptHeroGallery">
    <ItemTemplate>
        <li>
            <div class="container">
                <div class="heroHeadings ten columns">
                    <h1><%# Eval("afdsl_Hero_Heading") %></h1>
                    <h2><%# Eval("afdsl_Hero_Sub_Heading") %></h2>
                    <h4><a href='<%# Eval("afdsl_Hero_Link_Address") %>'>Find Out More</a></h4>
                </div>
                <div class="heroImage six columns">
                    <img src='<%# Eval("afdsl_Hero_Image_Src") %>' alt='<%# Eval("afdsl_Hero_Gallery_AltTag") %>' title="" style="margin:0!important;" /> 
                </div>
            </div>
        </li>
    </ItemTemplate>
</asp:Repeater>


