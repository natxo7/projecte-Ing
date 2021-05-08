<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginPage.aspx.cs" Inherits="WebApplication1.loginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="groupName">
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
            <div class="btn_login">
                <asp:Button ID="btnInitiateSesion" runat="server" Text="Login" OnClick="btnInitiateSesion_Click" />
            </div>
        </div>
    </form>
</body>
</html>
