<%@ Page Title="Forgot Password?" Language="C#" MasterPageFile="~/Admin/AdminLogin.Master"
    AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="CyberValetGrocery.Admin.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="782" border="0" align="center" cellpadding="0" cellspacing="0">
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
                    <legend>Forgot Password?</legend>
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
                            <td width="46%" align="right" class="formText">
                                <span class="star">*</span>Email Address:
                            </td>
                            <td width="54%" height="40">
                                <asp:TextBox ID="txtAdminEmail" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvAdminEmail" runat="server" Text="*" ControlToValidate="txtAdminEmail"
                                    ErrorMessage="Email address is required" ForeColor="White"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtAdminEmail"
                                    ErrorMessage="Invalid email address" ForeColor="White" Text="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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
                                <asp:Button ID="btnLogin" runat="server" Text="Submit" CssClass="button" OnClick="btnLogin_Click" />
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
