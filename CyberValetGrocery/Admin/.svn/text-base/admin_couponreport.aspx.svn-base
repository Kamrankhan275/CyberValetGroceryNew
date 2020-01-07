<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="admin_couponreport.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_couponreport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="JavaScript1.2">showHide("reports");</script>

    <asp:ScriptManager ID="Script1" runat="server">
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
                    <legend>Coupon Report </legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="30" class="formText" nowrap="nowrap">
                               Choose the dates below for which you would like to see all coupon details: 
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
                                            <td width="20%" align="right" nowrap="nowrap">
                                                <span class="formText"><span class="star">*</span>Start Date:</span>
                                            </td>
                                            <td width="80%">
                                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="textBox" Enabled="false"></asp:TextBox>
                                                <span style="padding-left:3px;">
                                                    
                                                    <img src="../images/CalendorIcon.jpg" id="imgFromCalendar" /></span>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                                        CssClass="AjaxCalendar" Format="MM/dd/yyyy" PopupButtonID="imgFromCalendar" Enabled="True">
                                                    </cc1:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" ControlToValidate="txtFromDate"
                                                        ErrorMessage="Select start date  " ForeColor="White" Text="*"></asp:RequiredFieldValidator>
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
                                                <span class="formText"><span class="star">*</span>End Date:</span>
                                            </td>
                                            <td width="80%">
                                                <asp:TextBox ID="txtToDate" runat="server" CssClass="textBox" Enabled="false"></asp:TextBox>
                                               <span style="padding-left:5px;">
                                                    <img src="../images/CalendorIcon.jpg" id="imgToCalendar" /></span>
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                                                        CssClass="AjaxCalendar" Format="MM/dd/yyyy" PopupButtonID="imgToCalendar" Enabled="True">
                                                    </cc1:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvTodate" runat="server" ControlToValidate="txtToDate"
                                                        ErrorMessage="Select end date" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
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
                                                <span class="formText"><span class="star">*</span>Location:</span>
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
                                            <td align="right">
                                                &nbsp;
                                            </td>
                                            <td style="padding-left: 10px;">
                                                <asp:Button ID="btnBegin" runat="server" Text="Begin" CssClass="button" OnClick="btnBegin_Click" />
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
