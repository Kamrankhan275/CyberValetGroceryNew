﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserOrderDeatilsPrint.aspx.cs"
    Inherits="CyberValetGrocery.Admin.UserOrderDeatilsPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../CSS/general.css" type="text/css" />
 <link href="../Css/Print.css" rel="stylesheet" type="text/css" />
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
<body bgcolor="white"  onload="javascript:window.print()">
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="3" cellspacing="0" width="500px">
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
                    <asp:Label ID="lblOrderNumber" runat="server" CssClass="formTextPrint"></asp:Label>
                </td>
            </tr>
            <tr valign="top" class="formTextPrint">
                <td width="300">
                    <table cellpadding="3" cellspacing="0" border="0">
                        <tr>
                            <td align="right" class="formTextPrint" valign="top">
                                <strong>Ordered:</strong>
                            </td>
                            <td align="left" class="formTextSmallPrint" nowrap="nowrap">
                                <asp:Label ID="lblOrederDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextPrint" align="right" valign="top">
                                <strong>Pickup/Delivery:</strong>
                            </td>
                            <td align="left" class="formTextSmallPrint" nowrap="nowrap">
                                <asp:Label ID="lblDeliveryDateTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr valign="top" align="right" class="formTextPrint">
                            <td nowrap="nowrap">
                                <strong>Payment method:</strong>
                            </td>
                            <td align="left" class="formTextSmallPrint" nowrap="nowrap">
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
                <td class="formTextPrint">
                <table cellpadding="3" cellspacing="0" border="0">
                        <tr>
                            <td align="right" class="formTextPrint" valign="top">
                              <strong>Special Order Instructions?</strong>  
                            </td>
                            <td align="left" class="formTextSmallPrint" >
                            <asp:Label ID="lblSpecialOrInfo" runat="server" CssClass="formTextSmallPrint"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextPrint" align="right" valign="top">
                                <strong>Company Name:</strong>
                            </td>
                            <td align="left" class="formTextSmallPrint" nowrap="nowrap">
                                <asp:Label ID="lblCompName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr valign="top" align="right" class="formTextPrint">
                            <td nowrap="nowrap">
                                <strong>Phone:</strong>
                            </td>
                            <td align="left" class="formTextSmallPrint" nowrap="nowrap">
                                <asp:Label ID="lblConfirmPhone" runat="server"></asp:Label><%--<br />
							<asp:Label ID="lblCreditInfo" runat="server"></asp:Label>--%>
                            </td>
                        </tr>
                    </table>
                    
                    
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
                <td>
                    <table cellpadding="3" cellspacing="0" border="0">
                        <tr>
                            <td width="120" align="right">
                                <strong>First Name:</strong>
                            </td>
                            <td align="left" class="formTextSmallPrint">
                                <asp:Label ID="lblFName" runat="server" >
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>Last Name:</strong>
                            </td>
                            <td align="left" class="formTextSmallPrint">
                                <asp:Label ID="lblLName" runat="server" >
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>Phone:</strong>
                            </td>
                            <td class="formTextSmallPrint">
                                <asp:Label ID="lblPhone" runat="server" >
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>Phone 2:</strong>
                            </td>
                            <td align="left" class="formTextSmallPrint">
                                <asp:Label ID="lblPhone2" runat="server" >
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
                                <asp:Label ID="lblAddress" runat="server" >
                                </asp:Label>
                                <br />
                                <asp:Label ID="lblAddress2" runat="server" >
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>City, State Zip:</strong>
                            </td>
                            <td align="left" class="formTextSmallPrint">
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
                                    <%--<asp:Label ID="lblProductPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_price")%>'></asp:Label>--%>
                                    <asp:Label ID="lblProductPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_price")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="pagingtext" ForeColor="#FFFFFF" />
                        <HeaderStyle CssClass="grideheading" ForeColor="#404248" />
                        <AlternatingRowStyle CssClass="grideAlternatetext" />
                        <RowStyle CssClass="gridetext" />
                    </asp:GridView>
                    <span style="padding-left:80px;">
                    <asp:Label ID="lblMsg1" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label></span>
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
                                            <asp:Label ID="lblSubtotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <strong>Tax($):</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrint">
                                            <asp:Label ID="lblTax" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <strong>Supply Fee($):</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrint">
                                            <asp:Label ID="lblSodaDeposit" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <strong>Pickup/Delivery Fee($):</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrint">
                                            <asp:Label ID="lblDeliveryFee" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <strong>Tip($):</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrint">
                                            <asp:Label ID="lblTips" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <strong>ORDER TOTAL($):</strong>
                                        </td>
                                        <td align="left" class="formTextSmallPrint">
                                            <asp:Label ID="lblOrderTotal" runat="server"></asp:Label>
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
                                    <asp:Label ID="lblThankYou" runat="server" Text="THANK YOU!" CssClass="formTextPrint"></asp:Label></strong>
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
        </table>
    </div>
    </form>
</body>
</html>
