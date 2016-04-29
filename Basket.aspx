<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Vozra.Master" AutoEventWireup="true" CodeBehind="Basket.aspx.cs" Inherits="VozaraCarpet.Pages.Basket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
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
        <div id="titr" class="large-12 columns">
            <h2 style="font-family: 'B Bardiya'; text-align: center; font-size: 28px;">تکمیل سبد خرید</h2>
            <asp:HiddenField runat="server" ID="hdf" />
        </div>
        <div class="large-12 columns" style="direction: rtl; margin: auto; text-align: center; padding-top: 50px; padding-bottom: 50px" id="slide">
            <asp:Label ID="lblmsg" runat="server" Text="سبد خرید خالی می باشد." Font-Size="Large" ForeColor="Red" Font-Names="b yekan" Style="text-align: center"></asp:Label>
            <asp:GridView ID="GridView1" class="large-12 columns" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" DataKeyNames="Id" DataSourceID="SqlDataSource1" Style="font-family: 'B Yekan'; font-size: 13px; margin: auto; font-weight: normal">
                <Columns>
                    <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("Id") %>' ID="lblId" runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label Text='<%#Eval("Id") %>' ID="lblId" runat="server"></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="قیمت">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("Price") %>' ID="lblPriceId" runat="server"></asp:Label>
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
                    <asp:TemplateField HeaderText="رنگ">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("Color") %>' ID="lblcolor" runat="server"></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="رنگ" Visible="false">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("Color") %>' ID="lblcolorId" runat="server"></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="تعداد">
                        <ItemTemplate>
                            <asp:Label Text='<%#Bind("number") %>' ID="lblNo" runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox Text='<%#Bind("number") %>' ID="txtModifyNo" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>' OnClick="LinkButton1_Click">بروزرسانی</asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>' OnClick="LinkButton3_Click1">ویرایش</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton5" runat="server" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>' OnClick="LinkButton5_Click">انصراف</asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="blkaFasel" Text="  -  " runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>' OnClick="LinkButton2_Click">حذف</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lblprice" runat="server" Text=''></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
            <asp:Button ID="btnfactor" Visible="false" runat="server" Text="ارسال فاکتور " OnClick="Button1_Click" Font-Names="B Yekan" Height="24px" Width="80px" />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Vozaraconnection %>" SelectCommand="select Tbl_Buy.Id as Id, Tbl_Buy.Colorid, Tbl_Buy.ProductId , Tbl_Product.OffPrice as Price, Tbl_Buy.[No] as number, Tbl_Color.ColorName as Color , Tbl_Product.ProductName from Tbl_Buy 
                inner join Tbl_Color on Tbl_Buy.Colorid=Tbl_Color.Id 
                inner join Tbl_Product on Tbl_Buy.ProductId=Tbl_Product.Id WHERE (([UserId] = @UserId))"
                ProviderName="<%$ ConnectionStrings:Vozaraconnection.ProviderName %>">
                <SelectParameters>
                    <asp:SessionParameter Name="UserId" SessionField="userid" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView2" class="large-12 columns" DataKeyNames="کد شناسايي" runat="server" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowCommand="GridView2_RowCommand" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" AutoGenerateColumns="false" Style="font-family: 'B Yekan'; font-size: 13px; direction: rtl; margin: auto; width: 380px;" AutoGenerateDeleteButton="False" AutoGenerateEditButton="True" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                <Columns>

                    <asp:TemplateField HeaderText="کد محصول" Visible="true">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("کد محصول") %>' ID="lblNo2" runat="server"> </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label Text='<%#Eval("کد محصول") %>' ID="lblNo2" runat="server"></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="کد شناسايي" Visible="true">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("کد شناسايي") %>' ID="lblNo4" runat="server"> </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label Text='<%#Eval("کد شناسايي") %>' ID="lblNo4" runat="server"></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="نام محصول" Visible="true">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("نام محصول") %>' ID="lblNo3" runat="server"> </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label Text='<%#Eval("نام محصول") %>' ID="lblNo3" runat="server"></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="رنگ">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("رنگ") %>' ID="lblcolor" runat="server"> </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label Text='<%#Eval("رنگ") %>' ID="lblcolor" runat="server"></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="تعداد" Visible="true">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("تعداد") %>' ID="lblNo" runat="server"> </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox Text='<%#Bind("تعداد") %>' ID="nn" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="قیمت" Visible="true">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("قیمت") %>' ID="lblprice" runat="server"> </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label Text='<%#Eval("قیمت") %>' ID="lblprice" runat="server"></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="قیمت کل" Visible="true">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("قیمت کل") %>' ID="lbltprice" runat="server"> </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label Text='<%#Eval("قیمت کل") %>' ID="lbltprice" runat="server"></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClick="LinkButton3_Click">حذف</asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClick="LinkButton3_Click">حذف</asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            <asp:Label ID="lbltprice" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblHide" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Button ID="btncookie" runat="server" Visible="false" Text="ارسال فاکتور" OnClick="btncookie_Click" Height="24px" Width="80px" Style="font-family: 'B Yekan'; font-size: 13px; float: left" />
        </div>

    </div>
</asp:Content>
