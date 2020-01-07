<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="LoyaltyProgram.aspx.cs" Inherits="CyberValetGrocery.LoyaltyProgram" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<asp:ScriptManager ID="script1" runat="server" 
></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server"  >
    <ContentTemplate>
    <table>
        <tr>
            <td  class="formHeading">
                Loyalty Program
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="formTextUSer" style="padding-right:20px;">
            
               At <asp:Label ID="lblCompanyNm" runat="server"></asp:Label> we value our loyal customers.  To show our appreciation we give free Account Funds to customers that place repeat orders.  For every 5 orders under $100, you will receive $5 dollars in free Account Funds.  For every 5 orders over $100, we will add $10 dollars into your Account.
            </td>
        </tr>
        <tr>
            <td>
            
            </td>
        </tr>
        <tr>
            <td>
               <center><img src="images/loyalty_diagram_Loy.gif" alt="loyalty program" width="326" height="155" border="0" /></center>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="formTextUSer">
                <strong>How it’s Tracked</strong>                      
            </td>
        </tr>
        <tr>
            <td class="formTextUSer" style="padding-right:20px;">
            Your orders are tracked
		 automatically for you and can be viewed anytime in the <a href="My_Account.aspx" class="Userlink1">My Account</a> section of our website.  Once you complete either level of our loyalty program, we will deposit the respective amount into your Account.

            </td>
        </tr>
         <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="formTextUSer" style="padding-right:20px;">
                
                   <strong>Start shopping today and earn your FREE GROCERY FUNDS!</strong>
            </td>
        </tr>
          <tr><td height="10px">&nbsp;</td></tr>
        <tr>
            <td style="padding-left:225px;"  >
                <asp:Button ID="btnShopping" runat="server" CssClass="buttonUser" 
                    Text="Start shopping" onclick="btnShopping_Click" />
            </td>
        </tr>
        <tr><td height="10px">&nbsp;</td></tr>
    </table>

</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
