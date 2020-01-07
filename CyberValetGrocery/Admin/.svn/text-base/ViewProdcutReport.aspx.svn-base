<%@ Page Title="Product Report List" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewProdcutReport.aspx.cs" Inherits="CyberValetGrocery.Admin.ViewProdcutReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script language="JavaScript1.2">showHide("reports");</script>
 <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager> 
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="Logoutlink">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="Logoutlink">
               Product Report
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 200px;">
                <asp:ImageButton ID="imgBack1" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0" CausesValidation="false" 
                    onclick="imgBack1_Click" />
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
            <td align="left" class="formText">
                <table width="721" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="721">
                        
                        <asp:UpdatePanel ID="update1" runat="server">
    <ContentTemplate>
                            <asp:GridView ID="gridProductReport" runat="server" AutoGenerateColumns="False" Width="700px"
                                AllowPaging="true"  OnPageIndexChanging="gridProductReport_PageIndexChanging"
                                CssClass="gridBorder" CellPadding="0" CellSpacing="0" AllowSorting="True" OnSorting="gridProductReport_Sorting">
                                <Columns>
                                 
                                    <asp:TemplateField HeaderText="# Sold"  >
                                        <ItemTemplate>
                                            <asp:Label ID="lblSold" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "quantity")%>'></asp:Label>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product" SortExpression="product_title">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProdcut" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Shelf"  SortExpression="shelf_name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAisleShelf" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Total($)" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "extended_price")%>'></asp:Label>
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
            <td align="right" style="padding-right: 200px;">
                <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0"  CausesValidation="false" 
                    onclick="imgBack_Click" />
            </td>
        </tr>
    </table>
    
   
</asp:Content>
