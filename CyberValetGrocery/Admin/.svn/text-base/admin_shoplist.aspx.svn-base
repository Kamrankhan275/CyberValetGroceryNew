<%@ Page Title=" Shopping List" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="admin_shoplist.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_shoplist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="JavaScript1.2">showHide("sitefunctions");</script>
 <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager> 
   
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="Logoutlink">&nbsp;</td>
              </tr>
              <tr>
                <td class="Logoutlink">
                
               Shopping List
                
                 </td>
              </tr>
              <tr>
                <td class="Logoutlink">
                
                    &nbsp;</td>
              </tr>
             <tr>
            <td>
                <asp:Label ID="lblMsg" CssClass="formText" runat="server"></asp:Label>
            </td>
        </tr>
              <tr>
                <td align="left" class="formText">
                <table width="721" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td width="721">
                     <asp:UpdatePanel ID="update1" runat="server">
    <ContentTemplate>
                    <asp:GridView ID="gridDeliveryDateShoopingList" runat="server" AutoGenerateColumns="False" Width="600px"
                    AllowPaging="true" PageSize="10" OnPageIndexChanging="gridDeliveryDateShoopingList_PageIndexChanging"
                       CssClass="gridBorder"  CellPadding="0" CellSpacing="0"  AllowSorting="True" onsorting="gridDeliveryDateShoopingList_Sorting" >
                    <Columns>
                       
                        <asp:TemplateField HeaderText="Delivery Date" SortExpression="deliverydate_date">
                            <ItemTemplate>
                                    <asp:Label ID="Date" CssClass="lbl" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "deliverydate_date")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Location" >
                            <ItemTemplate>
                                <asp:Label ID="lblLocation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "location_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Details">
                            <ItemTemplate>
                                <a href='ViewShoppingListDetail.aspx?deliveryId=<%# DataBinder.Eval(Container.DataItem, "deliverydate_date")%>' >
                                   
                                    <img src="../images/view-icon.jpg" width="18" height="21" border="0" />
                              </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                     <PagerStyle CssClass="pagingtext"   ForeColor="#FFFFFF"   />
                    <HeaderStyle CssClass="grideheading" ForeColor="#404248" />
                    <AlternatingRowStyle CssClass="grideAlternatetext" />
                    <RowStyle CssClass="gridetext" />
                </asp:GridView>
                    
                    
                     </ContentTemplate>
     </asp:UpdatePanel>
                    
                    
                    </td>
                  </tr>
                 
                </table></td>
              </tr>
              <tr>
              <td height="15px">
              
              </td>
              </tr>
                
              
            </table>
     
    

</asp:Content>
