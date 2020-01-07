<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="admin_future.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_future" %>
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
<script language="JavaScript1.2">showHide("reports");</script>

 <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager> 
  
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="Logoutlink">&nbsp;</td>
              </tr>
              <tr>
                <td class="Logoutlink">
                
              Non-Delivery Zones Administration
                
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

                     <asp:GridView ID="gridNonDeliveryList" runat="server" AutoGenerateColumns="False"                                     
                                             Width="600px"   AllowPaging="true" 
        PageSize="10"  
        onpageindexchanging="gridNonDeliveryList_PageIndexChanging" OnRowCommand="gridNonDeliveryList_OnRowCommand"  CssClass="gridBorder"  CellPadding="0" CellSpacing="0"  AllowSorting="True" onsorting="gridNonDeliveryList_Sorting" >
                                       <Columns>
                                       
                                       <asp:TemplateField   Visible="false" >
                                        <ItemTemplate > 
                                                                            
                                         <asp:Label ID="lblDepositorId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "future_id")%>' ></asp:Label>
                                        
                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>  
                                       
                                       <asp:TemplateField  HeaderText="Zip Code" SortExpression="future_zip" >
                                        <ItemTemplate > 
                                                                           
                                         <asp:Label ID="lblZipCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "future_zip")%>' ></asp:Label>
                                         </a>
                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>                                     
                                     
                                      
                                      
                                      
                                      <asp:TemplateField  HeaderText="Name"  SortExpression="future_name">
                                        <ItemTemplate >                                        
                                         <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "future_name")%>' ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                       <asp:TemplateField  HeaderText="Email" >
                                        <ItemTemplate >                                       
                                         <asp:Label ID="lblEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "future_email")%>' ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      
                                      
                                      
                                      <asp:TemplateField  HeaderText="Date Submitted"  >
                                        <ItemTemplate >                                       
                                         <asp:Label ID="lblDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "futureDate")%>' ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      
                                      <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" runat="server"   ImageUrl="../images/delete.png" width="18" height="18"  border="0" CommandName="DeleteZip"  CommandArgument='<%# Eval("future_id") %>'   OnClientClick="return confirmsubmit();" />
                               
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
                
              
            </table>
     
    
</asp:Content>
