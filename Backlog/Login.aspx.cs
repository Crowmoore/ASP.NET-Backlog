using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Backlog
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] != null)
            {
                Response.Redirect("BacklogMain.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = HashPassword(tbPassword.Text);
            try
            {
                if (Database.CheckUsersCredentialsFromDatabase(username, password)) {
                    lblError.Text = "Logged in";
                    this.Session["user"] = username;
                    Response.Redirect("BacklogMain.aspx");
                }
                else {
                    lblError.Text = "Invalid username or password";
                }
            } catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
          
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        public static string HashPassword(string password)
        {
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.Default.GetBytes(password);
            byte[] hashedBytes = sha.ComputeHash(bytes);
            string hashedPassword = string.Empty;
            for(int i = 0; i < hashedBytes.Length; i++)
            {
                hashedPassword += hashedBytes[i].ToString("X");
            }
            return hashedPassword;
        }
    }
}