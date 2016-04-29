<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/vozara1.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="VozaraCarpet.Pages.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        input:-webkit-autofill {
            -webkit-box-shadow: 0 0 0px 1000px #eecaf7 inset;
        }


        .tdd{
            font-size: 15px;
            font-weight: bold;
            text-align:right;
            font-family:'B Yekan';
               
        }
    </style>
    <link rel="stylesheet" href="http://ifont.ir/apicode/38" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="width:90%;margin-top:20px">
        
            <div id="map" class="large-12 columns">
                <iframe width="100%" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://www.google.com/maps/d/embed?mid=z5JOm3wJi42o.klV1NnYbtz24"></iframe>
                <br />
                <small><a href="https://www.google.com/maps/d/embed?mid=z5JOm3wJi42o.klV1NnYbtz24" style="color: #0000FF; text-align: left">نقشه را بزرگتر ببینید</a></small>
            </div>
            <div class="large-6 columns">
                <table>
                    <tr>
                        <td class="tdd">تلفن : 
                        </td>

                    </tr>
                    <tr>
                        <td>
                            026-34439834
                            <br />
                            026-34405088
                        </td>
                    </tr>
                    <tr>
                        <td class="tdd">ایمیل : 

                        </td>
                    </tr>
                    <tr>

                        <td>info@vozaracarpet.com
                        </td>
                    </tr>
                    <tr>
                        <td class="tdd">آدرس :
                        </td>
                    </tr>
                    <tr>

                        <td style="font-family:'B Yekan';text-align:right;font-size:13px">
                             استان البرز - کرج - سه راه گوهردشت - نرسیده به سه باندی
                        </td>
                    </tr>
                </table>
            </div>
            <div class="large-6 columns">
                <table>
                    <tr>
                        <td class="tdd">نام و نام خانوادگی :</td>
                        
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox CssClass="w3-input w3-border" ID="txtname" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="وارد کردن نام الزامی است" ForeColor="#CC0000" ControlToValidate="txtname" Font-Size="Medium" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="tdd">آدرس یمیل :</td>
                    
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox CssClass="w3-input w3-border" ID="txtmail" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="وارد کردن نام الزامی است" ForeColor="#CC0000" ControlToValidate="txtmail" Font-Size="Medium" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                      
                    </tr>
                    <tr>
                        <td class="tdd">شماره تماس :</td>
                     
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox CssClass="w3-input w3-border" ID="txttell" runat="server"></asp:TextBox>
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="tdd">درخواست :</td>
                      
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox CssClass="w3-input w3-border" ID="txtrequest" runat="server" Height="123px" TextMode="MultiLine" Width="383"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="وارد کردن نام الزامی است" ForeColor="#CC0000" ControlToValidate="txtrequest" Font-Size="Medium" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                       
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnsend" runat="server" Text="ارسال" BorderStyle="None" Font-Names="b yekan" Font-Size="Medium" Height="35px" Width="391px" Style="border-radius: 9px; background: linear-gradient(to left,rgb(91, 14, 97),rgb(250, 250, 250)); background: -webkit-linear-gradient(left,rgb(91, 14, 97),rgb(250, 250, 250)); box-shadow: 0px 0px 15px -2px; margin-top: 13px;" OnClick="btnsend_Click" />
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </td>
                      
                    </tr>
                </table>
            </div>

        </div>
    
</asp:Content>
