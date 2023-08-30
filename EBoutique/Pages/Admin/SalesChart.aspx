<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="SalesChart.aspx.cs" Inherits="EBoutique.Pages.Admin.WebForm8" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HyperLink ID="HyperLink1" CssClass="btn btn-primary" runat="server"
        NavigateUrl="Sale.aspx">Retour aux Ventes
    </asp:HyperLink>
    <br />
    <asp:Chart ID="Chart1" runat="server" Height="600px" Width="800px">  
        <Titles>  
            <asp:Title ShadowOffset="3" Name="Items" Text="Ventes réalisées" Font="Microsoft Sans Serif, 16pt" />  
        </Titles>  
        <Legends>  
            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" TitleFont="Microsoft Sans Serif, 16pt, style=Bold" />  
        </Legends>  
        <Series>  
            <asp:Series Name="Ventes" Font="Microsoft Sans Serif, 14pt" />  
        </Series>  
        <ChartAreas>  
            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />  
        </ChartAreas>  
    </asp:Chart>  
</asp:Content>
