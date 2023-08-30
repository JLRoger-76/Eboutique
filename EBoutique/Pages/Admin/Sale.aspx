<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Sale.aspx.cs" Inherits="EBoutique.Pages.Admin.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h1>Liste des ventes</h1>
    <asp:GridView ID="GridViewSales" runat="server"
        CssClass="table table-hover table-striped table-responsive" 
        ItemType="EBoutique.Model.Sale"
        DataKeyNames="SaleId"
        SelectMethod="Sales_GetData"
        OnRowCommand="Sales_RowCommand">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                   <asp:Button ID="btn_Chart" runat="server" class="btn btn-danger" Text="Chart" CommandName="Chart" />  
                </HeaderTemplate>
                <ItemTemplate>  
                   <asp:Button ID="btn_SaleDetail" runat="server" class="btn btn-primary" Text="Invoice" CommandName="SaleDetail" CommandArgument='<%#Bind("SaleId")%>'  />  
               </ItemTemplate> 
            </asp:TemplateField>           
        </Columns>
    </asp:GridView>
</asp:Content>
