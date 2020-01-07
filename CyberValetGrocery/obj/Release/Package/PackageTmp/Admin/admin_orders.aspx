<%@ Page Title="Orders" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="admin_orders.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_orders" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="JavaScript1.2">showHide("customers");</script>
    <asp:ScriptManager ID="script1" runat="server"> </asp:ScriptManager>
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
                    <legend>Orders</legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="30" class="formText" nowrap="nowrap" colspan="2">
                                Choose a location first, and then a delivery date to view a schedule for that day.
                            </td>
                        </tr>
                       <tr><td height="3px">&nbsp;</td></tr>
               <tr>
                            <td width="46%" align="left" colspan="2" class="FieldTextSearch">
                                Field with a <span class="star">*</span> are required
                            </td>
                        </tr>
                        
                        <tr>
                            <td width="46%" align="left" colspan="2" style="padding-left: 125px">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                                <asp:Label ID="lblMsg" runat="server" CssClass="formText"></asp:Label>
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
                                        <td align="right" class="formText">
                                           <span class="star">*</span> Location:
                                        </td>
                                        <td height="40">
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
                                        <td  colspan="2" class="formHeadingText">
                                       
                                        &nbsp;
                                        Search by Date:
                                           </td>
                                        <td>
                                            
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
                                        <td align="right" class="formText" valign="top">
                                            
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:RadioButtonList ID="rdDate" runat="server" class="formText" >
                                                            <asp:ListItem Value="1">Dates Ordered </asp:ListItem>
                                                            <asp:ListItem Value="2">Dates Delivered</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                      
                                                   
                                                  
                                                       <table><tr><td>
                                                        <asp:Label ID="lblBetween" runat="server" Text="Between:" CssClass="formText" Font-Bold="true"></asp:Label>
                                                        </td></tr>
                                                        <tr>
                                                        <td class="formText">Start Date</td>
                                                        <td>
                                                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="textBox"  Enabled="false"></asp:TextBox>
                                                    <span style="padding-left:3px;">
                                        <img src="../images/CalendorIcon.jpg" id="imgFromCalendar" /></span>
                                        <cc1:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="txtFromDate"
                                            cssclass="AjaxCalendar" format="MM/dd/yyyy" popupbuttonid="imgFromCalendar" enabled="True"></cc1:calendarextender>
                                       
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                        <td class="formText">End Date</td>
                                                        <td>
                                                         <asp:TextBox ID="txtToDate" runat="server" CssClass="textBox"  Enabled="false"></asp:TextBox>
                                                         <span style="padding-left:5px;">
                                        <img src="../images/CalendorIcon.jpg " id="imgToCalendar" /></span>
                                        <cc1:calendarextender id="CalendarExtender2" runat="server" targetcontrolid="txtToDate"
                                            cssclass="AjaxCalendar" format="MM/dd/yyyy" popupbuttonid="imgToCalendar" enabled="True"></cc1:calendarextender>
                                                        </td>
                                                        </tr>
                                                        </table>
                                                       
                                                       
                                                        
                                                    </td>
                                                </tr>
                                            </table>
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
                                        <td  colspan="2" class="formHeadingText">
                                       
                                        &nbsp;
                                          OR Search by Order Number:</td>
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
                                        <td align="right" class="formText">
                                            Order #:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtorderNum" runat="server" CssClass="textBox" MaxLength="4">
                                            </asp:TextBox>
                                            <asp:RegularExpressionValidator ID="revNuumber" runat="server" ControlToValidate="txtorderNum"
                                                ValidationExpression="[0-9]+" ErrorMessage="Only number for  order #"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                            
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
                                        <td align="right" class="formText">
                                            Show:
                                        </td>
                                        <td class="formText">
                                             <asp:DropDownList ID="drpShow" runat="server" CssClass="DropDownBox">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="5">5</asp:ListItem>
                                                 <asp:ListItem Value="10">10</asp:ListItem>
                                                  <asp:ListItem Value="20">20</asp:ListItem>
                                                   <asp:ListItem Value="50">50</asp:ListItem>
                                            </asp:DropDownList>&nbsp;Per page
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
                                            <span class="ErrorTxt" style="padding-left:2px;">To view all records, hit begin with no search term.</span>
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
