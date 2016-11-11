using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Backlog
{
    public partial class BacklogMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if(!IsPostBack)
            {
                lblUser.Text = string.Format("Welcome, {0}!", this.Session["user"]);
                PopulateGridView();
                PopulateDropDownList();
            }
        }

        protected void PopulateGridView()
        {
            //gvGames.DataSource = Database.GetAllUsersGamesFromDatabase(this.Session["user"].ToString());
            lvGames.DataSource = Database.GetTestData();
            lvGames.DataBind();
        }

        protected void PopulateDropDownList()
        {
            
        }
    }
}