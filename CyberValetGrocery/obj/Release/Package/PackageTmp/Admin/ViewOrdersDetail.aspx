<%@ Page Title="Orders List" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewOrdersDetail.aspx.cs" Inherits="CyberValetGrocery.Admin.ViewOrdersDetail" %>
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
     <script language="javascript" type="text/javascript">
         function confirmUpdate() {
             if (confirm("You are about to update the data, please confirm?") == true) {
                 return true;
             }
             else {
                 return false;
             }
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="JavaScript1.2">showHide("customers");</script>
    
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager> 
   
    

 <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="Logoutlink">&nbsp;</td>
              </tr>
              <tr>
                <td class="Logoutlink">
                
              Orders Administration
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
            <td style="padding-left:200px;">
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
                      <asp:GridView ID="gridOrderList" runat="server" AutoGenerateColumns="False" Width="750px"
                    AllowPaging="true"  OnPageIndexChanging="gridOrderList_PageIndexChanging"
                     CssClass="gridBorder"  CellPadding="0" CellSpacing="0"  AllowSorting="True" onsorting="gridOrderList_Sorting" OnRowCommand="gridOrderList_OnRowCommand"   >
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblOrederId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_id")%>'></asp:Label>
                                 <asp:Label ID="lblUserId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                        
                         <asp:TemplateField HeaderText="Order #" SortExpression="orders_number">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_number")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Last Name" SortExpression="users_lname">
                            <ItemTemplate>
                                <asp:Label ID="lblLastNum" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_lname")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="First Name" SortExpression="users_fname">
                            <ItemTemplate>
                                <asp:Label ID="lblFirstNum" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_fname")%>'></asp:Label>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        
                         <asp:TemplateField HeaderText="Location"   >
                            <ItemTemplate>
                             <asp:Label ID="lblLocation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "location_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>   
                        
                         <asp:TemplateField HeaderText="Delivery Date"   >
                            <ItemTemplate>
                            <asp:TextBox ID="txtDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "delDate")%>' CssClass="textBoxSmall"></asp:TextBox>
                            <asp:Label ID="lblDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "delDate")%>' Visible="false"></asp:Label>
                           </ItemTemplate>
                        </asp:TemplateField>  
                        
                        
                        
                         <asp:TemplateField HeaderText="Delivery Time"   >
                            <ItemTemplate>
                          <asp:TextBox ID="txtTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_deliverytime")%>' CssClass="textBoxSmall"></asp:TextBox>
                            <asp:Label ID="lblTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_deliverytime")%>' Visible="false"></asp:Label>

                           </ItemTemplate>
                        </asp:TemplateField> 
                        
                                            
                                            
                        
                       <asp:TemplateField HeaderText="Update">
              <ItemTemplate >
              
                      <%-- OnClientClick="return confirmUpdate();"--%>
                        <asp:ImageButton ID="btnUpdate" runat="server"   ImageUrl="../images/gtk-edit.png" width="18" height="18"  border="0"
                                 CommandName="UpdateDelievry" CommandArgument='<%# Eval("orders_id") %>'     CausesValidation="false" />           
                             
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        
                         <asp:TemplateField HeaderText="Details">
                            <ItemTemplate >
                                <a  href="#" onclick='openOrderDetailPopUp(<%# DataBinder.Eval(Container.DataItem, "orders_id")%>,<%# DataBinder.Eval(Container.DataItem, "users_id")%>)' >
                                   <img src="../images/view-icon.jpg" width="18" height="18"  border="0" />
                               </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                     
                        
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate >
                          <asp:ImageButton ID="btnDelete" runat="server"   ImageUrl="../images/delete.png"  width="18" height="18"  border="0"
                                 CommandName="DeleteDelievry" CommandArgument='<%# Eval("orders_id") %>'     CausesValidation="false" OnClientClick="return confirmsubmit();"/>           
                             
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
