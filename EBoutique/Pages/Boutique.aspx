<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Boutique.aspx.cs" Inherits="EBoutique.Pages.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btn_Cart" runat="server" class="btn btn-success" Text="Mon Panier: 0 €" OnClick="Button_Cart_Click"  /> 
    <br />
    <asp:Panel ID="panel_Cart" runat="server" Visible="false" BackColor="LightGray">
        <asp:GridView ID="CartGridView" CssClass='table table-hover table-striped'
            ItemType="EBoutique.Model.SaleDetail" runat="server"
            DataKeyNames="ProductId"
            SelectMethod="SaleDetails_GetData"
            DeleteMethod="SaleDetails_DeleteItem"
            AutoGenerateColumns="false"
            OnRowCommand="SaleDetails_RowCommand"
            ShowFooter="True" onrowdatabound="SaleDetails_RowDataBound">
            <Columns>  
            <asp:BoundField DataField="Product.Name" HeaderText="Product" ReadOnly = "true"/>
            <asp:TemplateField HeaderText="Quantity">  
                <ItemTemplate>
                    <asp:TextBox ID="Quantity" AutoPostBack="true" OnTextChanged="Quantity_TextChanged"  Width="75" runat="server" Text='<%# Eval("Quantity") %>' TextMode="Number" /> 
                </ItemTemplate>                
            </asp:TemplateField>
            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" ReadOnly = "true"/>
            <asp:TemplateField HeaderText="Total">  
                <ItemTemplate>
                </ItemTemplate>                
            </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btn_Delete" runat="server" class="btn btn-danger" Text="Delete" CommandName="Delete" CommandArgument='<%#Bind("SaleDetailId")%>'/>  
                    </ItemTemplate>
                    <FooterTemplate>
                         <asp:Button ID="btn_Validate" runat="server" class="btn btn-success" Text="Validate" CommandName="Validate" CommandArgument='<%#Bind("SaleDetailId")%>'/>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <div class="form-inline">
        <asp:DropDownList ID="CategoriesDDL" runat="server" CssClass="form-control form-control-sm"
            AutoPostBack = "true" OnSelectedIndexChanged = "CategoryChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="ProductsPerPageDDL" runat="server" CssClass="form-control form-control-sm"
            AutoPostBack = "true" OnSelectedIndexChanged = "ProductsByPageChanged">
            <asp:ListItem Text="1 par page" Value="1" />
            <asp:ListItem Text="2 par page" Value="2" />
            <asp:ListItem Text="3 par page" Value="3" />
            <asp:ListItem Text="4 par page" Value="4" />
            <asp:ListItem Text="5 par page" Value="5" />
        </asp:DropDownList>
        <asp:DropDownList ID="SortDDL"  runat="server" CssClass="form-control form-control-sm"
            AutoPostBack = "true" OnSelectedIndexChanged = "SortChanged">
            <asp:ListItem Text="Nom Croissant" Value="1" />
            <asp:ListItem Text="Nom Décroissant" Value="2" />
        </asp:DropDownList>
        <asp:TextBox ID="SearchTerm" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
        <asp:Button ID="Btn_Search" runat="server" class="btn btn-info" Text="Search" OnClick="Btn_Search_Click" />
    </div>
    
    <!-- DataPager control. -->
      <asp:DataPager runat="server" ID="ProductsListPager"
        PagedControlID="ProductsList" PageSize="1">
        <Fields>
          <asp:NextPreviousPagerField ButtonType="Button"
            ShowFirstPageButton="true" ButtonCssClass="btn btn-info"
            ShowNextPageButton="false" ShowPreviousPageButton="false"
             />
          <asp:NumericPagerField ButtonCount="10"  NumericButtonCssClass="btn btn-info" />
          <asp:NextPreviousPagerField ButtonType="Button"
            ShowLastPageButton="true" ButtonCssClass="btn btn-info"
            ShowNextPageButton="false" ShowPreviousPageButton="false"
             />
        </Fields>
      </asp:DataPager>
    <br />
    <asp:ListView ID="ProductsList" runat="server"
        DataKeyNames="ProductId"
        ItemType="EBoutique.Model.Product"
        SelectMethod="ProductsList_GetData"
        OnItemCommand="ProductsList_ItemCommand">
        <ItemTemplate>           
            <div class="col-xs-12 col-sm-8 col-md-6 col-lg-4 text-center">
                <div class="card bg-primary">
                    <asp:Image ID="Image1" class="card-img-top img-fluid" style="width:100%; object-fit:cover;" runat="server" ImageUrl='<%#"~/Images/"+ Eval("Image") %>'/> 
                    <div class="card-body">
                        <h3 class="card-text"> <%#Eval("Name") %><br /> <%#Eval("Price") %> €</h3>
                        <asp:Button ID="btn_Edit" runat="server" class="btn btn-success" Text="Add to Cart" CommandName="Edit" CommandArgument='<%#Bind("ProductId")%>'  /> 
                     </div>
                </div>
            </div>                      
        </ItemTemplate>
    </asp:ListView>  
</asp:Content>
