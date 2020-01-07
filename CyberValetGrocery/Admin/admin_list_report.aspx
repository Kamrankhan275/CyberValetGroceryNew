<%@ Page Title="Saved List Report" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="admin_list_report.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_list_report" %>

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
                    <legend>Saved List Report</legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="30" class="formText">
                                You can view users' saved shopping lists below. Either choose to view all products
                                on the lists, or view individual lists sorted by user.
                            </td>
                        </tr>
                        <%--<tr>
                            <td width="46%" align="left" colspan="2" class="FieldTextSearch">
                                Field with a <span class="star">*</span> are required
                            </td>
                        </tr>
                        <tr>
                            <td height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td width="46%" align="left" colspan="2" style="padding-left: 125px">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                            </td>
                        </tr>--%>
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
                                        <td width="20%" align="right" nowrap="nowrap">
                                            <span class="formText">Product:</span>
                                        </td>
                                        <td width="80%">
                                            <asp:DropDownList ID="drpNumber" runat="server" CssClass="DropDownBox">
                                                <asp:ListItem Value="0">All</asp:ListItem>
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="50">50</asp:ListItem>
                                                <asp:ListItem Value="100">100</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp; &nbsp;
                                            <asp:DropDownList ID="drpProductType" runat="server" CssClass="DropDownBox">
                                                <asp:ListItem Value="1">Most Popular</asp:ListItem>
                                                <asp:ListItem Value="2">Least Popular</asp:ListItem>
                                            </asp:DropDownList>
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
                                            <span class="formText">Location:</span>
                                        </td>
                                        <td width="80%">
                                            <asp:DropDownList ID="drpLocation" runat="server" CssClass="DropDownBox">
                                               
                                            </asp:DropDownList>
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
                                            <asp:Button ID="btnView" runat="server" Text="View Report" CssClass="button" OnClick="btnView_Click" />
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
                                            OR
                                        </td>
                                        <td>
                                            &nbsp;
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
                                            <span class="formText">User:</span>
                                        </td>
                                        <td width="80%">
                                            <asp:DropDownList ID="drpUser" runat="server" CssClass="DropDownBox">
                                                <asp:ListItem Value="1">List Name</asp:ListItem>
                                                <asp:ListItem Value="2">User Name</asp:ListItem>
                                            </asp:DropDownList>
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
                                            <span class="formText">Location:</span>
                                        </td>
                                        <td width="80%">
                                            <asp:DropDownList ID="drpLoc" runat="server" CssClass="DropDownBox">
                                              
                                            </asp:DropDownList>
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
                                            <asp:Button ID="btnList" runat="server" Text="View lists" CssClass="button" OnClick="btnList_Click" />
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
