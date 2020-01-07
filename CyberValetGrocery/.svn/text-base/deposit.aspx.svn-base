<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="deposit.aspx.cs" Inherits="CyberValetGrocery.deposit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="script1" runat="server" 
></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server"  >
    <ContentTemplate>
    <table>
 <tr>
            <td align="left" class="formHeading">
                <strong><asp:Label ID="lblCompanyNameTitle" runat="server"></asp:Label> &nbsp;Shopping 
                Funds</strong>
            </td>
        </tr>
          <tr>
        <td  height="10px">
        
        </td>
        
        </tr>
          <tr>
        <td class="formTextUSer">
        When you are ready, choose the amount you wish to deposit <strong>($<asp:Label ID="lblMinAmt" runat="server"></asp:Label>&nbsp;minimum)</strong> and fill out the form below.
        </td>
        
        </tr>
 <tr>
        <td  height="10px">
        
        </td>
        
        </tr>
<tr>
<td align="left" class="formTextUSer">
<table cellpadding="3" cellspacing="0" border="0" >
                    <tr>
                    <td></td>
                        <td align="left" >
                            Field with a <span class="star1">*</span> are required
                        </td>
                    </tr>
                    <tr>
                        <td height="3px">
                        </td>
                    </tr>                    
                    <tr>
                    <td></td>
                        <td align="left" >
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1"/>
                        </td>
                    </tr>
                    <tr>                    
                        <td align="left" colspan="2" style="padding-left:100px;" >                           
                            <asp:Label ID="lblMsg" CssClass="formTextUSer" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td height="3px">
                        </td>
                    </tr>
                     <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>Amount to Deposit($):
                        </td>
                        <td>
                            <asp:TextBox ID="txtDepositAmt" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" Text="*" ControlToValidate="txtDepositAmt"
                                ErrorMessage="Your amount to deposit is required" ForeColor="White"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="revAmount" runat="server" ControlToValidate="txtDepositAmt"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for amount to deposit"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                        </td>
                        
                    </tr>
                                        
                    
                    <tr valign="top">
                        <td align="right">
                             Personal Message: 
                        </td>
                        <td valign="top">
                         <asp:TextBox ID="txtPerMsg" runat="server" CssClass="textMultiline" MaxLength="2000"  TextMode="MultiLine"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr><td height="5px"></td></tr>
                    <tr>
                    <td colspan="2"  class="formHeadingText" align="center" >
                    <strong >Billing Information</strong>
                    </td>
                    
                    </tr>
                    <tr><td height="5px"></td></tr>
                     <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>First Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtFName" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFname" runat="server" Text="*" ControlToValidate="txtFName"
                                ErrorMessage="First name is required" ForeColor="White"></asp:RequiredFieldValidator>
                                 
                        </td>
                        
                    </tr>
             
                   <tr><td height="5px"></td></tr>
                     <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>Last Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtLName" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLName" runat="server" Text="*" ControlToValidate="txtLName"
                                ErrorMessage="Last name is required" ForeColor="White"></asp:RequiredFieldValidator>
                                 
                        </td>
                        
                    </tr>
                    
                    <tr><td height="5px"></td></tr>
                     <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>Address1:
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress1" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" Text="*" ControlToValidate="txtAddress1"
                                ErrorMessage="Address1 is required" ForeColor="White"></asp:RequiredFieldValidator>
                                 
                        </td>
                        
                    </tr>
                    
                    
                     <tr><td height="5px"></td></tr>
                     <tr valign="top">
                        <td align="right">
                           Address2:
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress2" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                                             
                        </td>
                        
                    </tr>
                    
                    
                    <tr><td height="5px"></td></tr>
                     <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>City:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCity" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCity" runat="server" Text="*" ControlToValidate="txtCity"
                                ErrorMessage="City is required" ForeColor="White"></asp:RequiredFieldValidator>
                                 
                        </td>
                        
                    </tr>
                    <tr><td height="5px"></td></tr>
                     <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>State:
                        </td>
                        <td>
                            <asp:DropDownList ID="drpState" runat="server" CssClass="DropDown">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvState" runat="server" Text="*" ControlToValidate="drpState"
                                        ErrorMessage="Select state" ForeColor="White" InitialValue="Select"></asp:RequiredFieldValidator>
                                 
                        </td>
                        
                    </tr>
                    <tr><td height="5px"></td></tr>
                     <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>Zip Code:
                        </td>
                        <td>
                            <asp:TextBox ID="txtZip" runat="server" CssClass="textbox1" MaxLength="5"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvZip" runat="server" Text="*" ControlToValidate="txtZip"
                                ErrorMessage="Zip code is required" ForeColor="White"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="reqZip" runat="server" ControlToValidate="txtZip"
                                ErrorMessage="Invalid zip code,exactly  five digits allowed" Text="*" ValidationExpression="\d{5}" ForeColor="White"></asp:RegularExpressionValidator>
                                 
                        </td>
                        
                    </tr>
                    
                     <tr><td height="5px"></td></tr>
                     <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>Phone:
                            <br /><span class="formTextSmall1">(111-111-1111)</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="textbox1" MaxLength="12"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" Text="*" ControlToValidate="txtPhone"
                                ErrorMessage="Phone is required" ForeColor="White"></asp:RequiredFieldValidator>
                                 
                        </td>
                        
                    </tr>
                    <tr>
                    <td colspan="2" style="padding-left:50px;">
                    
                    <asp:Panel ID="pnlAuthorize" runat="server" Visible="false">
                    <table>
                    
                   
                   
                   <tr><td height="5px"></td></tr>
                    <tr>
                    <td colspan="2"  class="formHeadingText" align="center" >
                    <strong >Credit Card Information</strong>
                    </td>
                    
                    </tr>
                    <tr valign="top">
                        <td align="right">
                             <span class="star1">*</span>Credit Card Number: 
                        </td>
                        <td>
                            <asp:TextBox ID="ttxPayCCNm" runat="server" CssClass="textbox1" MaxLength="16"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Rfvccc" runat="server" Text="*" ControlToValidate="ttxPayCCNm"
                                ErrorMessage="Credit card number is required" ForeColor="White"></asp:RequiredFieldValidator>
                                
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="right">
                            
                        </td>
                        <td style="padding-left:10px;">
                           <img src="images/CC1.gif"   border="0"/>
                           <img src="images/CC2.gif"  border="0"/>
                           <img src="images/CC3.gif"  border="0"/>
                           <img src="images/CC4.gif"  border="0"/>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="right">
                             <span class="star1">*</span>Card Type:
                        </td>
                        <td>
                            <asp:DropDownList ID="drpPayCardType" runat="server" CssClass="DropDown">
                           <asp:ListItem Value="Select">Select</asp:ListItem>  
                             <asp:ListItem Value="American Express">Amex</asp:ListItem>                               
                                 <asp:ListItem Value="Discover">Discover</asp:ListItem>  
                                    <asp:ListItem Value="MasterCard">Master Card</asp:ListItem> 
                                    <asp:ListItem Value="Visa">Visa</asp:ListItem>   
                                                       
                           
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvType" runat="server" Text="*" ControlToValidate="drpPayCardType"
                                ErrorMessage="Select card type" ForeColor="White" InitialValue="Select"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                   
                                         
                    <tr valign="top">
                        <td align="right">
                          <span class="star1">*</span> Expiration Date:  
                        </td>
                        <td>
                        <asp:Panel ID="pnlPayPal" runat="server" Visible="false">
                        <table>
                        
                        <tr>
                        <td>
                        <asp:TextBox ID="txtPayExp" runat="server" MaxLength="6" CssClass="textbox1"></asp:TextBox>
                        </td>
                        <td style="padding-left:5px;">
                        <strong>Format:</strong>&nbsp;MMYYYY
                        </td>
                        </tr>
                        </table>
                           </asp:Panel> 
                            <asp:Panel ID="pnlAuto" runat="server" Visible="false">
                        <table>
                        
                        <tr>
                        <td>
                        <table>
                        <tr>
                        <td>
                         <asp:TextBox ID="txtAutoExpMM" runat="server" MaxLength="2" CssClass="textboxSmall"> </asp:TextBox>
                        </td>
                        <td>/</td>
                         <td>
                         <asp:TextBox ID="txtAutoExpYY" runat="server" MaxLength="4"  CssClass="textboxSmall"></asp:TextBox>
                        </td>
                        </tr>
                        </table>
                       
                        
                        </td>
                        <td style="padding-left:5px;">
                        <strong>Format:</strong>&nbsp;MM/YYYY
                        </td>
                        </tr>
                        </table>
                           </asp:Panel> 
                        </td>
                    </tr>
                     <tr valign="top">
                        <td align="right">
                             <span class="star1">*</span>3-Digit Security Code: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtPayCvv" runat="server" CssClass="textbox1" MaxLength="4"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCVV" runat="server" Text="*" ControlToValidate="txtPayCvv"
                                ErrorMessage="3-digit security code is required" ForeColor="White"></asp:RequiredFieldValidator>
                               
                        </td>
                    </tr>
                    </table>
                    </asp:Panel>
                    </td>
                    </tr>
                   
                    <tr>
                    <td></td>
                        <td  align="left" style="padding-left: 15px;">
                            <asp:Button ID="btnSend" runat="server" Text="Submit" CssClass="buttonUser" OnClick="btnSend_Click" />
                        </td>
                    </tr>
                    <tr>
                    <td>
                    
                     <asp:Label ID="lblPayPalUrl" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblPayEmail" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblWebsiteLong" runat="server" Visible="false"></asp:Label>
                    </td>
                    </tr>
                </table>
 
 </td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
