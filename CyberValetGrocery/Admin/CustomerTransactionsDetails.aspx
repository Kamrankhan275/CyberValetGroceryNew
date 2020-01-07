<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerTransactionsDetails.aspx.cs" Inherits="CyberValetGrocery.Admin.CustomerTransactionsDetails1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Customer Transactions</title>
      <link rel="Stylesheet" href="../CSS/general.css" type="text/css" />
</head>
<body bgcolor="white">
    <form id="form1" runat="server">
    <div>
     
       
             <table border="0" align="center" cellpadding="0" cellspacing="0" class="table-border" width="350px">
                        <tr><td colspan="2" class="formHeadingText">Transaction Info</td></tr>
            
                  <tr >
                    <td class="formText" align="right">
                    <strong>Date:</strong>
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                         <asp:Label ID="lblTransactionsDate" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr><td >&nbsp;</td></tr>
                <tr>
                    <td class="formText"  align="right">
                      <strong> Customers:</strong>
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                     <asp:Label ID="lblCustomers" runat="server" ></asp:Label>  
                    </td>
                </tr>
                <tr><td >&nbsp;</td></tr>
                <tr >
                    <td class="formText"  align="right">
                      <strong> Amount:</strong>
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                       <asp:Label ID="lblTransactionsAmount" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr><td >&nbsp;</td></tr>
                <tr>
                    <td class="formText"  nowrap="nowrap"  align="right">
                       <strong>Comments:</strong>
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                          <asp:Label ID="lblComments" runat="server" ></asp:Label>        
                    </td>
                </tr>
                <tr><td >&nbsp;</td></tr>
                <tr>
                    <td class="formText" nowrap="nowrap"  align="right">
                       <strong> Order Number:</strong>
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                       <asp:Label ID="lblOrder" runat="server" ></asp:Label>         
                    </td>
                </tr>
              
                <tr><td colspan="2" class="formHeadingText">Personal Info</td></tr>
               
                <tr>
                    <td class="formText" align="right">
                      <strong> First Name:</strong>
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                       <asp:Label ID="lblFName" runat="server" ></asp:Label>
                    </td>
                </tr>
                 <tr><td >&nbsp;</td></tr>
                <tr>
                    <td class="formText" align="right">
                     <strong> Last Name:</strong>
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                         <asp:Label ID="lblLName" runat="server" ></asp:Label>
                    </td>
                </tr>
                 <tr><td >&nbsp;</td></tr>
                <tr>
                    <td class="formText" align="right" valign="top">
                      <strong>  Address:</strong>
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                         <asp:Label ID="lblTransactionsAddress" runat="server" ></asp:Label>
             <br />
              <asp:Label ID="lblTransactionsAddress2" runat="server" ></asp:Label>
                    </td>
                </tr>
                
        
     <%-- <tr><td colspan="2" class="formHeadingText">Shipping Info</td></tr>--%>
          <tr><td >&nbsp;</td></tr>
       
                
                 <tr>
                    <td class="formText" nowrap="nowrap" valign="top"  align="right">
                     <strong>   City,State, Zip: </strong> 
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                         <asp:Label ID="lblTransactionsCity" runat="server" ></asp:Label>
                         <asp:Label ID="lblComma" runat="server" Text=","></asp:Label>
                         
             <asp:Label ID="lblTransactionsState" runat="server" ></asp:Label>
              <asp:Label ID="lblComma1" runat="server" Text=","></asp:Label>
              <asp:Label ID="lblTransactionsZip" runat="server" ></asp:Label>
                    </td>
                </tr>
                 <tr><td >&nbsp;</td></tr>
                 <tr>
                    <td class="formText"  align="right">
                       <strong>   Phone: </strong> 
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                         <asp:Label ID="lblTransactionsPhone" runat="server" ></asp:Label>
            
                    </td>
                </tr>
                 <%-- <tr><td >&nbsp;</td></tr>
                <tr>
                    <td class="formText" nowrap="nowrap"  align="right">
                      <strong>  Credit Card: </strong> 
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                     xxxxxxxxxxxx<asp:Label ID="lblCreditCard" runat="server" ></asp:Label>
                    </td>
                </tr>
                 <tr><td >&nbsp;</td></tr>
                  <tr>
                    <td class="formText" nowrap="nowrap"  align="right">
                      <strong>    Expiration Date: </strong> 
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                          <asp:Label ID="lblExpirationDate" runat="server" ></asp:Label>
            
                    </td>
                </tr>--%>
                 <tr><td >&nbsp;</td></tr>
            </table>
        
    </div>
    </form>
</body>
</html>
