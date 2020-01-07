<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="UpdateLoginInfo.aspx.cs" Inherits="CyberValetGrocery.UpdateLoginInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">  
            var xmlhttp;

            function CheckEmailAvailability()   
            {  
                xmlhttp=null;
                var email = document.getElementById('<%=txtEmail.ClientID %>').value;  
                var ShowImage1 = document.getElementById("ShowImage");

                if (email = "" || email.length < 3)  
                {
                    document.getElementById("<%=lblUserName.ClientID%>").innerHTML = "";  
                    ShowImage1.style.display="none";
                    return false;  
                }  
      
                if (window.XMLHttpRequest)   
                {  
                    // code for all new browsers  
                   xmlhttp=new XMLHttpRequest();   
                }  
                else if (window.ActiveXObject)   
                {  
                   // code for IE5 and IE6xmlhttp=  
                   new ActiveXObject("Microsoft.XMLHTTP");   
                }  
     
                if (xmlhttp!=null)   
                {   
                   xmlhttp.onreadystatechange=state_Change;
                   var email2 = document.getElementById('<%=txtEmail.ClientID %>').value;
                   xmlhttp.open("GET", "../CheckEmailAddress.aspx?Email=" + email2, true);  
                    
                   
                    xmlhttp.send(null);   
                    
                }    
                else  
                {  
                   alert("Oops..Your browser does not support XMLHTTP.");   
                }  
            }  
     
          function state_Change()   
          {    
            if (xmlhttp.readyState==4)   
            {  
              // 4 = “loaded” 
               
              if (xmlhttp.status==200)   
               {  
                 //request was successful                
                 //check if email address is available and message  
                 var lblMesg = document.getElementById("<%=lblUserName.ClientID%>"); 
                // alert(lblMesg); 
                 var imgSuccessUserName = document.getElementById("imgSuccessUserName"); 
                 //  alert(imgSuccessUserName); 
                 var ShowImage = document.getElementById("ShowImage"); 
                  // alert(xmlhttp.responseText); 
  
              if(xmlhttp.responseText=="True")  
              {  
            //  alert(xmlhttp.responseText);
                ShowImage.style.display="block";
                imgSuccessUserName.src="../images/icon_success.png";
                
                lblMesg.style.color="Green";

                lblMesg.innerHTML = "Email address available.";  
               
              }  
  
              else if(xmlhttp.responseText=="False")
              { 
             //   alert(xmlhttp.responseText);
                ShowImage.style.display="block";
                imgSuccessUserName.src="../images/icon_error.png"; 
                lblMesg.innerHTML="Email address already in use.";  
                lblMesg.style.color="Red"; 
              } 
              }  
                else  
                {  
                   // alert(xmlhttp.responseText);
                    alert("Oops..email address availability could not be checked.");  
                }  
              }  
   
         }   
    
    </script>
    
    <script type="text/javascript">
     function clcontent() {
         var lb1 = document.getElementById("<%= lblMsg.ClientID %>");
         lb1.innerHTML = "";
     }


</script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="script1" runat="server" 
></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server"  >
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-left:10px;">
       
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td align="left" class="formHeading">
          <strong>  Update Email Address / Password  </strong>
            </td>
        </tr>
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td align="left" class="formTextUSer">
             Please use the form below to update your email address / password:



            </td>
        </tr>
        <tr>
            <td height="20px">
            </td>
        </tr>
        <tr>
            <td align="left" class="formTextUSer" style="padding-left:10px;">
                <table cellpadding="3" cellspacing="0" border="0" >
                   <tr>
                        <td colspan="2" align="center">
                            Field with a <span class="star1">*</span> are required
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr>
                     <td></td>
                        <td  align="left"   >
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1" />
                            <asp:Label ID="lblMsg" CssClass="formTextUSer" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="right">
                           <span class="star1">*</span>Email Address: 
                            <br />
                         <span class="formTextSmall1">  Your email address will serve as your username.</span> 
                        </td>
                        <td>
                             <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox1" MaxLength="50" onkeyup="CheckEmailAvailability();"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Text="*" ControlToValidate="txtEmail"
                                ErrorMessage="Email is required" ForeColor="White"></asp:RequiredFieldValidator>
                                <div id="ShowImage" style="display: none">
                                            <img id="imgSuccessUserName" />
                                            <asp:Label ID="lblUserName" runat="server" CssClass="formTextSmall1"></asp:Label>
                                        </div>
                        </td>
                    </tr>
                    
                     <tr valign="top">
                        <td align="right">
                            <span class="star1">*</span>Retype Email:
                        </td>
                        <td>
                            <asp:TextBox ID="txtReEmail" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="*" ControlToValidate="txtReEmail"
                                ErrorMessage="Retype email is required" ForeColor="White"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cmpEmail" runat="server" Text="*" ControlToValidate="txtReEmail" ControlToCompare="txtEmail"
                                 ErrorMessage="Email and retype email should be same" ForeColor="White"></asp:CompareValidator>
                                     
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="right">
                           <%--<span class="star1">*</span>--%>Password:<br />
                           <span class="formTextSmall1">Your password must be 7 - 20 characters long.</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox1" MaxLength="20" TextMode="Password"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ControlToValidate="txtPassword"
                                ErrorMessage="Password is required" ForeColor="White"></asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="rePwd" runat="server" Text="*" ForeColor="White"
                                                ErrorMessage="Password should be between 7 and 20 characters with at least one number and no symbols."
                                                ControlToValidate="txtPassword" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{7,20})$">
                                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    
                     <tr valign="top">
                        <td align="right">
                          <%-- <span class="star1">*</span>--%>Retype Password:
                        </td>
                        <td>
                             <asp:TextBox ID="txtRePassword" runat="server" CssClass="textbox1" MaxLength="20" TextMode="Password"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvRePassword" runat="server" Text="*" ControlToValidate="txtRePassword"
                                ErrorMessage="Retype password is required" ForeColor="White"></asp:RequiredFieldValidator>
                                --%>
                                <asp:CompareValidator ID="cmpPassword" runat="server" Text="*" ControlToValidate="txtRePassword" ControlToCompare="txtPassword"
                                 ErrorMessage="Password and retype password should be same" ForeColor="White"></asp:CompareValidator>
                        </td>
                    </tr>
                    
                    
                    <tr>
                    <td></td>
                        <td  align="left" style="padding-left:5px;" >
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="buttonUser" OnClick="btnUpdate_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
       
        
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
