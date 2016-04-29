<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Vozra.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="VozaraCarpet.Pages.Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href='http://fonts.googleapis.com/css?family=Open+Sans:400italic,400,300,600,700' rel='stylesheet' type='text/css' />--%>
    <%--<link href="../assets/css/bootstrapTheme.css" rel="stylesheet" />
    <link href="../assets/css/custom.css" rel="stylesheet" />--%>
    <link rel="stylesheet" href="../Content/fundation2.css" />
    <!-- Owl Carousel Assets -->
    <link href="../owl-carousel/owl.carousel.css" rel="stylesheet" />
    <link href="../owl-carousel/owl.theme.css" rel="stylesheet" />

    <link href="../assets/js/google-code-prettify/prettify.css" rel="stylesheet" />
    <script>
        var owldomain = window.location.hostname.indexOf("owlgraphic");
        if (owldomain !== -1) {
            !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');
        }
            </script>

    <%--<script src="../assets/js/jquery-1.9.1.min.js"></script>--%>
    <script src="../owl-carousel/owl.carousel.js"></script>


    <!-- Demo -->

    <style>
        .slide {
            width: 240px;
        }

        .x {
            height: 345px;
        }

        .owl-demo .slide {
            margin: 3px;
        }

            .owl-demo .slide img {
                display: block;
                width: 90%;
                height: auto;
            }

        li.nav {
            width: 200px;
        }
    </style>

    <script>
        $(document).ready(function () {

            $(".owl-demo").owlCarousel({

                autoPlay: 3000, //Set AutoPlay to 3 seconds

                items: 3,
                itemsDesktop: [1199, 3],
                itemsDesktopSmall: [979, 3]

            });

        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!----------------------------category------------------------------------>
    <div class="category" style="width: 90%; margin: auto; margin-top: 20px;">
        <nav class="top-bar" data-topbar>
            <ul class="title-area">
                <li class="name">
                    <h1><a href="#"></a></h1>
                </li>
                <!-- Collapsible Button on small screens: remove the .menu-icon class to get rid of icon. 
                            Remove the "Menu" text if you only want to show the icon -->
                <li class="toggle-topbar menu-icon"><a href="#"><span></span></a></li>
            </ul>

            <section class="top-bar-section">
                <ul class="right" style="text-align: center">

                    <asp:Literal runat="server" ID="ltrtopmenu"></asp:Literal>
                </ul>
            </section>
        </nav>
    </div>
    <!-------------------------------search------------------------------------------>
    <div class="row search" style="width: 90%; margin-top: 30px">
        <div class="medium-6 columns">
            <div class="row">
                <div class="large-10 columns">
                    <div class="row collapse">
                        <div class="small-2 columns">
                            <asp:Button runat="server" Text="جستجو" id="btnSearch" onclick="btnSearch_Click" href="#" class="button postfix"></asp:Button>
                        </div>
                        <div class="small-10 columns">
                            <asp:TextBox runat="server" id="txtsr" type="text" placeholder="محصول ، دسته یا برن مورد نظرتان را جستجو کنید" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="medium-6 columns"></div>

    </div>
    <!-------------------------------------------------------------------------------------->
    <div class="row" style="width: 90%;">
        <div class="small-2 columns show-for-medium-up" style="background: #f1f1f1; margin-top: 40px;">

            <ul class="no-bullet cat" style="direction: rtl; text-align: -webkit-center; font-family: b yekan;">
                <li style="border-bottom: 1px solid white; /* padding-bottom: 27px; */
    margin-bottom: 20px; margin-top: 10px;">دسته بندی محصولات
               
                </li>
                <asp:Literal runat="server" ID="ltrletfmenu"></asp:Literal>


            </ul>
        </div>
        <!-----------------------------------------category----------------------------------------->
        <div class="small-10 columns">
            <!--------------------------------------------------------------------------------------->
            <span style="width: 200px; height: 40px; background: #f1f1f1; float: right; font-size: 18px; font-family: b yekan; padding-top: 10px; text-align: center; border-top-left-radius: 40px; border-top-right-radius: 0px;">
                <asp:Label runat="server" ID="lbl1"></asp:Label></span>
            <div class="small-12px columns owl-demo" style="background: #f1f1f1; padding-top: 20px; padding-bottom: 20px; text-align: center; min-height: 520px;">
                <asp:Literal runat="server" ID="ltrslider1">
                   
                </asp:Literal>

            </div>

            <!------------------------------------------------------------------------------------------------->
            <span style="width: 200px; height: 40px; background: white; float: right; font-size: 18px; font-family: b yekan; padding-top: 10px; text-align: center; border-top-left-radius: 40px; border-top-right-radius: 0px; margin-top: -39px; z-index: 9999; position: relative;">
                <asp:Label runat="server" ID="lbl2"></asp:Label></span>
            <div class="small-12px columns owl-demo" style="padding-top: 20px; padding-bottom: 20px; text-align: center;">
                <asp:Literal runat="server" ID="ltrslider2">
                   
                </asp:Literal>
            </div>
            <!---------------------------------------------------------------------------------------------------------->
            <span style="width: 200px; height: 40px; background: #f1f1f1; float: right; font-size: 18px; font-family: b yekan; padding-top: 10px; text-align: center; border-top-left-radius: 40px; border-top-right-radius: 0px;">
                <asp:Label runat="server" ID="lbl3"></asp:Label></span>
            <div class="small-12px columns owl-demo" style="background: #f1f1f1; padding-top: 20px; padding-bottom: 20px; text-align: center;">
                <asp:Literal runat="server" ID="ltrslider3">
                   
                </asp:Literal>
            </div>
        </div>
        <!--------------------------------------------------------------------------------->

    </div>

</asp:Content>
