<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="admin_employee.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_employee" %>

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
 <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager> 
   
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="Logoutlink">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="Logoutlink">
                Employee Administration
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
                            <asp:GridView ID="gridEmployeeList" runat="server" AutoGenerateColumns="False" Width="600px"
                                AllowPaging="true" PageSize="10" OnPageIndexChanging="gridEmployeeList_PageIndexChanging"
                                OnRowCommand="gridEmployeeList_OnRowCommand" CssClass="gridBorder" CellPadding="0"
                                CellSpacing="0" AllowSorting="True" OnSorting="gridEmployeeList_Sorting">
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeeId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "admin_id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Last Name" SortExpression="admin_lname">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLastName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "admin_lname")%>'></asp:Label>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="First Name" SortExpression="admin_fname">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFirstName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "admin_fname")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "admin_email")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Update">
                                        <ItemTemplate>
                                            <a href='EditEmployee.aspx?employeeId=<%# DataBinder.Eval(Container.DataItem, "admin_id")%>'>
                                                <img src="../images/gtk-edit.png" width="18" height="18" border="0" />
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="../images/delete.png" Width="18"
                                                Height="18" border="0" CommandName="DeleteEmployee" CommandArgument='<%# Eval("admin_id") %>'
                                                OnClientClick="return confirmsubmit();" />
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
