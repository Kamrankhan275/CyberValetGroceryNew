<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="faqs.aspx.cs" Inherits="CyberValetGrocery.faqs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
//      var Image11 = document.getElementById("Image11");
//      var Image12 = document.getElementById("Image12");
//      var Image13 = document.getElementById("Image13");
//      var Image14 = document.getElementById("Image14");
//      var Image15 = document.getElementById("Image15");

//      Image11.src = "images/DI-btn.gif";
//      Image12.src = "images/Faq-btn-h.gif";
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
        Image30.src = "images/deliveryInfo-btn.png";
        Image31.src = "images/aboutUs-btn.png";
        Image32.src = "images/myShoppingList-btn.png";
        Image27.src = "images/accountFunds-btn.png";
        Image33.src = "images/FAQ-h.png";
        Image34.src = "images/contactUs-btn.png";
    </script>

    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table cellpadding="5" cellspacing="0" border="0" width="580px" style="margin-left: 30px">
                <tr>
                    <td class="formHeading">
                        Frequently Asked Questions
                    </td>
                </tr>
                <tr><td></td></tr>
                <tr>
                    <td align="left" class="formHeadingNew">
                        <%--<table cellpadding="0" cellspacing="0" border="0" >
                            <tr valign="top">
                                
                                <td width="200" align="left">--%>
                                   General
                               <%-- </td>
                            </tr>
                        </table>--%>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: What are the delivery days and times? </strong>
                        <br />
                            <strong>A:</strong> We deliver Monday through Friday 12-7 P.M. and Saturday & Sunday by appointment only. 
                             Saturday and Sunday are busy days during vacation season so we take many orders and set them to a logistical 
                             delivery route instead of a specific delivery time.  Most orders are delivered prior to arrival. (except Daufuskie Island)
                              Please call for details.
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: Does CVG deliver to Daufuskie Island? </strong>
                        <br />
                        <strong>A:</strong> We send groceries and supplies to Daufuskie almost daily. We
                        do not; do pre-arrival delivery or deliver to the house on Daufuskie as we do on
                        Hilton Head Island. The procedure is that we deliver to the boat you travel on and
                        a staff member from the boat service, if available or Daufuskie Transportation Services
                        will deliver to your house. Before departure please ask if your groceries are on
                        board. We also send groceries once you are on the island but unless other arrangements
                        are made you must meet the boat to pick up the groceries from the dock. Feel free
                        to call for further details.
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: What is the delivery fee?     </strong>
                        <br />
                        <strong>A:</strong> Our local delivery fee is $14.95 which includes shopping and delivery.  
                        Vacation deliveries are $29.95 to cover the logistics of shopping; delivery and putting the
                         groceries away before the guest arrive. (except Daufuskie Island) Please call for details.
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: What types of payment do you accept? 
                        </strong>
                        <br />
                        <strong>A:</strong> We accept all major credit cards.
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: Do you have a minimum order amount?  </strong>
                        <br />
                        <strong>A:</strong> No. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: How much time do I have to place my order before my requested delivery day?   </strong>
                        <br />
                        <strong>A:</strong> Local residential orders needs to be in before 5 pm the day before the delivery date. 
                         We recommend vacation orders to be placed as soon as possible to reserve a spot; any order less than 48 hours, 
                         we suggest you call to check availability. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: Can I change my order after it has been placed?   </strong>
                        <br />
                        <strong>A:</strong> We require all changes be made by 4 pm the day before the delivery date.
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: How do I cancel an order?  </strong>
                        <br />
                      <%--  <strong>A:</strong> Canceling an order can be completed by contacting us  <a href="mailto:keri@lowcountrygroceryrunner.com " class="Userlink1">keri@lowcountrygroceryrunner.com </a>. 
                       Orders can only be canceled by 5 pm the day before your delivery. If an order is canceled less than the required time beforehand, a restocking fee may apply.--%>
                       <%-- <strong>A:</strong>In the event of a cancellation, we will refund your full purchase price less credit card processing and supply fees up to 48 hours prior to delivery.  We do not guarantee full refund if cancellation takes place less than 48 hours prior to delivery, but we'll do our best to accommodate you.--%>
                        <strong>A:</strong> Cancelling an order can be completed by contacting us   <a href="mailto:keri@lowcountrygroceryrunner.com" class="Userlink1">keri@lowcountrygroceryrunner.com </a>. Orders must be canceled 48 hours or more prior to your delivery date.  We will refund your total less administrative fees. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: What do you do if an item is out of stock?   </strong>
                        <br />
                        <strong>A:</strong> We attempt to get every single item on your list. At times, the items you
                         choose may be out of inventory. If this is the case, we will purchase an equivalent item.
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: I want an item that is not on the website, what do I do?  </strong>
                        <br />
                        <strong>A:</strong> If you are looking for an item, but don't see it in our store you can let us know by
                         adding the item in the provided space on your order while checking out or simply call 843-505-8568.
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: There is a problem with my groceries, what should I do?   </strong>
                        <br />
                        <strong>A:</strong>We handle all customer complaints seriously. Please contact us immediately if you have any concerns about your groceries.
                         Please understand you must contact us within 24 hours after your delivery if you have a concern about the freshness of our groceries. 
                         We require you to contact us within 48 hours if you feel an item is missing. Be assured we double-check all orders when they are picked 
                         up and before they are delivered. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: Do you deliver during holidays?   </strong>
                        <br />
                        <strong>A:</strong> Cyber Valet Grocery does not deliver on Thanksgiving Day, Christmas Day, New Years Day or Easter Sunday.
                    </td>
                </tr>
               <%-- <tr>
                    <td class="formTextUSer">
                        <strong>Q: Do you sell alcohol or cigarettes?  </strong>
                        <br />
                        <strong>A:</strong> No.
                    </td>
                </tr>--%>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q:Do I have to be home when I want my food delivered?   </strong>
                        <br />
                        <strong>A:</strong>Local residents should be present or make other arrangements with us prior to delivery.  
                        Vacation customers DO NOT NEED TO BE PRESENT.  We make arrangements to deliver the groceries and put the perishables away. 
                        (except Daufuskie Island) Please call for details.
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: Can I have my groceries delivered to a different address than my own?   </strong>
                        <br />
                        <strong>A: </strong> Yes. During the checkout process you will be asked for your delivery address. 
                        Simply change this address to the one you wish to have the delivery. Your selection will be delivered 
                        to the location you enter. 
                    </td>
                </tr>
              
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: Do I have to tip the driver? </strong>
                        <br />
                        <strong>A:</strong> Leaving tips is entirely up to you. 
                        Tips are not expected, but are always appreciated by our employees. 
                    </td>
                </tr>
             <%--   <tr>
                    <td class="formTextUSer">
                        <strong>Q: Do I have to give an exact time of when I want my food delivered?  </strong>
                        <br />
                        <strong>A:</strong> You have three delivery time options (11am/1pm/3pm) in which there is a two hour window.
                    </td>
                </tr>--%>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: How do I change my profile?   </strong>
                        <br />
                        <strong>A:</strong>Changing your profile requires you to be signed in. Once signed in, simply click the 
                          <a href="MyAccount.aspx" class="Userlink1">My Account</a> tab on top of our website to access and edit your profile.
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: How can I retrieve my username and/or password?  </strong>
                        <br />
                        <strong>A:</strong> <a href="LoginPage.aspx" class="Userlink1">Retrieve your username and password.</a>
                    </td>
                </tr>
                
                
                
                  <tr>
                    <td align="left" class="formHeadingNew">
                        <a name="security"></a>Security & Privacy
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: Do you sell or trade my personal information?   </strong>
                        <br />
                        <strong>A:</strong> No we do not. We value your privacy and ensure your information is protected and only used internally 
                        to improve your experience. Your information can only be accessed when you sign in or by request.
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: What is Cyber Valet�s Privacy Policy? </strong>
                        <br />
                        <strong>A:</strong> Read our <a href="privacy.aspx" class="Userlink1">Policy</a>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: How do I know my order is secure?  </strong>
                        <br />
                        <strong>A:</strong> At Cyber Valet Grocery, we want you to feel safe while shopping with us. That's why we use the <a href="https://www.thawte.com/" class="Userlink1" target="_blank">THAWTE</a> brand to verify our standing.
                          <a href="https://www.thawte.com/" class="Userlink1" target="_blank">THAWTE</a>  THAWTE verifies our address and business standing for your comfort. 
                         In addition they encrypt all of your personal information, including name, address and credit card number, as it is submitted to
                          our Web server. Once received, your personal information is stored in our secure data center.

                    </td>
                </tr>
                <tr>
                    <td class="formTextUSer">
                        <strong>Q: Can I give you feedback/suggestions?    </strong>
                        <br />
                        <strong>A:</strong> Your suggestions are what will make our business grow. We love to hear what you have to
                         say about any facet of our business and encourage you to let us know any thought you have about Cyber Valet Grocery.
                         <a href="ContactUsPage.aspx" class="Userlink1">Send any comments, suggestions, or feedback to us.</a>
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
