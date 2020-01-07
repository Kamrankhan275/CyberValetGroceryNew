<%@ Page Title=" Depositors Report List" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewAdminDepositors.aspx.cs" Inherits="CyberValetGrocery.Admin.ViewAdminDepositors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                
           Depositors Report
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
                    
                      <asp:GridView ID="gridDepositorList" runat="server" AutoGenerateColumns="False"                                     
                                             Width="700px"   AllowPaging="true" 
        
        onpageindexchanging="gridDepositorList_PageIndexChanging" CssClass="gridBorder"  CellPadding="0" CellSpacing="0"  AllowSorting="True" onsorting="gridDepositorList_Sorting"  >
                                       <Columns>
                                       
                                       <asp:TemplateField    Visible="false" >
                                        <ItemTemplate > 
                                                                            
                                         <asp:Label ID="lblParentId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "parent_id")%>' ></asp:Label>
                                         
                                        
                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>  
                                       
                                       <asp:TemplateField  HeaderText="Last Name" SortExpression="parent_lname"  >
                                        <ItemTemplate > 
                                                                           
                                         <asp:Label ID="lblDepositorLName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "parent_lname")%>' ></asp:Label>
                                         </a>
                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>                                     
                                     
                                       <asp:TemplateField  HeaderText="First Name"  SortExpression="parent_fname"  >
                                        <ItemTemplate >                                       
                                         <asp:Label ID="lblDepositorFName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "parent_fname")%>' ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                      <asp:TemplateField  HeaderText="Email"   >
                                        <ItemTemplate >                                        
                                         <asp:Label ID="lblDealerEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "parent_email")%>' ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                      
                                      
                                      <asp:TemplateField  HeaderText="Location"   >
                                        <ItemTemplate >                                       
                                         <asp:Label ID="lblLocation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "location_name")%>' ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                       <asp:TemplateField  HeaderText="Customer" SortExpression="customer">
                                        <ItemTemplate >
                                        <asp:Label ID="lblCustomer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "customer")%>' ></asp:Label>                                          
                                                                                                                      
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                      
                                       <asp:TemplateField HeaderText="Details" >
                                        <ItemTemplate >
                                        <asp:Panel ID="pnlView" runat="server">
                                        <a href="#" onclick='openDepositorsTransacDetailsPopUp(<%# DataBinder.Eval(Container.DataItem, "parent_id")%>)'>
                                    <img src="../images/view-icon.jpg" width="18" height="18"  border="0"  />
                                    
                       
                                        </a>  
                                        </asp:Panel>                                       
                                                                                                                      
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
