<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="ShoppingCartVariables.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.ShoppingCartVariables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
     function clcontent() {
         var lb1 = document.getElementById("<%= lblMsg.ClientID %>");
         lb1.innerHTML = "";
     }


</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="70%" border="0" cellspacing="0" cellpadding="0">
       
        <tr>
            <td>
                <fieldset>
                    <legend>Shopping Cart Variables</legend>
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
                                    <td  width="23%"></td>
                                        <td align="left" >
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                                            <asp:Label ID="lblMsg" CssClass="formText" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td width="44%" align="right" class="formText">
                                            <span class="star">*</span>Same Day Service Delivery Fee($):
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtDeliveryFee" runat="server" CssClass="textBox" MaxLength="5"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvDeliveryFee" runat="server" ControlToValidate="txtDeliveryFee"
                                                ErrorMessage="Same Day Service delivery fee is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revDeliveryFee" runat="server" ControlToValidate="txtDeliveryFee"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for same Day service delivery fee"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td width="44%" align="right" class="formText">
                                            <span class="star">*</span>One Hour Delivery Fee($):
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtHourDeliveryFee" runat="server" CssClass="textBox" MaxLength="5"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvHourDeliveryFee" runat="server" ControlToValidate="txtHourDeliveryFee"
                                                ErrorMessage="One hour delivery fee is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revHourDeliveryFee" runat="server" ControlToValidate="txtHourDeliveryFee"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for delivery fee"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>--%>
                                   <tr>
                                        <td width="44%" align="right" class="formText">
                                            <span class="star">*</span>Delivery Fee($):
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtDeliveryFee" runat="server" CssClass="textBox" MaxLength="5"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvDeliveryFee" runat="server" ControlToValidate="txtDeliveryFee"
                                                ErrorMessage="Delivery fee is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revDeliveryFee" runat="server" ControlToValidate="txtDeliveryFee"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for delivery fee"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                            <span class="star">*</span>Delivery Fee of Members($):
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtMemberDeliveryFee" runat="server" CssClass="textBox" MaxLength="5"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvMemberDeliveryFee" runat="server" ControlToValidate="txtMemberDeliveryFee"
                                                ErrorMessage="Member's delivery fee is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revMemberDeliveryFee" runat="server" ControlToValidate="txtMemberDeliveryFee"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for member's delivery fee"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                            <span class="star">*</span>Pick Up Delivery Fee($):
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtPickUpDeliveryFee" runat="server" CssClass="textBox" MaxLength="5"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPickUpDeliveryFee"
                                                ErrorMessage="Pick Up delivery fee is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPickUpDeliveryFee"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for member's delivery fee"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                   <tr>
                                        <td width="44%" align="right" class="formText">
                                            <span class="star">*</span>First Order Gift($):
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtFirstOrderGift" runat="server" CssClass="textBox" MaxLength="5"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstOrderGift"
                                                ErrorMessage="First order gift is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFirstOrderGift"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for First Order Gift"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                           <span class="star">*</span> Tax Rate(Food Product)($):
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtTaxRate" runat="server" CssClass="textBox" MaxLength="5"></asp:TextBox>
                                        </td>
                                        <asp:RequiredFieldValidator ID="rfvTaxRate" runat="server" ControlToValidate="txtTaxRate"
                                            ErrorMessage="Tax rate is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revTaxRate" runat="server" ControlToValidate="txtTaxRate"
                                            ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for tax rate"
                                            Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                    </tr>
                                     <tr>
                                        <td width="44%" align="right" class="formText">
                                           <span class="star">*</span> Tax Rate(Non Food Product)($):
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtTaxRate1" runat="server" CssClass="textBox" MaxLength="5"></asp:TextBox>
                                        </td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTaxRate1"
                                            ErrorMessage="Tax rate 1 is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTaxRate1"
                                            ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for tax rate 1"
                                            Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                    </tr>
                                    
                                   
                                    
                                   
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                            <span class="star">*</span>Minimum Deposit($):
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtMinimumDeposit" runat="server" CssClass="textBox" MaxLength="3"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvMinimumDeposit" runat="server" ControlToValidate="txtMinimumDeposit"
                                                ErrorMessage="Minimum Deposit is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revMinimumDeposit" runat="server" ControlToValidate="txtMinimumDeposit"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for minimum deposit"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                            <span class="star">*</span>Number of time slot:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtNoOfTimeSlot" runat="server" CssClass="textBox" MaxLength="2"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvNoOfTimeSlot" runat="server" ControlToValidate="txtNoOfTimeSlot"
                                                ErrorMessage="Number of time slot is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revNoOfTimeSlot" runat="server" ControlToValidate="txtMinimumDeposit"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for number of time slot"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                            <span class="star">*</span>Delivery Fee Cut Off:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtDeliveryFeeCutOff" runat="server" CssClass="textBox" MaxLength="4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvDeliveryFeeCutOff" runat="server" ControlToValidate="txtDeliveryFeeCutOff"
                                                ErrorMessage="Delivery fee cut off is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revDeliveryFeeCutOff" runat="server" ControlToValidate="txtDeliveryFeeCutOff"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for delivery fee cut off"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                           <span class="star">*</span> Customer Service Email:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtCustomerServiceemail" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvCustServiceEmail" runat="server" ControlToValidate="txtCustomerServiceemail"
                                                ErrorMessage="Customer service email is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                            <span class="star">*</span>Contact Email:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtContactEmail" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvContactEmail" runat="server" ControlToValidate="txtContactEmail"
                                                ErrorMessage="Contact email is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                          
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                          <span class="star">*</span>  Info Email:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtInfoEmail" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvInfoEmail" runat="server" ControlToValidate="txtInfoEmail"
                                                ErrorMessage="Info email is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                          
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                          <span class="star">*</span>  Location Name:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtLocationName" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvLocationName" runat="server" ControlToValidate="txtLocationName"
                                                ErrorMessage="Location name is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                          <span class="star">*</span>  State Short Name:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtStateShortName" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvStateSortName" runat="server" ControlToValidate="txtStateShortName"
                                                ErrorMessage="State short name is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                           <span class="star">*</span> State Long Name:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtStateLongName" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="frvStateLongName" runat="server" ControlToValidate="txtStateLongName"
                                                ErrorMessage="State long name is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                           <span class="star">*</span> Company Short Name:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtCompanyName" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ControlToValidate="txtCompanyName"
                                                ErrorMessage="Company short name is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                           <span class="star">*</span> Company Long Name:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtCompanyLongName" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompanyLongName"
                                                ErrorMessage="Company long name is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                          <span class="star">*</span>  Short URL:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtShortURL" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvShortURL" runat="server" ControlToValidate="txtShortURL"
                                                ErrorMessage="Short URL is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                           <span class="star">*</span> Long URL:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtLongURL" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvLongURL" runat="server" ControlToValidate="txtLongURL"
                                                ErrorMessage="Long URL is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            &nbsp;
                                        </td>
                                        <td height="40" style="padding-left: 10px;">
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" 
                                                onclick="btnUpdate_Click" />
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
