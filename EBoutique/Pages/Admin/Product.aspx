<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="EBoutique.Pages.Admin.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Liste des Produits</h2>
    <div class="form-inline">
        <asp:DropDownList ID="CategoriesDDL" runat="server" CssClass="form-control"
            AutoPostBack = "true" OnSelectedIndexChanged = "CategoryChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="ProductsPerPageDDL" runat="server" CssClass="form-control"
            AutoPostBack = "true" OnSelectedIndexChanged = "ProductsByPageChanged">
            <asp:ListItem Text="1 par page" Value="1" />
            <asp:ListItem Text="2 par page" Value="2" />
            <asp:ListItem Text="3 par page" Value="3" />
            <asp:ListItem Text="4 par page" Value="4" />
            <asp:ListItem Text="5 par page" Value="5" />
        </asp:DropDownList>
        <asp:TextBox ID="SearchTerm" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="Btn_Search" runat="server" class="btn btn-info" Text="Search" OnClick="Btn_Search_Click" />
    </div>
    <asp:GridView ID="GridviewProducts" CssClass='table table-hover table-striped'
        ItemType="EBoutique.Model.Product" runat="server" 
        DataKeyNames="ProductId"
        SelectMethod="Products_GetData"
        DeleteMethod="Products_DeleteItem"
        AutoGenerateColumns="false"
        OnRowCommand="Products_RowCommand"
        AllowPaging="true" PageSize="1"
        AllowSorting="true"
        onsorted="Products_Sorted">
        <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Button ID="btn_Insert" runat="server" class="btn btn-success" Text="Add New Product" CommandName="Insert" /> 
                </HeaderTemplate>
               <ItemTemplate>  
                   <asp:Button ID="btn_Edit" runat="server" class="btn btn-primary" Text="Edit" CommandName="Edit" CommandArgument='<%#Bind("ProductId")%>'  />  
                   <asp:Button ID="btn_Delete" runat="server" class="btn btn-danger" Text="Delete" CommandName="Delete" CommandArgument='<%#Bind("ProductId")%>' />  
               </ItemTemplate>                                     
            </asp:TemplateField>
            <asp:BoundField DataField="ProductId" HeaderText="ID" SortExpression="ProductId" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:BoundField DataField="Detail" HeaderText="Detail" SortExpression="Detail" />
            <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock"/>
            <asp:TemplateField HeaderText="Image">  
                <ItemTemplate>
                    <asp:Image ID="Image1"  Width="75" runat="server" ImageUrl='<%#"~/Images/"+ Eval("Image") %>'/> 
                </ItemTemplate>                
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
