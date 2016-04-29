<%@ Page Title="وب سایت رسمی شرکت شیمیایی کمیکس - ارتباط با ما" Language="C#" MasterPageFile="~/masterFarsi.Master" AutoEventWireup="true" CodeBehind="contactusFarsi.aspx.cs" Inherits="PRojectCH.contactusFarsi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #contact {
            width:850px;
            height:auto;
            margin-left:30px;
        }
        .resize {
            resize:none;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:960px;margin-left:auto;margin-bottom:auto;margin-top:0px;margin-right:auto">
    <div id="contact" >
      <div style="width:960px;height:auto;direction:rtl;padding:50px;margin-left:-90px">
      
          <table style="margin-right:90px;font-family:'B Yekan';font-size:medium;font-weight:bold">
          <tr>
          <td>
           <asp:Label runat="server" Text="" ID="alert"></asp:Label>
          </td>
          
          </tr>
              <tr>
                  <td>نام و نام خانوادگی:</td>

                  <td class="style2">
                      <asp:TextBox ID="name" runat="server"  Width="450" Height="25"></asp:TextBox>
                  </td>
                  <td>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                          ControlToValidate="name" ErrorMessage="* "></asp:RequiredFieldValidator>
                  </td>
                  
              </tr>
              <tr>
                  <td>آدرس ایمیل: </td>

                  <td class="style2">
                      <asp:TextBox ID="mail" runat="server" Height="25" Width="450"></asp:TextBox>
                  </td>
                  <td>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                          ControlToValidate="mail" ErrorMessage="* "></asp:RequiredFieldValidator>
                  </td>
                  <td>
                  
                      &nbsp;</td>
              </tr>
              <tr>
                  <td>پیام:</td>

                  <td class="style2">
                      <asp:TextBox ID="payam" runat="server" TextMode="MultiLine" Width="446" Height="120" CssClass="resize"></asp:TextBox></td>
                      <td>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                              ControlToValidate="payam" ErrorMessage="* "></asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
              <td class="style1">  </td>
              <td class="style3">
              <asp:Button ID="btnclick" runat="server" Text="ثبت" onclick="btnclick_Click" 
                      Width="172px" Font-Bold="True" Font-Size="Large" Font-Names="B Yekan" CssClass="borderbtn" BackColor="#666666" ForeColor="White" />
                  
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                          ErrorMessage="ایمیل نامعتبر است" ControlToValidate="mail" 
                          ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
              </td>

              </tr>
          </table>
           
          </div>
        <br />
        <hr />
        <br />
        <style type="text/css">
            .txt {
                font-family:'B Yekan';
                direction:rtl;
                font-size:large;
                color:white;
                padding-right:10px;
            }
            p {
                padding-top:20px;
            }
            .borderbtn {}
        </style>
        <div class="txt" style="background:#ff6a00;width:190px;height:190px;margin:20px;float:left">
            <p>ایمیل :<br />
                info@chemixco.com<br />
                وب سایت : <br />
                www.chemixco.com

            </p>
        </div>
        <div class="txt" style="background:#1c1f5a;width:190px;height:190px;margin:20px;float:left;margin-left:70px;">
            <p>تلفن : <br />
                026-33416308 <br />
                026-33417452

            </p>
        </div>
        <div class="txt" style="background:#524f4f;width:190px;height:190px;margin:20px;float:left;margin-left:90px;">
            <p>آدرس : <br />
                کرج - مهرشهر - بن بست کاج - پالاک 12 شمالی 
            </p>
        </div>
        </div>

    </div>
</asp:Content>
