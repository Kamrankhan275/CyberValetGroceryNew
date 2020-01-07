<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="AddZip.aspx.cs" Inherits="CyberValetGrocery.Admin.AddZip" %>

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
                    <legend>Add Zip Code </legend>
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
                                           <span class="star">*</span> Zip Code:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtZipCode" runat="server" CssClass="textBox" MaxLength="5"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ControlToValidate="txtZipCode"
                                                ErrorMessage="Zip code is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                           <%-- <asp:RegularExpressionValidator ID="revZipCode" runat="server" Text="*" ForeColor="White"
                                                ErrorMessage="Invalid zip code,exactly  five digits allowed" ControlToValidate="txtZipCode"
                                                ValidationExpression="\d{5}"></asp:RegularExpressionValidator>--%>
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
                                    
                                   <%--  <tr>

                                        <td align="right" class="formText">
                                           <span class="star">*</span> Delivery Fees($):
                                        </td>
                                        <td height="40">
                                             <asp:TextBox ID="txtOrderSize" runat="server" CssClass="textBox" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvSize" runat="server" ControlToValidate="txtOrderSize"
                                                ErrorMessage="Delivery fees is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>--%>
                                     <tr>
                                        <td align="right" class="formText">
                                           <span class="star">*</span> Minimum Order Amount($):
                                        </td>
                                        <td height="40">
                                             <asp:TextBox ID="txtMinimumOrderAmt" runat="server" CssClass="textBox" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMinimumOrderAmt"
                                                ErrorMessage="Minimum order amount is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
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
