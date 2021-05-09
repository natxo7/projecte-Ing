<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="clientMaster.aspx.cs" Inherits="WebApplication1.clientMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged1"></asp:ListBox>

        </div>
</asp:Content>
