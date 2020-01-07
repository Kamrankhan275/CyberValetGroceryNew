<%@ Page Title="User Order Information" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewUserOrderInfo.aspx.cs" Inherits="CyberValetGrocery.Admin.ViewUserOrderInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="JavaScript1.2">showHide("customers");</script>

   
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="Logoutlink">&nbsp;</td>
              </tr>
              <tr>
                <td class="Logoutlink">
                
               User Administration
                
                 </td>
              </tr>
               <tr>
                   
                    <td align="right" style="padding-right:200px;">
                  
                    <asp:ImageButton ID="imgBack1" runat="server"  ImageUrl="../images/backbutton.jpg" 
                            width="71" height="23" border="0" onclick="imgBack1_Click" CausesValidation="false" />
                 
                    </td>
                  </tr>
              <tr>
                <td>&nbsp;</td>
              </tr>
              
              <tr>
                <td align="left" class="formText">
                <table width="721" border="0" cellpadding="0" cellspacing="0">
                
                
                	<tr>
					<td colspan="3"  align="left">
					<table>
					
					<tr>
						<td class="formText" align="right"><strong>First Name:</strong></td>
						<td  class="formTextSmall">
						<asp:Label ID="lblFName" runat="server"></asp:Label>
						</td>
						<td width="20"></td>
					</tr>
					<tr>
						<td class="formText" align="right"><strong> Last Name:</strong></td>
						<td  class="formTextSmall">
						<asp:Label ID="lblLName" runat="server"></asp:Label>
						</td>
						<td width="20"></td>
					</tr>
					
					<tr><td colspan="3">&nbsp;</td></tr>
				
					<tr>
						<td class="formText" align="right"><strong>Current Account Value:</strong></td>
						<td class="formTextSmall">
						<asp:Label ID="lblSign1" runat="server" Text="$"></asp:Label>
						<asp:Label ID="lblAccountVal"  runat="server"></asp:Label>
						
						</td>
						<td></td>
					</tr>
					
					<tr>
						<td class="formText" align="right"><strong>On Mailing List:</strong></td>
						<td class="formTextSmall">
						<asp:Label ID="lblMailing" runat="server"></asp:Label>
						</td>
						<td></td>
					</tr>
					
					</table>
					</td>
					</tr>
                
                <tr><td height="3px;">&nbsp;</td></tr>
                
                 <tr><td align="left"  class="formText"><strong>Order Activity:</strong></td></tr>
                
                  <tr>
                    <td width="721">
                   
                    <asp:GridView ID="gridUserOrderList" runat="server" AutoGenerateColumns="False" PageSize="5"       Width="700"  CssClass="gridBorder"  CellPadding="0" CellSpacing="0" >                                  
                                              
      
                                       <Columns>
                                       
                                      
                                       
                                       <asp:TemplateField    Visible="false" >
                                        <ItemTemplate >                                                                             
                                        
                                         <asp:Label ID="lblOrderId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_id")%>' ></asp:Label>
                                        
                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>  
                                       
                                       <asp:TemplateField  HeaderText="Order #"  >
                                        <ItemTemplate > 
                                                                           
                                         <asp:Label ID="lblOrderNumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_number")%>' ></asp:Label>
                                         </a>
                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>                                     
                                     
                                       <asp:TemplateField  HeaderText="Delivery"   >
                                        <ItemTemplate >                                       
                                         <asp:Label ID="lblDelivery" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "delivery")%>'  ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                      <asp:TemplateField  HeaderText="Ordered"   >
                                        <ItemTemplate >                                        
                                         <asp:Label ID="lblOrdered" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ordered")%>' ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                      
                                      
                                      <asp:TemplateField  HeaderText="Total($)"   >
                                        <ItemTemplate >                                       
                                         <asp:Label ID="lblTotal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_totalfinal")%>' ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                       
                                      
                                      
                                      
                                       <asp:TemplateField   HeaderText="Details" >
                                        <ItemTemplate >
                                        <a  href="#" onclick='openOrderDetailPopUp(<%# DataBinder.Eval(Container.DataItem, "orders_id")%>,<%=Request.QueryString["userId"]%>)' >
                                   <img src="../images/view-icon.jpg" width="18" height="18"  border="0"/>
                       
                                        </a>                                         
                                                                                                                      
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                     
                                      </Columns>
                                          <PagerStyle CssClass="pagingtext"   ForeColor="#FFFFFF"   />
                    <HeaderStyle CssClass="grideheading" ForeColor="#404248" />
                    <AlternatingRowStyle CssClass="grideAlternatetext" />
                    <RowStyle CssClass="gridetext" />
                   
                                       
                                       </asp:GridView>
                    
                    <span style="padding-left:50px;">
                     <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label>
                     </span>
                    
                    
                    </td>
                  </tr>
                 
                </table></td>
              </tr>
               <tr>
   <td  style="padding-left:470px;">
   <asp:Panel ID="pnlTot" runat="server">
   <table>
   <tr>
   <td class="formText"><strong>Grand Total:</strong></td>
						<td class="ErrorTxt">
						<asp:Label ID="lblSign" runat="server" Text="$"></asp:Label>
						<asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
						</td>
   </tr>
   </table>
   </asp:Panel>
   </td>
  
   </tr>
   
   
    <tr><td  height="5px">&nbsp;</td></tr>
  
  <tr><td align="left"  class="formText"><strong>Product Activity:</strong></td></tr>
  
      <tr>
                    <td width="721">
                    
                  <asp:GridView ID="gridUserProductList" runat="server" AutoGenerateColumns="False"   PageSize="5"     Width="700" CssClass="gridBorder"  CellPadding="0" CellSpacing="0" >    
                                      
                                              
      
                                       <Columns>
                                       
                                       
                                      
                                       <asp:TemplateField  HeaderText="Sr #"   >
                                        <ItemTemplate > 
                                                                           
                                         <asp:Label ID="lblNumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_id")%>' ></asp:Label>
                                         
                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField> 
                                      
                                       
                                       <asp:TemplateField  HeaderText="Total Order"   >
                                        <ItemTemplate > 
                                                                           
                                         <asp:Label ID="lblTotalProductQty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "crap")%>' ></asp:Label>
                                         </a>
                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>                                     
                                     
                                       <asp:TemplateField HeaderText="Product Name"    >
                                        <ItemTemplate >                                       
                                         <asp:Label ID="lblProductName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'  ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                      <asp:TemplateField  HeaderText="Price($)"   >
                                        <ItemTemplate >                                        
                                        <asp:Label ID="lblProductPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_price")%>' ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                      
                                      
                                      
                                      
                                      
                                       
                                      
                                      
                                      
                                     
                                      
                                      
                                     
                                      </Columns>
                                          
                                            <PagerStyle CssClass="pagingtext"   ForeColor="#FFFFFF"   />
                    <HeaderStyle CssClass="grideheading" ForeColor="#404248" />
                    <AlternatingRowStyle CssClass="grideAlternatetext" />
                    <RowStyle CssClass="gridetext" />
                                       
                                       </asp:GridView>
                    
                    
                   <span style="padding-left:50px;">
                     <asp:Label ID="lblMsg1" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label>
                     </span>
                    
                    
                    </td>
                  </tr>
                
                 <tr><td  height="5px">&nbsp;</td></tr>
                 
                  <tr>
                   
                    <td align="right" style="padding-right:200px;">
                  
                    <asp:ImageButton ID="imgBack" runat="server"  ImageUrl="../images/backbutton.jpg" 
                            width="71" height="23" border="0" onclick="imgBack_Click" CausesValidation="false" />
                 
                    </td>
                  </tr>
                     <tr><td  height="15px">&nbsp;</td></tr>
  
            </table>
     
    
</asp:Content>
