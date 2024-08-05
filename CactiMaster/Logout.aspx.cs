using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CactiMaster
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Clear();
            
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Cacti.aspx");

            string managerStr = "";

            string menuStr = "";
            
            menuStr = menuStr + managerStr;
        }
    }
}