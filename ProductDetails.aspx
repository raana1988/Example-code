<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/vozara1.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="VozaraCarpet.Pages.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Js/jquery.elevatezoom.js"></script>
    <%--  <script type="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>--%>

    <style type="text/css">
        .auto-style1 {
            /*width: 100%;*/
            font-family: 'B Yekan';
            font-size: 13px;
            text-align: center;
        }

        .auto-style2 {
            height: 24px;
        }

        .auto-style3 {
            height: 26px;
        }

        .cs {
            text-align: center;
            direction: ltr;
            font-size: 13px;
        }

        .cs2 {
            text-align: center;
            /*direction: ltr;*/
            font-size: 18px;
        }
        /*---------------------------------------------------------*/
        

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="row" style="width: 90%; margin: auto; margin-top: 20px;">
        <!-----------------------------color carpet-------------------------------->
        <div class="large-2 columns">
            <table runat="server" class="auto-style1 pro" dir="rtl">

                <tr>

                    <td class="cs">
                        <asp:Literal runat="server" ID="ltrcolocarpet"></asp:Literal>
                    </td>
                </tr>
            </table>
        </div>
        <!-----------------------------Image-------------------------------->
        <div class="large-6 columns">
            <table runat="server" class="auto-style1 pro" style="margin: auto" dir="rtl">
                <tr>

                    <td colspan="4" class="cs" rowspan="5">
                        
                            <asp:Literal ID="ltrimg" runat="server"></asp:Literal>
                        
                    </td>

                </tr>

            </table>
            <table runat="server" class="auto-style1 pro displaygallery" style="margin: auto" dir="rtl">
                <tr>
                    <td rowspan="2" class="cs">
                        <a href="#">
                            <asp:Literal ID="ltrpic1" runat="server"></asp:Literal>
                        </a>
                    </td>
                    <td rowspan="2" class="cs">
                        <a href="#">
                            <asp:Literal ID="ltrpic2" runat="server"></asp:Literal>
                        </a>
                    </td>
                    <td rowspan="2" class="cs">
                        <a href="#">
                            <asp:Literal ID="ltrpic3" runat="server"></asp:Literal>
                        </a>
                    </td>
                    <td rowspan="2" class="cs">
                        <a href="#">
                            <asp:Literal ID="ltrpic4" runat="server"></asp:Literal>
                        </a>
                    </td>
                </tr>
            </table>
        </div>
        <!-----------------------------Info-------------------------------->
        <div class="large-4 columns">
            <table runat="server" class="auto-style1 pro" style="float: right" dir="rtl">
                <tr>
                    <td class="auto-style3 cs2">قیمت اصلی</td>

                    <td class="auto-style3 cs2">
                        <asp:Literal ID="ltrprice" runat="server"></asp:Literal>
                    </td>

                </tr>
                <tr>
                    <td class="cs2">قیمت با تخفیف&nbsp;
                    </td>
                    <td class="cs2">
                        <asp:Literal ID="ltrpriceoff" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="cs2">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Style="text-align: justify" DataSourceID="SqlDataSource1" DataTextField="ColorName" DataValueField="ColorId"></asp:RadioButtonList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Vozaraconnection %>" ProviderName="<%$ ConnectionStrings:Vozaraconnection.ProviderName %>" SelectCommand="SELECT Tbl_CarpetColor.ColorId, Tbl_CarpetColor.Id, Tbl_Color.ColorName FROM Tbl_CarpetColor INNER JOIN Tbl_Color ON Tbl_CarpetColor.ColorId = Tbl_Color.Id WHERE (Tbl_CarpetColor.ProductId = @ProductId)">
                            <SelectParameters>
                                <asp:QueryStringParameter DefaultValue="1035" Name="ProductId" QueryStringField="id" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td class="cs" colspan="2">
                        <asp:Button ID="btnbuy" Style="background-color: white; border: none" ToolTip="اضافه به سبد خرید" runat="server" Text="اضافه به سبد خرید" OnClick="btnbuy_Click" Font-Names="B Yekan" Font-Size="13px" />
                    </td>
                </tr>
            </table>
            <table runat="server" class="auto-style1 pro" style="float: right" dir="rtl">
                <tr>
                    <td class="auto-style3 cs">کد محصول</td>

                    <td class="auto-style3 cs">
                        <asp:Literal ID="ltrcode" runat="server"></asp:Literal>
                    </td>

                </tr>
                <tr>
                    <td class="cs">نام محصول
                    </td>
                    <td class="cs">
                        <asp:Literal ID="ltrname" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="cs">نام تولید کننده
                    </td>
                    <td class="cs">
                        <asp:Literal ID="ltrproducer" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="cs">تراکم</td>
                    <td class="cs">
                        <asp:Literal ID="ltrtarakom" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="cs">شانه</td>
                    <td class="cs">
                        <asp:Literal ID="ltrshane" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="cs">ابعاد</td>
                    <td class="cs">
                        <asp:Literal ID="ltrdimen" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2 cs">رنک
                    </td>
                    <td class="auto-style2 cs">
                        <asp:Literal ID="ltrcolor" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="cs">تعداد
                    </td>

                    <td class="cs">
                        <asp:Literal ID="ltrcount" runat="server"></asp:Literal>
                    </td>

                </tr>
                <tr>
                    <td colspan="2" class="cs">
                        <asp:Literal ID="ltrdesc" runat="server"></asp:Literal>
                    </td>
                </tr>


            </table>
        </div>
        <asp:Label runat="server" ID="lblcode" Visible="false" Text=""></asp:Label>
        <asp:Label runat="server" ID="lblprice" Visible="false" Text=""></asp:Label>
        <asp:Label runat="server" ID="lblcolor" Visible="false" Text=""></asp:Label>
    </div>
    <div class="row" style="width: 90%; margin: auto">
        <!-----------------------------suggest-------------------------------->
        <div class="large-12 columns" style="height: 50px;">
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
        </div>
        <!-----------------------------more-------------------------------->
        <div class="large-12 columns" style="height: 50px;">
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#zoom_01').elevateZoom();
        });
    </script>
</asp:Content>
