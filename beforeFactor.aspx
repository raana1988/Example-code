<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Vozra.Master" AutoEventWireup="true" CodeBehind="beforeFactor.aspx.cs" Inherits="VozaraCarpet.Pages.beforeFactor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 800px;
            font-family: 'B Yekan';
            font-size: 13px;
            margin: auto;
            border-collapse: collapse;
            border: solid 2px;
        }

        .auto-style2 {
            height: 23px;
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
    <div class="row" style="width: 90%; margin: auto;">

        <div class="large-12 columns" id="titr">
            <h2 style="font-family: 'B Bardiya'; text-align: center; font-size: 28px;">پیش فاکتور</h2>
            <asp:HiddenField runat="server" ID="hdf" />
        </div>
        <div class="large-12 columns" style="direction: rtl; margin: auto; text-align: center; padding-top: 50px;">
            <asp:LinkButton ID="LinkButton1" Style="margin: auto" OnClick="LinkButton1_Click" runat="server">ویرایش و حذف سبد خرید</asp:LinkButton>
            <table class="auto-style1" dir="rtl" border="1">

                <tr>
                    <td>فروشنده&nbsp; </td>
                    <td>فروشگاه فرش وزرا</td>
                </tr>
                <tr>
                    <td>خریدار </td>
                    <td>

                        <asp:Literal runat="server" ID="ltrusername">

                        </asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">

                        <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Style="width: 800px; font-family: 'B Yekan'; font-size: 13px; direction: ltr; text-align: right;" OnLoad="GridView1_Load">
                            <Columns>
                                <asp:TemplateField HeaderText="" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("Id") %>' ID="lblId" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label Text='<%#Eval("Id") %>' ID="lblId" runat="server"></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="قیمت کل">
                                    <ItemTemplate>
                                        <asp:Label ID="lblprice" runat="server" Text=''></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" قیمت واحد">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("Price") %>' ID="lblPriceId" runat="server"></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="تعداد">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("No") %>' ID="lblNo" runat="server"></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="رنگ">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("ColorName") %>' ID="lblDimension" runat="server"></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="رنگ" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("ColorName") %>' ID="lblDimensionId" runat="server"></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="محصول">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("ProductName") %>' ID="lblProduct" runat="server"></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="محصول" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("ProductId") %>' ID="lblProductId" runat="server"></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>

                            </Columns>

                        </asp:GridView>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Vozaraconnection %>" SelectCommand="select Tbl_Buy.Id,
 Tbl_Buy.UserId , Tbl_Buy.Colorid, Tbl_Buy.ProductId,
 Tbl_Buy.Price, Tbl_Buy.[No], Tbl_Color.ColorName , Tbl_Product.ProductName from Tbl_Buy 
inner join Tbl_Color on Tbl_Buy.Colorid=Tbl_Color.Id 
inner join Tbl_Product on Tbl_Buy.ProductId=Tbl_Product.Id WHERE ([UserId] = @UserId)">
                            <SelectParameters>
                                <asp:SessionParameter Name="UserId" SessionField="userid" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Style="width: 800px; font-family: 'B Yekan'; font-size: 13px; text-align: right;">
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
                                <asp:TemplateField HeaderText="رنگ">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("رنگ") %>' ID="lblColor" runat="server"></asp:Label>
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
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">مبلغ قابل پرداخت :</td>
                    <td class="auto-style2">
                        <asp:Literal ID="ltrprice" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            نحوه تحویل کالا
    <hr />
            <br />
        </div>
    </div>
    <div class="row" style="width: 90%">
        <div class="large-12 columns" style="direction: rtl">
            <asp:GridView OnRowCommand="grdTransfer_RowCommand" runat="server" ID="grdTransfer" DataSourceID="SDSTransfer" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="انتخاب کنید">
                        <ItemTemplate>
                            <asp:RadioButton ID="rdlTransfer" Checked="false" runat="server" onclick="checkRadioBtn(this);" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="کد">
                        <ItemTemplate>
                            <asp:Label ID="lblTId" runat="server" Text='<%#Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="نوع ارسال">
                        <ItemTemplate>
                            <asp:Label ID="lblTName" runat="server" Text='<%#Eval("TransferName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="هزینه ارسال">
                        <ItemTemplate>
                            <asp:Label ID="lblTFee" runat="server" Text='<%#Eval("TransferFee") %>' />
                            ریال 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="توضیحات">
                        <ItemTemplate>
                            <asp:Label ID="lblTDesc" runat="server" Text='<%#Eval("TDesc") %>' Width="400px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SDSTransfer" runat="server" ConnectionString="<%$ ConnectionStrings:Vozaraconnection %>" SelectCommand="select_active_Transfer" SelectCommandType="StoredProcedure" />
            <br />

            <asp:Label Text="  نشانی تحویل کالا بصورت نام استان - نام شهر -خیابان اصلی - خیابان فرعی - کوچه - پلاک " ID="Label1" runat="server" />
            <hr />
            <asp:Label Text="آدرس " ID="Label2" Width="300px" runat="server" />

            <asp:TextBox ID="txtAddress" Width="450px" Height="50px" Font-Names="B Yekan,Tahoma" TextMode="MultiLine" runat="server" />
            <br />
            <asp:Label Text="کدپستی " ID="Label3" Width="300px" runat="server" />
            <asp:TextBox ID="TxtPostalCode" Width="200px" Font-Names="B Yekan,Tahoma" runat="server" />
            <br />
            <asp:Label Text="نام تحویل گیرنده - ارائه کدملی الزامی است" ID="Label4" Width="300px" runat="server" />
            <asp:TextBox ViewStateMode="Enabled" ID="txtDest" Width="200px" Font-Names="B Yekan,Tahoma" runat="server" />
            <br />
            <asp:Label Text="تلفن ثابت بصورت کدشماره تلفن مثال : 02122222222" ID="Label5" Width="300px" runat="server" />
            <asp:TextBox ViewStateMode="Enabled" ID="txtTel" Width="200px" Font-Names="B Yekan,Tahoma" runat="server" />
            <br />
            <asp:Label Text="تلفن همراه" ID="Label6" Width="300px" runat="server" />
            <asp:TextBox ViewStateMode="Enabled" ID="TxtMob" Width="200px" Font-Names="B Yekan,Tahoma" runat="server" />
            <br />

            روش پرداخت
                    <hr />
            <table id="tblPay" style="margin: auto" runat="server" dir="rtl">
                <tr>
                    <td>
                        <asp:RadioButton runat="server" ID="rdlonlinePay" Text="پرداخت اینترنتی" />
                    </td>
                    <td></td>
                    <td>انتخاب درگاه پرداخت
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Vozaraconnection %>" SelectCommand="SELECT [Id], [BankName] FROM [Tbl_Bank] WHERE ([IsActive] = @IsActive)">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="true" Name="IsActive" Type="Boolean" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpPTP" DataSourceID="SqlDataSource2" DataTextField="BankName" DataValueField="Id" Font-Names="B Yekan,Tahoma" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton runat="server" ID="RadioButton1" Text="پرداخت کارت به کارت" />
                    </td>
                    <td></td>
                    <td>نام بانک - به نام - شماره کارت </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpCTC" Font-Names="B Yekan,Tahoma" />

                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>مبلغ پرداختی</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" TextMode="Number" Width="85px"></asp:TextBox>
                        &nbsp;
                                ریال
                    </td>
                    <td>&nbsp;تاریخ واریز&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Width="94px"></asp:TextBox>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton runat="server" ID="RadioButton2" Text="پرداخت در محل" />
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button3" runat="server" Visible="false" Style="font-family: 'B Yekan'" Text="پرداخت" OnClick="Button1_Click" Height="27px" Width="65px" BackColor="#993366" BorderStyle="Solid" ForeColor="White" />
                        <asp:Button ID="Button4" runat="server" Visible="false" Text="پرداخت" Style="font-family: 'B Yekan'" OnClick="Button2_Click" Height="27px" Width="65px" BackColor="#993366" BorderStyle="Solid" ForeColor="White" />

                        <asp:Label ID="lblMsg" runat="server" Font-Names="B yekan,Tahoma" ForeColor="Red"></asp:Label>

                        <asp:Button ID="Button1" runat="server" Visible="false" Style="font-family: 'B Yekan'" Text="پرداخت" OnClick="Button1_Click" Height="27px" Width="65px" BackColor="#993366" BorderStyle="Solid" ForeColor="White" />
                        <asp:Button ID="Button2" runat="server" Visible="false" Text="پرداخت" Style="font-family: 'B Yekan'" OnClick="Button2_Click" Height="27px" Width="65px" BackColor="#993366" BorderStyle="Solid" ForeColor="White" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Label runat="server" Text="نشانی تحویل کالا" ID="lbl"></asp:Label>
        </div>


    </div>


</asp:Content>
