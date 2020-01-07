<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="EditEmployee.aspx.cs" Inherits="CyberValetGrocery.Admin.EditEmployee" %>

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
                    <legend>Update Employee</legend>
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
                                        <td width="23%">
                                        </td>
                                        <td align="left">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                                            <asp:Label ID="lblMsg" CssClass="formText" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                            <span class="star">*</span>First Name:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="textBox" MaxLength="15"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                                                ErrorMessage="First name is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revFirstName" runat="server" Text="*" ForeColor="White"
                                                ErrorMessage="Invalid first name,only characters allowed" ControlToValidate="txtFirstName"
                                                ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            <span class="star">*</span>Last Name:
                                        </td>
                                        <td height="40">
                                            <asp:TextBox ID="txtLastName" runat="server" CssClass="textBox" MaxLength="15"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                                                ErrorMessage="Last name is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revLName" runat="server" Text="*" ForeColor="White"
                                                ErrorMessage="Invalid last name,only characters allowed" ControlToValidate="txtLastName"
                                                ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            <span class="star">*</span>Email Address:
                                        </td>
                                        <td height="40">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textBox" MaxLength="30"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvAdminEmail" runat="server" Text="*" ControlToValidate="txtEmail"
                                                ErrorMessage="Email address is required" ForeColor="White"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            <%--<span class="star">*</span>--%>Password:
                                        </td>
                                        <td height="40">
                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="textBox" MaxLength="20"  TextMode="Password"></asp:TextBox>
                                           <%-- <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                                ErrorMessage="Password is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="rePwd" runat="server" Text="*" ForeColor="White"
                                                ErrorMessage="password should be between 7 and 20 characters with at least one number and no symbols."
                                                ControlToValidate="txtPassword" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{7,20})$">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td align="right" class="formText">
                                            <%--<span class="star">*</span>--%>Confirm Password:
                                        </td>
                                        <td height="40">
                                            <asp:TextBox ID="txtConfirmPwd" runat="server" CssClass="textBox" MaxLength="20" TextMode="Password"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtConfirmPwd"
                                                ErrorMessage="Confirm password is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>--%>
                                            <asp:CompareValidator ID="conPwd" runat="server" Text="*" ForeColor="White"  ControlToCompare="txtPassword" ControlToValidate="txtConfirmPwd" 
                                             ErrorMessage="Confirm password and password should be same" ></asp:CompareValidator>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText" valign="top">
                                            <span class="star">*</span>Permission(s):
                                        </td>
                                        <td height="40" class="formText" style="padding: 3px;">
                                            <asp:CheckBoxList ID="chkPermission" runat="server">
                                                
                                            </asp:CheckBoxList>
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
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" OnClick="btnUpdate_Click" />
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
