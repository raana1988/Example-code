<%@ Page Title="وب سایت رسمی شرکت شیمیایی کمیکس - آلبوم تصاویر" Language="C#" MasterPageFile="~/masterFarsi.Master" AutoEventWireup="true" CodeBehind="AlbumFarsi.aspx.cs" Inherits="PRojectCH.AlbumFarsi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .pic {
            border:#080a2f solid thin;
            border-radius:10px;
            -moz-border-radius:10px;
            -webkit-border-radius:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:960px;margin-left:auto;margin-bottom:auto;margin-top:0px;margin-right:auto">
        <div style="padding-top:30px;margin-left:-45px;">
        <asp:ListView runat="server" ID="ImagesListView"
    GroupItemCount="3" DataSourceID="SqlDataSource1"  >
  <LayoutTemplate>
    <table cellpadding="2" runat="server"
           id="tblProducts" style="height:320px">
      <tr runat="server" id="groupPlaceholder">
      </tr>
    </table>
  
  </LayoutTemplate>
  <GroupTemplate>
    <tr runat="server" id="productRow"
        style="height:80px">
      <td runat="server" id="itemPlaceholder">
      </td>
    </tr>
  </GroupTemplate>
     <ItemTemplate>
    <td id="Td1" valign="top" align="center" style="width:100px;color:white;font-family:'B Nazanin';font-weight:bold" runat="server">
    <a href="ImageFarsi.aspx?AlbumID=<%#Eval("ID") %>" style="margin-left:35px" id="pi">
    <asp:Image ID="Images" runat="server" ImageUrl='<%#"~/AlbumUrl/" + Eval("AlbumUrl") %>' Height="200" Width="280"  CssClass="pic"  />    

           </a>
       <asp:Literal ID="LiteralName" runat="server" Text='<%#createThumbString(Eval("AlbumName").ToString(),Eval("DateAlbum").ToString())%>'></asp:Literal>  
    </td>
  </ItemTemplate>
</asp:ListView>
            <asp:SqlDataSource ID="SqlDataSource1" SelectCommand="SELECT * FROM [tbl_Album] where language=2" runat="server" ConnectionString="<%$ ConnectionStrings:chemixdbConnectionString1 %>"></asp:SqlDataSource>
      </div>

    </div>
</asp:Content>
