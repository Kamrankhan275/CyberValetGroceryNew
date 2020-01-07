<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewDeliveryDateInfo.aspx.cs" Inherits="CyberValetGrocery.Admin.ViewDeliveryDateInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                
              <span >
                    Delivery Times  for </span>&nbsp<asp:Label ID="lblDate" runat="server" ></asp:Label> 
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
                    <asp:GridView ID="gridDeliveryDetails" runat="server" AutoGenerateColumns="False"
                            Width="700px" AllowPaging="true" PageSize="10" OnPageIndexChanging="gridDeliveryDetails_PageIndexChanging"
                             CssClass="gridBorder"  CellPadding="0" CellSpacing="0"  AllowSorting="True" onsorting="gridDeliveryDetails_Sorting" >
                           
                            
                            <Columns>
                           
                                <asp:TemplateField HeaderText="Delivery Time" SortExpression="deliverytime_time">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "deliverytime_time")%>'></asp:Label>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cut Off" SortExpression="deliverytime_cuttime">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCutOff" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "deliverytime_cuttime")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Capacity" SortExpression="deliverydatetime_capacity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCapacity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "deliverydatetime_capacity")%>'></asp:Label>
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
