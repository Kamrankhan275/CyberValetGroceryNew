<%@ Page Title="Sale Newsletter" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="admin_newsletter_sale.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_newsletter_sale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="JavaScript1.2">showHide("customers");</script>

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>Newsletter</legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="30" class="formText" nowrap="nowrap">
                                To begin building a sale newsletter, please choose your location below. This will
                                start the newsletter with 8 random<br /> sale items.
                            </td>
                        </tr>
                        <tr>
                            <td height="3px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="46%" align="left" colspan="2" class="FieldTextSearch">
                                Field with a <span class="star">*</span> are required
                            </td>
                        </tr>
                        <tr>
                            <td width="46%" align="left" colspan="2" style="padding-left: 125px">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" align="right">
                                            <span class="formText"><span class="star">*</span>Location:</span>
                                        </td>
                                        <td width="80%">
                                            <asp:DropDownList ID="drpLocationName" runat="server" CssClass="DropDownBox">
                                                
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvLocationName" runat="server" ControlToValidate="drpLocationName"
                                                ErrorMessage="Select location" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                        <td style="padding-left: 10px;">
                                            <asp:Button ID="btnBegin" runat="server" Text="Begin" CssClass="button" OnClick="btnBegin_Click" />
                                            <span style="padding-left: 10px;">
                                              <asp:Button ID="btnView" runat="server" Text="View All" CssClass="button" OnClick="btnView_Click" CausesValidation="false" />
                                              
                                              </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
