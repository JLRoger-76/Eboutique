<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="SaleDetail.aspx.cs" Inherits="EBoutique.Pages.Admin.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Facture
        <asp:Literal ID="SaleID" runat="server"></asp:Literal>
    </h1>
    <asp:HyperLink ID="HyperLink1" CssClass="btn btn-primary" runat="server"
        NavigateUrl="Sale.aspx">Retour aux Ventes
    </asp:HyperLink>
    <asp:GridView ID="GridViewSalesDetail"
        CssClass='table table-hover table-striped table-responsive'
        ItemType="EBoutique.Model.SaleDetail" 
        runat="server"
        AutoGenerateColumns="false"
        DataKeyNames="SaleDetailId"
        SelectMethod="SalesDetail_GetData"
        ShowFooter="True" onrowdatabound="SalesDetail_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Product.Name" HeaderText="Produit"/>
            <asp:BoundField DataField="Quantity" HeaderText="Quantite"/>
            <asp:BoundField DataField="UnitPrice" HeaderText="Prix" FooterStyle-Font-Bold="true" FooterText="Total:"/>
            <asp:TemplateField HeaderText="Total">  
                <ItemTemplate></ItemTemplate>                
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
