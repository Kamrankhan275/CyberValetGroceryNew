<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="AddNonDeliveryZone.aspx.cs" Inherits="CyberValetGrocery.AddNonDeliveryZone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="script1" runat="server"> 
</asp:ScriptManager>
   <asp:UpdatePanel ID="updatePnl1" runat="server"  >
    <ContentTemplate>
   <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-left:10px;">
       
        <tr>
            <td height="20px">
            </td>
        </tr>
        <tr>
            <td align="left"  class="formHeading">
          We're sorry, delivery is not yet available in your area. 
            </td>
        </tr>
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td align="left" class="formTextUSer">
             Please give us your email address and we will contact you when we begin delivery
              in your area. 



            </td>
        </tr>
        <tr>
            <td height="20px">
            </td>
        </tr>
        <tr>
            <td align="left" class="formTextUSer" style="padding-left:10px;">
                <table cellpadding="3" cellspacing="0" border="0" >
                    <tr>
                        <td colspan="2" align="center" class="formTextUSer">
                            Field with a <span class="star1">*</span> are required
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="padding-left:80px;">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1" />
                            <asp:Label ID="lblMsg" CssClass="formTextUSer" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>Name: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvZip" runat="server" Text="*" ControlToValidate="txtName"
                                ErrorMessage="Name is required" ForeColor="White"></asp:RequiredFieldValidator>
                                
                        </td>
                    </tr>
                    
                     <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>Email: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Text="*" ControlToValidate="txtEmail"
                                ErrorMessage="Email is required" ForeColor="White"></asp:RequiredFieldValidator>
                                     
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>Zip Code: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtZipCode" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ControlToValidate="txtZipCode"
                                ErrorMessage="Zip code is required" ForeColor="White"></asp:RequiredFieldValidator>
                               <%-- <asp:RegularExpressionValidator ID="reqZip" runat="server" ControlToValidate="txtZipCode"
                                ErrorMessage="Invalid zip code,exactly  five digits allowed" Text="*" ValidationExpression="\d{5}" ForeColor="White"></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    
                    
                    <tr>
                    <td></td>
                        <td  align="left" style="padding-left:15px;">
                            <asp:Button ID="btnSend" runat="server" Text="Submit" CssClass="buttonUser" OnClick="btnSend_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
       
        
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
