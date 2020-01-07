<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideScript.ascx.cs" Inherits="CyberValetGrocery.Admin.SideScript" %>
<script language="javascript" type="text/javascript">


         function showHide(divid) {

             if (document.getElementById(divid).style.display == "none") {
                 if (divid == "customers") {
                     document.getElementById(divid).style.display = "block";
                     var sitefunctionsId = document.getElementById("sitefunctions");
                     sitefunctionsId.style.display = "none";
                     var reportsId = document.getElementById("reports");
                     reportsId.style.display = "none";              
                     

                 }
                 if (divid == "sitefunctions") {
                     document.getElementById(divid).style.display = "block";
                     var customersId = document.getElementById("customers");
                     customersId.style.display = "none";
                     var reportsId = document.getElementById("reports");
                     reportsId.style.display = "none";                     
                     
                 }
                 if (divid == "reports") {
                     document.getElementById(divid).style.display = "block";
                     var customersId = document.getElementById("customers");
                     customersId.style.display = "none";
                     var sitefunctionsId = document.getElementById("sitefunctions");
                     sitefunctionsId.style.display = "none";
                 }



             }

         }
              
    </script>
    
    
     

    
