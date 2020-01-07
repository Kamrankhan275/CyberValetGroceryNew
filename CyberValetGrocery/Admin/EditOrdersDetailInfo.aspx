<%@ Page Title=" Delivery Schedules" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="EditOrdersDetailInfo.aspx.cs" Inherits="CyberValetGrocery.Admin.EditOrdersDetailInfo" %>
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
  <script language="JavaScript1.2">showHide("customers");</script>
   <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager> 
    
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="Logoutlink" colspan="2">&nbsp;</td>
              </tr>
              <tr>
                <td class="Logoutlink" colspan="2">
                
              Delivery Schedules
                 </td>
              </tr>
              
              <tr>
                   
                    <td align="right" style="padding-right:200px;" colspan="2">
                  
                    <asp:ImageButton ID="imgBack1" runat="server"  ImageUrl="../images/backbutton.jpg" 
                            width="71" height="23" border="0" onclick="imgBack1_Click" CausesValidation="false" />
                 
                    </td>
                  </tr>
			

					<tr>
                <td colspan="2">&nbsp;</td>
              </tr>
				
				<tr><td colspan="2" class="formHeadingText">
				
				Order #: 
				
				<asp:Label ID="lblOrderNumber" runat="server" CssClass="formText"></asp:Label>
				
				</td></tr>
				
				<tr valign="top" class="formText">
					<td width="300">
						<table cellpadding="3" cellspacing="0" border="0">
						<tr><td align="right">Ordered:</td>
						<td align="left" class="formTextSmall">
						<asp:Label ID="lblOrederDate" runat="server"></asp:Label>
						</td>
						</tr>
						<tr><td class="formText" align="right"> Pickup/Delivery:</td>
						<td align="left"  class="formTextSmall">
						<asp:Label ID="lblDeliveryDate" runat="server"></asp:Label>
						 -						 
						 <asp:Label ID="lblDeliveryTime" runat="server"></asp:Label>
						</td
						></tr>
						
						<tr valign="top" align="right"><td>Payment method:</td>
							<td align="left" class="formTextSmall">
								
							<asp:Label ID="lblPaymentMethod" runat="server"></asp:Label><br />
							<asp:Label ID="lblCreditInfo" runat="server"></asp:Label>
							</td>
						
						</tr>
						</table>
					
					</td>
					
					<td width="300">Special Order Instructions?<br />
					<asp:Label ID="lblSpecialOrInfo" runat="server" CssClass="formTextSmall" ></asp:Label>
					<br />
					</td>
				</tr>

				<tr><td colspan="2">&nbsp;</td></tr>
				
				<tr  class="formHeadingText">
					<td>Customer Information</td>
					<td>Delivery Address</td>
				</tr>
				
				<tr valign="top" class="formText">
					<td width="300">
						<table cellpadding="3" cellspacing="0" border="0">
						<tr>
						<td width="120" align="right">First Name:</td>
						
						<td align="left" class="formTextSmall">
						<asp:Label ID="lblFName" runat="server">
												</asp:Label>
						</td>
						
						</tr>
						<tr><td align="right">Last Name:</td>
						<td align="left" class="formTextSmall">
						<asp:Label ID="lblLName" runat="server">
												</asp:Label>
						</td></tr>
						<tr><td align="right"> Phone:</td>
						<td class="formTextSmall">
						<asp:Label ID="lblPhone" runat="server">
												</asp:Label>
						</td>
						</tr>
						<tr><td align="right">Phone 2:</td>
						<td align="left" class="formTextSmall">
						<asp:Label ID="lblPhone2" runat="server">
												</asp:Label>
						</td>
						</tr>
						
						</table>
					
					</td>
					
					<td width="300">
						<table cellpadding="3" cellspacing="0" border="0">
						<tr>
						<td width="120" align="right">
						Address1:</td>
						<td align="left" class="formTextSmall">						
						<asp:TextBox ID="txtAddress" runat="server" CssClass="textBox"></asp:TextBox>
						
						</td>
						</tr>
						<tr>
						<td width="120" align="right">
						Address2:
						</td>
						<td>
						<asp:TextBox ID="txtAddress2" runat="server" CssClass="textBox" ></asp:TextBox>
						</td>
						</tr>
						
						<tr><td align="right" valign="top">City:</td>
						<td align="left" class="formTextSmall">
						<asp:TextBox ID="txtCity" runat="server" CssClass="textBox"></asp:TextBox>
						
						
						 </td></tr>
						 
						 <tr>
						<td width="120" align="right">
						State:
						</td>
						<td>
						<asp:TextBox ID="txtState" runat="server" CssClass="textBox"></asp:TextBox>
						</td>
						</tr>
						 <tr>
						<td width="120" align="right">
						Zip:
						</td>
						<td>
						<asp:TextBox ID="txtZip" runat="server" CssClass="textBox"></asp:TextBox>
						</td>
						</tr>
						 
						 <tr><td>
						 </td>
						 <td>
						 <asp:Button ID="btnUpdate" runat="server" Text="Update Address" CssClass="button" OnClick="btnUpdate_Click" />
						 </td>
						 </tr>
						
						</table>
						
					</td>
					
				</tr>
				
				<tr><td>&nbsp;</td></tr>
				
				<tr>
					<td colspan="2" >
					<asp:UpdatePanel ID="update1" runat="server">
    <ContentTemplate>
					<asp:GridView ID="gridUserProductList" runat="server" AutoGenerateColumns="False"   PageSize="10"  Height="100"   Width="600"   CssClass="gridBorder" CellPadding="0" CellSpacing="0">    
                                      
                                        
      
                                       <Columns>
                                       
                                       <asp:TemplateField   Visible="false" >
                                        <ItemTemplate >                                                                             
                                        
                                         <asp:Label ID="lblProductId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductId")%>' ></asp:Label>
                                        
                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>  
                                      
                                      
                                      
                                       
                                       <asp:TemplateField  HeaderText="Quantity"  >
                                        <ItemTemplate > 
                                                                           
