<%@ Page Title="Search Report" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="admin_search_report.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_search_report" %>
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
                    <legend>Search Report</legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                       
                      
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
                                        <td width="20%" align="right" class="formText">
                                            Searched Terms:
                                        </td>
                                        <td width="80%">
                                            <asp:DropDownList ID="drpTotalPages" runat="server" CssClass="DropDownBox">
                                                  <asp:ListItem Value="0">10</asp:ListItem>
                                                 <asp:ListItem Value="1">50</asp:ListItem>
                                                  <asp:ListItem Value="2">100</asp:ListItem>
                                            </asp:DropDownList>
                                        
                                        
                                            <asp:DropDownList ID="drpSearchPopular" runat="server" CssClass="DropDownBox">
                                              
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
                                        <td width="20%" align="right" nowrap="nowrap" class="formText">
                                           Location:
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
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                        <td style="padding-left: 10px;">
                                            <asp:Button ID="btnView" runat="server" Text="View Report" CssClass="button" 
                                                onclick="btnView_Click" />
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
