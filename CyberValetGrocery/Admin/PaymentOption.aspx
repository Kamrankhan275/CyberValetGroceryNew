<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="PaymentOption.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.PaymentOption" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function clcontent() {
            var lb1 = document.getElementById("<%= lblMsg.ClientID %>");
            lb1.innerHTML = "";
        }


    </script>

    <script language="javascript" type="text/javascript">
        function confirmsubmit() {
            if (confirm("You are about to update the payment option, please confirm?") == true) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <fieldset>
                    <legend>Payment Option</legend>
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
                                            <span class="star">*</span>Payment Option:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:DropDownList ID="drpPaymentOption" runat="server" CssClass="DropDownBox" OnSelectedIndexChanged="drpPaymentOption_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvPaymentOption" runat="server" ControlToValidate="drpPaymentOption"
                                                ErrorMessage="Select payment option" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="padding-left: 110px;">
                                            <asp:Panel ID="pnlAthorize" runat="server" Visible="false">
                                                <table>
                                                    <tr>
                                                        <td width="44%" align="right" class="formText">
                                                            <span class="star">*</span>API Login:
                                                        </td>
                                                        <td width="56%" height="40">
                                                            <asp:TextBox ID="txtAPILogin" runat="server" CssClass="textBoxPayment" MaxLength="100"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAPILogin" runat="server" ControlToValidate="txtAPILogin"
                                                                ErrorMessage="API login is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="44%" align="right" class="formText">
                                                            <span class="star">*</span>API Transaction Key:
                                                        </td>
                                                        <td width="56%" height="40">
                                                            <asp:TextBox ID="txtTranKey" runat="server" CssClass="textBoxPayment" MaxLength="100"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvTranKey" runat="server" ControlToValidate="txtTranKey"
                                                                ErrorMessage="API transaction key is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="44%" align="right" class="formText">
                                                            <span class="star">*</span>API Post Url:
                                                        </td>
                                                        <td width="56%" height="40">
                                                            <asp:TextBox ID="txtPostUrl" runat="server" CssClass="textBoxPayment" MaxLength="500"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvPostUrl" runat="server" ControlToValidate="txtPostUrl"
                                                                ErrorMessage="API  post url is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                          <%--  <asp:Panel ID="pnlPaypel" runat="server" Visible="false">
                                                <table>
                                                    <tr>
                                                        <td width="44%" align="right" class="formText">
                                                            <span class="star">*</span>API EndPoint Url:
                                                        </td>
                                                        <td width="56%" height="40">
                                                            <asp:TextBox ID="txtEndPayUrl" runat="server" CssClass="textBoxPayment" MaxLength="100"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEndPayUrl"
                                                                ErrorMessage="API endPoint url is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="44%" align="right" class="formText">
                                                            <span class="star">*</span>API User Name:
                                                        </td>
                                                        <td width="56%" height="40">
                                                            <asp:TextBox ID="txtPayUserNm" runat="server" CssClass="textBoxPayment" MaxLength="100"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtPayUserNm"
                                                                ErrorMessage="API user name is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="44%" align="right" class="formText">
                                                            <span class="star">*</span>API Password:
                                                        </td>
                                                        <td width="56%" height="40">
                                                            <asp:TextBox ID="txtPayPwd" runat="server" CssClass="textBoxPayment" MaxLength="100"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvPayPwd" runat="server" ControlToValidate="txtPayPwd"
                                                                ErrorMessage="API  password is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="44%" align="right" class="formText">
                                                            <span class="star">*</span>API Signature:
                                                        </td>
                                                        <td width="56%" height="40">
                                                            <asp:TextBox ID="txtPaySignature" runat="server" CssClass="textBoxPayment" MaxLength="500"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPaySignature"
                                                                ErrorMessage="API  password is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="44%" align="right" class="formText">
                                                            <span class="star">*</span>Paypal EC_URL :
                                                        </td>
                                                        <td width="56%" height="40">
                                                            <asp:TextBox ID="txtECURL" runat="server" CssClass="textBoxPayment" MaxLength="500"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="tfvEcurl" runat="server" ControlToValidate="txtECURL"
                                                                ErrorMessage="Paypal ecC_url is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="44%" align="right" class="formText">
                                                            <span class="star">*</span>Paypal EC_URL_LOGIN :
                                                        </td>
                                                        <td width="56%" height="40">
                                                            <asp:TextBox ID="txtECURLLOGIN" runat="server" CssClass="textBoxPayment" MaxLength="500"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ControlToValidate="txtECURLLOGIN"
                                                                ErrorMessage="Paypal ec_url_login  is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>--%>
                                            
                                             <asp:Panel ID="pnlPaypalIPN" runat="server" Visible="false">
                                                <table>
                                                    <tr>
                                                        <td width="44%" align="right" class="formText">
                                                            <span class="star">*</span>Paypal Url:
                                                        </td>
                                                        <td width="56%" height="40">
                                                            <asp:TextBox ID="txtPaypalUrl" runat="server" CssClass="textBoxPayment" MaxLength="100"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPaypalUrl"
                                                                ErrorMessage="Paypal url is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="44%" align="right" class="formText">
                                                            <span class="star">*</span>Business Email:
                                                        </td>
                                                        <td width="56%" height="40">
                                                            <asp:TextBox ID="txtBusEmail" runat="server" CssClass="textBoxPayment" MaxLength="100"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBusEmail"
                                                                ErrorMessage="Business email is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="44%" align="right" class="formText">
                                                            <span class="star">*</span>Paypal Submit Url:
                                                        </td>
                                                        <td width="56%" height="40">
                                                            <asp:TextBox ID="txtSubmitUrl" runat="server" CssClass="textBoxPayment" MaxLength="100"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSubmitUrl"
                                                                ErrorMessage="Paypal submit url is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="44%" align="right" class="formText">
                                                            <span class="star">*</span>PDT Token:
                                                        </td>
                                                        <td width="56%" height="40">
                                                            <asp:TextBox ID="txtToken" runat="server" CssClass="textBoxPayment" MaxLength="500"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtToken"
                                                                ErrorMessage="PDT token is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                                                                    
                                                      
                                                </table>
                                            </asp:Panel>
                                            
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            &nbsp;
                                        </td>
                                        <td height="40" style="padding-left: 10px;">
                                            <%-- OnClientClick="return confirmsubmit();"--%>
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" OnClick="btnUpdate_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
