<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="EditDeliveryDate.aspx.cs" Inherits="CyberValetGrocery.Admin.EditDeliveryDate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <script type="text/javascript">
      function clcontent() {
          var lb1 = document.getElementById("<%= lblMsg.ClientID %>");
          lb1.innerHTML = "";
      }


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script language="JavaScript1.2">showHide("sitefunctions");</script>

    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="update1" runat="server">
        <ContentTemplate>
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="left" class="Logoutlink">
                        <table width="70%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="91%">
                                    &nbsp;
                                </td>
                                <td width="9%">
                                    <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../images/backbutton.jpg"
                                        Width="71" Height="23" border="0" OnClick="imgBack_Click" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <fieldset>
                            <legend>Edit Delivery Date </legend>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="30" class="formText">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td colspan="2" class="FieldText">
                                                    Field with a <span class="star">*</span> are required
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="23%">
                                                </td>
                                                <td align="left">
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                                                    <asp:Label ID="Label1" CssClass="formText" runat="server"></asp:Label>
                                                    <asp:Label ID="lblMsg" CssClass="formText" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="44%" align="right" class="formText">
                                                    <span class="star">*</span>Delivery Date:
                                                </td>
                                                <td width="56%" height="40"><br />
                                              <%--  <asp:DropDownList runat="server" ID="ddlDate" CssClass="DropDownBox"></asp:DropDownList><br /><br />--%><%--AutoPostBack="True" onselectedindexchanged="ddlDate_SelectedIndexChanged"--%>
                                                   <asp:TextBox ID="txtDeliveryDate" runat="server" CssClass="textBox" Enabled="false"></asp:TextBox>
                                                   <%--<span style="padding-left: 5px;"></span>
                                                    <img id="imgCalendar" src="../images/CalendorIcon.jpg" />
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                        Enabled="True" Format="MM/dd/yyyy" PopupButtonID="imgCalendar" TargetControlID="txtDeliveryDate">
                                                    </cc1:CalendarExtender>--%>
                                                  <%--  <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                        Enabled="True" Format="MM/dd/yyyy" PopupButtonID="imgCalendar" TargetControlID="txtDeliveryDate">
                                                    </cc1:CalendarExtender>--%>
                                                  <%--<asp:RequiredFieldValidator ID="reqeffDate" runat="server" ControlToValidate="txtDeliveryDate"
                                                        ErrorMessage="Delivery date is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="formText">
                                                    <span class="star">*</span>Location:
                                                </td>
                                                <td height="40">
                                                    <asp:DropDownList ID="drpLocation" runat="server" CssClass="DropDownBox">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ControlToValidate="drpLocation"
                                                        ErrorMessage="Select location" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="formText" valign="top">
                                                    <span class="star">*</span> Zip Code:
                                                </td>
                                                <td height="40" class="formText" style="padding-left: 10px;">
                                                    
                                                    <asp:CheckBoxList ID="lisZip" runat="server" RepeatColumns="3">
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="formText" valign="top">
                                                </td>
                                                <td height="40" class="formText" align="left">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:DataList ID="dtlDelieveryTime" runat="server" GridLines="None" RepeatDirection="Vertical">
                                                                    <HeaderTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <strong>Hours:</strong>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                    <strong># Per Slot:</strong>
                                                                                </td>
                                                                            </tr>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblTimeID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"deliverytime_id") %>'
                                                                                    Visible="false"></asp:Label>
                                                                            </td>
                                                                            <td align="center">
                                                                                <asp:CheckBox ID="chkDelieveryTime" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"deliverytime_time") %>' checked="true"/>
                                                                               <%--<asp:Label ID="lblDeliveryTime" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"deliverytime_time") %>' ></asp:Label>--%>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtTime" runat="server" CssClass="textBoxDateSmall" MaxLength="2" Text='<%#DataBinder.Eval(Container.DataItem,"deliverytime_capacity") %>' ></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                </asp:DataList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="formText">
                                                    &nbsp;
                                                </td>
                                                <td height="20" style="padding-left: 10px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="formText">
                                                    &nbsp;
                                                </td>
                                                <td height="40" style="padding-left: 10px;">
                                                    <asp:Button ID="btnAdd" runat="server" Text="Update" CssClass="button" OnClick="btnAdd_Click" />
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
                    <td>
                        <table width="70%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="91%">
                                    &nbsp;
                                </td>
                                <td width="9%">
                                    <asp:ImageButton ID="imgBack1" runat="server" ImageUrl="../images/backbutton.jpg"
                                        Width="71" Height="23" border="0" OnClick="imgBack1_Click" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
