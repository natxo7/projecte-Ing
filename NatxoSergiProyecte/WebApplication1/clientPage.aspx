﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientPage.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div> <asp:Label ID="Label1" runat="server" Text="">Nombre del cliente:</asp:Label>
                        <br />
            <asp:Label ID="Label4" runat="server" Text="">dato nombre</asp:Label>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="">Apellidos del cliente</asp:Label>
                        <br />
             <asp:Label ID="Label5" runat="server" Text="">dato apellido</asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="">DNI</asp:Label>
                        <br />
             <asp:Label ID="Label6" runat="server" Text="">dato dni</asp:Label>
                        <br />
                        <br />

        </div>
     
        <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged1"></asp:ListBox>
     
    </form>
</body>
</html>