<%--                                         <asp:Label ID="lblTotalProductQty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductQty")%>' ></asp:Label>
--%>                                         
                                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="textBoxGridSmall" Text='<%# DataBinder.Eval(Container.DataItem, "ProductQty")%>'></asp:TextBox>
                                        
                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>                                     
                                     
                                       <asp:TemplateField HeaderText="Product"   >
                                        <ItemTemplate >                                       
                                         <asp:Label ID="lblProductName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductName")%>'  ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                       <asp:TemplateField HeaderText="Size"   >
                                        <ItemTemplate >                                       
                                         <asp:Label ID="lblSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Size")%>'  ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                      <asp:TemplateField  HeaderText="Price"  >
                                        <ItemTemplate >                                        
                                         <%--<asp:Label ID="lblProductPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductPrice")%>' ></asp:Label>  
                                                                           
  --%>
                                          <asp:TextBox ID="txtPrice" runat="server" CssClass="textBoxGridSmall" Text='<%# DataBinder.Eval(Container.DataItem, "ProductId")%>'></asp:TextBox>

                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                       <asp:TemplateField HeaderText="Update">
              <ItemTemplate >
              

                        <asp:ImageButton ID="btnUpdate" runat="server"   ImageUrl="../images/gtk-edit.png" width="18" height="18"  border="0"
                                 CommandName="UpdateProduct" CommandArgument='<%# Eval("OrderId") %>'     CausesValidation="false" OnClientClick="return confirmsubmit();"/>           
                             
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
				<tr>
				<td colspan="2" align="right" class="formText">
				<table>
				
				<tr>
								<td></td>
								<td align="right">Sub Total: </td>
								<td align="left" class="formTextSmall">
								
								<asp:Label ID="lblSubtotal" runat="server"></asp:Label>
								
								
								</td>
							</tr>
							
							<tr>
								<td></td>
								<td align="right">Tax: </td>
								<td align="left" class="formTextSmall">
							<asp:Label ID="lblTax" runat="server"></asp:Label>
								</td>
							</tr>
							<tr>
								<td></td>
								<td align="right">Supply Fees: </td>
								<td align="left" class="formTextSmall">
								
									<asp:Label ID="lblSodaDeposit" runat="server"></asp:Label>
								
								</td>
							</tr>
							<tr>
								<td></td>
								<td align="right">Delivery Fee: </td>
								<td align="left" class="formTextSmall">
								<asp:Label ID="lblDeliveryFee" runat="server"></asp:Label>
								</td>
							</tr>
							<tr>
								<td></td>
								<td align="right">Tip: </td>
								<td align="left" class="formTextSmall">
								
								<asp:Label ID="lblTips" runat="server"></asp:Label>
								
								
								</td>
							</tr>
							<tr>
								<td></td>
								<td colspan="2"><hr size="-1" color="#000000" /></td>
							</tr>
							<tr>
								<td></td>
								<td align="right">ORDER TOTAL: </td>
								<td align="left" class="formTextSmall">
								<asp:Label ID="lblOrderTotal" runat="server"></asp:Label>
								
								</td>
							</tr>
				</table>
				
				</td>
				
				</tr>
				
  
  
				
			</table>	
			
			
</asp:Content>
