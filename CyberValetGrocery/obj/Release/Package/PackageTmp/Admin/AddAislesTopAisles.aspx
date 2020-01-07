﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddAislesTopAisles.aspx.cs" Inherits="CyberValetGrocery.Admin.AddAislesTopAisles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script type="text/javascript">
     function clcontent() {
         var lb1 = document.getElementById("<%= lblMsg.ClientID %>");
         lb1.innerHTML = "";
     }


</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="JavaScript1.2">showHide("sitefunctions");</script>

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
                    <legend>Add Top Aisle </legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="30" class="formText">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="2" class="FieldText">
                                            Field with a <span class="star">*</span> are required
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="46%" align="center" colspan="2">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                                            <asp:Label ID="lblMsg" CssClass="formText" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                  
                                    
                                   
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                            <span class="star">*</span>Top Aisle Name:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtTopAisleName" runat="server" CssClass="textBox" MaxLength="75"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvAisleName" runat="server" ControlToValidate="txtTopAisleName"
                                                ErrorMessage="Top aisle name is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText" >
                                            Upload Image:
                                        </td>
                                        <td height="40" class="formText" style="padding-left:10px;">
                                          <asp:FileUpload ID="imgAsileUpload" runat="server" />
                                        </td>
                                    </tr>
                                  
                                    <tr>
                                        <td align="right" class="formText" valign="top">
                                            Show:
                                        </td>
                                        <td height="40" class="formText">
                                            <asp:RadioButtonList ID="rdShow" runat="server" CssClass="Radiobutton">
                                                <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td align="right" class="formText" valign="top">
                                            Highlight Top Aisle :
                                        </td>
                                        <td height="40" class="formText">
                                            <asp:CheckBox ID="highlightedShop" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            &nbsp;
                                        </td>
                                        <td height="20" style="padding-left: 10px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    
                                    
                                    
                                    <tr>
                                        <td align="right" class="formText">
                                            &nbsp;
                                        </td>
                                        <td height="40" style="padding-left: 10px;">
                                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" OnClick="btnAdd_Click" />
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
</asp:Content>