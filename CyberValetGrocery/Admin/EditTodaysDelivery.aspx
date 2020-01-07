<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="EditTodaysDelivery.aspx.cs" Inherits="CyberValetGrocery.Admin.EditTodaysDelivery" %>
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
                    <legend>Update Pick Up Info  </legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="30" class="formText">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="2" class="FieldText">
                                            Field with a <span class="star">*</span> are required
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10px" colspan="2">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="46%">
                                        </td>
                                        <td width="28%" height="40" colspan="2">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                                            <asp:Label ID="lblMsg" CssClass="formText" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                            <span class="star">*</span>Start Time:
                                        </td>
                                        <td width="28%" height="40">
                                            <asp:TextBox ID="txtStartTime" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvstartTime" runat="server" ControlToValidate="txtStartTime"
                                                ErrorMessage="Start time is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                        <td width="28%" height="40">
                                            <asp:DropDownList ID="drpStartTime" runat="server" CssClass="DropDownBox">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">AM</asp:ListItem>
                                                <asp:ListItem Value="2">PM</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvSTime" runat="server" ControlToValidate="drpStartTime"
                                                ErrorMessage="Select start time" ForeColor="White" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                            <span class="star">*</span>End Time:
                                        </td>
                                        <td width="28%" height="40">
                                            <asp:TextBox ID="txtEndTime" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <span style="padding-left: 5px;"></span>
                                            <asp:RequiredFieldValidator ID="rfvEndTime" runat="server" ControlToValidate="txtEndTime"
                                                ErrorMessage="End time is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                        <td width="28%" height="40">
                                            <asp:DropDownList ID="drpEndTime" runat="server" CssClass="DropDownBox">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">AM</asp:ListItem>
                                                <asp:ListItem Value="2">PM</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvTime" runat="server" ControlToValidate="drpEndTime"
                                                ErrorMessage="Select end time" ForeColor="White" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText" valign="top">
                                            Show:
                                        </td>
                                        <td height="40" class="formText">
                                            <asp:RadioButtonList ID="rdShow" runat="server" CssClass="Radiobutton">
                                                <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td height="40">
                                        </td>
                                    </tr>
                                    <%--    <tr>
                                        <td align="right" class="formText" valign="top">
                                            <span class="star">*</span>Top Aisles:
                                        </td>
                                        <td height="40" class="formText" style="padding: 3px;">
                                            <asp:CheckBoxList ID="chkTopAisles" runat="server">
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>--%>
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
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" OnClick="btnUpdate_Click" />
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
</asp:Content>
