<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="admin_zipcodes.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_zipcodes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script language="javascript" type="text/javascript">
        function confirmsubmit() {
            if (confirm("Are you sure you want to delete it, please confirm?") == true) {
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

    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="Logoutlink">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="Logoutlink">
                Zip Codes Administration
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
                                    <asp:GridView ID="gridZipList" runat="server" AutoGenerateColumns="False" Width="600px"
                                        AllowPaging="true" OnPageIndexChanging="gridZipList_PageIndexChanging"
                                        OnRowCommand="gridZipList_OnRowCommand" CssClass="gridBorder" CellPadding="0"
                                        CellSpacing="0" AllowSorting="True" OnSorting="gridZipList_Sorting" 
                                        >
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblZipId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "zipcode_id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Zip Code" SortExpression="zipcode_zipcode">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblZipCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "zipcode_zipcode")%>'></asp:Label>
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Location">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "zipcode_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Delivery Fee($)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMinimum" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DeliveryFee")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                             <asp:TemplateField HeaderText="Minimum Order Amout($)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMinimumOrderAmt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ZipOrderSize")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             
                                            <asp:TemplateField HeaderText="Update">
                                                <ItemTemplate>
                                                    <a href='EditZip.aspx?zipId=<%# DataBinder.Eval(Container.DataItem, "zipcode_id")%>'>
                                                        <img src="../images/gtk-edit.png" width="18" height="18" border="0" />
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="../images/delete.png" Width="18"
                                                        Height="18" border="0" CommandName="DeleteZip" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "zipcode_id")%>'
                                                        OnClientClick="return confirmsubmit();" />
                                                      
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pagingtext" ForeColor="#FFFFFF" />
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
