<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliverySchedulePrint.aspx.cs" Inherits="CyberValetGrocery.Admin.DeliverySchedulePrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Delivery Schedule Print</title>
    <link rel="Stylesheet" href="../CSS/general.css" type="text/css" />
</head>
<body bgcolor="white" onLoad="javascript:window.print()">
    <form id="form1" runat="server">
    <div>
    <table>
    
    <tr>
    <td>
    <strong>Deliveries for:<asp:Label ID="lblDate" runat="server"></asp:Label> </strong>
    </td>
    </tr>
    
    <tr>
    <td>
    &nbsp;
    </td>
    </tr>
    <tr>
    <td>
    <asp:GridView ID="gridDeliveryList" runat="server" AutoGenerateColumns="False" Width="600px"
                  
                      CellPadding="0" CellSpacing="0"   GridLines="None" >
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblDeliveryId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Order #" >
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNum" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_number")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Customer" >
                            <ItemTemplate>
                                <asp:Label ID="lblCustomer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "customer")%>'></asp:Label>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        
                         <asp:TemplateField HeaderText="Time"   >
                            <ItemTemplate>
                             <asp:Label ID="lblTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_deliverytime")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address" >
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_address")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                       
                        
                        <asp:TemplateField HeaderText="Groceries($)" >
                            <ItemTemplate>
                           
                               <asp:Label ID="lblGroceries" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_grocerytotal")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delivery($)" >
                            <ItemTemplate>
                           
                               <asp:Label ID="lblDelivery" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_deliveryfee")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tax($)" >
                            <ItemTemplate>
                            
                               <asp:Label ID="lblTax" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_tax")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tip($)" >
                            <ItemTemplate>
                              <asp:Label ID="lblTip" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_tip")%>'></asp:Label>
                              <%-- <span class="horizontalLine"></span>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total($)" >
                            <ItemTemplate>
                             
                                <asp:Label ID="lblTotal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_totalfinal")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                      
                        
                         
                        
                       
                        
                        
                    </Columns>
                    
                    <HeaderStyle CssClass="grideheading" />
                    <AlternatingRowStyle CssClass="gridetext" />
                    <RowStyle CssClass="gridetext" />
                </asp:GridView>
    </td>
    </tr>
    <tr>
    <td>
    
    </td>
    </tr>
    
    </table>
    
	
					

					
    </div>
    </form>
</body>
</html>
