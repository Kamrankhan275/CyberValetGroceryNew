<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliveryDateInfo.aspx.cs" Inherits="CyberValetGrocery.Admin.DeliveryDateInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Delivery Date</title>
     <link rel="Stylesheet" href="../CSS/general.css" type="text/css" />
    
</head>
<body bgcolor="white">
    <form id="form1" runat="server">
    <div>
    
            <table >
               <tr>
                    <td height="10px">
                   
                    </td>
                </tr>
                <tr>
                    <td height="10px">
                    <span class="formText">
                    Delivery Times  for </span>&nbsp<asp:Label ID="lblDate" runat="server" CssClass="formTextSmall"></asp:Label> 
                    </td>
                </tr>
                <tr>
                    <td height="10px">
                 
                    </td>
                </tr>
                
                <tr>
                    <td  style="padding-left:100px;">
                  
                        <asp:GridView ID="gridDeliveryDetails" runat="server" AutoGenerateColumns="False"
                            Width="500px" AllowPaging="true" PageSize="10" OnPageIndexChanging="gridDeliveryDetails_PageIndexChanging"
                            CellPadding="0" CellSpacing="0"    CssClass="gridBorder">
                            <Columns>
                           
                                <asp:TemplateField HeaderText="Delivery Time">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DeliveryTime")%>'></asp:Label>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cut Off">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCutOff" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CutOff")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Capacity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCapacity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Capacity")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                             <PagerStyle CssClass="pagingtext"   ForeColor="#FFFFFF"   />
                    <HeaderStyle CssClass="grideheading" ForeColor="#404248" />
                    <AlternatingRowStyle CssClass="grideAlternatetext" />
                    <RowStyle CssClass="gridetext" />
                        </asp:GridView>
                        
                        
                    </td>
                </tr>
             
            </table>
       
    
    </div>
    </form>
</body>
</html>
