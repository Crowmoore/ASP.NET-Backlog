using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Backlog
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckIfUserIsLoggedIn();
        }

        protected void CheckIfUserIsLoggedIn()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                InitializeForm();
            }
        }

        protected void InitializeForm()
        {
            lblUser.Text = string.Format("Welcome, {0}!", Session["user"]);
            int id = int.Parse(Application["ID"].ToString());
            lblEdit.Text = string.Format("Editing entry {0}", id);
            PopulateGenreList();
            PopulateStatusList();
            ParseAchievements();
            tbTitle.Text = Application["Title"].ToString();
            tbComment.Text = Application["Comment"].ToString();
        }

        protected void ParseAchievements()
        {
            string[] achievements = Application["Achievements"].ToString().Split('/');
            tbAchievementsGained.Text = achievements[0];
            tbAchievementsTotal.Text = achievements[1];
        }

        protected void PopulateGenreList()
        {
            ddlGenres.DataSource = Database.GetAllGenresFromDatabase();
            ddlGenres.DataTextField = "name";
            ddlGenres.DataValueField = "name";
            ddlGenres.DataBind();
            ddlGenres.SelectedValue = Application["Genre"].ToString();
        }

        protected void PopulateStatusList()
        {
            ddlStatus.DataSource = Database.GetAllStatusFromDatabase();
            ddlStatus.DataTextField = "name";
            ddlStatus.DataValueField = "name";
            ddlStatus.DataBind();
            ddlStatus.SelectedValue = Application["Status"].ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string user = Session["user"].ToString();
            int id = int.Parse(Application["ID"].ToString());
            string title = tbTitle.Text;
            string genre = ddlGenres.SelectedValue.ToString();
            string status = ddlStatus.SelectedValue.ToString();
            string achievements = string.Format("{0}/{1}", tbAchievementsGained.Text, tbAchievementsTotal.Text);
            string comment = tbComment.Text;

            try
            {
                Database.UpdateGameInfoToDatabase(id, user, title, status, achievements, genre, comment);
                lblError.Text = "Entry updated";
                Response.Redirect("BacklogMain.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Could not update entry. Try again later";
            }            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BacklogMain.aspx");
        }
    }
}