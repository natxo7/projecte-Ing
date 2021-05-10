<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="logMaster.aspx.cs" Inherits="WebApplication1.logMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-login " style="background-image: url('/img/fondo.jpg'); background-repeat: no-repeat;background-size: 100%; width: 100%; height: 400px; text-align:center; padding-top:20px;id=content">
        <div class="groupName">
            <p class="txt-user-login">Login as Client</p>
            <div class="username">
                <asp:Label ID="Label1" runat="server" Text="Label">Username:</asp:Label>
                <br />
                <asp:TextBox ID="txtBoxName" runat="server"></asp:TextBox>
            </div>
            <div class="password">
                <asp:Label ID="Label2" runat="server" Text="Label">Password:</asp:Label>
                <br />
                <asp:TextBox ID="txtBoxPass" runat="server"></asp:TextBox>
            </div>
            <br />
            <div class="btn_login">
                <asp:Button ID="btnInitiateSesion" runat="server" Text="Login" OnClick="btnInitiateSesion_Click" />
            </div>
        </div>
        <br />
          <div class="groupRecepcionist">
                <p class="txt-user-login">Login as Recepcionist</p>
            <div class="usernameRec">
                <asp:Label ID="Label3" runat="server" Text="Label">Recepcionist Name:</asp:Label>
                <br />
                <asp:TextBox ID="txtBoxNameRecepcionist" runat="server"></asp:TextBox>
            </div>
            <div class="passwordRec">
                <asp:Label ID="Label4" runat="server" Text="Label">Password:</asp:Label>
                <br />
                <asp:TextBox ID="txtBoxPassRec" runat="server"></asp:TextBox>
                
            </div>
              <br />
            <div class="btn_loginRec ">
                <asp:Button ID="loginRecep" runat="server" Text="Recepcionist" OnClick="recepcionistSesion_Click" />
            </div>
        </div>
     </div>
</asp:Content>



