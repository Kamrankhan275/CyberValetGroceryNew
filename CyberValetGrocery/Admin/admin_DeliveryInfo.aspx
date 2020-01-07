<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="admin_DeliveryInfo.aspx.cs" Inherits="CyberValetGrocery.Admin.admin_DeliveryInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                Delivery Info Administration
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
                                    <asp:GridView ID="gridDeliInfoList" runat="server" AutoGenerateColumns="False" Width="600px"
                                        AllowPaging="true" PageSize="10" OnPageIndexChanging="gridDeliInfoList_PageIndexChanging"
                                        OnRowCommand="gridDeliInfoList_OnRowCommand" CssClass="gridBorder" CellPadding="0"
                                        CellSpacing="0" AllowSorting="True">
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDeliInfoId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DeliInfoId")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                            <asp:TemplateField HeaderText="Delivey Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDeliveryName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DeliveryName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Show" SortExpression="status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAisleShow" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "status")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Update">
                                                <ItemTemplate>
                                                    <a href='EditDeliInfo.aspx?DeliInfoId=<%# DataBinder.Eval(Container.DataItem, "DeliInfoId")%>'>
                                                        <img src="../images/gtk-edit.png" width="18" height="18" border="0" />
                                                    </a>
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
                
            </td>
        </tr>
    </table>
</asp:Content>
