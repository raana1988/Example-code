<%@ Page Title="وب سایت رسمی شرکت شیمیایی کمیکس - محصولات" Language="C#" MasterPageFile="~/masterFarsi.Master" AutoEventWireup="true" CodeBehind="ugc_farsi.aspx.cs" Inherits="PRojectCH.ugcFarsi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href='http://fonts.googleapis.com/css?family=Oranienbaum' rel='stylesheet' type='text/css' />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:960px;margin-left:auto;margin-bottom:auto;margin-top:0px;margin-right:auto">
       <div style="width:900px;height:auto;margin-left:-30px">
        <asp:ListView runat="server" ID="ImageListView" DataSourceID="SqlDataSource1" GroupItemCount="4" OnItemDataBound="ImageListView_ItemDataBound">
    <LayoutTemplate>
         <table id="Table1" cellpadding="0" runat="server" style="margin-right:80px;margin-top:30px;margin-bottom:50px;"  >
                    <tr runat="server" id="groupPlaceHolder">
                    </tr>
                </table>
       
    </LayoutTemplate>
    <GroupTemplate>
      
        <tr runat="server" id="MP3Row" >
                    <td runat="server" id="itemPlaceHolder" style="height:200px;width:200px;">
                    </td>
        </tr>
         
    </GroupTemplate>
    <ItemTemplate>
     <td id="Td1"  valign="top" align="center" style=' width:220px;height:235px;vertical-align:middle;'  runat="server">
          <a href="product_detail.aspx?product=<%#Eval("ID") %>" style="text-decoration:none;">
             <div style="width:220px;height:235px;">
         <div style=" color:White; width:220px;text-align:center;vertical-align:middle;font-family: 'Oranienbaum', serif;font-size:32pt;padding-top:85px;">
             <%#Eval("TitlePr")%>
         </div>
         </div>
         </a>
        </td>
        <td style="padding-right:35px;">&nbsp&nbsp&nbsp&nbsp&nbsp</td>
    </ItemTemplate>
    <EmptyItemTemplate>
        <td />
    </EmptyItemTemplate>
    <EmptyDataTemplate>
        <h3 style="font-family:'B Yekan';color:#860505;text-align:center">اطلاعاتی وارد نشده است </h3>
    </EmptyDataTemplate>
   
</asp:ListView>
 
 
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:chemixdbConnectionString1 %>" 
            
               SelectCommand="SELECT [TitlePr], [ID] FROM [chproduct] WHERE ([TypePr] = @TypePr) AND (elanguage = 2)">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="TypePr" Type="Byte" />
            </SelectParameters>
           </asp:SqlDataSource>
    
       </div>
   </div>

</asp:Content>
