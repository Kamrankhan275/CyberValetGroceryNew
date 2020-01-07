<%@ Page Title="Account Balances" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="admin_balance.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_balance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="JavaScript1.2">showHide("reports");</script>

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>Account Balances</legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="30" class="formText">
                                You can view account balances by balance :
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
                                    <table width="80%" border="0" cellspacing="0" cellpadding="0">
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
                                                <span class="formText"><span class="star">*</span> Location:</span>
                                            </td>
                                            <td width="80%">
                                                <asp:DropDownList ID="drpLocation" runat="server" CssClass="DropDownBox">
                                                   
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ControlToValidate="drpLocation"
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
                                            <td width="20%" align="right" nowrap="nowrap">
                                                <span class="formText"><span class="star">*</span> Balance Greater Than:</span>
                                            </td>
                                            <td width="80%">
                                                <asp:DropDownList ID="drpBalance" runat="server" CssClass="DropDownBox">
                                                    <asp:ListItem Value="Select">Select</asp:ListItem>
                                                    <asp:ListItem Value="0">$0</asp:ListItem>
                                                    <asp:ListItem Value="25">$25</asp:ListItem>
                                                    <asp:ListItem Value="50">$50</asp:ListItem>
                                                    <asp:ListItem Value="100">$100</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvBalance" runat="server" ControlToValidate="drpBalance"
                                                    ErrorMessage="Select balance greater than" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
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
                                            <td width="20%" align="right">
                                                <span class="formText"><span class="star">*</span> Order By:</span>
                                            </td>
                                            <td width="80%">
                                                <asp:DropDownList ID="drpOrder" runat="server" CssClass="DropDownBox">
                                                    <asp:ListItem Value="Select">Select</asp:ListItem>
                                                    <asp:ListItem Value="1">User Last Name</asp:ListItem>
                                                    <asp:ListItem Value="2">Account Balance</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvOrder" runat="server" ControlToValidate="drpOrder"
                                                    ErrorMessage="Select order by" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
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
                                                <asp:Button ID="btnView" runat="server" Text="View Balance" CssClass="button" OnClick="btnView_Click" />
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
