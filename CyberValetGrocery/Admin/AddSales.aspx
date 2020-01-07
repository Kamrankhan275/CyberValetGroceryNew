<%@ Page Title="Add Sales" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="AddSales.aspx.cs" Inherits="CyberValetGrocery.Admin.AddSales" %>

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
                    <legend>Add Sales </legend>
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
                                            <span class="star">*</span>Product Title:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:DropDownList ID="drpProduct" runat="server" CssClass="DropDownBox" 
                                                onselectedindexchanged="drpProduct_SelectedIndexChanged" AutoPostBack="true">
                                                
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvPrduct" runat="server" ControlToValidate="drpProduct"
                                                ErrorMessage="Select product title" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            <span class="star">*</span>Size:
                                        </td>
                                        <td height="40" class="formText">
                                            <asp:TextBox ID="txtSize" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSize"
                                                ErrorMessage="Size is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            <span class="star">*</span>Price($):
                                        </td>
                                        <td height="40" class="formText">
                                            <asp:TextBox ID="txtPrice" runat="server" CssClass="textBox" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice"
                                                ErrorMessage="Price is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revPrice" runat="server" ControlToValidate="txtPrice"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for price"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            <span class="star">*</span>Pre-Sale($):
                                        </td>
                                        <td height="40" class="formText">
                                            <asp:TextBox ID="txtPreSale" runat="server" CssClass="textBox"  MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFVPreSale" runat="server" ControlToValidate="txtPreSale"
                                                ErrorMessage="Pre-Sale is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPreSale"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for Pre-Sale"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
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
