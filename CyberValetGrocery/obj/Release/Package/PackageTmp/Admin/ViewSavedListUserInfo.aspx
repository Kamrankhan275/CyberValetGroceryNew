<%@ Page Title="Saved List Report" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="ViewSavedListUserInfo.aspx.cs" Inherits="CyberValetGrocery.Admin.ViewSavedListUserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="JavaScript1.2">showHide("reports");</script>

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
                Saved List Report
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 200px;">
                <asp:ImageButton ID="imgBack1" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0" OnClick="imgBack1_Click" CausesValidation="false" />
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
                                    <asp:GridView ID="gridUserList" runat="server" AutoGenerateColumns="False" Width="700px"
                                        AllowPaging="true" PageSize="10" OnPageIndexChanging="gridUserList_PageIndexChanging"
                                        CellPadding="0" CellSpacing="0" AllowSorting="True" OnSorting="gridUserList_Sorting"
                                        CssClass="gridBorder">
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblListId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "list_id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="List Name" SortExpression="list_name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblListName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "list_name")%>'></asp:Label>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="# Items">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalItem" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalItem")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Details">
                                                <ItemTemplate>
                                                    <a href="#" onclick='openUserSavedListDetailsPopUp(<%# DataBinder.Eval(Container.DataItem, "list_id")%>)'>
                                                        <img src="../images/view-icon.jpg" width="18" height="18" border="0" />
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
            <td align="right" style="padding-right: 200px;">
                <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0" OnClick="imgBack_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>
</asp:Content>
