<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="ContactUsPage.aspx.cs" Inherits="CyberValetGrocery.ContactUsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0"  width="580px" style="padding-left: 10px;">
                <tr>
                    <td align="left" class="formHeading">
                        <strong>Contact Us </strong>
                    </td>
                </tr>
               <%-- <tr>
                    <td height="10px">
                    </td>
                </tr>--%>
                 <tr>
                    <td class="formTextUSer" align="left" style="padding-right:20px;">
                    We want to hear from you! Please feel free to contact us with any questions or suggestions. The best way to contact us is by email. We are looking forward to hearing from you!
                 </td>
                </tr>
                <tr>
                    <td height="10px">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formTextUSer">
                        <strong>Website:</strong>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formTextUSer">
                       <a href="index.aspx" class="Userlink1">www.CyberValetGrocery.com</a>
                    </td>
                </tr>
                <tr>
                    <td height="10px">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formTextUSer">
                        <strong>Email:</strong>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <%-- <asp:Literal ID="litContactEmail1" runat="server"></asp:Literal>--%><a href="mailto:Charles@CyberValetGrocery.com" class="Userlink1">Charles@CyberValetGrocery.com</a>
                    </td>
                </tr>
                <tr>
                    <td height="10px">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formTextUSer">
                        <strong>Phone:</strong>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                       <%--(843) 338 2232--%>
                      (843) 290-3191
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" align="left" style="padding-right: 20px;">
                    </td>
                </tr>
                <tr>
                    <td height="20px">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formTextUSer">
                        <strong>Need Customer Service?</strong> Email us or fill out the form below.
                    </td>
                </tr>
                <tr>
                    <td height="10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="3" cellspacing="0" border="0" class="formTextUSer">
                            <tr>
                                <td colspan="2" align="center">
                                    Field with a <span class="star1">*</span> are required
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                </td>
                            </tr>
                              <tr>
                                <td align="left" colspan="2" style="padding-left: 150px;">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1" />
                                    <asp:Label ID="lblMsg" CssClass="formTextUSer" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right">
                                    <span class="star1">*</span>Name:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNm" runat="server" Text="*" ControlToValidate="txtName"
                                        ErrorMessage="Name is required" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right">
                                    <span class="star1">*</span>Email Address:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Text="*" ControlToValidate="txtEmail"
                                        ErrorMessage="Email is required" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right">
                                    <span class="star1">*</span>Questions/Comments:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQuestion" runat="server" CssClass="textMultiline" MaxLength="2000"
                                        TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                        ControlToValidate="txtQuestion" ErrorMessage="Questions/Comments is required"
                                        ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left" style="padding-left: 6px;">
                                    <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="buttonUser" OnClick="btnSend_Click" />
                                </td>
                            </tr>
                <tr>
                    <td height="10px">
                    </td>
                </tr>
            </table>
            </td> </tr> </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
