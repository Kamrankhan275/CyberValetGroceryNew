<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="viewallpast.aspx.cs" Inherits="CyberValetGrocery.viewallpast" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server" 
></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server"  >
    <ContentTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
 <tr>
 <td>
 </td>
 </tr>
        <tr>
            <td class="formHeading" align="left">
             View Past Orders
            </td>
        </tr>
        <tr>
            <td>
                
                <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
            </td>
        </tr>
          <tr><td height="20px">&nbsp;</td></tr>
        <tr>
            <td class="formTextUSer"  align="left" style="padding-left:20px;">
                
                          
                             
                
              <asp:Label ID="lblErrMsg" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                    
                                      
                    
                 
                    <asp:GridView ID="gridOrderList" runat="server" AutoGenerateColumns="False" Width="580px"
                    AllowPaging="true" OnPageIndexChanging="gridOrderList_PageIndexChanging" GridLines="None"
                       CellPadding="0" CellSpacing="0"  AllowSorting="True" onsorting="gridOrderList_Sorting" PageSize="10"  >
                    <Columns>
                        <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        
                         
                          <asp:TemplateField HeaderText="Order #" SortExpression="orders_number" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                           
                                <asp:Label ID="lblOrderNm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_number")%>'></asp:Label>
                             
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Order Date" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ordDate")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                      
                        <asp:TemplateField HeaderText="Delivery Date" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "delDate")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Amount($)" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                            <%--<asp:Label ID="lblAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_totalfinal")%>'> </asp:Label>--%>
                            <asp:Label ID="lblAmount" runat="server" Text='<%# Convert.ToDecimal(Eval("orders_totalfinal")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'> </asp:Label>
                               
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        
                        <asp:TemplateField HeaderText="Details">
                            <ItemTemplate >
                                <a href='orderdetails.aspx?chk=1&orderId=<%# DataBinder.Eval(Container.DataItem, "orders_id")%>' class="linkNew1">
                                Details
                                </a>          
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                       
                        
                    </Columns>
                  <PagerStyle CssClass="pagingUsertext"   ForeColor="#FFFFFF"/>
                   
                    <HeaderStyle CssClass="gridUserheading" ForeColor="#404248" />
                    <AlternatingRowStyle CssClass="gridUserAlternatetext" />
                    <RowStyle CssClass="gridUsertext" />
                </asp:GridView>
                    
                    
                    
             
                 
                    
                 
                
               
                            
                      
            </td>
        </tr>
        <tr><td height="160px">&nbsp;</td></tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
