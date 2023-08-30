using EBoutique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBoutique.Pages.Admin
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        public Context db = new Context();
        protected User user = new User();
        protected SHA256 sha256Hash = SHA256.Create();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {                     
            user.Pseudo = txtName.Text;
            user.Password = BitConverter.ToString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(txtPassword.Text))).Replace("-", String.Empty);
            user.Role = "Admin";
            db.Users.Add(user);
            db.SaveChanges();
            Session["User"] = user.Role;
        }

        protected void Connect_Click(object sender, EventArgs e)
        {
            user.Pseudo = txtName.Text;
            user.Password = BitConverter.ToString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(txtPassword.Text))).Replace("-", String.Empty);
            if (db.Users.Any(s => s.Password == user.Password))
            {
                Response.Redirect("Product.aspx");
            }
            else
            {
                txtPassword.Text = "";
            }
        }
    }
}