<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="admin_UserReport.aspx.cs" Inherits="CyberValetGrocery.Admin.admin_UserReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script language="JavaScript1.2">showHide("reports");</script>

    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>User Reports</legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      
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
                                            <td width="20%" align="right" nowrap="nowrap" class="formText" valign="top">
                                                <span class="star">*</span> Report Type:
                                            </td>
                                            <td width="80%">
                                                <asp:DropDownList ID="drpType" runat="server" CssClass="DropDownBox">
                                                <asp:ListItem Value="Select">Select</asp:ListItem>
                                                   <asp:ListItem Value="1">User Report By Zip Code</asp:ListItem>
                                                    <asp:ListItem Value="2">InActive User Report</asp:ListItem>
                                                     <asp:ListItem Value="3">Activity Report by Zip Code </asp:ListItem>
                                                   
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ControlToValidate="drpType"
                                                    ErrorMessage="Select report Type" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
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
                                    </table>
                                </td>
                            </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    
    
    
    
</asp:Content>
