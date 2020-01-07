<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="SuggestProduct.aspx.cs" Inherits="CyberValetGrocery.SuggestProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-left: 10px;">
                <tr>
                    <td align="left" class="formHeading">
                        Suggest a Product
                    </td>
                </tr>
                <tr>
                    <td height="10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlSuggest" runat="server">
                            <table>
                                <tr>
                                    <td align="left" class="formTextUSer" style="padding-right:20px;">
                                        Looking for an item, but don't see it in our store? Please use the form below to
                                        suggest an item for us
                                       
                                        to add to our store. We will do our best to accommodate all requests. Please provide
                                        your name and email address so we can contact you when we have fulfilled your request.
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
                                                <td align="left" colspan="2" style="padding-left: 100px;">
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
                                                    <span class="star1">*</span>Email:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Text="*" ControlToValidate="txtEmail"
                                                        ErrorMessage="Email is required" ForeColor="White"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td colspan="2">
                                                    <span class="star1">*</span>Item brand, name, description, etc.:
                                                    <br />
                                                    <asp:TextBox ID="txtItem" runat="server" CssClass="textMultilineSuggest" MaxLength="2000"
                                                        TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                                        ControlToValidate="txtItem" ErrorMessage="Item brand, name, description, etc. is required"
                                                        ForeColor="White"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td align="left" style="padding-left: 10px;">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="buttonUser" OnClick="btnSubmit_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlSuggestSuccuss" runat="server" Visible="false">
                            <table>
                                <tr>
                                    <td align="left" class="formTextUSer">
                                        Thank you for taking the time to contact us! We appreciate your suggestion and will
                                        do the best to accommodate your request.
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnContinue" runat="server" CssClass="buttonUser" Text="Continue Shopping"
                                            OnClick="btnContinue_Click" CausesValidation="false" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
