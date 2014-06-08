<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="afdsl_Hero_Gallery_Item.ascx.cs" Inherits="afdsl_Web_Application.afdsl_UserControls.Hero_Gallery_Item_UserControls.afdsl_Hero_Gallery_Item" %>

<asp:Repeater Visible="true" runat="server" ID="rptHeroGallery">
    <ItemTemplate>
        <li>
            <div class="container">
                <div class="heroHeadings ten columns">
                    <h1 title='<%# Eval("afdsl_Hero_Heading") %>'><%# Eval("afdsl_Hero_Heading") %></h1>
                    <h2 title='<%# Eval("afdsl_Hero_Sub_Heading") %>'><%# Eval("afdsl_Hero_Sub_Heading") %></h2>
                    <h4 title="Find Out More"><a href='<%# Eval("afdsl_Hero_Link_Address") %>'>FIND OUT MORE</a></h4>
                </div>
                <div class="heroImage six columns">
                    <img src='<%# Eval("afdsl_Hero_Image_Src") %>' alt='<%# Eval("afdsl_Hero_Gallery_AltTag") %>' title='<%# Eval("afdsl_Hero_Gallery_AltTag") %>' style="margin:0!important;" /> 
                </div>
            </div>
        </li>
    </ItemTemplate>
</asp:Repeater>


