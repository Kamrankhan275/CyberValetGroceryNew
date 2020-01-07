<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="admin_category2.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_category2" %>
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
                
                Shelves Administration
                
                 </td>
              </tr>
               <tr>
            <td>
                &nbsp;
            </td>
        </tr>
          <tr>
            <td>
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
                    <asp:GridView ID="gridShelvesList" runat="server" AutoGenerateColumns="False" Width="600px"
                    AllowPaging="true" PageSize="10" OnPageIndexChanging="gridShelvesList_PageIndexChanging"
                    OnRowCommand="gridShelvesList_OnRowCommand" CssClass="gridBorder"  CellPadding="0" CellSpacing="0"  AllowSorting="True" onsorting="gridShelvesList_Sorting" >
                    <Columns>
                        <asp:TemplateField  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblShelvesId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shelf Name" SortExpression="shelf_name" >
                            <ItemTemplate>
                                <asp:Label ID="lblShelvesName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_name")%>'></asp:Label>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mapping" >
                            <ItemTemplate>
                                <asp:Label ID="lblMapping" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_position")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                                <a href='EditShelves.aspx?shelfId=<%# DataBinder.Eval(Container.DataItem, "shelf_id")%>'>
                                     <img src="../images/gtk-edit.png" width="18" height="18"  border="0"/>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" >
                            <ItemTemplate>
                            
                            <asp:ImageButton ID="imgDelete" runat="server"   ImageUrl="../images/delete.png" width="18" height="18"  border="0" 
                           CommandName="DeleteShelves"  CommandArgument='<%# Eval("shelf_id") %>' OnClientClick="return confirmsubmit();" />
                                
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
                <td  style="padding-left:50px;">
                
                
                  
                     <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="button" OnClick="btnAdd_Click" />
                   
                </td>
              </tr>
              
            </table>
     
     
</asp:Content>
