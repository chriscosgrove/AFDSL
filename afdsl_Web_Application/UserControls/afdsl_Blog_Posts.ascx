<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="afdsl_Blog_Posts.ascx.cs" Inherits="afdsl_Web_Application.afdsl_UserControls.afdsl_Blog_Posts" %>
<div class="news-tab" data-tab="tab5">
    <asp:Repeater Visible="true" runat="server" ID="rptBlogItems">
        <ItemTemplate>
            <div class="eight columns blogItem afdsl_box">
                <h2><%# Eval("afdsl_blogTitle") %></h2>

                <img class="blogImage" width="230" height="213" src="<%# Eval("afdsl_image") %>" />
                <div class="blogDescription">
                    <p class="blogDescription"><%# Eval("afdls_intro") %>...</p>
                    <p class="blogDate"><%# Eval("afdsl_datePosted") %></p>
                    <h4><a class="blogReadMore" href='<%# Eval("afdsl_Url") %>'>READ MORE</a></h4>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</div>
