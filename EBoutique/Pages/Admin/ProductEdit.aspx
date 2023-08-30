<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="EBoutique.Pages.Admin.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>Edition Produit</h2>
    <asp:DetailsView 
        ID="DetailProduct" runat="server" 
        Height="50px" Width="125px"
        ItemType="EBoutique.Model.Product" 
        DataKeyNames="ProductId"
        SelectMethod="Products_GetDataByID"
        UpdateMethod="Products_UpdateItem"
        InsertMethod="Products_InsertItem"
        class="table table-hover"
        AutoGenerateRows="False" DefaultMode="Edit">
        <Fields>
            <asp:TemplateField HeaderText="ID"> 
                <EditItemTemplate><%#Eval("ProductId")%></EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:TemplateField HeaderText="Detail">
                <EditItemTemplate>
                    <asp:TextBox ID="txt_Detail" runat="server"
                        TextMode="MultiLine" Text='<%# Bind("Detail") %>'>
                    </asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Stock" HeaderText="Stock" />
            <asp:TemplateField HeaderText="Image"> 
                <EditItemTemplate>
                    <asp:Image ID="Image1"  Width="200" runat="server" ImageUrl='<%#"~/Images/"+ Eval("Image") %>'/>
                    <asp:FileUpload ID="FileUpload" runat="server" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category"> 
                <EditItemTemplate>
                    <asp:DropDownList ID="CategoriesDDL" runat="server">
                    </asp:DropDownList>
                 </EditItemTemplate>
            </asp:TemplateField>           
            <asp:TemplateField ShowHeader="False">
            <EditItemTemplate>
                <asp:Button ID="ButtonUpdate" runat="server" CausesValidation="True" class="btn btn-success"
                    CommandName="Update" Text="Update" OnClick="ButtonUpdate_Click"  />
                &nbsp;<asp:Button ID="ButtonInsert" runat="server" CausesValidation="True" class="btn btn-success"
                    CommandName="Insert" Text="Insert" OnClick="ButtonInsert_Click"/>
                &nbsp;<asp:Button ID="ButtonCancel" runat="server" CausesValidation="True" class="btn btn-danger"
                    CommandName="Cancel" Text="Cancel" OnClick="ButtonCancel_Click"/>
            </EditItemTemplate>
        </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
</asp:Content>
