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
    public partial class WebForm2 : System.Web.UI.Page
    {
        public Context db = new Context();
        protected DropDownList ddl;
        protected Model.Parameter parameters;
        public List<Category> categories;
        protected void Page_Load(object sender, EventArgs e)
        {
            categories = db.Categories.ToList();
            ddl = CategoriesDDL;
            DropdownMLCategories();
            parameters = new Model.Parameter(
                Convert.ToInt32(ddl.SelectedItem.Value),
                Convert.ToInt32(ProductsPerPageDDL.SelectedItem.Value),
                1, 1, "");
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            GridviewProducts.DataBind();
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
            GridviewProducts.PageSize = parameters.ProductsByPage;
            ddl.Items.Clear();
            DropdownMLCategories();
        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            parameters.SearchTerm = SearchTerm.Text;
        }
        public IQueryable<Product> Products_GetData()
        {
            return db.Products.
                Where(p => p.CategoryId == parameters.CategoryId &
                      p.Name.Contains(parameters.SearchTerm));
        }
        protected void Products_Sorted(object sender, EventArgs e)
        {
            foreach (DataControlField field in GridviewProducts.Columns)
            {
                int utf16;
                field.HeaderText = field.SortExpression;
                if (field.SortExpression == GridviewProducts.SortExpression)
                {
                    if (GridviewProducts.SortDirection == SortDirection.Ascending)
                    { utf16 = 9650; }
                    else
                    { utf16 = 9660; }
                    field.HeaderText += char.ConvertFromUtf32(utf16);
                }
            }
        }
        protected void Products_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("ProductEdit.aspx?ID=" + e.CommandArgument);
            }
            if (e.CommandName == "Insert")
            {
                Response.Redirect("ProductEdit.aspx");
            }
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                var item = new Product { ProductId = id };
                db.Entry(item).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void Products_DeleteItem() { }
    }
}