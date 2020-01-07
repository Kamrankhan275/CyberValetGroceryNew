<%@ Page Title="Shopping List" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewShoppingListDetail.aspx.cs" Inherits="CyberValetGrocery.Admin.ViewShoppingListDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="JavaScript1.2">showHide("sitefunctions");</script>
 <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager> 
   
  <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding-left:20px;">
        <tr>
            <td class="Logoutlink">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="Logoutlink">
                Shopping List
            </td>
        </tr>
        <tr>
            <td class="Logoutlink">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="Logoutlink">
               <strong class="formText">Shopping List for&nbsp;
        <asp:Label ID="lblDate" runat="server" CssClass="formTextSmall"></asp:Label>&nbsp;
        at&nbsp;
        <asp:Label ID="lblLocation" runat="server" CssClass="formTextSmall"></asp:Label>
    </strong> </td>
        </tr>
        <tr>
            <td align="right">
                <table>
                    <tr>
                        <td>
                            
                             <asp:ImageButton ID="imgBtnPrint" runat="server" ImageUrl="../images/printButton.jpg"
                                 border="0"  CausesValidation="false" onclick="imgBtnPrint_Click"  />
                                
                         <%--   <a href="ShoppingListPrint.aspx" target="_blank">
                                <img src="../images/printButton.jpg" border="0" />
                            </a>--%>
                        </td>
                        <td align="right" style="padding-right: 200px;">
                            <asp:ImageButton ID="imgBack1" runat="server" ImageUrl="../images/backbutton.jpg"
                                Width="71" Height="23" border="0" OnClick="imgBack1_Click" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-left:50px;">
                <asp:Label ID="lblMsg" CssClass="ErrorTxt" runat="server"></asp:Label>
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td align="left" class="formText">
                <table width="721" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="721" >
                            <asp:UpdatePanel ID="update1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gridShoppingList" runat="server" AutoGenerateColumns="False" Width="600px"
                                        AllowPaging="true" PageSize="10" OnPageIndexChanging="gridShoppingList_PageIndexChanging"
                                        CssClass="gridBorder" CellPadding="0" CellSpacing="0" AllowSorting="True" OnSorting="gridShoppingList_Sorting">
                                        <Columns>
                                           <asp:TemplateField HeaderText="Shelf_Mapping" SortExpression="shelf_position">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShelfmap" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_position")%>'></asp:Label>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          
                                            <asp:TemplateField HeaderText="Qty" SortExpression="orderproduct_quantity" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQuentity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_quantity")%>'></asp:Label>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product" SortExpression="product_title">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProductTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Category" SortExpression="shelf_name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShelfName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Size">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Price($)">
                                                <ItemTemplate>
                                                    $<%--<asp:Label ID="lblPrice" runat="server" Text='<%# String.Format("{0:0.00}", DataBinder.Eval(Container.DataItem, "orderproduct_price"))%>'></asp:Label>--%>
                                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Convert.ToDecimal(Eval("orderproduct_price")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                                                                                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pagingtext" ForeColor="#FFFFFF" />
                                        <HeaderStyle CssClass="grideheading" ForeColor="#404248" />
                                        <AlternatingRowStyle CssClass="grideAlternatetext" />
                                        <RowStyle CssClass="gridetext" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 490px;">
                            <table>
                                <tr>
                                    <td class="formText">
                                       
                                       <strong>  <asp:Label ID="lblTotalText" runat="server" Text="TOTAL:"></asp:Label>
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
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 200px;">
            <asp:Button ID="btnExcel" runat="server" Text="Convert To Excel" CssClass="button" 
                    onclick="btnExcel_Click"  />
               <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0" OnClick="imgBack_Click" CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 200px;">
                
            </td>
        </tr>
    </table>
  


</asp:Content>
