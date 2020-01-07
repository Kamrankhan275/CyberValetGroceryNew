<%@ Page Title="Update User" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="CyberValetGrocery.Admin.EditUser" %>

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
                    <legend>Update User </legend>
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="4" class="FieldText">
                                Field with a <span class="star">*</span> are required
                            </td>
                        </tr>
                        <tr>
                            <td height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td width="23%" colspan="2">
                            </td>
                            <td align="left" colspan="2">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                                <asp:Label ID="lblMsg" CssClass="formText" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="formHeadingText">
                                Personal Information
                            </td>
                        </tr>
                        <tr>
                            <td height="3px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="formText" nowrap="nowrap" align="right">
                                Member since:
                            </td>
                            <td class="formTextSmall" style="padding-left: 5px;">
                                <asp:Label ID="lblJoinedDate" runat="server"></asp:Label>
                            </td>
                            <td class="formText">
                            </td>
                            <td class="formTextSmall">
                            </td>
                        </tr>
                        <tr>
                            <td height="3px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="formText" nowrap="nowrap" align="right">
                                <span class="star">*</span> First Name:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtFName" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFName"
                                    ErrorMessage="First name is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revFirstName" runat="server" Text="*" ForeColor="White"
                                    ErrorMessage="Invalid first name,only characters allowed" ControlToValidate="txtFName"
                                    ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
                            </td>
                            <td class="formText" nowrap="nowrap" align="right">
                                <span class="star">*</span> Email:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="Email  is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td height="3px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="formText" nowrap="nowrap" align="right">
                                <span class="star">*</span> Last Name:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtLName" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLName" runat="server" ControlToValidate="txtLName"
                                    ErrorMessage="Last name is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revLName" runat="server" Text="*" ForeColor="White"
                                    ErrorMessage="Invalid last name,only characters allowed" ControlToValidate="txtLName"
                                    ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
                            </td>
                            <td class="formText" nowrap="nowrap" align="right">
                                <%--<span class="star">*</span>--%>
                                Password:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" TextMode="Password"
                                    ErrorMessage="Password is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="rePwd" runat="server" Text="*" ForeColor="White"
                                    ErrorMessage="password should be between 7 and 20 characters with at least one number and no symbols."
                                    ControlToValidate="txtPassword" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{7,20})$">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td height="3px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="formText" nowrap="nowrap" align="right">
                                <span class="star">*</span> Phone:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="textBox" MaxLength="12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
                                    ErrorMessage="Phone is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                            </td>
                            <td class="formText" nowrap="nowrap" align="right">
                                Mailing List:
                            </td>
                            <td class="formTextSmall" style="padding-left: 3px;">
                                <asp:CheckBox ID="chkMailingList" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td height="3px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="formText" nowrap="nowrap" align="right">
                                Cell:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtCell" runat="server" CssClass="textBox" MaxLength="12"></asp:TextBox>
                            </td>
                            <td class="formText" nowrap="nowrap" align="right">
                                <span class="star">*</span> Status:
                            </td>
                            <td class="formTextSmall">
                                <asp:DropDownList ID="drpStatus" runat="server" CssClass="DropDownBox">
                                    <asp:ListItem Value="Select">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">Inactive</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="drpStatus"
                                    ErrorMessage="Select status" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td height="3px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="formText" nowrap="nowrap" align="right">
                                Membership:
                            </td>
                            <td class="formTextSmall">
                                <asp:CheckBox runat="server" ID="chkMembership"></asp:CheckBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="formHeadingText">
                                Delivery Address
                            </td>
                            <td colspan="2" class="formHeadingText">
                                Billing Information
                            </td>
                        </tr>
                        <tr>
                            <td height="3px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="formText" align="right">
                                <span class="star">*</span> Address 1:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtDeliveryAdd1" runat="server" CssClass="textBox" MaxLength="2000"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDeliveryAdd1" runat="server" ControlToValidate="txtDeliveryAdd1"
                                    ErrorMessage="Delivery address 1 is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                            </td>
                            <td class="formText" align="right">
                                Address 1:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtBillingAdd1" runat="server" CssClass="textBox" MaxLength="2000"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="3px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="formText" align="right">
                                Address 2:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtDeliveryAdd2" runat="server" CssClass="textBox" MaxLength="2000"></asp:TextBox>
                            </td>
                            <td class="formText" align="right">
                                Address 2:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtBillingAdd2" runat="server" CssClass="textBox" MaxLength="2000"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="3px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="formText" align="right">
                                <span class="star">*</span> City:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtDeliveryCity" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDeliveryCity" runat="server" ControlToValidate="txtDeliveryCity"
                                    ErrorMessage="Delivery city  is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                            </td>
                            <td class="formText" align="right">
                                City:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtBillingCity" runat="server" CssClass="textBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="3px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="formText" align="right">
                                <span class="star">*</span> State:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtDeliveryState" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="txtDeliveryState"
                                    ErrorMessage="Delivery state  is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                            </td>
                            <td class="formText" align="right">
                                State:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtBillingState" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="3px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="formText" align="right">
                                <span class="star">*</span> Zip:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtDeliveryZip" runat="server" CssClass="textBox" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtDeliveryZip"
                                    ErrorMessage="Delivery zip is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                <%--  <asp:RegularExpressionValidator ID="reqZip" runat="server" ControlToValidate="txtDeliveryZip"
                                ErrorMessage="Invalid delivery zip,exactly  five digits allowed" Text="*" ValidationExpression="\d{5}" ForeColor="White"></asp:RegularExpressionValidator>--%>
                            </td>
                            <td class="formText" align="right">
                                Zip:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtBillingZip" runat="server" CssClass="textBox" MaxLength="5"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rfvBillingZip" runat="server" ControlToValidate="txtBillingZip"
                                    ErrorMessage="Invalid billing zip, exactly  five digits allowed" Text="*" ValidationExpression="\d{5}"
                                    ForeColor="White"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td height="3px;">
                                &nbsp;
                            </td>
                        </tr>
                        <%-- <tr>
                            <td class="formText">
                            </td>
                            <td class="formTextSmall">
                            </td>
                            <td class="formText" align="right">
                                Credit Card:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtCreditCard" runat="server" CssClass="textBox" MaxLength="16"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="3px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="formText">
                            </td>
                            <td class="formTextSmall">
                            </td>
                            <td class="formText" align="right">
                                Expiration:
                            </td>
                            <td class="formTextSmall">
                                <asp:TextBox ID="txtExpiration" runat="server" CssClass="textBox" MaxLength="8"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="3px;">
                                &nbsp;
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="4" align="center">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" OnClick="btnUpdate_Click" />
                                        </td>
                                        <td style="padding-left: 7px;">
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
