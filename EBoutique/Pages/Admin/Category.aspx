<%@ Page Title="Categories" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="EBoutique.Pages.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridviewCategories" CssClass='table table-hover table-striped'
        ItemType="EBoutique.Model.Category" runat="server" 
        DataKeyNames="CategoryId"
        SelectMethod="Categories_GetData"
        UpdateMethod="Categories_UpdateItem"
        DeleteMethod="Categories_DeleteItem"
        AutoGenerateColumns="false"        
        ShowFooter="true"
        OnRowCommand="Categories_RowCommand">
        <Columns>
            <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" class="btn btn-primary" Text="Edit" CommandName="Edit"  />  
                        <asp:Button ID="btn_Delete" runat="server" class="btn btn-danger" Text="Delete" CommandName="Delete" CommandArgument='<%#Bind("CategoryId")%>' />  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" class="btn btn-primary" Text="Update" CommandName="Update" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>  
                        <asp:Button ID="btn_Cancel" runat="server" class="btn btn-danger" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate> 
                    
                </asp:TemplateField>  
            <asp:TemplateField HeaderText="ID">  
                <ItemTemplate><%#Eval("CategoryId")%></ItemTemplate>
                <FooterTemplate> 
                    <asp:Button ID="btn_Insert" runat="server" class="btn btn-success" Text="Insert" CommandName="Insert"/> 
                </FooterTemplate>
            </asp:TemplateField>           
            <asp:TemplateField HeaderText="Name">  
                    <ItemTemplate><%#Eval("Name")%></ItemTemplate> 
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_name" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>  
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="txtNewName"></asp:TextBox>
                    </FooterTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ParentId">  
            <ItemTemplate><%#Eval("ParentId")%></ItemTemplate>
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_ParentId" runat="server" Text='<%#Eval("ParentId") %>'></asp:TextBox>  
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="txtNewParentId"></asp:TextBox>
                    </FooterTemplate>  
            </asp:TemplateField>            
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
