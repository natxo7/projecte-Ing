<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recepcionistPage.aspx.cs" Inherits="WebApplication1.WebForm2" %>

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
                        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                        <br />
                
        
    </form>
</body>
</html>
