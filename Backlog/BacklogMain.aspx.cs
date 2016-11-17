using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Backlog
{ 
    public partial class BacklogMain : System.Web.UI.Page
    {
        protected DataTable table;
        protected DataView view;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblUser.Text = string.Format("Welcome, {0}!", this.Session["user"]);
                LoadData();
            }
        }

        protected void LoadData()
        {
            PopulateGridView();
            PopulateGenreList();
            PopulateStatusList();
        }

        protected void PopulateGridView()
        {
            try
            {
                lvGames.DataSource = Database.GetAllUsersGamesFromDatabase(Session["user"].ToString());
                lvGames.DataBind();
            } catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
            
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
                lblError.Text = string.Format("Game {0} added to database", title);
                LoadData();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            try
            {
                int id = int.Parse(button.Attributes["GameID"]);
                string title = button.Attributes["GameTitle"];
                Database.DeleteGameFromDatabase(id);
                LoadData();
                lblError.Text = string.Format("{0} successfully removed from database", title);
            } catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

    }
}