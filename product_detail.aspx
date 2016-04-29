<%@ Page Title="وب سایت رسمی شرکت شیمیایی کمیکس - محصولات" Language="C#" MasterPageFile="~/masterFarsi.Master" AutoEventWireup="true" CodeBehind="product_detail.aspx.cs" Inherits="PRojectCH.product_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .link {
            float:left;
            color:#f00;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:960px;margin-left:auto;margin-bottom:auto;margin-top:0px;margin-right:auto">
    <div style="width: 850px; margin-left: 30px; direction: rtl; padding-bottom: 50px; padding-top: 50px; font-family: 'B Yekan'; font-size: large">
        <asp:Label ID="lblTitle" runat="server" Font-Bold="False" ForeColor="Black"></asp:Label><br />
        <br />
        <asp:Literal ID="ltrContent" runat="server"></asp:Literal><br />
        <br />
        <asp:HyperLink ID="dataSheetDowloadLink" runat="server" CssClass="link"> </asp:HyperLink>
    </div>
</div>
</asp:Content>
