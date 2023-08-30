using EBoutique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace EBoutique.Pages.Admin
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        public Context db = new Context();
        public List<Sale> sales;
        protected void Page_Load(object sender, EventArgs e)
        {
            sales = db.Sales.ToList();
            //SeriesChartType type = SeriesChartType
            //.Area ,.Bar, .Bubble, .Column, .Line;           
            SeriesChartType type = SeriesChartType.Line;
            DisplayChart(type);
        }
        private void DisplayChart(SeriesChartType cType)
        {
            Chart1.DataSource = sales;
            Chart1.Series[0].XValueMember = "SaleDate";
            Chart1.Series[0].YValueMembers = "SalePrice";
            Chart1.Series[0].ChartType = cType;
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.Legends[0].Enabled = true;
            Chart1.DataBind();
        }
    }
}