using EBoutique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBoutique.Pages.Admin
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        public Context db = new Context();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Sale> Sales_GetData()
        {
            return db.Sales;
        }

        protected void Sales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SaleDetail")
            {
                Response.Redirect("SaleDetail.aspx?ID=" + e.CommandArgument);
            }
            if (e.CommandName == "Chart")
            {
                Response.Redirect("SalesChart.aspx");
            }
        }
    }
}