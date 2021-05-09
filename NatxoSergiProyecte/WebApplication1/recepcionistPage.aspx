<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recepcionistPage.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div> <asp:Label ID="Label1" runat="server" Text="">Nombre del recepcionista:</asp:Label>
          <br />
          <asp:Label ID="Label4" runat="server" Text="">dato nombre</asp:Label>
          <br />
          <asp:Label ID="Label2" runat="server" Text="">Apellidos del recepcionista</asp:Label>
         <br />
          <asp:Label ID="Label5" runat="server" Text="">dato apellido</asp:Label>
         <br />
          <asp:ListBox ID="ListBox1" runat="server" Height="205px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="666px"></asp:ListBox>
           
         <br />
         <br />
        <asp:Button ID="btnAddReserve" runat="server" Text="Add Reserve" OnClick="btnAddReserve_Click" />
        <asp:Button ID="btnAddClient" runat="server" Text="Add Client" OnClick="btnAddClient_Click" style="height: 29px"  />

        <asp:Button ID="btnDeleteReserve" runat="server" Text="Delete Reserve" OnClick="btnDeleteReserve_Click" />
        <asp:TextBox ID="deleteTxBox" runat="server" OnTextChanged="deleteTxBox_TextChanged"></asp:TextBox>
        <asp:Button ID="btnModifyReserve" runat="server" Text="Modify Reserve" OnClick="btnModifyReserve_Click" />
         <br />
         <br />
         <br />
        
        <asp:Label ID="Label6" runat="server" Text="">Apellidos del recepcionista</asp:Label>
        <br />
        <br />
        <asp:TextBox ID="clientName" runat="server"></asp:TextBox>
        <asp:TextBox ID="clientSurname" runat="server"></asp:TextBox>
        <asp:TextBox ID="clientIdn" runat="server"></asp:TextBox>
        <asp:TextBox ID="clientPassword" runat="server"></asp:TextBox>
        <asp:TextBox ID="clientCard" runat="server"></asp:TextBox>

        <asp:TextBox ID="arrivalDate" runat="server"></asp:TextBox>
        <asp:TextBox ID="finishdate" runat="server"></asp:TextBox>
        <asp:TextBox ID="typeroom" runat="server"></asp:TextBox>

        <br />
        <br />
                
        
    </form>
</body>
</html>
