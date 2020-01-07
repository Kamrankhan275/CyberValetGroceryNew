<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAllOrderDeatilsPrint.aspx.cs"
    Inherits="CyberValetGrocery.Admin.UserAllOrderDeatilsPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../CSS/general.css" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: normal;
            color: #040404;
            height: 66px;
        }
    </style>
</head>
<body bgcolor="white" onload="javascript:window.print()">
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                <asp:DataList id="dtlOrder" runat="server" RepeatDirection="Vertical">
                
                <ItemTemplate>
                
                <asp:Label ID="lblOrd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_id")%>' Visible="false"></asp:Label>
                 <asp:Label ID="lblUid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_id")%>' Visible="false"></asp:Label>
                <p style="page-break-after: always"> 
                 <asp:DataList id="dtlOrderDetail" runat="server" RepeatDirection="Vertical">
                  <ItemTemplate>                
                    <table border="0" cellpadding="3" cellspacing="0" width="500px" >
                        <tr>
                            <td colspan="2" align="center">
                              <img src="../images/logo.jpg" alt="CyberValetGrocery Logo" width="220" height="125" border="0" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="formHeadingText">
                                <strong>Order #: </strong>
                                <asp:Label ID="lblOrderNumber1" runat="server" CssClass="formTextPrint" Text='<%# DataBinder.Eval(Container.DataItem, "orderNum")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr valign="top" class="formTextPrint">
                            <td>
                                <table cellpadding="3" cellspacing="0" border="0">
                                    <tr>
                                        <td align="right">
                                            <strong>Ordered:</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrint" nowrap="nowrap">
                                            <asp:Label ID="lblOrederDate1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderDate")%>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTextPrint" align="right">
                                            <strong>Pickup/Delivery:</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrint"  nowrap="nowrap">
                                             <asp:Label ID="lblDeliveryDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "deliveryDateTime")%>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr valign="top" align="right" class="formTextPrint">
                                        <td nowrap="nowrap">
                                            <strong>Payment method:</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrint">
                                            <asp:Label ID="lblPaymentMethod" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "paymentMethod")%>'></asp:Label><%--<br />--%>
                                          
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <strong>Special Order Instructions?</strong><br />
                                <asp:Label ID="lblSpecialOrInfo1" runat="server" CssClass="formTextSmallPrint" Text='<%# DataBinder.Eval(Container.DataItem, "SpecialOrInfo")%>'></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="formHeadingText">
                            <td>
                                <strong>Customer Information</strong>
                            </td>
                            <td>
                                <strong>Delivery Address</strong>
                            </td>
                        </tr>
                        <tr valign="top" class="formTextPrint">
                            <td width="300">
                                <table cellpadding="3" cellspacing="0" border="0">
                                    <tr>
                                        <td width="120" align="right">
                                            <strong>First Name:</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrint">
                                            <asp:Label ID="lblFName1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FName")%>'>
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <strong>Last Name:</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrint">
                                            <asp:Label ID="lblLName1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LName")%>'>
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <strong>Phone:</strong>
                                        </td>
                                        <td class="formTextSmallPrint">
                                            <asp:Label ID="lblPhone1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Phone")%>'>
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <strong>Phone 2:</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrint">
                                            <asp:Label ID="lblPhone21" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Phone2")%>'>
                                            </asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="300">
                                <table cellpadding="3" cellspacing="0" border="0">
                                    <tr>
                                        <td width="120" align="right">
                                            <strong>Address:</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrint">
                                            <asp:Label ID="lblAddress1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address")%>'>
                                            </asp:Label>
                                            <br />
                                            <asp:Label ID="lblAddress21" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address2")%>'>
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <strong>City, State Zip:</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrint">
                                            <asp:Label ID="lblCity1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "City")%>'> </asp:Label>
                                            ,
                                            <asp:Label ID="lblState1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "State")%>'></asp:Label>
                                            &nbsp;
                                            <asp:Label ID="lblZip1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Zip")%>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                               <asp:GridView ID="gridUserProductList1" runat="server" AutoGenerateColumns="False"
                                    PageSize="5" Width="550" CssClass="gridBorder" CellPadding="0" CellSpacing="0">
                                    <Columns>
                                       
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalProductQty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_quantity")%>'></asp:Label>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Product">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Size">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Price($)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_price")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pagingtext" ForeColor="#FFFFFF" />
                                    <HeaderStyle CssClass="grideheading" ForeColor="#404248" />
                                    <AlternatingRowStyle CssClass="grideAlternatetext" />
                                    <RowStyle CssClass="gridetext" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="right" class="formTextPrint" style="padding-left: 20px;">
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="right">
                                                        <strong>Sub Total($): </strong>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblSubtotal1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "subTotal")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="right">
                                                        <strong>Tax($):</strong>
                                                    </td>
                                                    <td align="left" class="formTextSmallPrint">
                                                        <asp:Label ID="lblTax1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Tax")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="right">
                                                        <strong>Supply Fee($):</strong>
                                                    </td>
                                                    <td align="left" class="formTextSmallPrint">
                                                        <asp:Label ID="lblSodaDeposit1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "sodaDeposit")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="right">
                                                        <strong>Delivery Fee($):</strong>
                                                    </td>
                                                    <td align="left" class="formTextSmallPrint">
                                                        <asp:Label ID="lblDeliveryFee1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "deliveryFee")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="right">
                                                        <strong>Tip($):</strong>
                                                    </td>
                                                    <td align="left" class="formTextSmallPrint">
                                                        <asp:Label ID="lblTips1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "tips")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="right">
                                                        <strong>ORDER TOTAL($):</strong>
                                                    </td>
                                                    <td align="left" class="formTextSmallPrint">
                                                        <asp:Label ID="lblOrderTotal1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderTot")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <strong>Sign:</strong>
                                                    </td>
                                                    <td colspan="2">
                                                        <span class="horizontalLine"></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td class="formTextSmallPrint" colspan="2" nowrap="nowrap">
                                                        I agree to pay the total amount shown above.
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td nowrap="nowrap" style="padding-top: 20px;">
                                            <strong>
                                                <asp:Label ID="lblThankYou1" runat="server" Text="THANK YOU!" CssClass="formTextPrint"></asp:Label></strong>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="2">
                                <strong>Return Details:</strong>&nbsp; We offer store credit for general grocery
                                returns and full refund for perishable returns. You must contact us within 24 hours
                                of delivery to receive a refund for perishables. You must contact us within 48 hours
                                of your delivery to receive credit for groceries. We do not offer refunds after
                                the 48 hour period is over. We reserve the right to withhold refunds and credits
                                until we deem them acceptable.
                            </td>
                        </tr>
                        <tr><td height="30px"></td></tr>
                    </table>
                   <br />
                     </ItemTemplate>
                     
                 </asp:DataList>
                 
                </ItemTemplate>
                            
                       </asp:DataList>
                </td>
            </tr>
           
        </table>
    </div>
    </form>
</body>
</html>
