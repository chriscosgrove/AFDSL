<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="afdsl_NewsLetter_SignUp.ascx.cs" Inherits="afdsl_Web_Application.afdsl_UserControls.NewsLetter_UserControls.afdsl_NewsLetter_SignUp" %>


<asp:UpdatePanel ID="upDatePnlNL" runat="server">
    <ContentTemplate>
        <asp:Panel runat="server" ID="pnlNewLetter">
            <div class="six columns afdsl_box afdsl_blueContentBox newsltterPosition">
                <div class="sixteen columns afdsl_Content columns afdsl_Content">
                    <h3>Newsletter Sign Up</h3>
                    <p>Sign up to the AFDS newsletter to receive all the latest developments and important announcements</p>
                    <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                </div>
                <div class="sixteen columns afdsl_Content">
                    <h4>
                        <asp:LinkButton ID="lnkButnNewsLtr" runat="server" OnClick="lnkButnNewsLtr_Click">Submit</asp:LinkButton>
                    </h4>
                </div>
                <div class="sixteen columns afdsl_Content">
                    <h4>
                        <asp:Label runat="server" ID="lblerror"></asp:Label>
                    </h4>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlSentNewsLetter">
            <div class="six columns afdsl_box afdsl_blueContentBox newsltterPosition">
            <div class="sixteen columns afdsl_Content columns afdsl_Content">
                <h3>Thanks For Signing Up!</h3>
                <p>You have signed up to the AFDSL Newletter!</p>
            </div>
                </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
