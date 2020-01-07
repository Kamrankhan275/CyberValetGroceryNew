<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="CyberValetGrocery.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
        function clcontent() {
            var lb1 = document.getElementById("<%= lblMsg.ClientID %>");
            lb1.innerHTML = "";
        }


    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="script1" runat="server" 
></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server"  >
    <ContentTemplate>
   
    <table cellpadding="0" cellspacing="0" border="0" width="580">
       
        <tr>
            <td class="formHeading">
                <strong>Log In</strong>
            </td>
        </tr>
        <tr>
            <td height="20px">
            </td>
        </tr>
        <tr>
            <td align="center" class="formTextUSer">
               <center> Please enter your <asp:Label ID="lblCompanyNm" runat="server"></asp:Label>&nbsp;
                username and password below to login:</center>
            </td>
        </tr>
        <tr>
            <td height="20px">
            </td>
        </tr>
        <tr>
            <td align="center"  >
                <table cellpadding="3" cellspacing="0" border="0" class="formTextUSer">
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
                        <td></td>
                        <td align="left"  >
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1" ValidationGroup="loginpage" />
                            
                        </td>
                    </tr>
                    <tr>
                    <td colspan="2" align="left">
                    <asp:Label ID="lblMsg" CssClass="ErrorTxtNew2" runat="server"></asp:Label>
                    </td>
                    </tr>
                    
                    <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>Username(email):
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Text="*" ControlToValidate="txtEmail"
                                ErrorMessage="Username(email) is required" ForeColor="White" ValidationGroup="loginpage"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>Password:
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox1" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPAssword" runat="server" Text="*" ControlToValidate="txtPassword"
                                ErrorMessage="Password is required" ForeColor="White" ValidationGroup="loginpage"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                    <td></td>
                        <td style="padding-left:5px;"  >
                           
                            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="buttonUser" 
                                OnClick="btnLogin_Click" ValidationGroup="loginpage" 
                                CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        <td height="20px">
        
        </td>
        </tr>
        <tr>
        <td align="center" >
        <table cellpadding="4" cellspacing="0" border="0"  class="border">

<tr bgcolor="#F5F5F5" valign="top">

	<td width="200" class="formTextUSer">
		<strong>Become a Member</strong><br />
		Not a member? Click below to become a member now!
		<p /><a href="CheckZipCode.aspx" class="Userlink1" ><strong>Register Now!</strong></a>
	</td>

	<td width="30" align="center" class="formTextUSer">
	</td>

	<td width="200" class="formTextUSer">
		<strong>Forgot Your Password?</strong><br />
		Have you lost or forgotten your account password? Click below to retrieve it.
		<br /><a href="UserForgotPasssword.aspx" class="Userlink1"><strong>Retrieve Password</strong></a>
	</td>

</tr>

</table>
        </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
