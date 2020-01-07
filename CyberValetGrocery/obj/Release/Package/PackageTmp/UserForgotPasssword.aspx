<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="UserForgotPasssword.aspx.cs" Inherits="CyberValetGrocery.UserForgotPasssword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="script1" runat="server" 
></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server"  >
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" border="0" width="580">
        <tr>
            <td height="20px">
            </td>
        </tr>
        <tr>
            <td>
                <span class="formHeading"><strong>Forgot Password</strong></span>
            </td>
        </tr>
        <tr>
            <td height="20px">
            </td>
        </tr>
        <tr>
            <td align="center" class="formTextUSer">
               <center> To send you an email with your password, we need your username (email) to verify 
                your identity.</center>
            </td>
        </tr>
        <tr>
            <td height="20px">
            </td>
        </tr>
        <tr>
            <td align="left" class="formTextUSer">
            <center><table cellpadding="3" cellspacing="0" border="0" >
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
                        <td align="left" >
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1" />
                            <asp:Label ID="lblMsg" CssClass="formTextUSer" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>Username(email):
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Text="*" ControlToValidate="txtEmail"
                                ErrorMessage="Username(email) is required" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                    <tr>
                    <td></td>
                        <td  align="left" style="padding-left:5px;">
                            <asp:Button ID="btnSend" runat="server" Text="Send Email" CssClass="buttonUser" OnClick="btnSend_Click" />
                        </td>
                    </tr>
                </table></center>
            </td>
        </tr>
        <tr>
        <td height="20px">
        
        </td>
        </tr>
        <tr>
        <td align="center" class="formTextUSer">
      
        </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
