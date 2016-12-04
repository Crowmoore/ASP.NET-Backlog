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
            CheckIfUserIsLoggedIn();
            if(!IsPostBack)
            {
                LoadData();
            }
            else
            {
                PopulateGamesList();
            }
        }

        protected void CheckIfUserIsLoggedIn()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblUser.Text = string.Format("Welcome, {0}!", Session["user"]);
            }
        }

        protected void LoadData()
        {
            PopulateGamesList();
            PopulateGenreList();
            PopulateStatusList();
            Session["selection"] = "Title";
        }

        protected void PopulateGamesList()
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
        }

        protected void PopulateStatusList()
        {
            DataTable status = Database.GetAllStatusFromDatabase();

            ddlStatus.DataSource = status;
            ddlStatus.DataTextField = "name";
            ddlStatus.DataValueField = "name";
            ddlStatus.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            try
            {
                int id = int.Parse(button.Attributes["GameID"]);
                string title = button.Attributes["GameTitle"];
                string genre = button.Attributes["GameGenre"];
                string status = button.Attributes["GameStatus"];
                string achievements = button.Attributes["GameAchievements"];
                string comment = button.Attributes["GameComment"];
                Application["ID"] = id;
                Application["Title"] = title;
                Application["Genre"] = genre;
                Application["Status"] = status;
                Application["Achievements"] = achievements;
                Application["Comment"] = comment;
                Response.Redirect("Edit.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text;
            string genre = ddlGenres.SelectedValue.ToString();
            lblError.Text = genre;
            string achievements = string.Format("{0}/{1}", tbAchievementsGained.Text, tbAchievementsTotal.Text);
            string status = ddlStatus.SelectedValue.ToString();
            string comment = tbComment.Text;
            string user = this.Session["user"].ToString();

            try
            {
                Database.AddNewGame(user, title, achievements, status, comment, genre);
                lblError.Text = string.Format("{0} added to database", title);
                LoadData();
                ClearAddForm();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void ClearAddForm()
        {
            tbTitle.Text = string.Empty;
            ddlGenres.SelectedIndex = 0;
            tbAchievementsGained.Text = string.Empty;
            tbAchievementsTotal.Text = string.Empty;
            ddlStatus.SelectedIndex = 0;
            tbComment.Text = string.Empty;
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
                lblError.Text = string.Format("{0} successfully removed", title);
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

        protected void lvGames_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvGames.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.PopulateGamesList();
        }
    }
}