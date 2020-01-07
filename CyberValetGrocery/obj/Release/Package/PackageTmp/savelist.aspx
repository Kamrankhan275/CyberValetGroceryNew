<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="savelist.aspx.cs" Inherits="CyberValetGrocery.savelist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
     function clcontent() {
         var lb1 = document.getElementById("<%= lblMsg.ClientID %>");
         lb1.innerHTML = "";
     }


</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="script1" runat="server" 
></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server"  >
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-left: 10px;">
        <tr>
            <td align="left" class="formHeading" colspan="2">
                Save Your List
            </td>
        </tr>
        <tr>
            <td height="10px" colspan="2">
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Panel ID="pnlSave" runat="server">
                    <table class="formTextUSer">
                        <tr>
                            <td colspan="2">
                                You can save your shopping list for next time:
                            </td>
                        </tr>
                        <tr>
                            <td height="10px" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" >
                                <table class="formTextUSer">
                                    <tr>
                                        <td colspan="2" align="center" class="formTextUSer">
                                            Field with a <span class="star1">*</span> are required
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" nowrap="nowrap" colspan="2">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                                        </td>
                                    </tr>
                                    <tr>
                                    <td></td>
                                        <td align="left" nowrap="nowrap" style="padding-left:5px;" >
                                           <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt1"></asp:Label> 
                                        </td></tr>
                                         <tr>
                                        <td>
                                        </td>
                                    </tr>
                                        <tr>
                                        <td nowrap="nowrap" valign="top">
                                            <strong><span class="star1">*</span>List Name:</strong>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtListNm" runat="server" CssClass="textbox1"></asp:TextBox><asp:RequiredFieldValidator ID="rfvFName" runat="server" Text="*" ControlToValidate="txtListNm"
                                                ErrorMessage="List name is required" ForeColor="White"></asp:RequiredFieldValidator></td></tr><tr>
                                        <td>
                                        </td>
                                        <td style="padding-left: 10px;" valign="top">
                                            <asp:Label ID="lblExample" runat="server" Text="Ex:My Lunch List" CssClass="ErrorTxt1"></asp:Label></td></tr><tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" Text="Save List" CssClass="buttonUser" OnClick="btnSave_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" align="left">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td colspan="3">
                                            <img src="images/savelist_top.gif" alt="items to be saved" width="300" height="33"
                                                border="0" />
                                        </td>
                                    </tr>
                                    <tr bgcolor="#E6E6E6" valign="top">
                                        <td width="14">
                                            <img src="images/savelist_left.gif" width="14" height="28" border="0" />
                                        </td>
                                        <td width="272" background="images/savelist_middle.gif" style="background-repeat: no-repeat;">
                                            <table cellpadding="3" cellspacing="0" border="0">
                                                <tr valign="top" height="20">
                                                    <td>
                                                        <asp:DataList ID="dtlShopList" runat="server" RepeatDirection="Vertical" Width="255px">
                                                            <ItemTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <td width="50" class="formTextSmall1" align="center" valign="top">
                                                                            <asp:Label ID="lblQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Qty") %>'></asp:Label></td><td width="150" class="formTextSmall1" valign="top" align="left">
                                                                            <asp:Label ID="lblProductNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ProdNm") %>'></asp:Label></td><td class="formTextSmall1" valign="top" align="center">
                                                                            <asp:Label ID="lblPrice" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Price") %>'></asp:Label></td></tr></table></ItemTemplate></asp:DataList></td></tr><tr>
                                                    <td>
                                                        <a href="product_order.aspx">
                                                            <img src="images/edit_list.gif" alt="edit list" width="70" height="13" border="0"
                                                                vspace="10" />
                                                        </a>
                                                    </td>
                                                </tr>
                                            </table>
                                            <td width="14">
                                                <img src="images/savelist_right.gif" width="14" height="28" border="0" />
                                            </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <img src="images/savelist_bottom.gif" width="300" height="16" border="0" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlSuccuss" runat="server">
                    <table>
                        <tr>
                            <td class="formTextUSer">
                                Your list has been successfully saved!
                            </td>
                        </tr>
                        <tr>
                            <td height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextUSer">
                                <a href="product_order.aspx" class="Userlink1">
                                    <img src="images/view_cart2.gif" alt="view cart" width="85" height="13" border="0" />
                                </a>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
