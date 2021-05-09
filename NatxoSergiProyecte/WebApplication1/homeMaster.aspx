<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homeMaster.aspx.cs" Inherits="WebApplication1.homeMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/StyleSheet1.css" rel="stylesheet" />
       
        <div class="grid-block" style="background-image: url('/img/fondo.jpg'); background-repeat: no-repeat;background-size: 100%; width: 100%; height: 400px;">
            <p class="welcome">WELCOME TO OUR HOTEL</p>
            <div class="ContentLogin">
                
                <asp:Button ID="btnGoLoginPage" runat="server" Text="GO LOGIN" OnClick="goLogin" Height="65px" Width="186px"  display="flex"   justify-content=" center" BackColor="White"/>
            </div>
            
        </div>

</asp:Content>
