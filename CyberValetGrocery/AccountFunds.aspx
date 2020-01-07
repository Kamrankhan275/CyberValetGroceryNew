<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="AccountFunds.aspx.cs" Inherits="CyberValetGrocery.AccountFunds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script type="text/javascript">
        function clcontent() {
            var lb1 = document.getElementById("<%= lblMsg.ClientID %>");
            lb1.innerHTML = "";
        }
    </script>
     <script type="text/javascript">
         var Image28 = document.getElementById("Image28");
         var Image29 = document.getElementById("Image29");
         var Image30 = document.getElementById("Image30");
         var Image31 = document.getElementById("Image31");
         var Image32 = document.getElementById("Image32");
         var Image27 = document.getElementById("Image27");
         var Image33 = document.getElementById("Image33");
         var Image34 = document.getElementById("Image34");
         Image28.src = "images/referaFrnd-btn.png";
         Image29.src = "images/loyaltyProgarm-btn.png";
         Image30.src = "images/deliveryInfo-btn.png";
         Image31.src = "images/aboutUs-btn.png";
         Image32.src = "images/myShoppingList-btn.png";
         Image27.src = "images/accountFunds-h.png";
         Image33.src = "images/FAQ-btn.png";
         Image34.src = "images/contactUs-btn.png";
    </script>

    <asp:ScriptManager ID="script1" runat="server"> 
</asp:ScriptManager>
   <asp:UpdatePanel ID="updatePnl1" runat="server"  >
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-left: 10px;">
        <tr>
            <td align="left" class="formHeading">
                <strong><asp:Label ID="lblCompanyName" runat="server"></asp:Label> Account Funds</strong>
            </td>
        </tr>
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
        
        <td>
        <asp:Panel ID="pnlForm" runat="server">
        <table>
        <tr><td align="left" class="formTextUSerSubTitle">
        Adding Funds to an Account 


        </td></tr>
        
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td align="left" class="formTextUSer" style="padding-right:20px;">
                <asp:Label ID="lblCompanyName1" runat="server"></asp:Label>&nbsp;Funds are great for parents of students 18 and over or those caring for a senior relative. 
               First, your loved one must have an account set up with us. Then you can deposit funds into their account at any time.
                 The funds you deposit will be available for withdrawal immediately. This program allows them to shop for their groceries 
                 online using funds that you deposited for them. We will deliver right to their door. 




            </td>
        </tr>
       
        <tr>
            <td height="10px">
            </td>
        </tr>
       
       
        <tr>
            <td class="formTextUSer">
                <table cellpadding="3" cellspacing="0" border="0" width="435px" >
                    <tr>
                        <td colspan="2" align="center">
                            Field with a <span class="star1">*</span> are required
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr>
                    
                        <td align="left" colspan="2" style="padding-left:20px;" >
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1"/>
                            <asp:Label ID="lblMsg" CssClass="formTextUSer" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                     <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>Email:<br />
                            <span class="formTextSmall1">(of recipient)</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRecipientEmail" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Text="*" ControlToValidate="txtRecipientEmail"
                                ErrorMessage="Recipient email is required" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                    <tr valign="top">
                        <td align="right">
                              <span class="star1">*</span>First Name: 
                        </td>
                        <td>
                           <asp:TextBox ID="txtFName" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFName" runat="server" Text="*" ControlToValidate="txtFName"
                                ErrorMessage="First name is required" ForeColor="White"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revFirstName" runat="server" Text="*" ForeColor="White"
                                    ErrorMessage="Invalid first name,only characters allowed" ControlToValidate="txtFName"
                                    ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    
                    
                    <tr valign="top">
                        <td align="right">
                              <span class="star1">*</span>Last Name: 
                        </td>
                        <td>
                         <asp:TextBox ID="txtLName" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLName" runat="server" Text="*" ControlToValidate="txtFName"
                                ErrorMessage="Last name is required" ForeColor="White"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revLName" runat="server" Text="*" ForeColor="White"
                                    ErrorMessage="Invalid last name,only characters allowed" ControlToValidate="txtLName"
                                    ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                   
                    <tr valign="top">
                       <td align="right">
                              <span class="star1">*</span>Your Email: 
                        </td>
                        <td>
                         <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ControlToValidate="txtEmail"
                                ErrorMessage="Your email is required" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                        
                    </tr>
                    <tr>
                    <td></td>
                        <td  align="left" style="padding-left: 15px;">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="buttonUser" OnClick="btnSubmit_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
         </table>         
         </asp:Panel>
         <asp:Panel ID="pnlSuccuss" runat="server" Visible="false">
         <table>
         <tr>
            <td height="10px">
            </td>
        </tr>
         <tr>
            <td align="left">
             <asp:ImageButton ID="imgBack1" runat="server" ImageUrl="images/back.gif" 
                onclick="imgBack1_Click" />
            </td>
        </tr>
        <tr>
            <td height="10px">
            </td>
        </tr>
         <tr>
         <td class="formTextUSer">
         The email address entered is connected to the following customer:&nbsp;<strong><asp:Label ID="lblUserName" runat="server"></asp:Label></strong>
         
         </td>
         
         </tr>
          <tr>
            <td height="10px">
            </td>
        </tr>
         <tr>
         <td class="formTextUSer">
         If this is correct, click <strong>NEXT</strong>. If this is not correct, please check the email you entered and try again.
         </td>
         </tr>
       <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
        <td align="left">
       
       
        <asp:ImageButton ID="imgNext" runat="server" ImageUrl="images/next.gif" 
                onclick="imgNext_Click" />
                 
        
        </td>
        </tr>
         
         </table>
         
         </asp:Panel>
         
         <asp:Panel ID="pnlFailed" runat="server" Visible="false">
         
         <table>
         <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td  class="ErrorTxt1" align="left">
            The person's information you entered is not in our database.
            </td>
        </tr>
         <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td  class="formTextUSer">
            This may have occurred for the following reasons:
            </td>
        </tr>
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td  class="formTextUSer">
            <li><strong>They have not yet signed up</strong>

		<br />We have just sent an email to the address you specified asking them to sign up! For security reasons, they must be a member for you to deposit money into their account. If they are not yet signed up, you may want to contact them and let them know they need to be signed up before you can deposit money into their account.</li>
            </td>
        </tr>
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td  class="formTextUSer">
            <li><strong>They may have signed up with a different email address</strong>

		<br />They may have signed up with their school email address, or another one you are unaware of. Please check with them to make sure you have their correct email address and try again.
            </td>
        </tr>
         <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td  class="formTextUSer">
            <li><strong>The email was entered incorrectly</strong>

		<br />If you think it may be incorrect, simply click back and re-enter the email correctly.</li>
		<br />
		
		 <asp:ImageButton ID="imgBack" runat="server" ImageUrl="images/back.gif" 
                onclick="imgBack_Click"  />
		
            </td>
        </tr>
         <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td  class="formTextUSer">
           
		If you are still having problems, please  <a href="ContactUsPage.aspx" class="linkNew1">contact us</a>  for help..
            </td>
        </tr>
         
         </table>
         
         </asp:Panel>
        
        </td>
        </tr>
    </table>
   
  </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
