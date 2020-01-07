<%@ Page Title="" Language="C#" MasterPageFile="~/UserLoginMasterPage.Master" AutoEventWireup="true"
    CodeBehind="OrderConfirmation.aspx.cs" Inherits="CyberValetGrocery.OrderConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td align="center">
                        <table cellpadding="0" cellspacing="0" border="0" width="80%" style="padding-left: 10px;">
                            <tr>
                                <td height="20px">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="formHeading" style="padding-left: 50px;">
                                    <strong>Order Confirmation</strong> <span style="padding-left: 400px;"><a href='OrderPrint.aspx?orderId=<%=Request.QueryString["orderId"]%>'
                                        target="_blank">
                                        <img src="images/printButton.jpg" border="0" />
                                    </a></span>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr valign="top">
                                            <td width="135" style="padding-left: 50px;">
                                                <img src="images/checkout_2.gif" alt="confirm delivery address" width="135" height="37"
                                                    border="0" />
                                            </td>
                                            <td width="122">
                                                <img src="images/checkout_1.gif" alt="pick a delivery time" width="122" height="37"
                                                    border="0" />
                                            </td>
                                            <td width="131">
                                                <img src="images/checkout_3.gif" alt="tip the delivery driver" width="131" height="37"
                                                    border="0" />
                                            </td>
                                            <td width="109">
                                                <img src="images/checkout_4.gif" alt="payment method" width="109" height="37" border="0" />
                                            </td>
                                            <td width="103">
                                                <img src="images/checkout_5c.gif" alt="complete order" width="103" height="37" border="0" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="20px">
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextUSer" style="padding-left: 50px;">
                                    <strong>Congratulations!</strong> You have just placed an order with&nbsp;<asp:Label 
                                        ID="lblCmpNm" runat="server"></asp:Label>
                                    &nbsp;. The details of your order are provided below.<br />
                                    We want to thank you for choosing &nbsp;<asp:Label ID="lblCmpNm1" runat="server"></asp:Label>
                                    , we will do our very best to provide exceptional service at all times.
                              </td>
                            </tr>
                            <tr>
                                <td height="20px">
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 50px;">
                                    <table border="0" cellpadding="3" cellspacing="0" class="tableBorder">
                                        <tr>
                                            <td colspan="2" class="formHeadingText">
                                                <strong>Order #: </strong><asp:Label ID="lblOrderNumber" runat="server" CssClass="formHeadingText" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr valign="top" class="formTextUSer">
                                            <td width="400">
                                                <table cellpadding="3" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="right">
                                                            <strong>Ordered:</strong>
                                                        </td>
                                                        <td align="left" class="formTextUSer">
                                                            <asp:Label ID="lblOrederDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <strong>Pickup/Delivery:</strong>
                                                        </td>
                                                        <td align="left" class="formTextUSer">
                                                            <asp:Label ID="lblDeliveryDateTime" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr valign="top" align="right">
                                                        <td>
                                                            <strong>Payment method:</strong>
                                                        </td>
                                                        <td align="left" class="formTextUSer">
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
                                            <td width="300">
                                                <strong>Special Order Instructions?</strong><br />
                                                <asp:Label ID="lblSpecialOrInfo" runat="server" CssClass="formTextUSer"></asp:Label>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr class="formHeadingText">
                                            <td class="formHeadingText">
                                                <strong>Customer Information</strong>
                                            </td>
                                            <td>
                                                <strong>Delivery Address</strong>
                                            </td>
                                        </tr>
                                        <tr valign="top" class="formTextUSer">
                                            <td width="300">
                                                <table cellpadding="3" cellspacing="0" border="0">
                                                    <tr>
                                                        <td width="120" align="right">
                                                            <strong>First Name:</strong>
                                                        </td>
                                                        <td align="left" class="formTextUSer">
                                                            <asp:Label ID="lblFName" runat="server"> </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <strong>Last Name:</strong>
                                                        </td>
                                                        <td align="left" class="formTextUSer">
                                                            <asp:Label ID="lblLName" runat="server"> </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <strong>Phone:</strong>
                                                        </td>
                                                        <td class="formTextUSer">
                                                            <asp:Label ID="lblPhone" runat="server"> </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <strong>Phone 2:</strong>
                                                        </td>
                                                        <td align="left" class="formTextUSer">
                                                            <asp:Label ID="lblPhone2" runat="server"> </asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="300">
                                                <table cellpadding="3" cellspacing="0" border="0">
                                                    <tr>
                                                        <td width="120" align="right" valign="top">
                                                            <strong>Address:</strong>
                                                        </td>
                                                        <td align="left" class="formTextUSer">
                                                            <asp:Label ID="lblAddress" runat="server"> </asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblAddress2" runat="server"> </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="top">
                                                            <strong>City, State Zip:</strong>
                                                        </td>
                                                        <td align="left" class="formTextUSer">
                                                            <asp:Label ID="lblCity" runat="server"></asp:Label>
                                                            ,
                                                            <asp:Label ID="lblState" runat="server"></asp:Label>
                                                            &nbsp;
                                                            <asp:Label ID="lblZip" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td align="right" valign="top">
                                                            <strong>Rental Company Name:</strong>
                                                        </td>
                                                    <td align="left" class="formTextUSer">
                                                            <asp:Label ID="lblRentalCompanyName" runat="server"></asp:Label>
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
                                                    PageSize="5" Width="600" CssClass="gridBorder" CellPadding="0" CellSpacing="0"
                                                    GridLines="None">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalProductQty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_quantity")%>'></asp:Label>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Product" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
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
                                                                <%--<asp:Label ID="lblProductPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_price")%>'></asp:Label>--%>
                                                                <asp:Label ID="lblProductPrice" runat="server" Text='<%# Convert.ToDecimal(Eval("orderproduct_price")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                                
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle CssClass="pagingUsertext" ForeColor="#FFFFFF" />
                                                    <HeaderStyle CssClass="gridUserheading" ForeColor="#404248" />
                                                    <AlternatingRowStyle CssClass="gridUserAlternatetext" />
                                                    <RowStyle CssClass="gridUsertext" />
                                                </asp:GridView>
                                                <span style="padding-left: 80px;">
                                                    <asp:Label ID="lblMsg1" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right" style="padding-right: 100px;">
                                                <table class="formTextUSer">
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
                                                        <td align="left" class="formTextUSer">
                                                            <asp:Label ID="lblTax" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="right">
                                                            <strong>Supply Fee($):</strong>
                                                        </td>
                                                        <td align="left" class="formTextUSer">
                                                            <asp:Label ID="lblSodaDeposit" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="right">
                                                            <strong>Delivery Fee($):</strong>
                                                        </td>
                                                        <td align="left" class="formTextUSer">
                                                            <asp:Label ID="lblDeliveryFee" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="right">
                                                            <strong>Tip($):</strong>
                                                        </td>
                                                        <td align="left" class="formTextUSer">
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
                                                        <td align="left" class="formTextUSer">
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
                                <td height="10px">
                                </td>
                            </tr>
                            </tr>
                             <tr>
                                <td height="2px">
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextUSer" >
                                    Thank you again for choosing <asp:Label ID="lblCmpNm2" runat="server" CssClass="formTextUSer"></asp:Label>,
                                </td>
                            </tr>
                            <tr>
                                <td height="5px">
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextUSer" >
                                    <strong>Respectfully,</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextUSer" >
                                    The&nbsp;<asp:Label ID="lblCmpNm3" runat="server" CssClass="formTextUSer"></asp:Label>&nbsp;Team
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
