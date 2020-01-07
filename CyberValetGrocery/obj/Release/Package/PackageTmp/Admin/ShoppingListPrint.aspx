<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingListPrint.aspx.cs"
    Inherits="CyberValetGrocery.Admin.ShoppingListPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shopping List Print</title>
    <link rel="Stylesheet" href="../CSS/general.css" type="text/css" />
</head>
<body bgcolor="white" onload="javascript:window.print()">
    <form id="form1" runat="server">
    <br />
    <strong class="formText">Shopping List for&nbsp;
        <asp:Label ID="lblDate" runat="server" CssClass="formTextSmall"></asp:Label>&nbsp;
        at&nbsp;
        <asp:Label ID="lblLocation" runat="server" CssClass="formTextSmall"></asp:Label>
    </strong>
    <br />
    <table cellpadding="3" cellspacing="0" border="0">
        <tr valign="top">
            <td width="100" class="formText">
                <strong>Start Time:</strong>
            </td>
            <td width="300" class="formText">
                _____________________
            </td>
        </tr>
        <tr valign="top">
            <td class="formText">
                <strong>End Time:</strong>
            </td>
            <td class="formText">
                _____________________
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <asp:GridView ID="gridShoppingList" runat="server" AutoGenerateColumns="False" Width="600px"
                    CellPadding="0" CellSpacing="0" GridLines="None">
                    <Columns>
                        <asp:TemplateField ItemStyle-VerticalAlign="Top" >
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkShop" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Store"  ItemStyle-VerticalAlign="Top" >
                            <ItemTemplate>
                                <asp:Label ID="lblStore" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty" SortExpression="orderproduct_quantity" ItemStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <asp:Label ID="lblQuentity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_quantity")%>'></asp:Label>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product"  ItemStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <asp:Label ID="lblProductTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category"  ItemStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <asp:Label ID="lblShelfName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Size"  ItemStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <asp:Label ID="lblSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price($)"   ItemStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <asp:Label ID="lblPrice" runat="server" Text='<%# String.Format("{0:0.00}",DataBinder.Eval(Container.DataItem, "orderproduct_price"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                               ______
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                  
                                        <HeaderStyle CssClass="grideheadingNew" ForeColor="#404248" />
                                        <AlternatingRowStyle CssClass="grideAlternatetextNew" />
                                        <RowStyle CssClass="gridetextNew" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            <hr />
            </td>
        </tr>
        <tr>
            <td style="padding-left: 480px;">
                <table>
                    <tr>
                        <td class="formText">
                            <strong>
                                <asp:Label ID="lblTotalText" runat="server" Text="TOTAL:"></asp:Label>
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="lblAmount" runat="server" CssClass="formTextSmall"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
