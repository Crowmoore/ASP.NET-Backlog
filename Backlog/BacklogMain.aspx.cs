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
            if (!IsPostBack)
            {
                CheckIfUserIsLoggedIn(Session["user"].ToString());
            }
        }

        protected void CheckIfUserIsLoggedIn(string user)
        {
            if (user == null)
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
            Session["selection"] = "Title";
        }

        protected void PopulateGridView()
        {
            try
            {
                table = Database.GetAllUsersGamesFromDatabase(Session["user"].ToString());
                view = table.DefaultView;
                lvGames.DataSource = view;
                lvGames.DataBind();
            } catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
            
        }

        protected void PopulateGenreList()
        {
            DataTable genres = Database.GetAllGenresFromDatabase();

            ddlGenres.DataSource = genres; 
            ddlGenres.DataTextField = "name";
            ddlGenres.DataValueField = "name";
            ddlGenres.DataBind();

            //ddlEditGenre.DataSource = genres;
            //ddlEditGenre.DataTextField = "name";
            //ddlEditGenre.DataValueField = "name";
            //ddlEditGenre.DataBind();
        }

        protected void PopulateStatusList()
        {
            DataTable status = Database.GetAllStatusFromDatabase();

            ddlStatus.DataSource = status;
            ddlStatus.DataTextField = "name";
            ddlStatus.DataValueField = "name";
            ddlStatus.DataBind();

            //ddlEditStatus.DataSource = status;
            //ddlEditStatus.DataTextField = "name";
            //ddlEditStatus.DataValueField = "name";
            //ddlEditStatus.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            try
            {
                int id = int.Parse(button.Attributes["GameID"]);
                string title = button.Attributes["GameTitle"];
                Page.ClientScript.RegisterStartupScript(this.GetType(), "key", "$('#editGame').modal('open'); return false;", true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = tbSearch.Text;
            DataTable dataTable = Database.GetAllUsersGamesFromDatabase(Session["user"].ToString());
            DataView dataView = dataTable.DefaultView;

            switch(Session["selection"].ToString())
            {
                case "Title": dataView.RowFilter = string.Format("name LIKE '%{0}%'", search); break;
                case "Genre": dataView.RowFilter = string.Format("genre LIKE '%{0}%'", search); break;
                case "Status": dataView.RowFilter = string.Format("status LIKE '%{0}%'", search); break;
                default: dataView.RowFilter = string.Empty; break;
            }

            lvGames.DataSource = dataView;
            lvGames.DataBind();
        }

        protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["selection"] = ddlSearch.SelectedValue.ToString();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            DataTable dataTable = Database.GetAllUsersGamesFromDatabase(Session["user"].ToString());
            DataView dataView = dataTable.DefaultView;
            dataView.RowFilter = string.Empty;
            lvGames.DataSource = dataView;
            lvGames.DataBind();
        }
    }
}