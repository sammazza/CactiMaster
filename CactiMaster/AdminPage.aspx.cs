using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CactiMaster
{
    public partial class AdminPage : System.Web.UI.Page
    {
        public string str = "";
        public string msg = "";
        public string sqlSelect = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(bool)Session["isAdmin"])
            {
                msg += "<div style='text-align: center; color: red;'>";
                msg += "<h3>You have no administration previliges to view this page</h3>";
                msg += "<a href='Cacti.aspx'>Continue</a>";
                msg += "</div>";
                return;
            }
            msg += "<h3><a href='SiteUsers.aspx'>Show Users</a></h3>";
            msg += "<br/><br/>";
            msg += "<h3><a href='SelectbyName.aspx'>Show users first name starts with S</a></h3>";
            msg += "<h3><a href='SelectGmailAndYear.aspx'>Show GMAIL users 2000-2005</a></h3>";
            msg += "<h3><a href='SelectByCityAndHobby.aspx'>Resident of Haifa or Tel-Aviv that like Sailing</a></h3>";
            msg += "<h3><a href='SelectByPrefix.aspx?prefix=050'>Users with prefix 050</a></h3>";
            msg += "<br/><br/>";
            msg += "<h3><a href='DynamicQueries.aspx'>Dynamic Queries</a></h3>";
            //msg += "<input id=\"btnRename\"runat=\"server\" type=\"button\" onserverclick=\"RenameTable\" value=\"Change Name\"/>";
        }

        
        protected void RenameTable(object sender, EventArgs e)
        {
            DBHelper.RenameTable(DBHelper.DB_FILENAME, "Personss", "Persons");
            
        }

        protected void GetSchema(object sender, EventArgs e)
        {
            DBHelper.GetSchema(DBHelper.DB_FILENAME, DBHelper.DB_USER_TABLE);

        }
    }
}