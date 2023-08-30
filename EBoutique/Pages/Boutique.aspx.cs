using EBoutique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBoutique.Pages
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        public Context db = new Context();
        public List<Category> categories;
        protected DropDownList ddl;
        protected Model.Parameter parameters;
        protected static List<SaleDetail> saleDetails=new List<SaleDetail>();
        protected SaleDetail detail = new SaleDetail();
        protected decimal total;
        private decimal TotalSales = (decimal)0.0;
        protected void Page_Load(object sender, EventArgs e)
        {
            categories = db.Categories.ToList();
            ddl = CategoriesDDL;
            DropdownMLCategories();
            parameters = new Model.Parameter(
                Convert.ToInt32(ddl.SelectedItem.Value),
                Convert.ToInt32(ProductsPerPageDDL.SelectedItem.Value),
                Convert.ToInt32(SortDDL.SelectedItem.Value), 1, "");
            if (!IsPostBack)
            {                
                CartGridView.DataBind();
                SortDDL.SelectedValue = parameters.Sort.ToString();
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ProductsList.DataBind();                 
        }     
        protected void CategoryChanged(object sender, EventArgs e)
        {
            parameters.CategoryId = Convert.ToInt32(ddl.SelectedItem.Value);
            ddl.Items.Clear();
            DropdownMLCategories();
        }
        public DropDownList DropdownMLCategories(int selected = 0, int parentId = 0, string submark = "")
        {
            if (parameters != null) { selected = parameters.CategoryId; }
            foreach (Category cat in categories)
            {
                if (cat.ParentId == parentId)
                {
                    bool hasChild = false;
                    foreach (Category child in categories)
                    {
                        if (child.ParentId == cat.CategoryId) { hasChild = true; }
                    }
                    ListItem li = new ListItem(submark + cat.Name, cat.CategoryId.ToString());
                    if (hasChild)
                    {
                        li.Attributes.Add("disabled", "disabled");
                    }
                    if (cat.CategoryId == selected) { li.Attributes.Add("selected", "selected"); }
                    ddl.Items.Add(li);
                    DropdownMLCategories(selected, cat.CategoryId, submark + "--");
                }
            }
            return ddl;
        }
        protected void ProductsByPageChanged(object sender, EventArgs e)
        {
            parameters.ProductsByPage = Convert.ToInt32(ProductsPerPageDDL.SelectedItem.Value);
            ProductsListPager.PageSize = parameters.ProductsByPage;
            ddl.Items.Clear();
            DropdownMLCategories();
        }
        protected void SortChanged(object sender, EventArgs e)
        {
            parameters.Sort = Convert.ToInt32(SortDDL.SelectedItem.Value);
            ddl.Items.Clear();
            DropdownMLCategories();
        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            parameters.SearchTerm = SearchTerm.Text;
        }
        public IQueryable<Product> ProductsList_GetData()
        {
            if (parameters.Sort == 2)
            {
                return db.Products.
                Where(p => p.CategoryId == parameters.CategoryId &
                      p.Name.Contains(parameters.SearchTerm))
                .OrderByDescending(p=>p.Name);
            }else
            {
                return db.Products.
                Where(p => p.CategoryId == parameters.CategoryId &
                      p.Name.Contains(parameters.SearchTerm))
                .OrderBy(p => p.Name);
            }            
        }
        public List<SaleDetail> SaleDetails_GetData()
        {
            return saleDetails.ToList();
        }
        protected void ProductsList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = (int)ProductsList.DataKeys[e.Item.DisplayIndex].Value;          
            if (!saleDetails.Any(s => s.ProductId == id))
            {
                Product product = db.Products.Find(id);
                detail.UnitPrice = Convert.ToDecimal(product.Price);
                detail.Quantity = 1;
                detail.ProductId = product.ProductId;
                detail.Product= product;
                saleDetails.Add(detail);
                btn_Cart.Text = "Mon Panier :" + CalcTotal().ToString() + " €";
                CartGridView.DataBind();
            }           
        }
        protected void Button_Cart_Click(object sender, EventArgs e)
        {
            panel_Cart.Visible = !panel_Cart.Visible;
        }
        protected void SaleDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TotalSales += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Quantity"))
                    * Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "UnitPrice"));
                e.Row.Cells[3].Text = String.Format("{0:c}", TotalSales);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
                e.Row.Cells[3].Text = String.Format("{0:c}", TotalSales);
        }
        protected void Quantity_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            TextBox t1 = (TextBox)row.FindControl("Quantity");
            saleDetails[row.RowIndex].Quantity = Convert.ToInt32(t1.Text);           
            btn_Cart.Text= "Mon Panier :" + CalcTotal().ToString()+ " €";
            CartGridView.DataBind();
        }
        protected decimal CalcTotal()
        {
            decimal total = 0;
            foreach (SaleDetail detail in saleDetails)
            {
                total += detail.Quantity * detail.UnitPrice;
            }
            return total;
        }
        protected void SaleDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                saleDetails.RemoveAt(index);
                btn_Cart.Text = "Mon Panier :" + CalcTotal().ToString() + " €";
            }
            if (e.CommandName == "Validate")
            {
                Sale sale = new Sale
                {
                    SalePrice = (double)CalcTotal(),
                    SaleDate = DateTime.Now
                };
                db.Sales.Add(sale);
                db.SaveChanges();
                int id = sale.SaleId;
                foreach (SaleDetail detail in saleDetails)
                {
                    detail.SaleId = id;
                    detail.Product = null;
                    db.SaleDetails.Add(detail);
                }
                db.SaveChanges();
                saleDetails.Clear();
                CartGridView.DataBind();
            }
        }
        public void SaleDetails_DeleteItem() { }
    }
}