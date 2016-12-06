using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Backlog
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string email = tbEmail.Text;
            if (validator.Validate(username, password, email))
            {
                Registeration register = new Registeration(username, password, email);
                if (register.RegisterUser())
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    lblError.Text = "Could not register at this time. Please try again later.";
                }
            }

            else
            {
                lblError.Text = HttpContext.Current.Session["Error"].ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            tbUsername.Text = string.Empty;
            tbEmail.Text = string.Empty;
            Response.Redirect("Login.aspx");
        }
    }
}