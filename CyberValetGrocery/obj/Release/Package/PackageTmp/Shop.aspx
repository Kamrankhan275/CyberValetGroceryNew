<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="Shop.aspx.cs" Inherits="CyberValetGrocery.Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   

    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table>
          
          <tr><td height="10px;"></td></tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlDeliveryInfo" runat="server">
                         <span class="formTextUSer" style="padding-top: 2px;" align="center"><strong>Start shopping today and enjoy the Cyber Valet Grocery experience - where groceries arrive fresh and fast!
                               </strong>
                                
                                
                            <br />
                            <span class="formTextUSer" style="padding-top: 2px; padding-left: 45px;"><strong>Next
                                delivery dates are: </strong>
                                <asp:Label ID="lblDeliveryDate1" runat="server" CssClass="ErrorTxt1" Text=""></asp:Label>
                                &nbsp;&nbsp;&nbsp;<asp:Label ID="lbland" runat="server" Text="and" CssClass="formTextUSer"></asp:Label>
                                <asp:Label ID="lblDeliveryDate2" runat="server" CssClass="ErrorTxt1" Text=""></asp:Label></span>
                            <br />
                            <hr size="-1" color="#fcd500">
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td height="2px">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <span class="formHeading"><strong>Choose an Aisle</strong></span>
                    </td>
                </tr>
                <tr>
                    <td height="2px">
                    </td>
                </tr>
                   <tr>
                    <td align="center">
                        <asp:DataList ID="HighlightTopAisle" runat="server" RepeatDirection="Vertical" RepeatColumns="4">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <a href='shelf.aspx?aisle=<%# Eval("aisletop_id") %>'>
                                                <asp:Image ID="imgProduct" runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"aisletop_image").ToString()) %>'
                                                    Width="84" Height="78" />
                                            </a>
                                        </td>
                                        <td width="10px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <asp:Panel ID="pnlHighLight" runat="server">
                 <tr>
                    <td height="2px">
                    <hr />
                    </td>
                </tr>
                 </asp:Panel>
                <tr>
                    <td>
                        <asp:DataList ID="dtlAislesDetail" runat="server" RepeatDirection="Vertical" RepeatColumns="4">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <a href='shelf.aspx?aisle=<%# Eval("aisletop_id") %>'>
                                                <asp:Image ID="imgProduct" runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"aisletop_image").ToString()) %>'
                                                    Width="84" Height="78" />
                                            </a>
                                        </td>
                                        <td width="10px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
