  <%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="UpdatePhoneInfo.aspx.cs" Inherits="CyberValetGrocery.UpdatePhoneInfo" %>
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
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-left:10px;">
       
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td align="left"  class="formHeading">
          <strong> Update Phone </strong>
            </td>
        </tr>
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td align="left" class="formTextUSer">
           Please use the form below to update your phone number(s): 
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
                        <td  align="left"   nowrap="nowrap" >
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                            <asp:Label ID="lblMsg" CssClass="formTextUSer" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="right">
                          <span class="star1">*</span>Primary Phone Number:
                          <br />
                          <span class="formTextSmall1">(111-111-1111)</span>
                           
                        </td>
                        <td>
                             <asp:TextBox ID="txtPhone1" runat="server" CssClass="textbox1" MaxLength="12"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" Text="*" ControlToValidate="txtPhone1"
                                ErrorMessage="Primary phone number is required" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                     <tr valign="top">
                        <td align="right">
                             Secondary  Phone Number:
                              <br />
                          <span class="formTextSmall1">(111-111-1111)</span>
                        </td>
                        <td>
                           <asp:TextBox ID="txtPhone2" runat="server" CssClass="textbox1" MaxLength="12"></asp:TextBox>
                        </td>
                    </tr>
                   
                       <tr><td height="10px">&nbsp;</td></tr>
                    
                    <tr>
                    <td></td>
                        <td  align="left" style="padding-left:5px;" >
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="buttonUser" OnClick="btnUpdate_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
       <tr><td height="80px">&nbsp;</td></tr>
        
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
