<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Vozra.Master" AutoEventWireup="true" CodeBehind="InformationBuyer.aspx.cs" Inherits="VozaraCarpet.Pages.InformationBuyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            /*width: 500px;*/
            direction: ltr;
            font-size: 13px;
            /*float:right;*/
            margin: auto;
            /*border-left:solid thin #755d80;*/
        }

        .auto-style3 {
            text-align: right;
            width: 128px;
        }

        .auto-style4 {
            width: 60px;
            direction: rtl;
            font-size: large;
        }

        .auto-style5 {
            width: 60px;
            height: 32px;
            direction: rtl;
            font-size: large;
        }

        .auto-style6 {
            text-align: right;
            width: 128px;
            height: 32px;
        }

        .address {
            resize: none;
        }

        #user {
            width: 960px;
            height: 300px;
            margin: auto;
            padding-top: 300px;
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

        .auto-style7 {
            width: 130px;
        }

        .auto-style8 {
            width: 130px;
            height: 32px;
            direction: rtl;
            font-size: large;
        }

        .auto-style9 {
            width: 130px;
            direction: rtl;
            font-size: large;
        }

        .auto-style10 {
        }

        .auto-style11 {
            width: 32px;
        }

        .auto-style12 {
            width: 32px;
            height: 32px;
            direction: rtl;
            font-size: large;
        }

        .auto-style13 {
            width: 32px;
            direction: rtl;
            font-size: large;
        }

        .auto-style14 {
            width: 364px;
        }

        .auto-style15 {
            width: 4px;
        }

        .auto-style16 {
            width: 4px;
            height: 32px;
            direction: rtl;
            font-size: large;
        }

        .auto-style17 {
            width: 4px;
            direction: rtl;
            font-size: large;
        }

        .auto-style19 {
            text-align: right;
            width: 141px;
            height: 32px;
        }

        .auto-style20 {
            text-align: right;
            width: 141px;
        }

        .auto-style21 {
            width: 141px;
        }

        .auto-style22 {
            width: 64px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="width: 90%; margin: auto">

        <div class="large-12 columns" id="titr">
            <h2 style="font-family: 'B Bardiya'; text-align: center; font-size: 28px;">ثبت نام در سایت</h2>
        </div>
        <div class="large-12 columns" style="direction: rtl; margin: auto; text-align: justify; padding-top: 50px;" id="slide">
            <table>
                <tr>
                    <td style="text-align: center">عضو سایت هستم
                    </td>
                    <td style="text-align: center" class="auto-style14">می خواهم عضو سایت بشوم
                    </td>
                    <td style="text-align: center">می خواهم کاربر مهمان باشم
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="auto-style1" style="direction: rtl; margin-top: -173px;">
                            <tr>
                                <td class="auto-style22">نام کاربری </td>
                                <td>
                                    <asp:TextBox ID="txtusername" runat="server" Font-Names="B Yekan" Height="22px" Width="170px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style22">کلمه عبور :</td>
                                <td>
                                    <asp:TextBox ID="txtpassword" runat="server" Font-Names="B Yekan" Height="22px" Width="170px" TextMode="Password" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style22">&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblmsg2" runat="server" Font-Names="B Yekan" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style22">&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnenter" runat="server" Font-Names="B Yekan" Height="28px" Text="ورود" Width="55px" OnClick="btnenter_Click" BackColor="#993366" ForeColor="White" BorderStyle="None" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10" colspan="2">اگر در هنگام خرید ، وارد حساب کاربری خود شوید ، علاوه بر امنیت بیشتر خرید از امکانات بیشتری بر خوردار می شود .
                                </td>
                            </tr>

                        </table>
                    </td>
                    <td class="auto-style14">
                        <table class="auto-style1" style="border-left: dotted 1px #8d639d; border-right: dotted 1px #8d639d">
                            <tr>
                                <td class="auto-style11"></td>
                                <td style="direction: rtl; text-align: center" class="auto-style7">&nbsp;</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style12">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="user" ControlToValidate="txtnm" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style8">
                                    <asp:TextBox ID="txtnm" runat="server" Height="22px" Width="234px" BorderColor="#993399" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" ValidationGroup="user"></asp:TextBox>
                                </td>
                                <td class="auto-style6">نام و نام خانوادگی </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="user" ControlToValidate="txtuser1" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="txtuser1" runat="server" Height="22px" Width="234px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" ValidationGroup="user"></asp:TextBox>
                                </td>
                                <td class="auto-style3">نام کاربری</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="user" ControlToValidate="txtpass1" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="txtpass1" runat="server" Height="22px" Width="234px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" TextMode="Password" ValidationGroup="user"></asp:TextBox>
                                </td>
                                <td class="auto-style3">کلمه عبور</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="txtrepeat" runat="server" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" Height="22px" Width="234px"></asp:TextBox>
                                </td>
                                <td class="auto-style3">تکرار کلمه عبور</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="user" ControlToValidate="txtphone" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="txtphone" runat="server" Height="22px" Width="234px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" TextMode="Phone" ValidationGroup="user"></asp:TextBox>
                                </td>
                                <td class="auto-style3">تلفن همراه</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="user" ControlToValidate="txtmail1" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="txtmail1" runat="server" Height="22px" Width="234px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" TextMode="Email" ValidationGroup="user"></asp:TextBox>
                                </td>
                                <td class="auto-style3">ایمیل</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="user" ControlToValidate="txtadd" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="txtadd" runat="server" Height="75px" TextMode="MultiLine" Width="230px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" CssClass="address" ValidationGroup="user"></asp:TextBox>
                                </td>
                                <td class="auto-style3">آدرس</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="txtposti" runat="server" Width="234px" Font-Names="b yekan" Style="margin-top: 0px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Height="22px" ValidationGroup="user"></asp:TextBox>
                                </td>
                                <td class="auto-style3">کد پستی</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style9">
                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="ثبت نام " ValidationGroup="user" BackColor="#993366" BorderStyle="None" Font-Names="B Yekan" ForeColor="White" Style="margin-right: 179px" Width="55px" />
                                </td>
                                <td class="auto-style3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style9">
                                    <asp:Label ID="lblmsg1" runat="server" Font-Names="B Yekan" ForeColor="Red" Style="text-align: left" Font-Size="13px"></asp:Label>
                                </td>
                                <td class="auto-style3">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table class="auto-style1" style="width: 333px; margin-top: -88px;">
                            <tr>
                                <td class="auto-style15"></td>
                                <td style="direction: rtl; text-align: center">&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                <td class="auto-style21"></td>
                            </tr>
                            <tr>
                                <td class="auto-style16">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="buyer" ControlToValidate="txtname" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="txtname" runat="server" Height="22px" Width="234px" BorderColor="#993399" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" ValidationGroup="buyer"></asp:TextBox>
                                </td>
                                <td class="auto-style19">نام و نام خانوادگی </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="buyer" ControlToValidate="txtmob" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txtmob" runat="server" Height="22px" Width="234px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" TextMode="Phone" ValidationGroup="buyer"></asp:TextBox>
                                </td>
                                <td class="auto-style20">تلفن همراه</td>
                            </tr>
                            <tr>
                                <td class="auto-style17">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="buyer" ControlToValidate="txtmail" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txtmail" runat="server" Height="22px" Width="234px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" TextMode="Email" ValidationGroup="buyer"></asp:TextBox>
                                </td>
                                <td class="auto-style20">ایمیل</td>
                            </tr>
                            <tr>
                                <td class="auto-style17">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="buyer" ControlToValidate="txtaddress" ErrorMessage="لطفا اطلاعات را کامل وارد نمایید" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txtaddress" runat="server" Height="75px" TextMode="MultiLine" Width="230px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Font-Names="B Yekan" CssClass="address" ValidationGroup="buyer"></asp:TextBox>
                                </td>
                                <td class="auto-style20">آدرس</td>
                            </tr>
                            <tr>
                                <td class="auto-style17">&nbsp;</td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txtpostcode" runat="server" Width="234px" Font-Names="b yekan" Style="margin-top: 0px" BorderColor="#993366" BorderStyle="Solid" BorderWidth="1px" Height="22px" ValidationGroup="buyer"></asp:TextBox>
                                </td>
                                <td class="auto-style20">کد پستی</td>
                            </tr>
                            <tr>
                                <td class="auto-style17">&nbsp;</td>
                                <td class="auto-style4">
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" ValidationGroup="buyer" Text="ثبت نام " BackColor="#993366" BorderStyle="None" Font-Names="B Yekan" ForeColor="White" Style="margin-right: 179px" Width="55px" />
                                </td>
                                <td class="auto-style20">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style17">&nbsp;</td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblmsg" runat="server" Font-Names="B Yekan" ForeColor="Red" Style="text-align: left" Font-Size="13px"></asp:Label>
                                </td>
                                <td class="auto-style20">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>

            </table>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Style="width: 800px; font-family: 'B Yekan'; font-size: 13px; text-align: right;" Visible="false">
                <Columns>

                    <asp:TemplateField HeaderText="قیمت">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("قیمت") %>' ID="lblPriceId" runat="server"></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="کد محصول">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("کد محصول") %>' ID="lblProductid" runat="server"></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="نام محصول">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("نام محصول") %>' ID="lblProduct" runat="server"></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ابعاد">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("ابعاد") %>' ID="lblDimension" runat="server"></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="تعداد">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("تعداد") %>' ID="lblNo" runat="server"></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lblprice" runat="server" Text=''></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
