using EBoutique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBoutique.Pages.Admin
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public Context db = new Context();
        protected Product product= new Product();
        protected DropDownList ddl;
        public List<Category> categories;
        protected int id;
        protected void Page_Load(object sender, EventArgs e)
        {            
            id = Convert.ToInt32(Request.QueryString["ID"]);
            if (id == 0)
            {
                DetailProduct.DefaultMode = DetailsViewMode.Insert;
                DetailProduct.FindControl("ButtonUpdate").Visible = false;
            }
            else
            {
                product = db.Products.Where(p => p.ProductId == id).Single();
                DetailProduct.FindControl("ButtonInsert").Visible = false;
            }
           
            categories = db.Categories.ToList();            
            ddl = DetailProduct.FindControl("CategoriesDDL") as DropDownList;
            DropdownMLCategories();
        }
        public Product Products_GetDataByID()
        {
            return product;
        }

        public Product SetProduct() 
        {
            TextBox name = DetailProduct.Rows[1].Cells[1].Controls[0] as TextBox;
            TextBox price = DetailProduct.Rows[2].Cells[1].Controls[0] as TextBox;
            TextBox detail = DetailProduct.FindControl("txt_Detail") as TextBox;
            TextBox stock = DetailProduct.Rows[4].Cells[1].Controls[0] as TextBox;
            FileUpload fileUpload = DetailProduct.FindControl("FileUpload") as FileUpload;
            if (fileUpload.HasFile)
            {
                fileUpload.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images"), fileUpload.FileName));
            }
            product.Name = name.Text;
            product.Price = Convert.ToSingle(price.Text);
            product.Detail = detail.Text;
            product.Stock = Convert.ToInt32(stock.Text);
            product.Image = fileUpload.FileName;
            product.CategoryId = Convert.ToInt32(ddl.SelectedValue);
            return product;
        }
      
        public DropDownList DropdownMLCategories(int parentId = 0, string submark = "")
        {
            foreach(Category cat in categories)
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
                    ddl.Items.Add(li);
                    DropdownMLCategories(cat.CategoryId, submark + "--");
                }                  
            }          
            return ddl;
        }
        
        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            Product item = SetProduct();
            db.SaveChanges();
            Response.Redirect("Product.aspx");
        }
        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            Product item = SetProduct();           
            db.Products.Add(item);
            db.SaveChanges();
            Response.Redirect("Product.aspx");
        }
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product.aspx");
        }
        public void Products_UpdateItem(){}
        public void Products_InsertItem(){}        
    }
}