<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="index3.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.index3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server" ></asp:ScriptManager>
   
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="Logoutlink">&nbsp;</td>
              </tr>
              <tr>
                <td class="Logoutlink">Welcome <em class="username"><strong><asp:Label ID="lblUserName" runat="server"></asp:Label></strong></em>, to the&nbsp;<asp:Label ID="lblCmpyNm" runat="server"></asp:Label>&nbsp;site manager. </td>
              </tr>
              <tr>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td height="35" class="formText">Top 5 Orders</td>
              </tr>
               <tr>
            <td style="padding-left:40px;">
              <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label>
            </td>
        </tr>
              <tr>
                <td align="left" class="formText">
                <asp:UpdatePanel ID="update1" runat="server">
    <ContentTemplate>
    
                
                      <asp:GridView ID="gridOrderList" runat="server" AutoGenerateColumns="False" Width="700px"
                    PageSize="5" 
                    CssClass="gridBorder"  CellPadding="0" CellSpacing="0"  AllowSorting="True" onsorting="gridOrderList_Sorting"      >
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblOrederId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbluserId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Order #"   SortExpression="orders_number">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_number")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Last Name"   SortExpression="users_lname">
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
                            <asp:Label ID="lblDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "deliverydate")%>'></asp:Label>                            
                           </ItemTemplate>
                        </asp:TemplateField>  
                        
                        
                        
                         <asp:TemplateField HeaderText="Delivery Time"   >
                            <ItemTemplate>
                            <asp:Label ID="lblTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_deliverytime")%>'></asp:Label>                        
                                                

                           </ItemTemplate>
                        </asp:TemplateField>    
                                            
                        
                       
                        
                        
                        
                         <asp:TemplateField HeaderText="Details">
                            <ItemTemplate >
                                <a  href="#" onclick='openUserOrderDetailNewPopUp(<%# DataBinder.Eval(Container.DataItem, "orders_id")%>,<%# DataBinder.Eval(Container.DataItem, "users_id")%>)' >
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
              <tr>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td height="35" class="formText">Top 5 Users</td>
              </tr>
               <tr>
               <td style="padding-left:40px;">
              <asp:Label ID="lblMsg1" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label>
            </td>
        </tr>
              <tr>
                <td align="left" class="formText">
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
                
                     <asp:GridView ID="griduserList" runat="server" AutoGenerateColumns="False"                                     
                                             Width="700px"   
        PageSize="5"  
        CssClass="gridBorder"  CellPadding="0" CellSpacing="0"  AllowSorting="True" onsorting="griduserList_Sorting"  >
                                       <Columns>
                                       
                                       <asp:TemplateField   Visible="false" >
                                        <ItemTemplate > 
                                                                            
                                         <asp:Label ID="lblUserId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_id")%>' ></asp:Label>
                                        
                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>  
                                       
                                       <asp:TemplateField  HeaderText="Last Name" SortExpression="users_lname" >
                                        <ItemTemplate > 
                                                                           
                                         <asp:Label ID="lblUserLName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_lname")%>' ></asp:Label>
                                         </a>
                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>                                     
                                     
                                       <asp:TemplateField  HeaderText="First Name"  SortExpression="users_fname" >
                                        <ItemTemplate >                                       
                                         <asp:Label ID="lblUserFName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_fname")%>' ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                      <asp:TemplateField  HeaderText="Email"  >
                                        <ItemTemplate >                                        
                                         <asp:Label ID="lblEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_email")%>' ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                      
                                      
                                      <asp:TemplateField  HeaderText="Joined"  >
                                        <ItemTemplate >                                       
                                         <asp:Label ID="lblJoined" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "date1")%>' ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                      
                                      
                                      
                                       <asp:TemplateField  HeaderText="Address">
                                        <ItemTemplate >
                                        <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_address1")%>' ></asp:Label>                                          
                                                                                                                      
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                   
                                      
                                       <asp:TemplateField HeaderText="Details">
                            <ItemTemplate >
                                <a  href="#" onclick='openUserDetailInformationPopUp(<%# DataBinder.Eval(Container.DataItem, "users_id")%>)' >
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
               <tr>
                <td height="10px">&nbsp;</td>
              </tr>
              
            </table>
     
    

</asp:Content>
