﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="Aboutcompany.aspx.cs" Inherits="CyberValetGrocery.Aboutcompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">


//         var Image11 = document.getElementById("Image11");
//         var Image12 = document.getElementById("Image12");
//         var Image13 = document.getElementById("Image13");
//         var Image14 = document.getElementById("Image14");
//         var Image15 = document.getElementById("Image15");

//         Image11.src = "images/DI-btn.gif";
//         Image12.src = "images/Faq-btn.gif";
//         Image13.src = "images/MSL-btn.gif";
//         Image14.src = "images/AF-btn.gif";
    //         Image15.src = "images/AU-btn-h.gif";
    var Image28 = document.getElementById("Image28");
    var Image29 = document.getElementById("Image29");
    var Image30 = document.getElementById("Image30");
    var Image31 = document.getElementById("Image31");
    var Image32 = document.getElementById("Image32");
    var Image27 = document.getElementById("Image27");
    var Image33 = document.getElementById("Image33");
    var Image34 = document.getElementById("Image34");

    //alert(img1);
    Image28.src = "images/referaFrnd-btn.png";
    Image29.src = "images/loyaltyProgarm-btn.png";
    Image30.src = "images/deliveryInfo-btn.png";
    Image31.src = "images/aboutUs-h.png";
    Image32.src = "images/myShoppingList-btn.png";
    Image27.src = "images/accountFunds-btn.png";
    Image33.src = "images/FAQ-btn.png";
    Image34.src = "images/contactUs-btn.png";
  
    </script>
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table cellpadding="4" cellspacing="0" border="0"  width="580px">
                <tr>
                    <td class="formHeading" align="left">
                        About the Company
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" align="left" style="padding-right: 20px;">
                    Cyber Valet Grocery started with the idea that we can help you save time and money by offering a pleasant on-line grocery store with delivery to your home or office.
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" align="left" style="padding-right: 20px;">
                        Our motto “Shop On-Line, Not In line” summarizes the shopping experience our customers enjoy by cyberspace. We want you to get back to the things that you want to do, and leave the shopping to us.
</td>
                </tr>
                <tr>
                    <td class="formTextUSer" align="left" style="padding-right: 20px;">
                       Our relationship with local businesses enables us to provide comparable prices with quality products. We look forward to your business!
                    </td>
                </tr>
                
                <tr>
                    <td height="40px">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
