using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CactiMaster
{
    public partial class Cacti : System.Web.UI.MasterPage
    {
        public string loginMsg = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.AppendHeader("Cache-Control", "no-store");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            Response.AppendHeader("pragma", "no-cache");

            if ((bool)Session["isAdmin"] == true)
                loginMsg = $"<h3>Welcome {Session["uFirstname"].ToString()} (admin)</h3>";
            else 
                loginMsg = $"<h3>Welcome {Session["uFirstname"].ToString()}</h3>";

           

            if (Session["uName"].ToString().Equals("Guest"))
            {
                //loginMsg += "<a href='Register.aspx'>Register</a><br/>";
                //loginMsg += "<a href='Login.aspx'>Login</a><br/>";


                ////TableHeaderCell td = (TableHeaderCell)this.Page.FindControl("logout");
                //td = (TableHeaderCell) this.Master.FindControl("MainContent").FindControl("logout");
                //td = (TableHeaderCell)this.FindControl("MainContent").FindControl("logout");
                //td = (TableHeaderCell)this.Page.FindControl("logout");

                login.Visible = true;
                register.Visible = true;
                logout.Visible = false;
                adminUsers.Visible = false;

                //Control c = Page.FindControl("login");
                //Master.FindControl("login").Visible = true;
                //Master.FindControl("register").Visible = true;
                //Master.FindControl("logout").Visible = false;
            }
            else
            {
                // loginMsg += "<a href='Logout.aspx'>Logout</a><br/>";
                login.Visible = false;
                register.Visible = false;
                logout.Visible = true;
                if (Session["isAdmin"].ToString().Equals(true.ToString()))
                    adminUsers.Visible = true;
                else
                    adminUsers.Visible = false;

                loginMsg += $"<h3><a href='UpdateUser.aspx'>[edit]</a></h3>";

                //Page.FindControl("login").Visible = false;
                //Page.FindControl("register").Visible = false;
                //Page.FindControl("logout").Visible = true;

            }

        }
    }
}