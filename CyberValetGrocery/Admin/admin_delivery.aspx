<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="admin_delivery.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_delivery1" %>
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
   <asp:ScriptManager ID="script1" runat="server" ></asp:ScriptManager>
   
    
    

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="Logoutlink">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="Logoutlink">
                Delivery Dates Administration
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
                          <asp:GridView ID="gridDeliveryDate" runat="server" AutoGenerateColumns="False" Width="600px"
                    AllowPaging="true" PageSize="10" OnPageIndexChanging="gridDeliveryDate_PageIndexChanging" OnRowCommand="gridDeliveryDate_OnRowCommand"
                    CssClass="gridBorder"  CellPadding="0" CellSpacing="0"  AllowSorting="True" onsorting="gridDeliveryDate_Sorting" >
                    <Columns>
                        <asp:TemplateField  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblDeliveryId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "deliverydate_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delivery Date" SortExpression="deliveryDate" >
                            <ItemTemplate>
                                <asp:Label ID="lblDeliveryDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "deliveryDate")%>'></asp:Label>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Location" >
                            <ItemTemplate>
                                <asp:Label ID="lblLocation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "location_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <%--  <asp:TemplateField HeaderText="Zone" >
                            <ItemTemplate>
                                <asp:Label ID="lblZone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "zone")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Details">
                            <ItemTemplate>
                                <a href='ViewDeliveryDateInfo.aspx?deliveryId=<%# DataBinder.Eval(Container.DataItem, "deliverydate_id")%>&deliveryDate=<%# DataBinder.Eval(Container.DataItem, "deliveryDate")%>' >
                                    <img src="../images/view-icon.jpg" width="18" height="18"  border="0" />
                       
                                        </a> 
                                        
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" >
                            <ItemTemplate>                            
                            <asp:ImageButton ID="imgDelete" runat="server"   ImageUrl="../images/delete.png" width="18" height="18"  border="0" 
                           CommandName="DeleteDelivery"  CommandArgument='<%# Eval("deliverydate_id") %>' OnClientClick="return confirmsubmit();" />
                              
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
            <td style="padding-left: 50px;">
                <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="button" OnClick="btnAdd_Click" />
            </td>
        </tr>
         <tr>
            <td height="15px">
            </td>
        </tr>
        
          <tr>
            <td style="padding-left: 50px;">
            <asp:Panel ID=pnldeldateedit runat=server visible=false>
          
            <table>
                <tr>
                <td> Select Delivery Date to Update :<asp:DropDownList runat="server" ID="ddlDate" CssClass="DropDownBox"></asp:DropDownList>
                </td>
                 <td style="padding-left: 10px;"><asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" OnClick="btnUpdate_Click"/>
                </td>
                </tr>
            </table>
              </asp:Panel>
           
            </td>
        </tr>
    </table>
</asp:Content>
