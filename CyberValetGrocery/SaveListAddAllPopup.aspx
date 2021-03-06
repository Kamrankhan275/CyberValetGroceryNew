﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaveListAddAllPopup.aspx.cs"
    Inherits="CyberValetGrocery.SaveListAddAllPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="CSS/UserSide.css" type="text/css" />
</head>
<body bgcolor="white">
    <form id="form1" runat="server">
     <asp:ScriptManager ID="script1" runat="server" 
></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server"  >
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="formHeading" style="padding-left: 10px;">
                <asp:Label ID="lblListNm" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="lblCartEmpty" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-left:10px;">
                <asp:GridView ID="gridShopList" runat="server" AutoGenerateColumns="False" Width="630px"
                    GridLines="None" CellPadding="0" CellSpacing="0" AllowPaging="true" 
                    PageSize="17" OnPageIndexChanging="gridShopList_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblShopProductId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_id")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Image" ItemStyle-Height="45" ItemStyle-Width="45" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Image ID="imgShopProduct" runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Height="45px" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Name" SortExpression="product_title" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblShopTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Size" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblShopSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price($)" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <%--<asp:Label ID="lblShopPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_price")%>'></asp:Label>--%>
                                <asp:Label ID="lblShopPrice" runat="server" Text='<%# Convert.ToDecimal(Eval("productlink_price")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblShopQty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Qty")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagingUsertext" ForeColor="#FFFFFF" />
                    <HeaderStyle CssClass="gridUserheading" ForeColor="#404248" />
                    <AlternatingRowStyle CssClass="gridUserAlternatetext" />
                    <RowStyle CssClass="gridUsertext" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td  valign="top" align="right" style="padding-right: 5px;">
                <asp:Panel ID="Panel1" runat="server">
                
                <table class="formTextUSer">
                    <tr>
                        <td style="padding-left: 2px;" align="right">
                            <strong>
                                <asp:Label ID="lblSubTot" runat="server" Text="Sub Total:"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 2px;">
                            <asp:Label ID="lblSign" runat="server" Text="$"></asp:Label>
                            <asp:Label ID="lblSubTotVal" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>
                                <asp:Label ID="lblTax" runat="server" Text="Tax"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 2px;">
                            <asp:Label ID="lblSign1" runat="server" Text="$"></asp:Label>
                            <asp:Label ID="lblTaxVal" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>
                                <asp:Label ID="lblDeliveryFee" runat="server" Text="Delivery Fee"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 2px;">
                            <asp:Label ID="lblSign2" runat="server" Text="$"></asp:Label>
                            <asp:Label ID="lblDeliveryFeeTot" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>
                                <asp:Label ID="lblSodaFee" runat="server" Text="Supply Fee"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 2px;">
                            <asp:Label ID="lblSodaSign" runat="server" Text="$"></asp:Label>
                            <asp:Label ID="lblSodaDepFeeTot" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <span class="horizontalLine1"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>
                                <asp:Label ID="lblTot" runat="server" Text="Total"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 2px;">
                            <asp:Label ID="lblSign3" runat="server" Text="$"></asp:Label>
                            <asp:Label ID="lblTotVal" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
