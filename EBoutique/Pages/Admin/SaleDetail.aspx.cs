using EBoutique.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBoutique.Pages.Admin
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        public Context db = new Context();        
        protected int id;
        private decimal TotalSales = (decimal)0.0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["ID"]);
            SaleID.Text = id.ToString();
            GridViewSalesDetail.DataBind();
        }
        public IQueryable<SaleDetail> SalesDetail_GetData()
        {
            return db.SaleDetails.Include(d=>d.Product).Where(d => d.SaleId == id) ;
        }
        protected void SalesDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) { 
                TotalSales += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Quantity"))
                    * Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "UnitPrice"));
                e.Row.Cells[3].Text = String.Format("{0:c}", TotalSales); }
            else if (e.Row.RowType == DataControlRowType.Footer)
                e.Row.Cells[3].Text = String.Format("{0:c}", TotalSales);
        }
    }
}