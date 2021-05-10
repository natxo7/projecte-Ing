<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="recepcionistMaster.aspx.cs" Inherits="WebApplication1.recepcionistMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="containerRecepcionistPage">
        <div class="divInfoRecepcionist">
            <asp:Label ID="Label1" runat="server" Text="">Welcome Back </asp:Label>
           <asp:Label ID="Label4" runat="server" Text="">dato nombre</asp:Label>
          <asp:Label ID="Label5" runat="server" Text="">dato apellido</asp:Label>
        </div>
        
         <div class="containerListBoxRecepcionist">
              <asp:ListBox ID="ListBox1" runat="server" Height="205px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="666px"></asp:ListBox>
         </div>
         
           <div class="divsOperations">
              <div class="buttonAddReserveDiv">
             <asp:Button ID="btnAddReserve" Width="100px" padding="10px" runat="server" Text="Add Reserve" OnClick="btnAddReserve_Click" />
             <div class="inputFieldsAdd">
                 <ul>
                     <li>
                         <div>
                             <asp:Label Text="Name: " runat="server" />
                              <asp:TextBox ID="clientName" runat="server"></asp:TextBox>
                         </div>
                     </li>
                     <li>
                         <div>
                             <asp:Label Text="Surname: " runat="server" />
                              <asp:TextBox ID="clientSurname" runat="server"></asp:TextBox>
                         </div>
                     </li>
                     <li>
                         <div>
                             <asp:Label Text="Client Idn: " runat="server" />
                             <asp:TextBox ID="clientIdn" runat="server"></asp:TextBox>
                         </div>
                     </li>
                     <li>
                         <div>
                             <asp:Label Text="Password: " runat="server" />
                             <asp:TextBox ID="clientPassword" runat="server"></asp:TextBox>
                         </div>
                     </li>
                     <li>
                         <div>
                             <asp:Label Text="CreditCard: " runat="server" />
                             <asp:TextBox ID="clientCard" runat="server"></asp:TextBox>
                         </div>
                     </li>
                     <li>
                         <div>
                             <asp:Label Text="Arrivaldate: " runat="server" />
                             <asp:TextBox ID="arrivalDate" runat="server"></asp:TextBox>
                         </div>
                     </li>
                     <li>
                         <div>
                             <asp:Label Text="FinishDate: " runat="server" />
                             <asp:TextBox ID="finishdate" runat="server"></asp:TextBox>
                         </div>
                     </li>
                     <li>
                         <div>
                             <asp:Label Text="Room type: " runat="server" />
                             <asp:TextBox ID="typeroom" runat="server"></asp:TextBox>
                         </div>
                     </li>
                 </ul>
                
       
             </div>
        
         </div>
               <div class="buttonDeleteReserveDiv">
                  <asp:Button ID="btnDeleteReserve" runat="server" Width="150px" Text="Delete Reserve" OnClick="btnDeleteReserve_Click" />
                   <div class="fieldsDelete">
                       <asp:Label Text="ID Reserve:" runat="server" />
                        <asp:TextBox ID="deleteTxBox" runat="server" OnTextChanged="deleteTxBox_TextChanged"></asp:TextBox>
                   </div>
               </div>
             <div class="buttonModifyDiv">
                 <asp:Button ID="btnModifyReserve" runat="server" Text="Modify Reserve" OnClick="btnModifyReserve_Click" />
                 <ul>
                     <li>
                         <div>
                             <asp:Label Text="Id Reserve: " runat="server" />
                             <asp:TextBox ID="inputModify" runat="server"></asp:TextBox>

                         </div>
                     </li>
                     <li>
                         <div>
                             <asp:Label Text="Idn Client:" runat="server" />
                             <asp:TextBox ID="modIdn" runat="server"></asp:TextBox>

                         </div>
                     </li>
                     <li>
                         <div>
                             <asp:Label Text="Arrival date: " runat="server" />
                             <asp:TextBox ID="modArrivalDate" runat="server"></asp:TextBox>

                         </div>
                     </li>
                     <li>
                         <div>
                             <asp:Label Text="Finish Date: " runat="server" />
                             <asp:TextBox ID="modFinishDate" runat="server"></asp:TextBox>

                         </div>
                     </li>
                     <li>
                         <div>
                             <asp:Label Text="Room type: " runat="server" />
                             <asp:TextBox ID="modTypeRoom" runat="server"></asp:TextBox>

                         </div>
                     </li>
                 </ul>
                 
                 
                
                 
                
                
                
                  <asp:Button ID="clearModify" runat="server" Text="Clear" OnClick="clearModify_Click"  />
             </div>
           </div>
        
        
        
        
         


        
    <div class="exportDiv">
        <asp:Label class="labelExport" Text="If you want to export your reserves in JSON format" runat="server" />
        <asp:Button ID="exportBtn" runat="server" Width="200px" Margin="10px" Text="EXPORT RESERVES IN JSON" OnClick="exportBtn_Click" />
    </div>
        
         </div>   
</asp:Content>