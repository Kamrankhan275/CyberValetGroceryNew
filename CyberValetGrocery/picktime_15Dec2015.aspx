<%@ Page Title="" Language="C#" MasterPageFile="~/UserLoginMasterPage.Master" AutoEventWireup="true" CodeBehind="picktime_15Dec2015.aspx.cs" Inherits="CyberValetGrocery.picktime_15Dec2015" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0" border="0" height="700px">
                <tr>
                    <td align="center" bgcolor="#FFFFFF" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" width="80%" style="padding-left: 10px;">
                            <tr>
                                <td height="20px">
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="left" class="formHeading" valign="top">
                                    <strong>Pick Your Delivery Time</strong>
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
                                                <img src="images/checkout_1c.gif" alt="pick a delivery time" width="122" height="37"
                                                    border="0" />
                                            </td>
                                            <td width="131">
                                                <img src="images/checkout_3b.gif" alt="tip the delivery driver" width="131" height="37"
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
                                    Please choose a delivery time below from the next upcoming delivery dates:
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 50px;">
                                    <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                </td>
                            </tr>
                            <asp:Panel ID="pnlDelivery" runat="server">
                                <tr>
                                    <td class="formTextUSer">
                                        Please Select Delivery Option:
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10px" align="left" style="padding-left: 200px">
                                        <asp:DropDownList ID="drpDelivery" runat="server" CssClass="DeliveryDropDown" OnSelectedIndexChanged="drpDelivery_SelectedIndexChanged"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvDelivery" runat="server" ControlToValidate="drpDelivery"
                                            ErrorMessage="Select delivery" ForeColor="White" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="pnlStoreLocation" runat="server" Visible="false">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPickLocation" Style="font-weight: bold;" Text="Store Location:"
                                            runat="server"> </asp:Label>
                                        <asp:DropDownList ID="ddlstoreLocation" runat="server" CssClass="DeliveryDropDown"
                                            Style="margin-top: 0px;" AppendDataBoundItems="true">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator InitialValue="0" ID="StoreRequiredField" runat="server"
                                            ControlToValidate="ddlstoreLocation" ErrorMessage="Select Store">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td height="10px">
                                    &nbsp;
                                </td>
                            </tr>
                            <asp:Panel ID="pnlDeldate" runat="server">
                                <asp:DataList ID="dtlDeliveryGrid" runat="server" GridLines="None" RepeatDirection="Horizontal"
                                    RepeatColumns="3" ItemStyle-VerticalAlign="Top">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Panel ID="pnlGrid" runat="server">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td valign="top">
                                                        <table border="0" align="center" cellpadding="0" cellspacing="0" class="tableBorderPickTime"
                                                            width="100%">
                                                            <tr>
                                                                <td valign="top" align="left" class="picktimeHeaderText" nowrap="nowrap">
                                                                    <asp:Label ID="lblDeliveryDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DelDate")%>'> </asp:Label>
                                                                    <asp:Label ID="lblDelId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DelId")%>'
                                                                        Visible="false"> </asp:Label>
                                                                    <asp:Label ID="lblDelDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DDate")%>'
                                                                        Visible="false"> </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" align="left" class="formTextUSer">
                                                                    <asp:RadioButtonList ID="rdChkTime" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdChkTime_SelectedIndexChanged">
                                                                    </asp:RadioButtonList>
                                                                    <asp:Label ID="lblNoTime" runat="server" Visible="false" CssClass="ErrorTxt1"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:DataList>
                            </asp:Panel>
                            <asp:Panel ID="pnlTodaysDelivery" runat="server">
                                <tr>
                                    <td class="formTextUSer">
                                        Pick your Delivery Time:
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10px">
                                        <asp:Label ID="lblTime" runat="server" CssClass="formTextUSer" Visible="false"></asp:Label>
                                        <asp:Label ID="lblNmTime" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblTimeForMinute" runat="server" CssClass="formTextUSer" Visible="false"></asp:Label>
                                        <asp:Label ID="lblCurrentTime" runat="server" CssClass="formTextUSer" Visible="false"></asp:Label>
                                        <asp:Label ID="lblNextTime" runat="server" CssClass="formTextUSer" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" width="175px">
                                            <tr>
                                                <td valign="top" align="center">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gridTimeInfo" runat="server" AutoGenerateColumns="False" Width="175px"
                                                                    AllowPaging="true" GridLines="Horizontal" CellPadding="0" CellSpacing="0" ItemStyle-VerticalAlign="Top">
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>
                                                                                <center>
                                                                                    Todays Pick up Hours</center>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:RadioButtonList ID="rdBtnChkTime" runat="server">
                                                                                </asp:RadioButtonList>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <PagerStyle CssClass="pagingUsertext" ForeColor="#FFFFFF" />
                                                                    <HeaderStyle CssClass="gridUserheading" ForeColor="#404248" />
                                                                    <AlternatingRowStyle CssClass="gridUserAlternatetext" />
                                                                    <RowStyle CssClass="gridUsertext" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="10px;">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="buttonUser" OnClick="btnSubmit_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="50px">
                                                    &nbsp;
                                                </td>
                                                <td valign="top" align="left">
                                                </td>
                                                <td width="50px">
                                                    &nbsp;
                                                </td>
                                                <td valign="top" align="center">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="250" class="border">
                                                        <tr>
                                                            <td width="100%" class="gridUserheading" valign="middle">
                                                                <center>
                                                                    Note</center>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" class="gridUsertext">
                                                                Please note our pick up cut off information below.
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" cellspacing="0" border="0" width="250" class="border">
                                                        <tr>
                                                            <td valign="top" width="" class="gridUsertext">
                                                                We deliver seven days a week, from 12 p.m. to 8 p.m.<br />
                                                                <br />
                                                                Please note that you must place your order by 4 p.m. the day of your pick up.
                                                                <br />
                                                                Orders placed after 4 p.m. will not be delivered until the next pick up day.<br />
                                                                <br />
                                                                <!--Please give us a call when you are on your way at <strong></strong>
                                                                        and we will meet you at your car under our portico.<br />
                                                                        <br />-->
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 270px;">
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="pnlImmediateDelivery" runat="server">
                                <tr>
                                    <td height="10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextUSer">
                                        Delivery Options Below:
                                    </td>
                                </tr>
                                <tr>
                                    <td height="20px">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td valign="top" align="center">
                                                    <table border="0" align="center" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td valign="top" align="right" nowrap="nowrap">
                                                                <span class="formTextUSer">Estimated time<br />
                                                                    order will ship in the next 24 hrs:</span>
                                                            </td>
                                                            <td valign="top" align="left" nowrap="nowrap">
                                                                <asp:Label ID="lblStartTime" runat="server" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblAM" runat="server" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblEndTime" runat="server" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblPM" runat="server" Visible="false"></asp:Label>
                                                                <asp:TextBox ID="txtImmediatedel" runat="server" CssClass="textbox1" MaxLength="10"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td valign="top" align="right" nowrap="nowrap">
                                                            </td>
                                                            <td valign="top" align="right" nowrap="nowrap">
                                                            </td>
                                                            <td valign="top" align="left" nowrap="nowrap">
                                                                <tr>
                                                                    <td valign="top" style="padding-left: 75px;" align="left" nowrap="nowrap">
                                                                        <asp:Button ID="btnImmdiateDelSubmit" runat="server" Text="Submit" CssClass="buttonUser"
                                                                            OnClick="btnImmdiateDelSubmit_Click" />
                                                                    </td>
                                                                </tr>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="50px">
                                                    &nbsp;
                                                </td>
                                                <td valign="top" align="center">
                                                    <br />
                                                    <table cellpadding="0" cellspacing="0" border="0" width="250" class="border">
                                                        <tr>
                                                            <td width="100%" class="gridUserheading" valign="middle">
                                                                <center>
                                                                    Note</center>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" class="gridUsertext">
                                                                Please note our delivery cut off information below.
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" cellspacing="0" border="0" width="250" class="border">
                                                        <tr>
                                                            <td valign="top" width="" class="gridUsertext">
                                                                We deliver seven days a week, from 12 p.m. to 8 p.m.<br />
                                                                <br />
                                                                Please note that you must place your order by 4 p.m. the day of your delivery.
                                                                <br />
                                                                Orders placed after 4 p.m. will not be delivered until the next delivery day.<br />
                                                                <br />
                                                                Please give us a call when you are on your way at <strong>614-846-3220</strong>
                                                                and we will meet you at your car under our portico.<br />
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="padding-left: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10px">
                                        &nbsp;
                                    </td>
                                </tr>
                            </asp:Panel>
                        </table>
                        <table cellpadding="0" cellspacing="0" border="0" width="80%" style="padding-left: 10px;
                            margin-top: -140px;">
                            <tr style="margin-left: 200px;" runat="server" id="trFuture">
                                <td class="formTextUSer" align="left">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        Or, choose from another future delivery date:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table cellspacing="0" border="0" class="formTextUSer">
                                                            <tr>
                                                                <td>
                                                                    Date:
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="drpFutureDate" runat="server" CssClass="DropDown" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="drpFutureDate_SelectedIndexChanged">
                                                                        <asp:ListItem></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="10px">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        Time:
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="drpFutureDateTime" runat="server" CssClass="DeliveryDropDown">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="Panel2" runat="server">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        Time:
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="DropDown">
                                                                            <asp:ListItem Selected="True">Select</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="10px">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 270px;">
                                                        <asp:Button ID="btnChoose" runat="server" Text="Choose Date/Time" CssClass="buttonUser"
                                                            OnClick="btnChoose_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="65px">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </td>
                            </tr>
                            <asp:Panel runat="server" ID="pnlFutureDate">
                            </asp:Panel>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
