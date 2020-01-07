<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="shelf.aspx.cs" Inherits="CyberValetGrocery.shelf" %>

<%@ Register Src="~/cart.ascx" TagName="UserScript" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
           
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <a href="Shop.aspx" class="Userlink1">All Aisles</a>&nbsp;
                        <asp:Label ID="lblArrow" runat="server" Text=">"></asp:Label>&nbsp;
                        <asp:Label ID="lblAisleName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formHeading">
                        <asp:Label ID="lblAisleName1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" width="100%" valign="top">
                        <table>
                            <tr>
                                <td valign="top" width="65%">
                                    <asp:Label ID="lblErrMsg" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                                    <asp:Panel ID="pnlPopular" runat="server">
                                        <table cellpadding="0" cellspacing="0" border="0" width="435px">
                                            <tr>
                                                <td class="formTextUSerGrid" style="vertical-align:top;">
                                                    <asp:DataList ID="dtlPopCatgory" runat="server" GridLines="None" RepeatDirection="Horizontal"
                                                        RepeatColumns="2"  ItemStyle-VerticalAlign="Top">
                                                       
                                                        <ItemTemplate>
                                                            <table width="150" border="0" cellpadding="1" cellspacing="0">
                                                                <tr>
                                                                    <td width="4" valign="top">
                                                                        <img src="images/arrow.gif" width="4" height="10" border="0" />
                                                                    </td>
                                                                    <td valign="top" align="left">
                                                                        <asp:Label ID="lblaisleid" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"aisle_id") %>'></asp:Label>
                                                                        <asp:Label ID="lblaisleText" Font-Bold="true" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"aisle_name") %>'></asp:Label>
                                                                        <br />
                                                                        <asp:DataList ID="dtlShelf" runat="server" GridLines="None" RepeatDirection="Vertical" AlternatingItemStyle-VerticalAlign="Top" >
                                                                            
                                                                            <ItemTemplate>
                                                                                <table width="150"  border="0" align="center" cellpadding="1" cellspacing="0">
                                                                                    <tr>
                                                                                        <td width="4" valign="top">
                                                                                            <img src="images/arrow.gif" width="4" height="10" border="0" />
                                                                                        </td>
                                                                                        <td valign="top" align="left">
                                                                                            <a href='products.aspx?shelf=<%#Eval("shelf_id")%>&aisle=<%#Eval("aisle_id") %>&aisletop=<%=Request.QueryString["aisle"] %>'
                                                                                                class="linkNew1">
                                                                                                <asp:Label ID="lblShelfText" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"shelf_name") %>'></asp:Label>
                                                                                            </a>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                            </FooterTemplate>
                                                                        </asp:DataList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    
                                                                    <td valign="top" colspan="2">
                                                                        
                                                                    </td>
                                                                </tr>
                                                                <%-- <tr>
                                                                    <td height="1px">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>--%>
                                                            </table>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                        </FooterTemplate>
                                                    </asp:DataList>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </asp:Panel>
                                </td>
                                <td valign="top" align="left" style="padding-right: 10px;" width="35%">
                                    <uc1:UserScript ID="UserScript1" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
