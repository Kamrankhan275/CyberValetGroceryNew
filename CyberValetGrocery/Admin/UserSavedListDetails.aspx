<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSavedListDetails.aspx.cs" Inherits="CyberValetGrocery.Admin.UserSavedListDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <link rel="Stylesheet" href="../CSS/general.css" type="text/css" />
    
</head>
<body bgcolor="white">
    <form id="form1" runat="server">
    <div>
   
            <table style="vertical-align:middle;" >
               <tr>
                    <td height="10px">
                    </td>
                </tr>
                
                <tr>
                    <td colspan="3" >
                        <asp:GridView ID="gridSavedListDetails" runat="server" AutoGenerateColumns="False"
                            Width="600px" AllowPaging="true" PageSize="5" OnPageIndexChanging="gridSavedListDetails_PageIndexChanging"
                            CellPadding="0" CellSpacing="0"    CssClass="gridBorder">
                            <Columns>
                          
                        
                        <asp:TemplateField HeaderText="Image" ItemStyle-Height="45px" ItemStyle-VerticalAlign="Middle"   >
                            <ItemTemplate>
                             <asp:Image ID="imgProduct"  runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>'  />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Product Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProduct" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Size">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuantity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "listlink_qty")%>'></asp:Label>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                               
                                <asp:TemplateField HeaderText="Price($)">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_price")%>'></asp:Label>--%>
                                        <asp:Label ID="lblPrice" runat="server" Text='<%# Convert.ToDecimal(Eval("productlink_price")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                             <PagerStyle CssClass="pagingtext"   ForeColor="#FFFFFF"   />
                    <HeaderStyle CssClass="grideheading" ForeColor="#404248" />
                    <AlternatingRowStyle CssClass="grideAlternatetext" />
                    <RowStyle CssClass="gridetext" />
                        </asp:GridView>
                        <span style="padding-left:250px;"><asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 490px;">
                        <strong  class="formText">
                        <asp:Label ID="lblSubTot" runat="server" Text="SubTotal:"></asp:Label>
                        </strong>&nbsp;<asp:Label ID="lblTotal" runat="server" CssClass="formTextSmall"></asp:Label>
                    </td>
                </tr>
                
            </table>
       
    </div>
    </form>
</body>
</html>
