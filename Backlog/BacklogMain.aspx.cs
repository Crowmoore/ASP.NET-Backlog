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
                PopulateGenreList();
                PopulateStatusList();
            }
        }

        protected void PopulateGridView()
        {
            //gvGames.DataSource = Database.GetAllUsersGamesFromDatabase(this.Session["user"].ToString());
            lvGames.DataSource = Database.GetTestData();
            lvGames.DataBind();
        }

        protected void PopulateGenreList()
        {
            ddlGenres.DataSource = Database.GetAllGenresFromDatabase();
            ddlGenres.DataTextField = "name";
            ddlGenres.DataValueField = "name";
            ddlGenres.DataBind(); 
        }

        protected void PopulateStatusList()
        {
            ddlStatus.DataSource = Database.GetAllStatusFromDatabase();
            ddlStatus.DataTextField = "name";
            ddlStatus.DataValueField = "name";
            ddlStatus.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text;
            string genre = ddlGenres.SelectedValue;
            string achievements = string.Format("{0}/{1}", tbAchievementsGained.Text, tbAchievementsTotal.Text);
            string status = ddlStatus.SelectedValue;
            string comment = tbComment.Text;
            string user = this.Session["user"].ToString();

            try
            {
                Database.AddNewGame(user, title, achievements, status, comment, genre);
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}