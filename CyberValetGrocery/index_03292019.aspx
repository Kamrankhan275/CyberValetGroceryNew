<%@ Page Title="" Language="C#" MasterPageFile="~/UserLoginMasterPage.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="CyberValetGrocery.index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="jsNew/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link href="jsNew/jquery-ui-1.10.2.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="jsNew/jquery-ui.custom.min.js" type="text/javascript"></script> 	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>            
            <table width="1054" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <%--<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0"
                            width="1054" height="315" id="main" align="middle">
                            <param name="allowScriptAccess" value="sameDomain">
                            <param name="movie" value="banner.swf">
                            <param name="quality" value="high">
                            <param name="wmode" value="transparent">
                            <embed src="banner.swf" quality="high" width="1054" height="315" name="main" align="middle"
                                wmode="transparent" allowscriptaccess="sameDomain" type="application/x-shockwave-flash"
                                pluginspage="http://www.macromedia.com/go/getflashplayer">
                        </object>--%>
<img src="images/banner1.jpg" />
                    </td>
                </tr>
                <tr>
                    <td height="18">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="25">
                                </td>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="302" align="left" valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="324" height="302" align="center" valign="middle" bgcolor="#0d0b0a">
                                                            <table width="255" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="255" height="233" align="center" valign="top" style="background-image: url(images/nowDeliveringBG.png);
                                                                        background-repeat: no-repeat; background-position: top center;">
                                                                        <table width="190" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td height="70" align="center" valign="middle" class="NowDelivering">
                                                                                    Delivery Zip Codes
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="40" align="center" valign="bottom">
                                                                                    <asp:DropDownList ID="drpZip" runat="server" CssClass="dropDown">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr align="center" valign="bottom">
                                                                                <td height="44">
                                                                                    <a href="Shop.aspx">
                                                                                        <img src="images/startShopping_Btn.png" width="133" height="24" border="0" /></a>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="40" align="center" valign="bottom" class="bold12pxBlack">
                                                                                    Don’t see your zip? <a href="AddNonDeliveryZone.aspx" class="clickHere">Click here</a>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td height="302" align="center" valign="top" bgcolor="#FFFFFF">
                                                            <table width="600" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td height="32">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr align="left" valign="top">
                                                                    <td height="40">
                                                                        <%--<span class="bold22pxBlack">Welcome to </span><span class="bold24pxOrange"> Cyber Valet Grocery </span>--%>
                                                                        <span class="bold22pxBlack">Welcome to </span><span class="bold24pxOrange">Cyber Valet
                                                                            Grocery</span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="welcomeText" height="150">
                                                                        <asp:Label ID="lblHomepageText" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="50" class="shop">
                                                                        <img src="images/shop.png" width="300" height="35" alt="shop" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="18">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="369" align="left" valign="top" class="mainBoxBorder" style="background-image: url(images/boxGradient.png);
                                                background-repeat: repeat-x;">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="42" height="35">
                                                            &nbsp;
                                                        </td>
                                                        <td height="35">
                                                            &nbsp;
                                                        </td>
                                                        <td width="42" height="35">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="42">
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="306" height="295" align="left" valign="top">
                                                                        <table width="306" border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <%-- <td width="275" height="50" align="center" valign="middle" class="bold16px" style="background-image: url(images/testimonialTextBG.png);
                                                                                    background-repeat: no-repeat; background-position: top;">
                                                                                    Customer Testimonial
                                                                                </td>--%>
                                                                                <td width="275" height="50" align="center" valign="middle" class="bold16px">
                                                                                    3 Easy Ways to Order
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="245" align="center" valign="top" style="background-image: url(images/boxBottmBG.png);
                                                                                    background-repeat: no-repeat; background-position: bottom;">
                                                                                    <table width="262" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td height="20">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="black15pxBold">
                                                                                                <table width="269" border="0" cellspacing="0" cellpadding="0" align="left">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            1.
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            Online : www.cybervaletgrocery.com
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td height="10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            2.
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            Email : Charles@cybervaletgrocery.com
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td height="10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            3.
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            Phone : 843-290-3191
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td height="50" align="right" valign="bottom">
                                                                                                <a href="how.aspx">
                                                                                                    <img src="images/readMore_Btn.png" width="107" height="34" border="0" /></a>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td width="3" height="295" align="center" valign="bottom">
                                                                        <img src="images/boxDivider.png" width="3" height="245" />
                                                                    </td>
                                                                    <td width="306" height="295">
                                                                        <table width="306" border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td width="275" height="50" align="center" valign="middle" class="bold16px" style="background-image: url(images/weeklySaleItemTextBG.png);
                                                                                    background-repeat: no-repeat; background-position: top;">
                                                                                    This Week’s Sale
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="245" align="center" valign="top" style="background-image: url(images/boxBottmBG.png);
                                                                                    background-repeat: no-repeat; background-position: bottom;">
                                                                                    <table width="262" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td height="20">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr align="left" valign="bottom">
                                                                                                        <td width="131" height="165">
                                                                                                            <%--<img src="images/product.png" width="131" height="145" />--%><asp:Image ID="imgSaleImage"
                                                                                                                runat="server" Width="131" Height="145" Style="border: 3px solid #666;" />
                                                                                                        </td>
                                                                                                        <td height="165" align="center" valign="middle">
                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                                <tr>
                                                                                                                    <td align="center" class="orange23pxBold">
                                                                                                                        $
                                                                                                                        <asp:Label ID="lblSalesPrice" runat="server"></asp:Label>*<br />
                                                                                                                        <br />
                                                                                                                        <p>
                                                                                                                            <asp:Label ID="lblSalesTxt" runat="server" CssClass="black15pxBold"></asp:Label></p>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <%--<tr valign="middle">
                       <td height="60" align="center" class="black15pxBold">Tide<br />
                        Laundry Detergent<br />
                        150oz Jug<br /></td>
                      </tr>--%>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td height="50" align="right" valign="bottom">
                                                                                                <a href="sales.aspx">
                                                                                                    <img src="images/readMore_Btn.png" width="107" height="34" border="0" /></a>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td width="3" height="295" align="center" valign="bottom">
                                                                        <img src="images/boxDivider.png" width="3" height="245" />
                                                                    </td>
                                                                    <td height="295">
                                                                        <table width="306" border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td width="275" height="50" align="center" valign="middle" class="bold16px" style="background-image: url(images/signupTodayTextBG.png);
                                                                                    background-repeat: no-repeat; background-position: top;">
                                                                                    Signup Today
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="245" align="center" valign="top" style="background-image: url(images/boxBottmBG.png);
                                                                                    background-repeat: no-repeat; background-position: bottom;">
                                                                                    <table width="262" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td height="20">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr align="left" valign="bottom">
                                                                                                        <td width="131" height="50" align="center" class="White18px">
                                                                                                            <%--  Get <span style="color: #ff6600;">$10 off</span><br />
                                                                                                            your First Delivery--%>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr align="left" valign="bottom">
                                                                                                        <td height="115" align="center">
                                                                                                            <img src="images/deliverVan.png" width="123" height="101" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td height="50" align="right" valign="bottom">
                                                                                                <a href="CheckZipCode.aspx">
                                                                                                    <img src="images/Signup-btn.png" width="107" height="34" border="0" /></a>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td width="42">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="42" height="35">
                                                            &nbsp;
                                                        </td>
                                                        <td height="35">
                                                            &nbsp;
                                                        </td>
                                                        <td width="42" height="35">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="25">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="32">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
