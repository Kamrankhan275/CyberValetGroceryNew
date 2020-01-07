<%@ Page Title="Send Newsletter" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="admin_newsletter.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_newsletter" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function clcontent() {
        var lb1 = document.getElementById("<%= lblMsg.ClientID %>");
        lb1.innerHTML = "";
    }


</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="JavaScript1.2">showHide("customers");</script>

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="left" class="Logoutlink">
                <table width="70%" border="0" cellspacing="0" cellpadding="0">
                 <tr><td height="10px"></td></tr>
                    <tr>
                        <td class="Logoutlink">
                            Text Only Newsletter
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td height="10px"></td></tr>
        <tr>
            <td>
                <fieldset>
                    <legend>Newsletter (Text)</legend>
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
                                        <td align="right" class="formText">
                                            <span class="star">*</span>Location:
                                        </td>
                                        <td height="40">
                                            <asp:DropDownList ID="drpLocation" runat="server" CssClass="DropDownBox">
                                                
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ControlToValidate="drpLocation"
                                                ErrorMessage="Select location" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                           <span class="star">*</span> Subject:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtSubject" runat="server" MaxLength="50" CssClass="textBox"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject"
                                                ErrorMessage="Subject is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText" valign="top">
                                           <span class="star">*</span> Body:
                                        </td>
                                        <td height="40">
                                            <%--<asp:TextBox ID="txtBody" runat="server" CssClass="multiLinetextbox" MaxLength="2000"
                                                TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvBody" runat="server" ControlToValidate="txtBody"
                                                ErrorMessage="Body is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>--%>
                                       
                                        <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Width="550px" Height="400px" >
                                        </FCKeditorV2:FCKeditor>
                                        
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
                                            <asp:Button ID="btnSend" runat="server" Text="Sent" CssClass="button" OnClick="btnSend_Click" />
                                            <span style="padding-left: 5px;" class="ErrorTxt">(Yes, this is for real. Press sent
                                                and it goes out.)</span>
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
