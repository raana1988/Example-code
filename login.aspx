<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Vozra.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="VozaraCarpet.Pages.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            width: 175px;
        }
        .auto-style2 {
            width: 100px;
        }
        .auto-style3 {
            width: 100px;
            height: 30px;
        }
        .auto-style4 {
            width: 175px;
            height: 30px;
        }
        .auto-style5 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="width:960px;height:300px;margin:auto;">
        <table style="width:500px;direction:rtl;font-family:'B Yekan';font-size:13px;margin:auto;padding-top:150px;">
            <tr>
                <td class="auto-style2">

                    کلمه کاربری :

                </td>
                <td class="auto-style1">

                    <asp:TextBox ID="txtuser" runat="server" Height="21px" Width="210px"></asp:TextBox>

                </td>
                <td>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="وارد نمایید" ForeColor="Red" ControlToValidate="txtuser">*</asp:RequiredFieldValidator>

                </td>
            </tr>
               <tr>
                <td class="auto-style2">

                    رمز عبور :</td>
                <td class="auto-style1">

                    <asp:TextBox ID="txtpass" runat="server" Height="21px" Width="210px" TextMode="Password"></asp:TextBox>

                </td>
                <td>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="وارد نمایید" ForeColor="Red" ControlToValidate="txtpass">*</asp:RequiredFieldValidator>

                </td>
            </tr>
               <tr>
                <td class="auto-style3">

                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>

                </td>
                <td class="auto-style4">

                    <asp:Button ID="btnsave" runat="server" Font-Names="B Yekan" Height="26px" Text="ورود" Width="54px" OnClick="btnsave_Click" />

                </td>
                <td class="auto-style5">

                </td>
            </tr>
        </table>
    </div>
</asp:Content>
