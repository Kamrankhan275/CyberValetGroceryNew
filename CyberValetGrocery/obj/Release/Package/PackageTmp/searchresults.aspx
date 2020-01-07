<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="searchresults.aspx.cs" Inherits="CyberValetGrocery.searchresults" %>

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
            <table border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="formHeading">
                        Search
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <asp:Panel ID="pnlNoresult" runat="server">
                            <table>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextUSer">
                                        <strong>Products that matched your search for&nbsp;<asp:Label ID="lblKey" runat="server"
                                            CssClass="ErrorTxt1"></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ErrorTxt1">
                                        There are no products that match your search.
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextUSer">
                                        Please feel free to &nbsp; <a id="A1" href="SuggestProduct.aspx" runat="server" class="Userlink1">
                                            suggest</a>&nbsp; that we add this item to our store.
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextUSer">
                                        <strong>In your search you also might want to:</strong>
                                        <ul>
                                            <li>Use more general terms<br />
                                                <br />
                                            </li>
                                            <li>Double check your spelling<br />
                                                <br />
                                            </li>
                                            <li>Avoid using plurals<br />
                                                <em>"Egg" instead of "Eggs"</em><br />
                                                <br />
                                            </li>
                                            <li>Use only the first 3 or 4 letters<br />
                                                <em>"fries" instead of "french fries"</em></li>
                                        </ul>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextUSer">
                                        <strong>Product Search by Keyword:</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5px">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextUSer">
                                        Searches all product & brand names and product descriptions.
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5px">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextUSer">
                                        <table>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblErrMsg" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtNewSearch" runat="server" CssClass="textbox1"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="buttonUser" OnClick="btnSearch_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formTextUSer" valign="top">
                        <asp:Panel ID="pnlSearchResult1" runat="server">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextUSer">
                                        <strong>Aisles that matched your search for &nbsp;<asp:Label ID="lblSearch" runat="server"
                                            CssClass="star1"></asp:Label>&nbsp; :</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gridSearchResult" runat="server" AutoGenerateColumns="False" Width="620px"
                                            GridLines="None" AllowPaging="true" PageSize="10" OnPageIndexChanging="gridSearchResult_PageIndexChanging"
                                            CellPadding="0" CellSpacing="0" AllowSorting="True" OnSorting="gridSearchResult_Sorting">
                                            <Columns>
                                                <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblShelfId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_id")%>'></asp:Label>
                                                        <asp:Label ID="lblAisleId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "aisle_id")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Shelf Name" SortExpression="shelf_name" ControlStyle-Width="400" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblShelfName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_name")%>'></asp:Label>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <a href="products.aspx?shelf=<%# DataBinder.Eval(Container.DataItem, "shelf_id")%>&aisle=<%# DataBinder.Eval(Container.DataItem, "aisle_id")%> &aisletop=<%# DataBinder.Eval(Container.DataItem, "aisletop_id")%>" 
                                                            class="linkNew1">
                                                            <asp:Label ID="lblView" runat="server" Text="View Aisle"></asp:Label>
                                                        </a>
                                                    </ItemTemplate>
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
                    <td align="left" class="formTextUSer">
                        <asp:Panel ID="pnlSearchRes" runat="server">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextUSer">
                                        <strong>Products that matched your search for &nbsp;<asp:Label ID="lblSerKey" runat="server"
                                            CssClass="star1"></asp:Label>&nbsp; :</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMsg1" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gridProductList" runat="server" AutoGenerateColumns="False" Width="620px"
                                            AllowPaging="true" OnPageIndexChanging="gridProductList_PageIndexChanging" GridLines="None"
                                            CellPadding="0" CellSpacing="0" AllowSorting="True" OnSorting="gridProductList_Sorting"
                                            OnRowCommand="gridProductList_OnRowCommand" 
                                             PageSize="20">
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
                                                <asp:TemplateField HeaderText="Image" ItemStyle-Height="45" ItemStyle-Width="45" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>                                                        
                                                      
                                                        <asp:Panel ID="pnlImg2" runat="server">
                                                        <a href="#" onclick='openProductDetailsPopUp(<%# DataBinder.Eval(Container.DataItem, "product_id")%>)'>
                                                            <asp:Image ID="imgProduct" runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>' />
                                                        </a>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnlNoImg" runat="server">
                                                         <asp:Image ID="Image1" runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>' />
                                                        </asp:Panel>
                                                        
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
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
                                               
                                                <asp:TemplateField HeaderText="Price($)" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                         <asp:Panel ID="pnlPrice" runat="server">
                                                       <asp:Label ID="lblPreSalePrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_presale")%>' CssClass="productcrossed"></asp:Label>
                                                       <br />  </asp:Panel>                                                  
                                                        <asp:Label ID="lblPrice" runat="server" Text='<%# Convert.ToDecimal(Eval("productlink_price")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'>
                                                                        </asp:Label>   
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty">
                                                    <ItemTemplate>
                                                    <asp:Panel ID="pnlSearchQtyErr" runat="server" Visible="false">
                                                        <asp:Label ID="lblErrQty" runat="server" CssClass="ErrorTxtNew1" Visible="false"> </asp:Label><br />
                                                        </asp:Panel>
                                                        <asp:TextBox ID="txtQty" runat="server" CssClass="textboxSmallNew" MaxLength="3" Text="1"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Add" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="images/AddIcon.png" Width="16"
                                                            Height="16" border="0" CommandName="AddQty" CommandArgument='<%# Eval("product_id") %>'
                                                            CausesValidation="false" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <a href="products.aspx?shelf=<%# DataBinder.Eval(Container.DataItem, "shelf_id")%>&aisle=<%# DataBinder.Eval(Container.DataItem, "aisle_id")%> &aisletop=<%# DataBinder.Eval(Container.DataItem, "aisletop_id")%>" 
                                                            class="linkNew1">
                                                            <asp:Label ID="lblView" runat="server" Text="view more"></asp:Label>
                                                        </a>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
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
                    <td height="20px">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
