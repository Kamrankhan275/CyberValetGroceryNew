<%@ Page Title="Delivery Schedules List" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Viewdeliveryschedule.aspx.cs" Inherits="CyberValetGrocery.Admin.Viewdeliveryschedule" %>
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="JavaScript1.2">showHide("sitefunctions");</script>
 <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager> 
    
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding-left:20px;">
              <tr>
                <td class="Logoutlink">&nbsp;</td>
              </tr>
              <tr>
                <td class="Logoutlink">
                
              Delivery Schedules
                 </td>
              </tr>
              
              <tr>
              <td align="right">
              <table>
               <tr>
              
              <td  >
             <%-- <a href='DeliverySchedulePrint.aspx?date='+ target="_blank" >
                 <img src="../images/printButton.jpg"  border="0"/>
                   </a>--%>
                   <asp:ImageButton ID="imgBtnPrint" runat="server" ImageUrl="../images/printButton.jpg"
                                 border="0"  CausesValidation="false" onclick="imgBtnPrint_Click"  />
                   </td>
                   
                    <td align="right" style="padding-right:200px;">
                  
                    <asp:ImageButton ID="imgBack1" runat="server"  ImageUrl="../images/backbutton.jpg" 
                            width="71" height="23" border="0" onclick="imgBack1_Click" CausesValidation="false" />
                 
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
                <td class="formText">
                <strong>
                Viewing all deliveries for &nbsp;<asp:Label ID="lblDate" runat="server"></asp:Label>
                </strong>
                
                </td>
              </tr>
              <tr>
                <td>&nbsp;</td>
              </tr>
                <tr>
            <td style="padding-left:100px;">
              <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label>
            </td>
        </tr>
              
              <tr>
                <td align="left" class="formText">
                <table width="850" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td width="850">
                    <asp:UpdatePanel ID="update1" runat="server">
    <ContentTemplate>
                      <asp:GridView ID="gridDeliveryList" runat="server" AutoGenerateColumns="False" Width="850px"
                    AllowPaging="true" PageSize="10" OnPageIndexChanging="gridDeliveryList_PageIndexChanging"
                     CssClass="gridBorder"  CellPadding="0" CellSpacing="0"  AllowSorting="True" onsorting="gridDeliveryList_Sorting" OnRowCommand="gridDeliveryList_OnRowCommand" >
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_id")%>'></asp:Label>
                                 <asp:Label ID="lblPayType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_paymenttype")%>'></asp:Label>
                                 <asp:Label ID="lblUserId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Order #" SortExpression="orders_number" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNum" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_number")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Customer" SortExpression="customer">
                            <ItemTemplate>
                                <asp:Label ID="lblCustomer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "customer")%>'></asp:Label>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        
                         <asp:TemplateField HeaderText="Time" HeaderStyle-Width="70px">
                            <ItemTemplate>
                             <asp:Label ID="lblTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_deliverytime")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                      <%--  <asp:TemplateField HeaderText="Address" >
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_address")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        
                       
                        
                        <asp:TemplateField HeaderText="Groceries($)" HeaderStyle-Width="70px">
                            <ItemTemplate>
                            <asp:textBox ID="txtGroceries" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_grocerytotal")%>' CssClass="textBoxGridSmall"></asp:textBox>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delivery($)" HeaderStyle-Width="70px">
                            <ItemTemplate>
                            <asp:textBox ID="txtDelivery" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_deliveryfee")%>' CssClass="textBoxGridSmall"></asp:textBox>
                                <%--<asp:Label ID="lblDelivery" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Delivery")%>'></asp:Label>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tax($)" HeaderStyle-Width="60px">
                            <ItemTemplate>
                             <asp:textBox ID="txtTax" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_tax")%>' CssClass="textBoxGridSmall"></asp:textBox>
                                <%--<asp:Label ID="lblTax" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Tax")%>'></asp:Label>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tip($)" HeaderStyle-Width="60px">
                            <ItemTemplate>
                             <asp:textBox ID="txtTip" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_tip")%>' CssClass="textBoxGridSmall"></asp:textBox>
                                <%--<asp:Label ID="lblTip" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Tip")%>'></asp:Label>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total($)" HeaderStyle-Width="60px">
                            <ItemTemplate>
                             <asp:textBox ID="txtTotal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_totalfinal")%>' CssClass="textBoxGridSmall"></asp:textBox>
                              <asp:Label ID="lblTotal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_totalfinal")%>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Charges($)" HeaderStyle-Width="60px">
                            <ItemTemplate>
                            <asp:textBox ID="txtCharges" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_complimentary")%>' CssClass="textBoxGridSmall"></asp:textBox>
                               <asp:Label ID="lblCharges" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_complimentary")%>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                         
                        
                       <asp:TemplateField HeaderText="Update" HeaderStyle-Width="60px">
              <ItemTemplate >
              
<%--OnClientClick="return confirmsubmit();"--%>
                        <asp:ImageButton ID="btnUpdate" runat="server"   ImageUrl="../images/gtk-edit.png" width="18" height="18"  border="0"
                                 CommandName="UpdateDelievry" CommandArgument='<%# Eval("orders_id") %>'     CausesValidation="false" />           
                             
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Details" HeaderStyle-Width="50px">
                            <ItemTemplate >
                               <a  href="#" onclick='openOrderDetailPopUp(<%# DataBinder.Eval(Container.DataItem, "orders_id")%>,<%# DataBinder.Eval(Container.DataItem, "users_id")%>)' >
                                   <img src="../images/view-icon.jpg" width="18" height="18"  border="0" />
                               </a>
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
              <td align="right" >
              <table>
               <tr>
              
              <td style="padding-right:200px;">
           
                   <table><tr>
                <td>
                <%--<a href="admin_shoplist.aspx" style="text-decoration:none;"  ></a>--%>
                <asp:Button ID="btnViewShopping" runat="server" Text="View Shopping List" 
                        CssClass="button" CausesValidation="false" 
                        onclick="btnViewShopping_Click"/>
                
                </td>
                <td>
<asp:Button ID="btnPrintAllRec" runat="server" Text="Print All Receipt" 
                        CssClass="button" CausesValidation="false" 
                        onclick="btnPrintAllRec_Click" />
               
                </td>
               </tr></table>
                   </td>
                   
                    <td align="right" style="padding-right:200px;">
                  
                     <asp:ImageButton ID="imgBack" runat="server"  ImageUrl="../images/backbutton.jpg" 
                            width="71" height="23" border="0" onclick="imgBack_Click" CausesValidation="false" />
                 
                    </td>
              </tr>
              
              </table>
              </td>
                   
                  </tr>
              
              
              
             
              
            </table>
 

</asp:Content>
