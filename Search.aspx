<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Vozra.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="VozaraCarpet.Pages.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row" style="width: 90%; direction: rtl">
            <asp:ListView class="Large-12 column" runat="server" ID="ImagesListView"
                GroupItemCount="3" Style="font-family: 'B Yekan'; font-size: 13px; text-align: center">
                <LayoutTemplate>
                    <table cellpadding="2" runat="server"
                        id="tblProducts" style="height: 320px; margin: auto; padding-top: 40px; width: 100%; text-align: center">
                        <tr runat="server" id="groupPlaceholder">
                        </tr>
                    </table>

                </LayoutTemplate>
                <GroupTemplate>
                    <tr runat="server" id="productRow"
                        style="height: 80px">
                        <td runat="server" id="itemPlaceholder"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td id="Td1" valign="top" align="center" style="width: 300px; color: white; font-family: 'B Yekan'; font-size: 13px; padding-bottom: 50px; text-align: center" runat="server">
                        <div style="width: 300px; height: 480px; text-align: center; margin: auto" runat="server">
                            <a href="ProductDetails.aspx?product=<%#Eval("Id")%>">
                                <asp:Image ID="Images" runat="server" ImageUrl='<%#"~/ProductImages/vlb_images1/" + Eval("ImageUrl") %>' Width="350" CssClass="pic" alt="danlop" />
                            </a>
                        </div>
                        <p class="carprtinfo" style="color: black;">
                            <asp:Literal ID="LiteralName" runat="server" Text='<%#(Eval("ProductName").ToString())%>'></asp:Literal>

                        </p>

                        <p class="carprtinfo" style="color: red;">
                            <del>
                                <asp:Literal runat="server" ID="ltrprice" Text='<%#(Eval("Price").ToString()) %>'></asp:Literal>
                            </del>
                        </p>

                        <p class="carprtinfo" style="color: green">
                            <asp:Literal runat="server" ID="ltroffprice" Text='<%#(Eval("OffPrice").ToString()) %>'></asp:Literal>
                        </p>
                    </td>
                </ItemTemplate>
            </asp:ListView>
          <asp:Label ID="Label1" runat="server" Font-Names="b yekan,tahoma" ForeColor="#CC0000"></asp:Label>
        </div>
</asp:Content>
