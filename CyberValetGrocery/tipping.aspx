<%@ Page Title="" Language="C#" MasterPageFile="~/UserLoginMasterPage.Master" AutoEventWireup="true"
    CodeBehind="tipping.aspx.cs" Inherits="CyberValetGrocery.tipping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td align="center">
                        <table cellpadding="0" cellspacing="0" border="0" width="80%" style="padding-left: 10px;">
                            <tr>
                                <td height="20px">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="formHeading">
                                    <strong>Add a Tip</strong>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr valign="top">
                                            <td width="135">
                                                <img src="images/checkout_2.gif" alt="confirm delivery address" width="135" height="37"
                                                    border="0" />
                                            </td>
                                            <td width="122">
                                                <img src="images/checkout_1.gif" alt="pick a delivery time" width="122" height="37"
                                                    border="0" />
                                            </td>
                                            <td width="131">
                                                <img src="images/checkout_3c.gif" alt="tip the delivery driver" width="131" height="37"
                                                    border="0" />
                                            </td>
                                            <td width="109">
                                                <img src="images/checkout_4b.gif" alt="payment method" width="109" height="37" border="0" />
                                            </td>
                                            <td width="103">
                                                <img src="images/checkout_5b.gif" alt="complete order" width="103" height="37" border="0" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="20px">
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextUSer">
                                    <strong>The total for this order is:&nbsp;<asp:Label ID="lblArr" runat="server" Text="$"
                                        CssClass="ErrorTxt1"></asp:Label><asp:Label ID="lblTotal" runat="server" CssClass="ErrorTxt1"></asp:Label></strong>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextUSer">
                                    <strong>Would you like to add a tip for your delivery driver?</strong> Tipping is
                                    completely optional, but always appreciated. 100% of your tip will go to your specific
                                    driver. You may add a tip now or when you sign for your groceries.
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                </td>
                            </tr>
                            <tr>
                                <td height="10px" align="left">
                                <asp:Label ID="lblMsg1" CssClass="ErrorTxtNew2" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextUSer">
                                    <table>
                                        <tr>
                                            <td>
                                                <strong>Amount:</strong>
                                            </td>
                                            <td style="padding-left: 10px;" valign="top">
                                                <strong>$</strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAmt" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="padding-left: 10px;" valign="top">
                                                <asp:Label ID="lblMsg" runat="server" Text="(Please do not include the $)" CssClass="ErrorTxt1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:RadioButtonList ID="rdTips" runat="server" OnSelectedIndexChanged="rdTips_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                    <asp:ListItem Value="1">Not at this time </asp:ListItem>
                                                    <asp:ListItem Value="2">5%</asp:ListItem>
                                                    <asp:ListItem Value="3">10%</asp:ListItem>
                                                    <asp:ListItem Value="4">15%</asp:ListItem>
                                                    <asp:ListItem Value="5">20%</asp:ListItem>
                                                    <asp:ListItem Value="6">To tip a different amount, simply enter it in the box above.</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Button ID="btnAddTips" runat="server" Text="Add Tips" CssClass="buttonUser"
                                                    OnClick="btnAddTips_Click" />
                                            </td>
                                        </tr>
                                    
                                    <tr>
                                    <td colspan="2">
                                            </td>
                                    <td colspan="2" class="formTextUSer">Please ignore if you have selected our Pickup Service</td>
                                    
                                    </tr>
                                    
                                    
                                    
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
