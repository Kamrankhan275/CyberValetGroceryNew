<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="My_Account.aspx.cs" Inherits="CyberValetGrocery.My_Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
  
<asp:ScriptManager ID="script1" runat="server" 
></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server"  >
    <ContentTemplate>
    <table  cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-left: 10px;">


 <tr>
            <td align="left" class="formHeading">
               My Account
            </td>
        </tr>
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr><td align="left" class="formTextUSer">
      We're sorry, but you must be &nbsp; <a href="LoginPage.aspx" class="Userlink1"> logged </a> &nbsp; in to access your account information.


        </td></tr>
        
        <tr>
            <td height="10px">
            </td>
        </tr>

<tr>

<td align="left" class="formTextUSer">
If you have not registered yet, you may &nbsp; <a href="CheckZipCode.aspx" class="Userlink1"> register here.</a> &nbsp;

</td>

</tr>
<tr>
            <td height="250px">
            </td>
        </tr>

</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
