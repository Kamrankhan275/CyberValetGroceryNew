<%@ Page Title="Login" Language="C#" MasterPageFile="~/Admin/AdminLogin.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="CyberValetGrocery.Admin.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="782" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" class="logintextheading">
                You must login to access this area of the website.
            </td>
        </tr>
        <tr>
            <td height="40">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>Admin Login</legend>
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
                            <td width="23%">
                            </td>
                            <td align="left">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                                <asp:Label ID="lblMsg" CssClass="ErrorTxt1" runat="server"></asp:Label>
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
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="formText">
                                <span class="star">*</span>Password:
                            </td>
                            <td height="40">
                                <asp:TextBox ID="txtAdminPassword" runat="server" MaxLength="15" TextMode="Password"
                                    CssClass="textBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Text="*" ControlToValidate="txtAdminPassword"
                                    ErrorMessage="Password is required" ForeColor="White">
                                </asp:RequiredFieldValidator>
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
                                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button" OnClick="btnLogin_Click" />
                                <%-- <a href="#" class="Button">Login</a> --%>
                                <asp:Button ID="btnForgot" runat="server" Text="Forgot Password?" CssClass="button"
                                    CausesValidation="false" OnClick="btnForgot_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
