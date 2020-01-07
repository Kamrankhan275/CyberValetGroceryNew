<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="admin_UploadProductPrice.aspx.cs" Inherits="CyberValetGrocery.Admin.admin_UploadProductPrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<script language="JavaScript1.2">showHide("sitefunctions");</script>
 <script language="JavaScript1.2">showHide("sitefunctions");</script>
    
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>Product Administration  </legend>
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
                                <asp:Label ID="lblMsg" runat="server" CssClass="formText"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="formText">
                               <span class="star">*</span> Location:
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
                                Shelf:
                            </td>
                            <td height="40">
                                <asp:DropDownList ID="drpShelf" runat="server" CssClass="DropDownBox">
                                    
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="formText">
                                Keyword:
                            </td>
                            <td height="40">
                                <asp:TextBox ID="txtKeyWord" runat="server" CssClass="textBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="formText">
                                Per Page:
                            </td>
                            <td height="40">
                                <asp:DropDownList ID="drpPerPage" runat="server" CssClass="DropDownBox">
                                    <asp:ListItem Value="Select">Select</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                </asp:DropDownList>
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
                                            <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="button" OnClick="btnAdd_Click"
                                                CausesValidation="false" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    




</asp:Content>
