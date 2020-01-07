<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SavelistAddProduct.aspx.cs" Inherits="CyberValetGrocery.SavelistAddProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
<link rel="Stylesheet" href="CSS/UserSide.css" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <link href="js/dhtmlwindow.css" rel="stylesheet" type="text/css" />
    <link href="js/modal.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/dhtmlwindow.js"></script>

    <script type="text/javascript" src="js/modal.js"> </script>

    <link href="js/dhtmlwindow1.css" rel="stylesheet" type="text/css" />
    <link href="js/modal1.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/dhtmlwindow1.js"></script>

    <script type="text/javascript" src="js/modal1.js"> </script>

    <script type="text/javascript" src="jsNew/jquery-1.2.2.pack.js"> </script>

    <link href="CSS/Style.css" rel="stylesheet" type="text/css" />
    <link href="CSS/general.css" rel="stylesheet" type="text/css" />
    
</head>
<body bgcolor="white">
    <form id="form1" runat="server">
         <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-left: 10px;">
                <tr>
                    <td align="left" class="formHeading">
                         Shopping Lists
                    </td>
                </tr>
                <tr>
                    <td height="10px">
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                     
                            <table class="formTextUSer">
                                <tr>
                                    <td>
                                        Here are your current saved shopping lists:
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMsg" runat="server"  Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:DataList ID="dtlShopList" runat="server" RepeatDirection="Vertical" OnItemCommand="dtlShopList_ItemCommand">
                                            <ItemTemplate>
                                                <table class="formTextSmall1">
                                                    <tr>
                                                        <td width="20" align="center" valign="top">
                                                            <asp:Image ID="imgArrow" runat="server" ImageUrl="images/arrow5.gif" />
                                                            <asp:Label ID="lblListId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"list_id") %>'
                                                                Visible="false" ></asp:Label>
                                                        </td>
                                                        <td width="130" valign="top" align="left">
   
                                                                <asp:Label ID="lblListNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"list_name") %>'  CssClass="formTextUSer"></asp:Label>
                                                            </a>
                                                        </td>
                                                        <td valign="top" align="center">
                               
                                                              <asp:Button ID="btnAdd" runat="server" Text="Add Product" 
                                                              CssClass="button" CommandName="AddAllList"  CommandArgument='<%# Eval("list_id")%>' CausesValidation="false"/>

                                                        </td>
                                                        
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                            </table>
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>
