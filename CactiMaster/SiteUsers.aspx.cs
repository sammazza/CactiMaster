using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

// Page life cycle
// https://www.c-sharpcorner.com/UploadFile/8911c4/page-life-cycle-with-examples-in-Asp-Net/
namespace CactiMaster
{
    public partial class SiteUsers : System.Web.UI.Page
    {
        // we will show this on HTML page for debugging
        public string str = "";
        public string msg = "";
        public string sqlSelect = "";

        protected void Page_Load(object sender, EventArgs e)
        {

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

            // Are we coming here because of a DELETE request?
            // yes perform the delete and then... below show the table
            string deleteUName = string.Empty;
            int rowsAffected = 0;

            if (Request.Form["uName"] != null)
            {
                deleteUName = Request.Form["uName"].ToString();
            }
            if (Request.QueryString["uName"] != null)
            {
                deleteUName = Request.QueryString["uName"].ToString();
            }
            if (!deleteUName.Equals(String.Empty))
            {
                string sqlDelete = $"DELETE FROM {DBHelper.DB_USER_TABLE} WHERE uName='{deleteUName}';";
                rowsAffected = DBHelper.DoQuery(DBHelper.DB_FILENAME, sqlDelete);
            }

            sqlSelect = $"SELECT usersTbl.*, CountryCodes.CountryCode FROM {DBHelper.DB_USER_TABLE} INNER JOIN CountryCodes ON CountryCodes.ID = UsersTbl.CountryCodeID";
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
                str += "<th class='userth'>Question</th>";
                str += "<th class='userth'>Answer</th>";
                str += "<th class='userth'>Action</th>";
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
                    str += $"<td class='usertd'>({usersTable.Rows[i]["CountryCode"]}) {usersTable.Rows[i]["prefix"]}-{usersTable.Rows[i]["phone"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["city"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["hob1"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["hob2"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["hob3"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["hob4"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["password"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["question"]}</td>";
                    str += $"<td class='usertd'>{usersTable.Rows[i]["answer"]}</td>";
                    str += $"<td class='usertd'><a style='text-decoration:none' href='SiteUsers.aspx?uName={usersTable.Rows[i]["uName"]}'>Delete</a></td>";
                    str += "</tr>";
                }
                
                msg += "<div style='text-align: center;'>";
                msg += $"<h3>There are {usersTable.Rows.Count} users. </h3>";
                msg += "<a href='Cacti.aspx'>Continue</a>";
                msg += "</div>";
                
            }
        }
        public static int Sum(int x, int y)
        {
            return x+y;
        }
    }
}