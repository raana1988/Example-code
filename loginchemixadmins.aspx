<%@ Page Title="" Language="C#" MasterPageFile="~/masterFarsi.Master" AutoEventWireup="true" CodeBehind="loginchemixadmins.aspx.cs" Inherits="PRojectCH.loginchemixadmins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-bottom:50px;margin-top:80px;height:200px;margin-left:300px">
    <asp:Login ID="Login2" runat="server" DestinationPageUrl="~/Admin/HomeAdmin.aspx" style="text-align: justify; margin-left: 76px" Width="218px" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333">
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
        <TextBoxStyle Font-Size="0.8em" />
        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
    </asp:Login>
                                    
    </div>
</asp:Content>
