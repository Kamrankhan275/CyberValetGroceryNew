<%@ Page Title="Delivery Reminders" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="admin_deliveryreminder.aspx.cs" ValidateRequest="false" Inherits="CyberValetGrocery.Admin.admin_deliveryreminder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="JavaScript1.2">showHide("sitefunctions");</script>

   <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>Delivery Reminders </legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="30" class="formText" nowrap="nowrap">
                                Choose a delivery date below to send out delivery reminders to customers...
                            </td>
                        </tr>
                        <tr>
                            <td height="3px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="46%" align="left" colspan="2" class="FieldTextSearch">
                                Field with a <span class="star">*</span> are required
                            </td>
                        </tr>
                        <tr>
                            <td width="46%" align="left" colspan="2" style="padding-left: 125px">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                                <asp:Label ID="lblMsg" CssClass="formText" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                <table width="80%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30%" align="right" nowrap="nowrap">
                                            <span class="formText"><span class="star">*</span>Delivery Date:</span>
                                        </td>
                                        <td width="70%">
                                            <asp:DropDownList ID="drpDeliveryDate" runat="server" CssClass="DropDownBox">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvDelivery" runat="server" ControlToValidate="drpDeliveryDate"
                                                ErrorMessage="Select delivery date" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                        <td style="padding-left: 10px;">
                                            <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="button" OnClick="btnSend_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td height="30" class="formText">
                <strong>Following delivery dates have been recently reminded: </strong>
            </td>
        </tr>
        <tr>
            <td height="30" class="formText">
                <asp:GridView ID="gridDeliveryReminderSentEmail" runat="server" AutoGenerateColumns="False"
                    Width="600px" AllowPaging="true" CssClass="gridBorder" CellPadding="0" CellSpacing="0"
                    AllowSorting="True"  PageSize="10" onpageindexchanging="gridDeliveryReminderSentEmail_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                
                                <asp:Label ID="Date"  runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "deliverydate_date").ToString()).Month + "/" + Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "deliverydate_date").ToString()).Day + "/" + Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "deliverydate_date").ToString()).Year%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Location">
                            <ItemTemplate>
                                <asp:Label ID="lblLocation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "location_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagingtext" ForeColor="#FFFFFF" />
                    <HeaderStyle CssClass="grideheading" ForeColor="#404248" />
                    <AlternatingRowStyle CssClass="grideAlternatetext" />
                    <RowStyle CssClass="gridetext" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td height="5px">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlEmail" runat="server" Visible="false">
                    <table>
                        <tr>
                            <td height="30" class="formText">
                                <strong>Email reminders were sent to the following customers:</strong>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" class="formText">
                                <asp:GridView ID="gridCustomerInfo" runat="server" AutoGenerateColumns="False" Width="600px"
                                    AllowPaging="true" CssClass="gridBorder" CellPadding="0" CellSpacing="0" AllowSorting="True" PageSize="10" onpageindexchanging="gridCustomerInfo_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Customer Name">
                                            <ItemTemplate>
                                                <asp:Label ID="users_fname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_fname")%>'></asp:Label>
                                                <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_lname")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pagingtext" ForeColor="#FFFFFF" />
                                    <HeaderStyle CssClass="grideheading" ForeColor="#404248" />
                                    <AlternatingRowStyle CssClass="grideAlternatetext" />
                                    <RowStyle CssClass="gridetext" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
