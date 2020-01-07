<%@ Page Title="User List" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="ViewUserInformation.aspx.cs" Inherits="CyberValetGrocery.Admin.ViewUserInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="JavaScript1.2">showHide("customers");</script>

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
                User Administration
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 200px;">
                <asp:ImageButton ID="imgBack1" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0" CausesValidation="false" 
                    onclick="imgBack1_Click" />
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
                                    <asp:GridView ID="griduserList" runat="server" AutoGenerateColumns="False" Width="700px"
                                        AllowPaging="true"  OnPageIndexChanging="griduserList_PageIndexChanging"
                                        CssClass="gridBorder" CellPadding="0" CellSpacing="0" AllowSorting="True" OnSorting="griduserList_Sorting">
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Last Name" SortExpression="users_lname">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserLName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_lname")%>'></asp:Label>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="First Name" SortExpression="users_fname">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserFName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_fname")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_email")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="users_regdate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblJoined" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_regdate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Orders">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrders" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="users_address1">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_address1")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Referred">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblReferred" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_hear")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Details">
                                                <ItemTemplate>
                                                <asp:Panel ID="pnlView" runat="server">
                                                    <a href='ViewUserOrderInfo.aspx?userId=<%# DataBinder.Eval(Container.DataItem, "users_id")%>&strKey=<%=Request.QueryString["strKey"]%>&intIn=<%=Request.QueryString["intIn"]%>&SortBy=<%=Request.QueryString["SortBy"]%>&locId=<%=Request.QueryString["locId"]%>&perPage=<%=Request.QueryString["perPage"]%>'>
                                                        <img src="../images/view-icon.jpg" width="18" height="18" border="0" />
                                                    </a>
                                                    </asp:Panel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Update">
                                                <ItemTemplate>
                                                    <a href='EditUser.aspx?userId=<%# DataBinder.Eval(Container.DataItem, "users_id")%>&strKey=<%=Request.QueryString["strKey"]%>&intIn=<%=Request.QueryString["intIn"]%>&SortBy=<%=Request.QueryString["SortBy"]%>&locId=<%=Request.QueryString["locId"]%>&perPage=<%=Request.QueryString["perPage"]%>'>
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
            <td align="right" style="padding-right: 200px;">
                <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0"  CausesValidation="false" 
                    onclick="imgBack_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
