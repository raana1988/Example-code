<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Vozra.Master" AutoEventWireup="true" CodeBehind="EnterUser.aspx.cs" Inherits="VozaraCarpet.Pages.EnterUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 300px;
            margin: auto;
            font-family: 'B Yekan';
            font-size: 13px;
        }



        #flo {
            background-image: url('images/floabout.png');
            width: 548px;
            height: 868px;
            margin-top: 111px;
        }

        #text {
            width: 1000px;
            height: auto;
            min-height: 870px;
            background: #ffffff;
            /*opacity:0.8;*/
            position: absolute;
            font-family: 'B yekan';
            font-size: 13px;
            text-align: justify;
            box-shadow: 0px 7px 45px 0px #000;
        }

        #titr {
            height: 50px;
            background: #F1F1F1;
            border-top: 1px solid;
        }

        a {
            text-decoration: none;
            color: #521669;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="width: 90%; margin: auto">

        <div class="large-12 columns" id="titr">
            <h2 style="font-family:'B Bardiya'; text-align: center; font-size: 28px;">ورود کاربر</h2>
        </div>
        <div class="large-12 columns" style="direction: rtl; margin: auto; text-align: justify; padding-top: 105px;" id="slide">
            <table class="auto-style1" dir="rtl">
                <tr>
                    <td>نام کاربری : </td>
                    <td>
                        <asp:TextBox ID="txtuser" runat="server" Font-Names="B Yekan" Height="22px" Width="170px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>کلمه عبور :</td>
                    <td>
                        <asp:TextBox ID="txtpass" runat="server" Font-Names="B Yekan" Height="22px" Width="170px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="lblmsg" runat="server" Font-Names="B Yekan" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnenter" runat="server" Font-Names="B Yekan" Height="26px" Text="ورود" Width="65px" OnClick="btnenter_Click" BackColor="#993366" BorderStyle="None" ForeColor="White" />
                    </td>
                </tr>
            </table>
            <p style="text-align: center; font-family: 'B Yekan'; font-size: 13px;">برای ثبت نام در سایت <a href="Submit.aspx">کلیک کنید</a></p>
        </div>

    </div>
</asp:Content>
