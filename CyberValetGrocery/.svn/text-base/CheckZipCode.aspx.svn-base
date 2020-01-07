<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="CheckZipCode.aspx.cs" Inherits="CyberValetGrocery.CheckZipCode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function clcontent() {
            var lb1 = document.getElementById("<%= lblMsg.ClientID %>");
            lb1.innerHTML = "";
        }
    </script>
    
    <asp:ScriptManager ID="script1" runat="server" 
></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server"  >
    <ContentTemplate>
<table cellpadding="0" cellspacing="0" border="0" width="580" style="padding-left:5px;">
       
        <tr>
            <td height="20px">
            </td>
        </tr>
        <tr>
            <td align="center" class="formHeading">
            <center>Find out if we are delivering to you! </center>
            </td>
        </tr>
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td align="center" class="formTextUSer">
              <center>Please enter your ZIP Code and click &quot;Go&quot; </center>

            </td>
        </tr>
        <tr>
            <td height="20px">
            </td>
        </tr>
        <tr>
            <td align="center"  style="padding-left:10px;" >
                <table cellpadding="3" cellspacing="0" border="0" class="border"  width="340px" bgcolor="#F5F5F5">
                    <tr>
                        <td colspan="3"  class="formTextUSer" align="center">
                           <center>Field with a <span class="star1">*</span> are required</center>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3" style="padding-left:80px;" class="formTextUSer">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1" />
                            <asp:Label ID="lblMsg" CssClass="formTextUSer" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="right" class="formTextUSer">
                            <span class="star1">*</span>Zip Code:
                        </td>
                        <td class="formTextUSer">
                            <asp:TextBox ID="txtZipCode" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvZip" runat="server" Text="*" ControlToValidate="txtZipCode"
                                ErrorMessage="Zip code is required" ForeColor="White"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="reqZip" runat="server" ControlToValidate="txtZipCode"
                                ErrorMessage="Invalid zip code,exactly  five digits allowed" Text="*" ValidationExpression="\d{5}" ForeColor="White"></asp:RegularExpressionValidator>
                        </td>
                        <td style="padding-left:5px;" >
                           
                            <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="buttonUser" OnClick="btnGo_Click" />
                        </td>
                    </tr>
                    
                   <tr valign="top">
                   <td colspan="3" height="20px">
                   
                   </td>
                   </tr>
                </table>
            </td>
        </tr>
        <tr>
        <td height="3px">
        
        </td>
        </tr>
        <tr>
        <td align="center" >
        <span class="formTextUSer">
         Already a customer?&nbsp;<a href="LoginPage.aspx" class="Userlink1">Click here to log in.</a>  
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            </span>

        </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
