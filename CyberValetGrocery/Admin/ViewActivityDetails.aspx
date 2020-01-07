<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewActivityDetails.aspx.cs" Inherits="CyberValetGrocery.Admin.ViewActivityDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                    <legend>User Reports</legend>
        
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
                                            <td nowrap="nowrap">
                                                 <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                &nbsp;
                                            </td>
                                            <td>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="20%" align="right" nowrap="nowrap" valign="top">
                                                <span class="formText"><span class="star">*</span> Zip Code:</span>
                                            </td>
                                            <td width="80%">
                                                <asp:DropDownList ID="drpZip" runat="server" CssClass="DropDownBox">
                                                   
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvZip" runat="server" ControlToValidate="drpZip"
                                                    ErrorMessage="Select zip code" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
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
                                                        ErrorMessage="Select start date" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
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
                                            <td align="right">
                                                &nbsp;
                                            </td>
                                            <td style="padding-left: 10px;">
                                            <table>
                                            <tr>
                                            <td>
                                     <asp:Button ID="btnView" runat="server" Text="View Report" CssClass="button" OnClick="btnView_Click" />

                                            </td>
                                            <td style="padding-left: 10px;">
                                       <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="button" OnClick="btnBack_Click" CausesValidation="false" />
                                            
                                            
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
                                    </table>
                                    
                                    
                                
                                </td>
                            </tr>
                            
                           
                                        
                                        <tr>
                                        <td colspan="2" align="left">
                                        
                                         
                                        
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

