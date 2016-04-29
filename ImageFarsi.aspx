<%@ Page Title="وب سایت رسمی شرکت شیمیایی کمیکس - تصاویر" Language="C#" MasterPageFile="~/masterFarsi.Master" AutoEventWireup="true" CodeBehind="ImageFarsi.aspx.cs" Inherits="PRojectCH.ImageFarsi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="js/vlb_files1/vlightbox1.css" type="text/css" />
		<link rel="stylesheet" href="js/vlb_files1/visuallightbox.css" type="text/css" media="screen" />
		<script src="js/vlb_engine/visuallightbox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:960px;margin-left:auto;margin-bottom:auto;margin-top:0px;margin-right:auto">
    <div id="cc" style="margin-left:-22px">
    <div id="vlightbox1" style="/*width:900px;margin-left:90px; */position:relative; z-index:0;margin-top:50px;">
        
         <asp:Literal ID="LiteralImages" runat="server"></asp:Literal>
        </div>
	</div>
   </div>
	<script src="js/vlb_engine/vlbdata1.js" type="text/javascript"></script>
</asp:Content>
