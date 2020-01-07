<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewProductdDetailsexport.aspx.cs" Inherits="CyberValetGrocery.Admin.ViewProductdDetailsexport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
              <asp:Label ID="lblMsgError" runat="server" CssClass="ErrorTxt" Visible="false" Text="Please select the .csv file"></asp:Label>
            </td>
          
        </tr>
        <tr>
            <td style="padding-left:50px;">
              <asp:Label ID="lblMsg" runat="server" CssClass="formText" Visible="false"></asp:Label>
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
                        
                        <%-- <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblAsileId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "aisle_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        
                        
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
                   <%--      <asp:TemplateField HeaderText="UPC">
                            <ItemTemplate>
                                <asp:Label ID="lblUPC" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_upc")%>'></asp:Label>
                                </a>
                            </ItemTemplate>
                            </asp:TemplateField>--%>
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
                        
                        <asp:TemplateField HeaderText="Pre Sale($)" >
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
                        
                 <asp:TemplateField HeaderText="Product Size">
                            <ItemTemplate >
                                <asp:Label ID="lblSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                  <%--     <asp:TemplateField HeaderText="Product Desc">
                            <ItemTemplate>
                             <asp:Label ID="lblDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "description") %>'></asp:Label>
                               
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        
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
               <%-- <tr>
                   
                    <td align="right" style="padding-right:200px;">
                  
                    <asp:ImageButton ID="imgBack" runat="server"  ImageUrl="../images/backbutton.jpg" 
                            width="71" height="23" border="0" onclick="imgBack_Click" CausesValidation="false" />
                 
                    </td>
                  </tr>--%>
                <tr>
                   
                    <td align="left" style="padding-right:200px;">
                  <asp:Button ID="btnExcel" runat="server" Text="Download CSV" CssClass="button" onclick="btnExcel_Click" />
                        <table>
                            <tr>
                                <td>
                                    <asp:FileUpload ID="fileUploadCsv" runat="server" />
                                </td>
                                <td>
                                    <asp:Button ID="BtnUploadCsv" runat="server" OnClick="BtnUploadCsv_Click" Text="Upload CSV"
                                        CssClass="button" />
                                </td>
                                <td width="500px">
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../images/backbutton.jpg"
                                        Width="71" Height="23" border="0" OnClick="imgBack_Click" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                   
                    </td>
             
                  </tr>
         
            </table>
</asp:Content>
