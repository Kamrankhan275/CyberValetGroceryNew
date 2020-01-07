<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBalanceDetails.aspx.cs"
    Inherits="CyberValetGrocery.Admin.ViewBalanceDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../CSS/general.css" type="text/css" />
</head>
<body bgcolor="white">
    <form id="form1" runat="server">
    <div>
        
            <table >
                <tr>
                    <td height="10px">
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:200px;" >
                    <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td >
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="gridBalanceDetails" runat="server" AutoGenerateColumns="False"
                            PageSize="5" Width="600" OnPageIndexChanging="gridBalanceDetails_PageIndexChanging"
                            CssClass="gridBorder" CellPadding="0" CellSpacing="0" AllowPaging="true">
                            <Columns>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "transactions_date")%>'></asp:Label>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount($)">
                                    <ItemTemplate>
                                       <%-- <asp:Label ID="lblAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "transactions_amount")%>'></asp:Label>--%>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Convert.ToDecimal(Eval("transactions_amount")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Order #">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrdered" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_number")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comments">
                                    <ItemTemplate>
                                        <asp:Label ID="lblComments" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "transactions_comment")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                             <PagerStyle CssClass="pagingtext"   ForeColor="#FFFFFF"   />
                    <HeaderStyle CssClass="grideheading" ForeColor="#404248" />
                    <AlternatingRowStyle CssClass="grideAlternatetext" />
                    <RowStyle CssClass="gridetext" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
       
    </div>
    </form>
</body>
</html>
