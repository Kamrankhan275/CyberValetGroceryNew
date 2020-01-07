<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="AddNewsletterSale.aspx.cs" Inherits="CyberValetGrocery.Admin.AddNewsletterSale" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="JavaScript1.2">showHide("customers");</script>

    <asp:ScriptManager ID="Script1" runat="server">
    </asp:ScriptManager>
   <asp:UpdatePanel ID="update1" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="left" class="Logoutlink">
                        <table width="70%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="91%">
                                    &nbsp;
                                </td>
                                <td width="9%">
                                    <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../images/backbutton.jpg"
                                        Width="71" Height="23" border="0" OnClick="imgBack_Click" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <fieldset>
                            <legend>Newsletter</legend>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="30" class="formText">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="23%">
                                                </td>
                                                <td align="left" class="FieldTextNew">
                                                    Field with a <span class="star">*</span> are required
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="23%">
                                                </td>
                                                <td align="left">
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                                                    <asp:Label ID="lblMsg" CssClass="formText" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="44%" align="right" class="formText">
                                                    <span class="star">*</span>Subject:
                                                </td>
                                                <td width="56%" height="40">
                                                    <asp:TextBox ID="txtSubject" runat="server" CssClass="textBox" MaxLength="255"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject"
                                                        ErrorMessage="Subject is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <%-- <tr>
                                            <td width="44%" align="right" class="formText">
                                                <span class="star">*</span>Dates:
                                            </td>
                                            <td width="56%" height="40">
                                               <asp:TextBox ID="txtDates" runat="server" CssClass="textBox" MaxLength="30"></asp:TextBox> <span class="formTextSmall">(ex: May 20th - 26th)</span>
                                                <asp:RequiredFieldValidator ID="rfvDates" runat="server" ControlToValidate="txtDates"
                                                    ErrorMessage="Dates is required" ForeColor="White" Text="*" ></asp:RequiredFieldValidator>
                                                    
                                                    
                                            </td>
                                        </tr>--%>
                                            <tr>
                                                <td width="44%" align="right" class="formText">
                                                    <span class="star">*</span>Start Date:
                                                    <br /><span class="formTextSmall">(mm/dd/yyyy)</span>
                                                </td>
                                                <td width="56%" height="40">
                                                
                                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="textBox" ></asp:TextBox>
                                                    <span style="padding-left: 3px;">
                                                        <img src="../images/CalendorIcon.jpg" id="imgFromCalendar" /></span>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                                        CssClass="AjaxCalendar" Format="MM/dd/yyyy" PopupButtonID="imgFromCalendar" Enabled="True">
                                                    </cc1:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" ControlToValidate="txtFromDate"
                                                        ErrorMessage="Select start date" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                        
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="44%" align="right" class="formText">
                                                    <span class="star">*</span>End Date:
                                                     <br /><span class="formTextSmall">(mm/dd/yyyy)</span>
                                                </td>
                                                <td width="56%" height="40">
                                               
                                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="textBox"></asp:TextBox>
                                                    <span style="padding-left: 5px;">
                                                        <img src="../images/CalendorIcon.jpg" id="imgToCalendar" /></span>
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                                                        CssClass="AjaxCalendar" Format="MM/dd/yyyy" PopupButtonID="imgToCalendar" Enabled="True">
                                                    </cc1:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvTodate" runat="server" ControlToValidate="txtToDate"
                                                        ErrorMessage="Select end date" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                        
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="44%" align="right" class="formText" valign="top">
                                                    Header Message:
                                                </td>
                                                <td width="56%" height="40">
                                                    <%--<asp:TextBox ID="txtHeaderMessage" runat="server" CssClass="multiLinetextbox" MaxLength="500"
                                                    TextMode="MultiLine"></asp:TextBox>--%>
                                                    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Width="550px" Height="400px">
                                                    </FCKeditorV2:FCKeditor>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="44%" align="left" class="formText">
                                                    Sale Items:<br />
                                                    <span class="ErrorTxt">Use item titles EXACTLY as they appear</span>
                                                </td>
                                                <td width="56%" height="40">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="44%" align="right" class="formText">
                                                    Items1:
                                                </td>
                                                <td width="56%" height="40">
                                                    <asp:TextBox ID="txtSaleItem1" runat="server" CssClass="textBox2" MaxLength="50"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="44%" align="right" class="formText">
                                                    Items2:
                                                </td>
                                                <td width="56%" height="40">
                                                    <asp:TextBox ID="txtSaleItem2" runat="server" CssClass="textBox2" MaxLength="50"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="44%" align="right" class="formText">
                                                    Items3:
                                                </td>
                                                <td width="56%" height="40">
                                                    <asp:TextBox ID="txtSaleItem3" runat="server" CssClass="textBox2" MaxLength="50"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="44%" align="right" class="formText">
                                                    Items4:
                                                </td>
                                                <td width="56%" height="40">
                                                    <asp:TextBox ID="txtSaleItem4" runat="server" CssClass="textBox2" MaxLength="50"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="44%" align="right" class="formText">
                                                    Items5:
                                                </td>
                                                <td width="56%" height="40">
                                                    <asp:TextBox ID="txtSaleItem5" runat="server" CssClass="textBox2" MaxLength="50"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="44%" align="right" class="formText">
                                                    Items6:
                                                </td>
                                                <td width="56%" height="40">
                                                    <asp:TextBox ID="txtSaleItem6" runat="server" CssClass="textBox2" MaxLength="50"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="44%" align="right" class="formText">
                                                    Items7:
                                                </td>
                                                <td width="56%" height="40">
                                                    <asp:TextBox ID="txtSaleItem7" runat="server" CssClass="textBox2" MaxLength="50"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="44%" align="right" class="formText">
                                                    Items8:
                                                </td>
                                                <td width="56%" height="40">
                                                    <asp:TextBox ID="txtSaleItem8" runat="server" CssClass="textBox2" MaxLength="50"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="44%" align="right" class="formText" valign="top">
                                                    Footer Message:
                                                </td>
                                                <td width="56%" height="40">
                                                    <%-- <asp:TextBox ID="txtFooterMessage" runat="server" CssClass="multiLinetextbox" MaxLength="500"
                                                    TextMode="MultiLine"></asp:TextBox>--%>
                                                    <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server" Width="550px" Height="400px">
                                                    </FCKeditorV2:FCKeditor>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="formText">
                                                    &nbsp;
                                                </td>
                                                <td height="40" style="padding-left: 10px;">
                                                    <asp:Button ID="btnPreviewNewsletter" runat="server" Text="Preview" CssClass="button"
                                                        OnClick="btnPreviewNewsletter_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="70%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="91%">
                                    &nbsp;
                                </td>
                                <td width="9%">
                                    <asp:ImageButton ID="imgBack1" runat="server" ImageUrl="../images/backbutton.jpg"
                                        Width="71" Height="23" border="0" OnClick="imgBack1_Click" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
