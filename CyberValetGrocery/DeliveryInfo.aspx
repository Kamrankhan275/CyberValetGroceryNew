<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="DeliveryInfo.aspx.cs" Inherits="CyberValetGrocery.DeliveryInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: normal;
            color: #000000;
            text-align: justify;
            height: 19px;
        }
        p.MsoNormal
	{margin-bottom:.0001pt;
	font-size:12.0pt;
	font-family:"Times New Roman";
	        margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <script type="text/javascript">
//      var Image11 = document.getElementById("Image11");
//      var Image12 = document.getElementById("Image12");
//      var Image13 = document.getElementById("Image13");
//      var Image14 = document.getElementById("Image14");
//      var Image15 = document.getElementById("Image15");
//      Image11.src = "images/DI-btn-h.gif";
//      Image12.src = "images/Faq-btn.gif";
//      Image13.src = "images/MSL-btn.gif";
//      Image14.src = "images/AF-btn.gif";
      //      Image15.src = "images/AU-btn.gif";
      var Image28 = document.getElementById("Image28");
      var Image29 = document.getElementById("Image29");
      var Image30 = document.getElementById("Image30");
      var Image31 = document.getElementById("Image31");
      var Image32 = document.getElementById("Image32");
      var Image27 = document.getElementById("Image27");
      var Image33 = document.getElementById("Image33");
      var Image34 = document.getElementById("Image34");
      Image28.src = "images/referaFrnd-btn.png";
      Image29.src = "images/loyaltyProgarm-btn.png";
      Image30.src = "images/deliveryInfo-h.png";
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
            <table cellpadding="0" cellspacing="0" border="0" width="620px" height="500px" style="margin-left: 30px">
                <tr>
                    <td class="formHeading">
                        Delivery Information
                    </td>
                </tr>
                <tr>
                    <td height="5px">
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Delivery Days</strong>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" style="padding-right: 20px;margin-left: 30px;">
                        &nbsp;•	Sunday Through Saturday
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                       &nbsp;• Saturdays & Sundays: By appointment only during peak vacation season, Memorial Day through Labor Day.
                    </td>
                </tr>
                <tr>
                    <td height="5px">
                    </td>
                </tr>
                
                 <tr>
                    <td class="formTextUSer">
                        <strong>Delivery Hours</strong>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" style="padding-right: 20px;">12-7 P.M.</td>
                    </tr>
                  
                    <tr>
                    <td class="formTextUSer" style="padding-right: 20px;">
                         *local residents allow a one hour window
                         <br />
                         <br />
                         <p><b>Hilton Head Island: </b> Vacation Home delivery is done logistically to allow for the
                        fastest delivery possible. While the majority of the orders are delivered prior
                        to your arrival, in some cases you may arrive prior to the grocery delivery during
                        the peak season. Feel free to call for a status of your order. 843-505-8568 
                         </p><br />
                       <p> <b>Daufuskie Island:</b> We send groceries and supplies to Daufuskie almost daily. We do not deliver
                        to the house on Daufuskie. The procedure is that we deliver to the boat you travel
                        on and a staff member from the boat service, if available, or Daufuskie Transportation
                        Services will deliver to your house if arranged prior. All boat deliveries are set
                        according to the boat departure schedules, regardless of time selected during check
                        out. We will verify with the boat company that you are on that boat and arrange
                        the grocery delivery to the boat. Before departure please ask if your groceries
                        are on board. We also deliver groceries once you are on the island but unless other
                        arrangements are made you must meet the boat to pick up the groceries from the dock.
                        Feel free to call for further details.</p>  
                    </td>
                </tr>
                  <tr>
                    <td height="5px">
                    </td>
                </tr>
                
                
                   <tr>
                    <td class="formTextUSer">
                        <strong>Delivery Fee</strong>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" style="padding-right: 20px;">
                     There is a $14.95 fee for local residents and businesses which include shopping and delivery. 
                    </td>
                </tr>
                
                 <tr>
                    <td height="5px">
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Vacation Home delivery</strong>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" style="padding-right: 20px;">
                  Due to the logistics of grocery delivery to Vacation Homes we require a fee of $29.95. 
                    </td>
                </tr>
                 <tr>
                    <td height="5px">
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Cut Off Time</strong>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" style="padding-right: 20px;">
         All local resident orders must be placed by 5 pm the day before the delivery date.  All vacation guest orders can be place months in
          advance if you wish; we would like at least 5-6 days lead time on the order, however we do our best to accept all orders.  
          If ordering with 2 days or less prior to arrival, please call for availability.<br />  843-505-8568
                    </td>
                </tr>
                <tr>
                    <td height="5px">
                    </td>
                </tr>
                   <%--<tr>
                    <td class="formTextUSer">
                        <strong>Extra Stops</strong>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" style="padding-right: 20px;">
               Other errand stops permitted for a $4.95 per stop fee
                    </td>
                </tr>--%>
          <%--      <tr>
                    <td class="formTextUSer">
                        <strong>Miscellaneous Information</strong>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" style="padding-right: 20px;">
               Payment Methods Accepted : All major credit & debit cards
                    
                    
                

                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer" style="padding-right: 20px;">
             Sales Tax : The standard sales tax applies
                    
                    
                

                    </td>
                </tr>--%>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td height="60px">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
