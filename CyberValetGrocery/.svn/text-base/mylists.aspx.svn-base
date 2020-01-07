<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="mylists.aspx.cs" Inherits="CyberValetGrocery.mylists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    
  
     <script type="text/javascript">


         var Image11 = document.getElementById("Image11");
         var Image12 = document.getElementById("Image12");
         var Image13 = document.getElementById("Image13");
         var Image14 = document.getElementById("Image14");
         var Image15 = document.getElementById("Image15");

         Image11.src = "images/DI-btn.gif";
         Image12.src = "images/Faq-btn.gif";
         Image13.src = "images/MSL-btn-h.gif";
         Image14.src = "images/AF-btn.gif";
         Image15.src = "images/AU-btn.gif";
  
    </script>



    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-left: 10px;">
                <tr>
                    <td align="left" class="formHeading">
                        My Shopping Lists
                    </td>
                </tr>
                <tr>
                    <td height="10px">
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <asp:Panel ID="pnlSaveList" runat="server">
                            <table class="formTextUSer">
                                <tr>
                                    <td>
                                        Here are your current saved shopping lists:
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:DataList ID="dtlShopList" runat="server" RepeatDirection="Vertical" OnItemCommand="dtlShopList_ItemCommand">
                                            <ItemTemplate>
                                                <table class="formTextSmall1">
                                                    <tr>
                                                        <td width="20" align="center" valign="top">
                                                            <asp:Image ID="imgArrow" runat="server" ImageUrl="images/arrow5.gif" />
                                                            <asp:Label ID="lblListId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"list_id") %>'
                                                                Visible="false"></asp:Label>
                                                        </td>
                                                        <td width="130" valign="top" align="left">
                                                            <a href="#" class="Userlink1" onclick='OpenSavedListPopUp(<%#DataBinder.Eval(Container.DataItem,"list_id") %>)'>
                                                                <asp:Label ID="lblListNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"list_name") %>'></asp:Label>
                                                            </a>
                                                        </td>
                                                        <td valign="top" align="center">
                                                            <asp:ImageButton ID="ImageAddAll1" runat="server" CommandArgument='<%# Eval("list_id") %>'
                                                                ImageUrl="images/add-all-items.gif" CommandName="AddAllList" CausesValidation="false" />
                                                        </td>
                                                        <td valign="top" align="center">
                                                            <asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<%# Eval("list_id") %>'
                                                                ImageUrl="images/delete_list.gif" CommandName="DeleteList" CausesValidation="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlNoSaveList" runat="server">
                            <table>
                                <tr>
                                    <td class="ErrorTxt1">
                                        You currently do not have any saved shopping lists.
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextUSer">
                                        Creating your shopping list is easy. Start creating a list now.
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextUSer" style="padding-left: 10px; padding-top: 5px;">
                                        Create a shopping list that you can save to use week after week. Why fill up your
                                        shopping cart each visit time? Creating and saving a new shopping list is simple:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextUSer" style="padding-left: 10px;">
                                        <ol>
                                            <li>Browse the categories and add items to your cart</li>
                                            <li>At the checkout screen click "save list"</li>
                                            <li>Give your list a name</li>
                                        </ol>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnStartShop" runat="server" CssClass="buttonUser" Text="Start Shopping"
                                            OnClick="btnStartShop_Click" />
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
