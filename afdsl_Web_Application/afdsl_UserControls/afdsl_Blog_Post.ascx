<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="afdsl_Blog_Post.ascx.cs" Inherits="afdsl_Web_Application.afdsl_UserControls.afdsl_Blog_Post" %>
<asp:Repeater Visible="true" runat="server" ID="rptBlogItem">
    <ItemTemplate>
        <div class="five columns afdsl_box afdsl_Content  blogPost" style="background:url('http://www.afdsl.net<%# Eval("afdsl_image") %>'); background-size:cover;">
            <h3><%# Eval("afdsl_blogTitle") %></h3>
            <div class="sixteen columns blogPostIntro" style="opacity: 0.8; margin-top: 81px; background-color: white;">
                <p class="sixteen columns blogIntro">

                    <%# Eval("afdls_intro") %>...
                </p>

                <h4><a href='<%# Eval("afdsl_Url") %>'>Read More </a></h4>
            </div>
        </div>


    </ItemTemplate>
</asp:Repeater>



