<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPrint.aspx.cs" Inherits="CyberValetGrocery.OrderPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title></title>
    <link rel="Stylesheet" href="CSS/UserSide.css" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 60px;
        }
        .style3
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-weight: normal;
            color: #040404;
            width: 164px;
        }
    </style>
</head>
<body  onload="javascript:window.print()">
    <form id="form1" runat="server">
    <div>
       <table border="0" cellpadding="3" cellspacing="0" width="500px">
        <tr>
                <td colspan="2" align="center">
                 <img src="images/logo.jpg" alt="CyberValetGrocery Logo" width="220" height="125" border="0" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
       <tr>
            <td class="formTextPrintUser" colspan="2">
                <strong>Congratulations!</strong> You have just placed an order with&nbsp;Cyber Valet Grocery&nbsp;. The details of your order are provided below.<br />
                                    Thank you for choosing to shop with The Cyber Valet Grocery.  We always do our very best to provide exceptional service at all times.
            </td>
        </tr>
            
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="formHeadingText">
                    <strong>Order #: </strong>
                    <asp:Label ID="lblOrderNumber" runat="server" CssClass="formTextPrintUser" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr valign="top" class="formTextPrintUser">
                <td width="300">
                    <table cellpadding="3" cellspacing="0" border="0">
                        <tr>
                            <td align="right" class="formTextPrintUser" valign="top">
                                <strong>Ordered:</strong>
                            </td>
                            <td align="left" class="formTextSmallPrintUser" nowrap="nowrap">
                                <asp:Label ID="lblOrederDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextPrintUser" align="right" valign="top">
                                <strong>Pickup/Delivery:</strong>
                            </td>
                            <td align="left" class="formTextSmallPrintUser" nowrap="nowrap">
                                <asp:Label ID="lblDeliveryDateTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr valign="top" align="right" class="formTextPrintUser">
                            <td nowrap="nowrap">
                                <strong>Payment method:</strong>
                            </td>
                            <td align="left" class="formTextSmallPrintUser" nowrap="nowrap">
                                <asp:Label ID="lblPaymentMethod" runat="server"></asp:Label><%--<br />
							<asp:Label ID="lblCreditInfo" runat="server"></asp:Label>--%>
                            </td>
                        </tr>
                        <tr valign="top" align="right">
                            <td>
                                <strong>Store Location:</strong>
                            </td>
                            <td align="left" class="formTextUSer">
                                <asp:Label ID="lblStoreLocation" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="formTextPrintUser">
                    <strong>Special Order Instructions?</strong><br />
                    <asp:Label ID="lblSpecialOrInfo" runat="server" CssClass="formTextSmallPrintUser"></asp:Label>
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
            <tr valign="top" class="formTextPrintUser">
                <td>
                    <table cellpadding="3" cellspacing="0" border="0">
                        <tr>
                            <td width="120" align="right">
                                <strong>First Name:</strong>
                            </td>
                            <td align="left" class="formTextSmallPrintUser">
                                <asp:Label ID="lblFName" runat="server" >
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>Last Name:</strong>
                            </td>
                            <td align="left" class="formTextSmallPrintUser">
                                <asp:Label ID="lblLName" runat="server" >
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>Phone:</strong>
                            </td>
                            <td class="formTextSmallPrintUser">
                                <asp:Label ID="lblPhone" runat="server" >
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>Phone 2:</strong>
                            </td>
                            <td align="left" class="formTextSmallPrintUser">
                                <asp:Label ID="lblPhone2" runat="server" >
                                </asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="300">
                    <table cellpadding="3" cellspacing="0" border="0">
                        <tr>
                            <td align="right" valign="top" class="style2">
                                <strong>Address:</strong>
                            </td>
                            <td align="left" class="style3">
                                <asp:Label ID="lblAddress" runat="server" >
                                </asp:Label>
                                <br />
                                <asp:Label ID="lblAddress2" runat="server" >
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top" class="style2">
                                <strong>City, State Zip:</strong>
                            </td>
                            <td align="left" class="style3">
                                <asp:Label ID="lblCity" runat="server" ></asp:Label>
                                ,
                                <asp:Label ID="lblState" runat="server" ></asp:Label>
                                &nbsp;
                                <asp:Label ID="lblZip" runat="server" ></asp:Label>
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
                    <asp:GridView ID="gridUserProductList" runat="server" AutoGenerateColumns="False"
                        Width="550"  CellPadding="0" CellSpacing="0" GridLines="None">
                        <Columns>
                                    <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalProductQty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_quantity")%>'></asp:Label>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                        <asp:Label ID="lblProdId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_id")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblProductName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Size" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price($)" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                           <%-- <asp:Label ID="lblProductPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_price")%>'></asp:Label>--%>
                                            <asp:Label ID="lblProductPrice" runat="server" Text='<%# Convert.ToDecimal(Eval("orderproduct_price")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                        
                                <HeaderStyle CssClass="gridUserheading" ForeColor="#404248" />
                                <AlternatingRowStyle CssClass="gridUserAlternatetext" />
                                <RowStyle CssClass="gridUsertext" />
                    </asp:GridView>
                    <span style="padding-left:80px;">
                    <asp:Label ID="lblMsg1" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label></span>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="right" class="formTextPrintUser" style="padding-left: 20px;">
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
                                            <asp:Label ID="lblSubtotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <strong>Tax($):</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrintUser">
                                            <asp:Label ID="lblTax" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <strong>Supply Fee($):</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrintUser">
                                            <asp:Label ID="lblSodaDeposit" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <strong>Delivery Fee($):</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrintUser">
                                            <asp:Label ID="lblDeliveryFee" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <strong>Tip($):</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrintUser">
                                            <asp:Label ID="lblTips" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                      <tr>
                                    <td>
                                    </td>
                                    <td colspan="2">
                                        <hr size="-1" color="#000000" />
                                    </td>
                                </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <strong>ORDER TOTAL($):</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrintUser">
                                            <asp:Label ID="lblOrderTotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                                                    </table>
                            </td>
                            
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
            <td height="2px">
            </td>
        </tr>
        <%--<tr>
            <td class="formTextPrintUser" colspan="2">
                <strong>Be sure to be at your delivery address during the time you chose. </strong>
            </td>
        </tr>
        <tr>
            <td height="2px">
            </td>
        </tr>--%>
        <tr>
            <td class="formTextPrintUser" colspan="2">
                 Thank you again for choosing Cyber Valet Grocery,
            </td>
        </tr>
        <tr>
            <td height="2px">
            </td>
        </tr>
        <tr>
            <td class="formTextPrintUser" colspan="2">
              <strong>  Sincerely,</strong>
            </td>
        </tr>
        <tr>
            <td class="formTextPrintUser" colspan="2" style="padding-left: 5px;">
              The Cyber Valet Grocery Team
            </td>
        </tr>
        <tr><td height="10px">&nbsp;</td></tr>
        </table>
    </div>
    </form>
</body>
</html>
