<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="admin_coupon.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_coupon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script language="javascript" type="text/javascript">
        function confirmHide() {
            if (confirm("You are about to hide the data, please confirm?") == true) {
                return true;
            }
            else {
                return false;
            }
        }

        function confirmUnhide() {
            if (confirm("You are about to unhide the data, please confirm?") == true) {
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
            <td class="Logoutlink">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="Logoutlink">
                Coupon Administration
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
                            <asp:GridView ID="gridCouponList" runat="server" AutoGenerateColumns="False" Width="600px"
                                AllowPaging="true" PageSize="10" OnPageIndexChanging="gridCouponList_PageIndexChanging"
                                CssClass="gridBorder" CellPadding="0" CellSpacing="0" OnSorting="gridCouponList_Sorting"
                                OnRowCommand="gridCouponList_OnRowCommand" AllowSorting="true" 
                               >
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCouponId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "coupon_id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Coupon Code" SortExpression="coupon_code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCouponCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "coupon_code")%>'></asp:Label>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount($)" SortExpression="coupon_amount">
                                        <ItemTemplate>
                                         <%--<asp:Label ID="lblAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "coupon_amount")%>'></asp:Label>--%>
                                         <asp:Label ID="lblAmount" runat="server" Text='<%# Convert.ToDecimal(Eval("coupon_amount")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLocation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "location_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Update">
                                        <ItemTemplate>
                                            <a href='EditCoupon.aspx?couponId=<%# DataBinder.Eval(Container.DataItem, "coupon_id")%>'>
                                                <img src="../images/gtk-edit.png" width="18" height="18" border="0" />
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCouponStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "coupon_hide")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Hide/UnHide">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnlHide" runat="server" Visible="true">
                                                <asp:ImageButton ID="btnHide" runat="server" ImageUrl="../images/14_layer_novisible.png"
                                                    Width="18" Height="18" border="0" CommandName="Hide" CommandArgument='<%# Eval("coupon_id") %>'
                                                    OnClientClick="return confirmHide();" />
                                            </asp:Panel>
                                            <asp:Panel ID="pnlUnHide" runat="server" Visible="false">
                                                <asp:ImageButton ID="btnUnHide" runat="server" ImageUrl="../images/hide.png" Width="18"
                                                    Height="18" border="0" CommandName="UnHide" CommandArgument='<%# Eval("coupon_id") %>'
                                                    OnClientClick="return confirmUnhide();" />
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
    </table>
    
   
</asp:Content>
