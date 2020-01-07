<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="admin_TodaysDelivery.aspx.cs" Inherits="CyberValetGrocery.Admin.admin_TodaysDelivery" %>

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
                In about an hour service Administration
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
                                    <asp:GridView ID="gridTodaysDateList" runat="server" AutoGenerateColumns="False"
                                        Width="600px" AllowPaging="true" PageSize="10" OnPageIndexChanging="gridTodaysDateList_PageIndexChanging"
                                        CssClass="gridBorder" CellPadding="0" OnRowCommand="gridTodaysDateList_OnRowCommand"
                                        CellSpacing="0" AllowSorting="True" OnSorting="gridTodaysDateList_Sorting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Start Time">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStartTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StartTime")%>'></asp:Label>
                                                    <asp:Label ID="lblTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AM_PM")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="End Time">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEndTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EndTime")%>'></asp:Label>
                                                    <asp:Label ID="lblTime2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PM_AM")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Show" SortExpression="status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDateShow" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ShowHide")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                               <%--     <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                     <asp:Label ID="lblProductTitle" runat="server" Text='<%# TimeInfo(DataBinder.Eval(Container.DataItem,"Time").ToString()) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Update">
                                                <ItemTemplate>
                                                    <a href='EditTodaysDelivery.aspx?TimeId=<%# DataBinder.Eval(Container.DataItem, "TimeId")%>'>
                                                        <img src="../images/gtk-edit.png" width="18" height="18" border="0" />
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="../images/delete.png" Width="18"
                                                        Height="18" border="0" CommandName="DeleteTime" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TimeId")%>'
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
