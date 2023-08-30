using EBoutique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace EBoutique.Pages.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public Context db = new Context();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public IQueryable<Category> Categories_GetData()
        {
            return db.Categories;
        }
 
        protected void Categories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridviewCategories.Rows[index];
                TextBox name = row.FindControl("txt_Name") as TextBox;
                TextBox parentId = row.FindControl("txt_ParentId") as TextBox;

                int id = Convert.ToInt32(GridviewCategories.DataKeys[index].Values[0]);
                Category item = db.Categories.Find(id);
                item.Name = name.Text;
                item.ParentId = Convert.ToInt32(parentId.Text);
                db.SaveChanges();
            }
                if (e.CommandName == "Insert")
            {
                TextBox name = (TextBox)GridviewCategories.FooterRow.FindControl("txtNewName");
                TextBox parentId = (TextBox)GridviewCategories.FooterRow.FindControl("txtNewParentId");
                Category item = new Category {Name = name.Text , ParentId= Convert.ToInt32(parentId.Text)};                       
                db.Categories.Add(item);
                db.SaveChanges();
                GridviewCategories.DataBind();
            }
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);                
                var item = new Category { CategoryId = id };
                db.Entry(item).State = EntityState.Deleted;
                db.SaveChanges();                
            }
        }
        public void Categories_UpdateItem() { }
        public void Categories_DeleteItem() { }
    }
}