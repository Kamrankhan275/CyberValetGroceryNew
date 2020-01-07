<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="products.aspx.cs" Inherits="CyberValetGrocery.products" %>

<%@ Register Src="~/cart.ascx" TagName="UserScript" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script language="javascript" type="text/javascript">
        function alertError() {
            alert("Please make sure your quantity is a number.");

        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
       
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" style="padding-left: 10px;">
                        <a href="Shop.aspx" class="Userlink1">All Aisles</a>&nbsp;
                        <asp:Label ID="lblArrow" runat="server" Text=">"></asp:Label>&nbsp;
                         <a href='shelf.aspx?aisle=<%=Request.QueryString["aisletop"] %>' class="Userlink1">
                            <asp:Label ID="lblAisleName" runat="server"></asp:Label></a>&nbsp;
                        <asp:Label ID="lblArrow1" runat="server" Text=">"></asp:Label>&nbsp;
                        <asp:Label ID="lblShelfName" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formHeading" style="padding-left: 10px;" >
                        <asp:Label ID="lblShelfName1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 50px;">
                        <asp:Label ID="lblMsg1" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                        <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" width="100%" valign="top">
                        <table>
                            <tr>
                                <td valign="top" width="80%">
                                    <table width="540" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="530" valign="top">
                                                <asp:Panel ID="pnlPopProd" runat="server">
                                                    <table>
                                                        <tr>
                                                            <td class="formTextUSer">
                                                                <strong>Most Popular Items List</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gridPopProdList" runat="server" AutoGenerateColumns="False" Width="530px"
                                                                    AllowPaging="true" OnPageIndexChanging="gridPopProdList_PageIndexChanging" CellPadding="0"
                                                                    CellSpacing="0" AllowSorting="True" OnSorting="gridPopProdList_Sorting" OnRowCommand="gridPopProdList_OnRowCommand"
                                                                    GridLines="None" PageSize="20">
                                                                    <Columns>
                                                                        <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPopProductId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_id")%>'></asp:Label>
                                                                                <asp:Label ID="lblPopProductImage2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_image2")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPopAsileId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "aisle_id")%>'></asp:Label>
                                                                                <asp:Label ID="lblPopProdDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_description")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPopShelfId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_id")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Image" ItemStyle-Height="45" ItemStyle-Width="45"
                                                                            HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <%--<asp:Panel ID="pnlPopImg2" runat="server">
                            <a href="javascript:void();" class="jkimagelarge" title='/Product/<%#Eval("product_image2")%>'  onmouseover="doTooltip(event,0)" onmouseout="hideTip()"  >
                             <asp:Image ID="imgPopProduct2"  runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>'  />
                             </a>
                             </asp:Panel>
                            
                            <asp:Panel ID="pnlPopNoImg" runat="server">
                            <a href="javascript:void();" class="jkimagelarge" title='/Product/<%#Eval("product_image")%>'  onmouseover="doTooltip(event,0)" onmouseout="hideTip()"  >
                            <asp:Image ID="imgPopProduct"  runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>'  />
                             </a>
                             </asp:Panel>--%>
                                                                                <asp:Panel ID="pnlPopImg2" runat="server">
                                                                                    <a href="#" onclick='openProductDetailsPopUp(<%# DataBinder.Eval(Container.DataItem, "product_id")%>)'>
                                                                                        <asp:Image ID="imgPopProduct2" runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>' />
                                                                                    </a>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="pnlPopNoImg" runat="server">
                                                                                    <asp:Image ID="imgPopProduct" runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>' />
                                                                                </asp:Panel>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle Height="45px" Width="45px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Product Name" SortExpression="product_title" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Panel ID="pnlPopDescImg2" runat="server">
                                                                                    <a href="#" onclick='openProductDetailsPopUp(<%# DataBinder.Eval(Container.DataItem, "product_id")%>)'
                                                                                        class="ProdLink1">
                                                                                        <asp:Label ID="lblPopTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                                                                    </a>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="PnlPopNoDescImg" runat="server">
                                                                                    <asp:Label ID="lblPopTitle1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                                                                </asp:Panel>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Size" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPopSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Price($)" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                 <asp:Panel ID="pnlPopPrice" runat="server">
                                                                               <asp:Label ID="lblPopPreSalePrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_presale")%>' CssClass="productcrossed"></asp:Label>
                                                                              <br /></asp:Panel>
                                                                               <asp:Label ID="lblPopPrice" runat="server" Text='<%# Convert.ToDecimal(Eval("productlink_price")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                                                
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Qty" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Panel ID="pnlPopQtyErr" runat="server" Visible="false">
                                                                                    <asp:Label ID="lblErrQty" runat="server" CssClass="ErrorTxtNew1" Visible="false"> </asp:Label><br />
                                                                                </asp:Panel>
                                                                                <asp:TextBox ID="txtPopQty" runat="server" CssClass="textboxSmallNew" MaxLength="3" Text="1"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Add" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btnPopAdd" runat="server" ImageUrl="images/AddIcon.png" Width="16"
                                                                                    Height="16" border="0" CommandName="AddPopQty" CommandArgument='<%# Eval("product_id") %>'
                                                                                    CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        
                                                                         <asp:TemplateField HeaderText="Save List" ItemStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btnSavePopAdd" runat="server" ImageUrl="images/saveList-img.png" Width="15"
                                                                                    Height="16" border="0" CommandName="SavePopAddQty" CommandArgument='<%# Eval("product_id") %>'
                                                                                    CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" />
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
                                                            <td height="10px">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlAllProd" runat="server">
                                                    <table>
                                                        <tr>
                                                            <td class="formTextUSer">
                                                                <strong>All Items List</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gridProductList" runat="server" AutoGenerateColumns="False" Width="530px"
                                                                    AllowPaging="true" OnPageIndexChanging="gridProductList_PageIndexChanging" GridLines="None"
                                                                    CellPadding="0" CellSpacing="0" AllowSorting="True" OnSorting="gridProductList_Sorting"
                                                                    OnRowCommand="gridProductList_OnRowCommand" PageSize="20">
                                                                    <Columns>
                                                                        <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblProductId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_id")%>'></asp:Label>
                                                                                <asp:Label ID="lblProductImage2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_image2")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAsileId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "aisle_id")%>'></asp:Label>
                                                                                <asp:Label ID="lblProdDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_description")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblShelfId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_id")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Image" ItemStyle-Height="45" ItemStyle-Width="45">
                                                                            <ItemTemplate>
                                                                                <asp:Panel ID="pnlImg2" runat="server">
                                                                                    <a href="#" onclick='openProductDetailsPopUp(<%# DataBinder.Eval(Container.DataItem, "product_id")%>)'>
                                                                                        <asp:Image ID="imgProduct2" runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>' />
                                                                                    </a>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="pnlNoImg" runat="server">
                                                                                    <asp:Image ID="imgProduct" runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>' />
                                                                                </asp:Panel>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Height="45px" Width="45px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Product Name" SortExpression="product_title" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Panel ID="pnlDescImg2" runat="server">
                                                                                    <a href="#" onclick='openProductDetailsPopUp(<%# DataBinder.Eval(Container.DataItem, "product_id")%>)'
                                                                                        class="ProdLink1">
                                                                                        <asp:Label ID="lblTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                                                                    </a>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="PnlNoDescImg" runat="server">
                                                                                    <asp:Label ID="lblTitle1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                                                                </asp:Panel>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Size" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Price($)" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                             <asp:Panel ID="pnlPrice" runat="server">
                                                                               <asp:Label ID="lblPreSalePrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_presale")%>' CssClass="productcrossed"></asp:Label>
                                                                                   <br />
                                                                                   </asp:Panel>
                                                                                <asp:Label ID="lblPrice" runat="server" Text='<%# Convert.ToDecimal(Eval("productlink_price")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                                                
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Qty" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Panel ID="pnlQtyErr" runat="server" Visible="false">
                                                                                    <asp:Label ID="lblErrQty1" runat="server" CssClass="ErrorTxtNew1" Visible="false"> </asp:Label><br />
                                                                                </asp:Panel>
                                                                                <asp:TextBox ID="txtQty" runat="server" CssClass="textboxSmallNew" MaxLength="3" Text="1"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Add" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="images/AddIcon.png" Width="16"
                                                                                    Height="16" border="0" CommandName="AddQty" CommandArgument='<%# Eval("product_id") %>'
                                                                                    CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        
                                                                          <asp:TemplateField HeaderText="Save List" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btnSavePopAdd" runat="server" ImageUrl="images/saveList-img.png" Width="15"
                                                                                    Height="16" border="0" CommandName="SavePopAddQty" CommandArgument='<%# Eval("product_id") %>'
                                                                                    CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        
                                                                    </Columns>
                                                                    <PagerStyle CssClass="pagingUsertext" ForeColor="#FFFFFF" />
                                                                    <HeaderStyle CssClass="gridUserheading" ForeColor="#404248" />
                                                                    <AlternatingRowStyle CssClass="gridUserAlternatetext" />
                                                                    <RowStyle CssClass="gridUsertext" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px;">
                                                <asp:Button ID="btnContinue" runat="server" CssClass="buttonUser" Text="Continue Shopping"
                                                    OnClick="btnContinue_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top" align="left" style="padding-left: 2px;" width="20%">
                                    <uc1:UserScript ID="UserScript1" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
