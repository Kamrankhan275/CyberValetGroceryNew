<%@ Page Title="Update Account" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="EditTransactions.aspx.cs" Inherits="CyberValetGrocery.Admin.EditTransactions" %>

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
                    <legend>Update Account </legend>
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
                                            Date:
                                        </td>
                                        <td width="56%" height="40" style="padding-left: 5px;">
                                            <asp:Label ID="lblDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            <span class="star">*</span>Customer:
                                        </td>
                                        <td height="40">
                                            <asp:DropDownList ID="drpCustomer" runat="server" CssClass="DropDownBox">
                                               
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvCustomer" runat="server" ControlToValidate="drpCustomer"
                                                ErrorMessage="Select customer" ForeColor="White" InitialValue="Select" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                          <span class="star">*</span>  Amount($):
                                        </td>
                                        <td height="40">
                                            <asp:TextBox ID="txtTransAmt" runat="server" MaxLength="6" CssClass="textBox"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvAmt" runat="server" ControlToValidate="txtTransAmt"
                                                ErrorMessage="Amount is required " ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                 <%--<asp:RegularExpressionValidator ID="revAmount" runat="server" ControlToValidate="txtTransAmt"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for amount"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>--%>
                                                
                                                
                                                    <asp:RegularExpressionValidator ID="revAmount" runat="server" ControlToValidate="txtTransAmt"
                                                ValidationExpression="^(\-)?(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for amount"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td align="right" class="formText">
                                            Order #:<br />
                                            (if applicable)
                                        </td>
                                        <td height="40">
                                            <asp:TextBox ID="txtOrderId" runat="server" MaxLength="6" CssClass="textBox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText" valign="top">
                                           <span class="star">*</span> Comment:
                                        </td>
                                        <td height="40">
                                            <%--<asp:TextBox ID="txtTranscomment" runat="server" CssClass="multiLinetextbox" MaxLength="2000"
                                                TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvComment" runat="server" ControlToValidate="txtTranscomment"
                                                ErrorMessage="Comment is required " ForeColor="White" Text="*"></asp:RequiredFieldValidator>--%>
                                            <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Width="550px" Height="400px">
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
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update Account" CssClass="button"
                                                OnClick="btnUpdate_Click" />
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
