<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewSalesInformation.aspx.cs" Inherits="CyberValetGrocery.Admin.ViewSalesInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script language="javascript" type="text/javascript">
     function confirmsubmit() {
         if (confirm("You are about to update the data, please confirm?") == true) {
             return true;
         }
         else {
             return false;
         }
     }

     function confirmHide() {
         if (confirm("You are about to make prdouct status unsale, please confirm?") == true) {
             return true;
         }
         else {
             return false;
         }
     }

     function confirmUnhide() {
         if (confirm("You are about to make prdouct status sale, please confirm?") == true) {
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
            <td class="Logoutlink">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="Logoutlink">
               Sale Items 
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
        </tr>
        <tr>
            <td align="left" class="formText">
                <table width="721" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="721">
                        <asp:UpdatePanel ID="update1" runat="server">
    <ContentTemplate>
                        
                            <asp:GridView ID="gridProductList" runat="server" AutoGenerateColumns="False" Width="700px"
                    AllowPaging="true" PageSize="10" OnPageIndexChanging="gridProductList_PageIndexChanging"
                    CssClass="gridBorder" CellPadding="0" CellSpacing="0" OnRowCommand="gridProductList_OnRowCommand" AllowSorting="True" onsorting="gridProductList_Sorting">
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblProductId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Image">
                           <%-- <ItemTemplate>
                                <img id="imgProduct" runat="server" src='<%# DataBinder.Eval(Container.DataItem, "image")%>' />
                            </ItemTemplate>--%>
                            <ItemTemplate>
                             <asp:Image ID="imgProduct"  runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>'  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Title" SortExpression="product_title">
                            <ItemTemplate>
                                <asp:Label ID="lblTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Size">
                            <ItemTemplate>
                                <asp:Label ID="lblSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'></asp:Label>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price($)">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_price")%>'
                                    CssClass="textBoxSmall"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Per Sale($)">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPerSale" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_presale")%>'
                                    CssClass="textBoxSmall"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate><%--OnClientClick="return confirmsubmit();"--%>
                                <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="../images/gtk-edit.png"
                                    Width="18" Height="18" border="0" CommandName="UpdateProduct" CommandArgument='<%# Eval("product_id") %>'
                                    CausesValidation="false"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sale/UnSale">
                            <ItemTemplate>
                                <%--<asp:Panel ID="pnlHide" runat="server" Visible="true">--%>
                                    <asp:ImageButton ID="btnHide" runat="server" ImageUrl="../images/salesman.png"
                                        Width="24" Height="24" border="0" CommandName="Hide" CommandArgument='<%# Eval("product_id") %>'
                                        OnClientClick="return confirmHide();" />
                              <%--  </asp:Panel>--%>
                               <%-- <asp:Panel ID="pnlUnHide" runat="server" Visible="false">
                                    <asp:ImageButton ID="btnUnHide" runat="server" ImageUrl="../images/unsales.gif" Width="18"
                                        Height="18" border="0" CommandName="UnHide" CommandArgument='<%# Eval("product_id") %>'
                                        OnClientClick="return confirmUnhide();" />
                                </asp:Panel>--%>
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
                </table>
            </td>
        </tr>
        <tr>
            <td height="15px">
            </td>
        </tr>
       
        <tr>
        <td>
        <table>
        <tr>
        <td style="padding-left: 50px;">
                <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="button" OnClick="btnAdd_Click" />
            </td>
          <td align="left" style="padding-left:345px;">
                  
                    <asp:ImageButton ID="imgBack" runat="server"  ImageUrl="../images/backbutton.jpg" 
                            width="71" height="23" border="0" onclick="imgBack_Click" CausesValidation="false" />
                 
                    </td>
        </tr>
        </table>
        </td>
           
        </tr>
    </table>
    
</asp:Content>
