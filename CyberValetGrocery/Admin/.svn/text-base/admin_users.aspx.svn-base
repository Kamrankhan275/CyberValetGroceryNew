<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="admin_users.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="JavaScript1.2">showHide("customers");</script>

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>User Administration </legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                       <tr>
                            <td width="46%" align="left" colspan="2" class="FieldTextSearch">
                                Field with a <span class="star">*</span> are required
                            </td>
                        </tr>
                        <tr>
                            <td height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td width="46%" align="left" colspan="2" style="padding-left: 125px">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                            </td>
                        </tr>
        <tr>
            <td align="right" class="formText">
                Search For:
            </td>
            <td height="40">
                <asp:TextBox ID="txtSearch" runat="server" MaxLength="30" CssClass="textBox">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="formText">
                In:
            </td>
            <td height="40">
                <asp:DropDownList ID="drpSearchField" runat="server" CssClass="DropDownBox">                   
                    <asp:ListItem Value="1">User's Last Name</asp:ListItem>
                    <asp:ListItem Value="2">User's First Name</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="formText">
                Sort By:
            </td>
            <td height="40">
                <asp:DropDownList ID="drpSortBy" runat="server" CssClass="DropDownBox">                   
                    <asp:ListItem Value="1">Last Name</asp:ListItem>
                    <asp:ListItem Value="2">First Name</asp:ListItem>
                    <asp:ListItem Value="3">Sign Up Date</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="formText">
               <span class="star">*</span>  Location:
            </td>
            <td height="40">
                <asp:DropDownList ID="drpLocation" runat="server" CssClass="DropDownBox">
                    
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ControlToValidate="drpLocation"
                    ErrorMessage="Select location" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="formText">
                Show:
            </td>
            <td height="40" class="formText">
                <asp:DropDownList ID="drpPagingNmber" runat="server" CssClass="DropDownBox">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="100">100</asp:ListItem>
                    <asp:ListItem Value="50">50</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                </asp:DropDownList>
                &nbsp;per page
            </td>
        </tr>
        <tr>
            <td align="right" class="formText">
                &nbsp;
            </td>
            <td height="40" style="padding-left: 10px;">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnBegin" runat="server" Text="Begin" CssClass="button" OnClick="btnBegin_Click" />
                        </td>
                        <td>
                            <asp:Label ID="lblMessage" runat="server" Text="To view all records, hit begin with no search term."
                                CssClass="ErrorTxt"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </fieldset></td> </tr> </table>
</asp:Content>
