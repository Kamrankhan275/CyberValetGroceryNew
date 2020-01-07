<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewClientActivityReport.aspx.cs" Inherits="CyberValetGrocery.ViewClientActivityReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 19px;
        }
        .style2
        {
            height: 13px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    
    
    
    
    
    
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding-left:10px;">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="Logoutlink">
               All Users Details For Registered Between <asp:Label ID="lblStDate" runat="server" ForeColor="Red"></asp:Label>  and 
               <asp:Label ID="lblEndDate" runat="server" ForeColor="Red"></asp:Label> for 
                Zip Code(<asp:Label ID="lblZipNm" runat="server"  ForeColor="Red"></asp:Label>)
            </td>
        </tr>
       
        <tr>
            <td class="style1">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
              <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" class="formText">
                <table width="721" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="721">
                            
                                      <asp:GridView ID="griduserList" runat="server" AutoGenerateColumns="False"                                     
                                             Width="700px"   
        PageSize="10"  AllowPaging="true"  
        CssClass="gridBorder"  CellPadding="0" CellSpacing="0"  AllowSorting="True" onsorting="griduserList_Sorting"  OnPageIndexChanging="griduserList_PageIndexChanging"  >
                                       <Columns>
                                       
                                       <asp:TemplateField   Visible="false" >
                                        <ItemTemplate > 
                                                                            
                                         <asp:Label ID="lblUserId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_id")%>' ></asp:Label>
                                        
                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>  
                                       
                                       <asp:TemplateField  HeaderText="Name" SortExpression="userName" >
                                        <ItemTemplate > 
                                                                           
                                         <asp:Label ID="lblUserLName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "userName")%>' ></asp:Label>
                                         </a>
                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField>                                  
                                     
                                      <asp:TemplateField  HeaderText="Email"  >
                                        <ItemTemplate >                                        
                                         <asp:Label ID="lblEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_email")%>' ></asp:Label>                                                                                                                    
                                        </ItemTemplate>
                                      </asp:TemplateField> 
                                      
                                      <asp:TemplateField  HeaderText="Address">
                                        <ItemTemplate >
                                        <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_address1")%>' ></asp:Label>                                          
                                                                                                                      
                                        </ItemTemplate>
                                      </asp:TemplateField>  
                                      
                                       <asp:TemplateField  HeaderText="Phone">
                                        <ItemTemplate >
                                        <asp:Label ID="lblPhone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_phone")%>' ></asp:Label>                                          
                                                                                                                      
                                        </ItemTemplate>
                                      </asp:TemplateField>  
                                      
                                       <asp:TemplateField  HeaderText="City">
                                        <ItemTemplate >
                                        <asp:Label ID="lblCity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_city")%>' ></asp:Label>                                          
                                                                                                                      
                                        </ItemTemplate>
                                      </asp:TemplateField>   
                                      
                                       <asp:TemplateField  HeaderText="State">
                                        <ItemTemplate >
                                        <asp:Label ID="lblState" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_state")%>' ></asp:Label>                                          
                                                                                                                      
                                        </ItemTemplate>
                                      </asp:TemplateField>     
                                      
                                      <asp:TemplateField  HeaderText="Zip">
                                        <ItemTemplate >
                                        <asp:Label ID="lblZip" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_zip")%>' ></asp:Label>                                          
                                                                                                                      
                                        </ItemTemplate>
                                      </asp:TemplateField>                                  
                                      
                                      
                                      
                                      <asp:TemplateField  HeaderText="Registered Date"  >
                                        <ItemTemplate >                                       
                                         <asp:Label ID="lblJoined" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "date1")%>' ></asp:Label>                                                                                                                    
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
            </td>
        </tr>
       
        <tr>
            <td height="15px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 50px;" class="style2">
                <asp:Button ID="btnExcel" runat="server" Text="Convert To Excel" CssClass="button" OnClick="btnExcel_Click" />
                <span  style="padding-left: 420px;">
                <asp:ImageButton ID="imgBack2" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0" OnClick="imgBack2_Click" CausesValidation="false" /></span>
            </td>
        </tr>
          <tr>
            <td >
                
            </td>
        </tr>
         <tr>
            <td height="15px">
            </td>
        </tr>
    </table>
    
    
    
    
   



</asp:Content>
