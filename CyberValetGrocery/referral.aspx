<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="referral.aspx.cs" Inherits="CyberValetGrocery.referral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script type="text/javascript">

    var Image28 = document.getElementById("Image28");
    var Image29 = document.getElementById("Image29");
    var Image30 = document.getElementById("Image30");
    var Image31 = document.getElementById("Image31");
    var Image32 = document.getElementById("Image32");
    var Image27 = document.getElementById("Image27");
    var Image33 = document.getElementById("Image33");
    var Image34 = document.getElementById("Image34");
    //alert(img1);
    Image28.src = "images/referaFrnd-h.png";
    Image29.src = "images/loyaltyProgarm-btn.png";
    Image30.src = "images/deliveryInfo-btn.png";
    Image31.src = "images/aboutUs-btn.png";
    Image32.src = "images/myShoppingList-btn.png";
    Image27.src = "images/accountFunds-btn.png";
    Image33.src = "images/FAQ-btn.png";
    Image34.src = "images/contactUs-btn.png";
    </script>
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td class="formHeading">
                        Refer a Friend
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" style="padding-right:20px;" >
                        <b>How?</b><br />
                        Use the form below to email your friends about &nbsp;<asp:Label ID="lblCmpNm" runat="server"></asp:Label>. Get them to sign up and for each one that places an order, you will receive $5
                        of Account Funds! There is no limit on how many friends you can get to order.
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>To get your name as the referral:</strong>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" style="padding-right:20px;">
                        Your friend must add your name in the bottom of the "Become a Member" form (shown
                        below). Once they place their first order, we will deposit $5 into your account
                        and you will be notified by email.
                    </td>
                </tr>
                <tr>
                    <td>
                        <center>
                            <img src="images/referral.gif" alt="" width="457" height="222" border="0" /></center>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        Use the form below to email your friends. <a href="#" class="Userlink1" onclick='openReferFriendsPopUp()'>
                            View the email message that is sent </a>:
                    </td>
                </tr>
                <tr>
                    <td height="10px">
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <table cellpadding="3" cellspacing="0" border="0">
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    Field with a <span class="star1">*</span> are required
                                </td>
                            </tr>
                            <tr>
                                <td height="3px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" style="padding-left: 100px;">
                                    <asp:Label ID="lblMsg" CssClass="formTextUSer" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td height="3px">
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right">
                                    <span class="star1">*</span>Your Name:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtYourName" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" Text="*" ControlToValidate="txtYourName"
                                        ErrorMessage="Your name is required" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right">
                                    <span class="star1">*</span>Your Email:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtYourEmail" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFName" runat="server" Text="*" ControlToValidate="txtYourEmail"
                                        ErrorMessage="Your email is required" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right">
                                    Personal Message:
                                </td>
                                <td valign="top">
                                    <asp:TextBox ID="txtPerMsg" runat="server" CssClass="textMultiline" MaxLength="2000"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="5px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding-left: 10px; color: #003b65;">
                                    <strong>Friend Information</strong>
                                </td>
                            </tr>
                            <tr>
                                <td height="5px">
                                </td>
                            </tr>
                            <tr valign="top">
                                <td colspan="2" style="padding-left: 10px;">
                                    <table cellpadding="3" cellspacing="0" border="0">
                                        <tr valign="top">
                                            <td align="right">
                                               1. <span class="star1">*</span>Name:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtName1" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Text="*" ControlToValidate="txtName1"
                                                    ErrorMessage="Name is required" ForeColor="White"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right">
                                                <span class="star1">*</span>Email:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmail1" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                                    ControlToValidate="txtEmail1" ErrorMessage="Email is required" ForeColor="White"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td colspan="5">
                                        
                                        <hr size=-1 color="#fcd500"/>
                                        
                                        </td>
                                        </tr>
                                        <tr valign="top">
                                            <td align="right">
                                               2.&nbsp;&nbsp; Name:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtName2" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                Email:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmail2" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td colspan="5">
                                        
                                        <hr size=-1 color="#fcd500"/>
                                        
                                        </td>
                                        </tr>
                                        <tr valign="top">
                                            <td align="right">
                                               3.&nbsp;&nbsp; Name:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtName3" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                Email:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmail3" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left" style="padding-left: 15px;">
                                    <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="buttonUser" OnClick="btnSend_Click" />
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
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
