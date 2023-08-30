<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="EBoutique.Pages.Admin.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblName" runat="server" Text="Non d'Utilisateur"></asp:Label>
    <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblPassword" runat="server" Text="Mot de Passe"></asp:Label>
    <asp:TextBox ID="txtPassword" class="form-control" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Connect" runat="server" class="btn btn-primary" Text="Connection" OnClick="Connect_Click" />
    <asp:Button ID="Save" runat="server" class="btn btn-primary" Text="Enregistrement" OnClick="Save_Click" />

</asp:Content>
