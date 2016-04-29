<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Vozra.Master" AutoEventWireup="true" CodeBehind="VozaraActivity.aspx.cs" Inherits="VozaraCarpet.Pages.VozaraActivity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #sub {
            margin-top: 60px;
        }

        #fancy {
            width: 250px;
        }

        #title {
            font-size: 40px;
            color: #930000;
            font-family: b bardiya;
        }

        span {
            font-size: 13px;
            text-align: justify;
            width: 700px;
            margin: auto;
            padding-top: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="row about" style="width: 90%; margin: auto; text-align: center">
        <div class="row" id="sub">
            <h3 id="title">فروشگاه های فرش وزرا</h3>
            <img alt="فروشگاه های فرش وزرا" id="fancy" src="../Images/fancy1.png" />
            <div class="large-12 columns" style="font-family: 'B Yekan'; margin-right: 86px; font-size: 13px; text-align: center;">
                <asp:Literal runat="server" ID="ltrabout1"></asp:Literal>
            </div>

        </div>

    </div>
</asp:Content>
