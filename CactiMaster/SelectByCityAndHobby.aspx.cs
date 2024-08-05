using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CactiMaster
{
    public partial class SelectByCityAndHobby : System.Web.UI.Page
    {
        public string str = "";
        public string msg = "";
        public string sqlSelect = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.AppendHeader("Cache-Control", "no-store");




            //str = "";
            //sqlSelect = "";
            //msg

            if (!(bool)Session["isAdmin"])
            {
                msg += "<div style='text-align: center; color: red;'>";
                msg += "<h3>You have no administration previliges to view this page</h3>";
                msg += "<a href='Cacti.aspx'>Continue</a>";
                msg += "</div>";
                return;
            }

            sqlSelect = $"SELECT * FROM {DBHelper.DB_USER_TABLE} ";
            sqlSelect += " WHERE city in ('Tel-Aviv', 'Haifa')  AND hob1='T';";


            DataTable usersTable = DBHelper.ExecuteDataTable(DBHelper.DB_FILENAME, sqlSelect);

            if (usersTable.Rows.Count == 0)
            {
                msg = "There are no registered users";
            }
            else
            {
                str += "<tr>";
                str += "<th class='userth'>User Name</th>";
                str += "<th class='userth'>First Name</th>";
                str += "<th class='userth'>Last Name</th>";
                str += "<th class='userth'>Email</th>";
                str += "<th class='userth'>TZ ID</th>";
                str += "<th class='userth'>Year of Birth</th>";
                str += "<th class='userth'>Gender</th>";
                str += "<th class='userth'>Phone Number</th>";
                str += "<th class='userth'>City</th>";
                str += "<th class='userth'>Sailing</th>";
                str += "<th class='userth'>Biking</th>";
                str += "<th class='userth'>Cooking</th>";
                str += "<th class='userth'>Movies</th>";
                str += "<th class='userth'>Password</th>";
                str += "</tr>";
                for (int i = 0; i < usersTable.Rows.Count; i++)
                {
                    str += "<tr>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["uName"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["fName"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["lName"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["email"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["tzid"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["yearBorn"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["gender"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["prefix"]}- {usersTable.Rows[i]["phone"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["city"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["hob1"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["hob2"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["hob3"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["hob4"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["password"]}</td>";
                    str += "</tr>";
                }
                msg += "<div style='text-align: center;'>";
                msg += $"<h3>There are {usersTable.Rows.Count} users. </h3>";
                msg += "<a href='AdminPage.aspx'>Continue</a>";
                msg += "</div>";

            }

        }
    }
}