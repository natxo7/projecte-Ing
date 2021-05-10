<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="clientMaster.aspx.cs" Inherits="WebApplication1.clientMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="containerClientPage"> 
           <div class="clientcontainerDiv">

                <div class="box-info-user">
               <div class="infoUserName">
                   <asp:Label ID="Label1" runat="server" Text="">WELCOME</asp:Label>    
                   <br />
                   <asp:Label ID="Label4" runat="server" Text="">dato nombre</asp:Label>           
                   <asp:Label ID="Label5" runat="server" Text="">dato apellido</asp:Label>
               </div>
                

               <div class="infoIDNClient">
                     <asp:Label ID="Label3" runat="server" Text="">Your reserves with IDN : </asp:Label>
                  
                        <asp:Label ID="Label6" runat="server" Text="">dato dni</asp:Label>
               </div>
                     

           </div>
          
           <div class="infolistboxUser">
                <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged1" Height="81px" Width="269px"></asp:ListBox>
           </div>
           </div>
          
           

        </div>
</asp:Content>
