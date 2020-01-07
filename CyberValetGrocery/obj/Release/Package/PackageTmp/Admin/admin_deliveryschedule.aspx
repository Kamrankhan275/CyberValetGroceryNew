<%@ Page Title="Delivery Schedules" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="admin_deliveryschedule.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_deliveryschedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script language="JavaScript1.2">showHide("sitefunctions");</script>
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
               <tr>
                <td height="10px"></td>
              </tr>
              <tr>
                <td><fieldset>
            <legend>Delivery Schedules </legend>
            
            
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="30" class="formText" nowrap="nowrap">
                Choose a location first, and then a delivery date to view a schedule for that day.


                </td>
              </tr>
              <tr><td height="3px">&nbsp;</td></tr>
               <tr>
                            <td width="46%" align="left" colspan="2" class="FieldTextSearch">
                                Field with a <span class="star">*</span> are required
                            </td>
                        </tr>
                        
                        <tr>
                            <td width="46%" align="left" colspan="2" style="padding-left: 125px">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                            </td>
                        </tr>
              <tr>
                <td height="40"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td align="right">&nbsp;</td>
                    <td>&nbsp;</td>
                  </tr>
                  
                  <tr>
                    <td align="right" class="formText"> <span class="star">*</span> Location:</td>
                    <td height="40" >
                      <asp:DropDownList ID="drpLocation" runat="server" CssClass="DropDownBox">
					<asp:ListItem Value="Select">Select</asp:ListItem>
				<asp:ListItem value="1" >Bozeman</asp:ListItem>
				
				</asp:DropDownList>
				  <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ControlToValidate="drpLocation"
                    ErrorMessage="Select location" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                  </td>
                  </tr> 
                  <tr>
                    <td width="20%" align="right" class="formText" nowrap="nowrap"><span class="star">*</span>Delivery Date:</td>
                    <td width="80%">
                    <asp:DropDownList ID="drpDeliveryDate" runat="server"  CssClass="DropDownBox">
					<asp:ListItem Value="Select">Select</asp:ListItem>
					<asp:ListItem Value="1">5/3/2010</asp:ListItem>
					<asp:ListItem Value="2">4/30/2010</asp:ListItem>	
					<asp:ListItem Value="3">4/28/2010</asp:ListItem>				
					</asp:DropDownList>
					<asp:RequiredFieldValidator ID="rfvDelivery" runat="server" ControlToValidate="drpDeliveryDate"
                    ErrorMessage="Select delivery date" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                    
                    </td>
                  </tr>
                  <tr>
                    <td align="right">&nbsp;</td>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td align="right">&nbsp;</td>
                    <td style="padding-left:10px;">
                   
                     <asp:Button ID="btnView" runat="server" Text="View Schedule" CssClass="button" OnClick="btnView_Click" />
                    </td>
                  </tr>
                </table></td>
              </tr>
              
              
              
              
               
            </table>
         
            </fieldset></td>
              </tr>
              
               
            
            </table>
</asp:Content>
