<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetailInformation.aspx.cs" Inherits="CyberValetGrocery.Admin.UserDetailInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <link rel="Stylesheet" href="../CSS/general.css" type="text/css" />
</head>
<body bgcolor="white">
    <form id="form1" runat="server">
    <div>
    <%-- <center>--%>
    
    <br />
       
            <table border="0"  cellpadding="0" cellspacing="0"  class="table-border" style="padding-left:5px;" width="350px">
             <tr><td  class="formHeadingText" colspan="2" align="left">User Information</td></tr>
                <tr><td height="3px">&nbsp;</td></tr>
                <tr>
                    <td class="formText" align="right">
                      <strong>  Name:</strong>
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr><td height="3px">&nbsp;</td></tr>
                <tr>
                    <td class="formText" align="right">
                        <strong>Email:</strong>
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                       <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </td>
                </tr>
                
                <tr><td height="3px">&nbsp;</td></tr>
                <tr valign="top">
                    <td class="formText" align="right" style="padding-left:5px;">
                       <strong> Address1:</strong>
                    </td>
                    <td class="formTextSmall">
                        <asp:Label ID="lblAddress1" runat="server"></asp:Label>
                        
                    </td>
                </tr>
                
                
                <tr><td height="3px">&nbsp;</td></tr>
                <tr valign="top">
                    <td class="formText" align="right">
                       <strong> Address2:</strong>
                    </td>
                    <td class="formTextSmall"style="padding-left:5px;" >
                        <asp:Label ID="lblAddress2" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr><td height="3px">&nbsp;</td></tr>
                <tr>
                    <td class="formText"  nowrap="nowrap" align="right">
                      <strong>  City:</strong>
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                        <asp:Label ID="lblCity" runat="server" ></asp:Label>
                       
                       
                    </td>
                </tr>
                 <tr><td height="3px">&nbsp;</td></tr>
                <tr>
                    <td class="formText"  nowrap="nowrap" align="right">
                      <strong> State:</strong>
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">                        
                        <asp:Label ID="lblState" runat="server" ></asp:Label>
                    </td>
                </tr>
                 <tr><td height="3px">&nbsp;</td></tr>
                <tr>
                    <td class="formText"  nowrap="nowrap" align="right">
                      <strong>  Zip:</strong>
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                        
                        <asp:Label ID="lblZip" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr><td height="3px">&nbsp;</td></tr>
                <tr>
                    <td class="formText" nowrap="nowrap" align="right">
                       <strong> Phone:</strong>
                    </td>
                    <td class="formTextSmall" style="padding-left:5px;">
                        <asp:Label ID="lblPhone" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr><td height="3px">&nbsp;</td></tr>
                
                
                
            </table>
          
        <%--</center>--%>
    </div>
    </form>
</body>
</html>
