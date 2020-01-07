<%@ Page Title="Product Reports" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="admin_product_report.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_product_report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="JavaScript1.2">showHide("reports");</script>

     <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="update1" runat="server">
        <ContentTemplate>

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>Product Reports </legend>
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
                            <td width="46%" align="left" colspan="2" style="padding-left: 125px">
                              
                                <asp:Label ID="lblMsg" CssClass="formText" runat="server" ></asp:Label>
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
                                        <td width="20%" align="right" class="formText">
                                            Run Report By:
                                        </td>
                                        <td width="80%" class="formText">
                                          <%--  <asp:RadioButton ID="radShelves" runat="server" Text="Shelves" />--%>
                                            <asp:DropDownList ID="drpShelves" runat="server" CssClass="DropDownBox">
                                               
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
                                        <td width="20%" align="right" class="formText">
                                            Products:
                                        </td>
                                        <td width="80%">
                                            <asp:DropDownList ID="drpTotalPages" runat="server" CssClass="DropDownBox" >
                                                <asp:ListItem Value="Select">Select</asp:ListItem>                                                
                                                <asp:ListItem Value="50">50</asp:ListItem>
                                                <asp:ListItem Value="100" >100</asp:ListItem>
                                                <asp:ListItem Value="500">500</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="drpProdcutPopular" runat="server" CssClass="DropDownBox" >                                               
                                                <asp:ListItem Value="DESC">Most Popular</asp:ListItem>
                                                <asp:ListItem Value="ASC">Least Popular</asp:ListItem>
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
                                        <td width="20%" align="right" nowrap="nowrap" class="formText" valign="top">
                                            Dates:
                                        </td>
                                        <td width="80%" class="formText" valign="top">
                                        <span style="padding-left:5px;">
                                        <table>
                                        
                                        <tr>
                                        <td >Start:</td>
                                        <td>
                                        
                                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="textBox"  Enabled="false"></asp:TextBox>
                                                     <span style="padding-left:3px;">
                                        <img src="../images/CalendorIcon.jpg" id="imgFromCalendar" /></span>
                                        <cc1:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="txtFromDate"
                                            cssclass="AjaxCalendar" format="MM/dd/yyyy" popupbuttonid="imgFromCalendar" enabled="True"></cc1:calendarextender>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td>End:
                                        </td>
                                        <td >
                                        <asp:TextBox ID="txtToDate" runat="server" CssClass="textBox"  Enabled="false"></asp:TextBox>
                                        <span style="padding-left:5px;">
                                        <img src="../images/CalendorIcon.jpg " id="imgToCalendar" /></span>
                                        <cc1:calendarextender id="CalendarExtender2" runat="server" targetcontrolid="txtToDate"
                                            cssclass="AjaxCalendar" format="MM/dd/yyyy" popupbuttonid="imgToCalendar" enabled="True"></cc1:calendarextender>
                                        </td>
                                        </tr>
                                        </table>
                                           
                                          </span>
                                         
                                           
                                           
                                             
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
    
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
