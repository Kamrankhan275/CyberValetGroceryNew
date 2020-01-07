<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewProductdDetails.aspx.cs" Inherits="CyberValetGrocery.Admin.ViewProductdDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script language="javascript" type="text/javascript">
     function confirmsubmit() {
         if (confirm("You are about to delete the data, please confirm?") == true) {
             return true;
         }
         else {
             return false;
         }
     }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="JavaScript1.2">showHide("sitefunctions");</script>
 <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager> 
    
 <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="Logoutlink">&nbsp;</td>
              </tr>
              <tr>
                <td class="Logoutlink">
                
               Product Administration 
                 </td>
              </tr>
              
              <tr>
                   
                    <td align="right" style="padding-right:200px;">
                  
                    <asp:ImageButton ID="imgBack1" runat="server"  ImageUrl="../images/backbutton.jpg" 
                            width="71" height="23" border="0" onclick="imgBack1_Click" CausesValidation="false" />
                 
                    </td>
                  </tr>
                  
                 <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-left:50px;">
              <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
              <tr>
                <td align="left" class="formText">
                <table width="721" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td width="721">
                    <asp:UpdatePanel ID="update1" runat="server">
    <ContentTemplate>
                      <asp:GridView ID="gridProductList" runat="server" AutoGenerateColumns="False" Width="750px"
                    AllowPaging="true" OnPageIndexChanging="gridProductList_PageIndexChanging"
                     CssClass="gridBorder"  CellPadding="0" CellSpacing="0"  AllowSorting="True" onsorting="gridProductList_Sorting" OnRowCommand="gridProductList_OnRowCommand" >
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblProductId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                         <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblAsileId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "aisle_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                         <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblShelfId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Image" ItemStyle-Height="45px" ItemStyle-VerticalAlign="Middle"   >
                            <ItemTemplate>
                             <asp:Image ID="imgProduct"  runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>'  />
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Title" SortExpression="product_title">
                            <ItemTemplate>
                                <asp:Label ID="lblTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Location" >
                            <ItemTemplate>
                                <asp:Label ID="lblLocation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "location_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                      
                        <asp:TemplateField HeaderText="Price($)" >
                            <ItemTemplate>
                                <%--<asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_price")%>'></asp:Label>--%>
                                <asp:Label ID="lblPrice" runat="server" Text='<%# Convert.ToDecimal(Eval("productlink_price")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Per Sale($)" >
                            <ItemTemplate>
                                <asp:Label ID="lblPerSale" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_presale")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Buy Price($)" >
                            <ItemTemplate>
                                <%--<asp:Label ID="lblBuyPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_buyprice")%>'></asp:Label>--%>
                                 <asp:Label ID="lblBuyPrice" runat="server" Text='<%# Convert.ToDecimal(Eval("productlink_buyprice")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate >
                                <a href='EditProduct.aspx?productId=<%# DataBinder.Eval(Container.DataItem, "product_id")%>&shf=<%# DataBinder.Eval(Container.DataItem, "shelf_id")%>&asileId=<%# DataBinder.Eval(Container.DataItem, "aisle_id")%>&loc=<%=Request.QueryString["loc"]%>&shefId=<%=Request.QueryString["shefId"]%>&strKey=<%=Request.QueryString["strKey"] %>&perPage=<%=Request.QueryString["perPage"]%>'>
                                   <img src="../images/gtk-edit.png" width="18" height="18"  border="0"/>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" runat="server"   ImageUrl="../images/delete.png" width="18" height="18"  border="0" CommandName="DeleteProduct"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "product_id")%>'  OnClientClick="return confirmsubmit();" />
                               
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <PagerStyle CssClass="pagingtext"   ForeColor="#FFFFFF"   />
                    <HeaderStyle CssClass="grideheading" ForeColor="#404248" />
                    <AlternatingRowStyle CssClass="grideAlternatetext" />
                    <RowStyle CssClass="gridetext" />
                </asp:GridView>
                    
                    
                    </ContentTemplate>
  </asp:UpdatePanel>
                    
                    
                    </td>
                  </tr>
                 
                </table></td>
              </tr>
              <tr>
              <td height="15px">
              
              </td>
              </tr>
                <tr>
                   
                    <td align="right" style="padding-right:200px;">
                  
                    <asp:ImageButton ID="imgBack" runat="server"  ImageUrl="../images/backbutton.jpg" 
                            width="71" height="23" border="0" onclick="imgBack_Click" CausesValidation="false" />
                 
                    </td>
                  </tr>
              
            </table>
  
</asp:Content>
