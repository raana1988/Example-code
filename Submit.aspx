<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Vozra.Master" AutoEventWireup="true" CodeBehind="Submit.aspx.cs" Inherits="VozaraCarpet.Pages.Submit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .address {
            resize: none;
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
            <h2 style="font-family: 'B Bardiya'; text-align: center; font-size: 28px;">ثبت نام در سایت</h2>
        </div>
        <div class="large-12 columns" style="padding-bottom: 100px; padding-top: 100px;">
            <table style="direction: ltr; margin: auto;">
                <tr>
                    <td></td>
                    <td style="direction: rtl; text-align: center">
                        <span style="color: #755d80">لطفا اطلاعات خود را وارد نمایید</span>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtname" runat="server" Height="22px" Width="234px" BorderColor="#993399" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan"></asp:TextBox>
                    </td>
                    <td class="auto-style6">نام و نام خانوادگی </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtuser" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtuser" runat="server" Height="22px" Width="234px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan"></asp:TextBox>
                    </td>
                    <td class="auto-style3">نام کاربری</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpass" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtpass" runat="server" Height="22px" Width="234px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style3">کلمه عبور</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtrepeat" runat="server" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" Height="22px" Width="234px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style3">تکرار کلمه عبور </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtmob" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtmob" runat="server" Height="22px" Width="234px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" TextMode="Phone"></asp:TextBox>
                    </td>
                    <td class="auto-style3">تلفن همراه</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtmail" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtmail" runat="server" Height="22px" Width="234px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" TextMode="Email"></asp:TextBox>
                    </td>
                    <td class="auto-style3">ایمیل</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtaddress" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtaddress" runat="server" Height="75px" TextMode="MultiLine" Width="230px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" CssClass="address"></asp:TextBox>
                    </td>
                    <td class="auto-style3">آدرس</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtpostcode" runat="server" Width="234px" Font-Names="b yekan" Style="margin-top: 0px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Height="22px"></asp:TextBox>
                    </td>
                    <td class="auto-style3">کد پستی</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ثبت نام " BackColor="#993366" BorderStyle="None" Font-Names="B Yekan" ForeColor="White" Style="margin-right: 179px" Width="55px" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Label ID="lblmsg" runat="server" Font-Names="B Yekan" ForeColor="Red" Style="text-align: left" Font-Size="13px"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>
