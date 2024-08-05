using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Microsoft.Ajax.Utilities;

namespace CactiMaster
{

    public partial class DynamicQueries : System.Web.UI.Page
    {
        public static string sqlSelect = string.Empty;
        public static string msg = string.Empty;
        public static string strTable = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string filter1 = Request.Form["filter1"];
            string filter2 = Request.Form["filter2"];

            string value1 = Request.Form["value1"];
            string value2 = Request.Form["value2"];

            string sqlOperator = Request.Form["operator"];

            string dbFileName = "CactiDB.mdf";
            string tableName = "usersTbl";
            string query1 = string.Empty;
            string query2 = string.Empty;

            sqlSelect = string.Empty;
            strTable = string.Empty;
            if (value1 != null)
            {
                if ("gender".Equals(filter1) || "prefix".Equals(filter1))
                    query1 = $"{filter1} = '{value1}'";
                else if ("yearBorn".Equals(filter1)) // it's a number
                    query1 = $"{filter1} = {value1}";
                else if ("fromYear".Equals(filter1))
                    query1 = $"yearBorn >= {value1}";
                else if ("hobby".Equals(filter1))
                    query1 = $"hob${int.Parse(value1)} = 'T'";
                else //if (filter1.Equals("email"))
                    query1 = $"{filter1} LIKE '%{value1}%'";
                // last else not needed my DB does not have hebrew content
                //else query1 = filter1 + $"LIKE N'%{value1}%'";
            }
            if (value2 != null)
            {
                if ("gender".Equals(filter2) || "prefix".Equals(filter2))
                    query2 = $"{filter2} = '{value2}'";
                else if ("yearBorn".Equals(filter2)) // it's a number
                    query2 = $"{filter2} = {value2}";
                else if ("toYear".Equals(filter2))
                    query2 = $"yearBorn <= {value2}";
                else if ("hobby".Equals(filter2))
                    query2 = $"hob${int.Parse(value2)} = 'T'";
                else //if (filter2.Equals("email"))
                    query2 = $"{filter1} LIKE '%{value2}%'";
                // last else not needed my DB does not have hebrew content
                //else query1 = filter1 + $"LIKE N'%{value1}%'";
            }

            // both parts are EMPTY
            if (query1.Equals(string.Empty) && query2.Equals(string.Empty))
                return;

            // both parts have info
            if (!query1.Equals(string.Empty) && !query2.Equals(string.Empty))
            {
                sqlSelect = $"SELECT * FROM {DBHelper.DB_USER_TABLE} WHERE ({query1} {sqlOperator.ToUpper()} {query2});";
                #region                
                //if ("AND".Equals(sqlOperator))
                //    sqlSelect = $"SELECT * FROM {DBHelper.DB_USER_TABLE} WHERE ({query1} AND {query2});";
                //else // OR
                //    sqlSelect = $"SELECT * FROM {DBHelper.DB_USER_TABLE} WHERE ({query1} OR {query2});";
                #endregion
            }
            else if (!query1.Equals(string.Empty)) // only Query 1 has data
            {
                sqlSelect = $"SELECT * FROM {DBHelper.DB_USER_TABLE} WHERE ({query1});";
            }
            else if (!query2.Equals(string.Empty)) // only Query 2 has data
            {
                sqlSelect = $"SELECT * FROM {DBHelper.DB_USER_TABLE} WHERE ({query2});";
            }
            else // both are empty - show the whole table
                sqlSelect = $"SELECT * FROM {DBHelper.DB_USER_TABLE};";
            DataTable usersTable = DBHelper.ExecuteDataTable(DBHelper.DB_FILENAME, sqlSelect);
            int length = usersTable.Rows.Count;
            if (length == 0)
                msg = "No matching records found";
            else
            {
                strTable += "<tr>";
                strTable += "<th class='userth'>User Name</th>";
                strTable += "<th class='userth'>First Name</th>";
                strTable += "<th class='userth'>Last Name</th>";
                strTable += "<th class='userth'>Email</th>";
                strTable += "<th class='userth'>TZ ID</th>";
                strTable += "<th class='userth'>Year of Birth</th>";
                strTable += "<th class='userth'>Gender</th>";
                strTable += "<th class='userth'>Phone Number</th>";
                strTable += "<th class='userth'>City</th>";
                strTable += "<th class='userth'>Sailing</th>";
                strTable += "<th class='userth'>Biking</th>";
                strTable += "<th class='userth'>Cooking</th>";
                strTable += "<th class='userth'>Movies</th>";
                strTable += "<th class='userth'>Question</th>";
                strTable += "<th class='userth'>Answer</th>";
                strTable += "</tr>";
                for (int i = 0; i < usersTable.Rows.Count; i++)
                {
                    strTable += "<tr>";
                    strTable += $"<td class='usertd'>{usersTable.Rows[i]["uName"]}</td>";
                    strTable += $"<td class='usertd'>{usersTable.Rows[i]["fName"]}</td>";
                    strTable += $"<td class='usertd'>{usersTable.Rows[i]["lName"]}</td>";
                    strTable += $"<td class='usertd'>{usersTable.Rows[i]["email"]}</td>";
                    strTable += $"<td class='usertd'>{usersTable.Rows[i]["tzid"]}</td>";
                    strTable += $"<td class='usertd'>{usersTable.Rows[i]["yearBorn"]}</td>";
                    strTable += $"<td class='usertd'>{usersTable.Rows[i]["gender"]}</td>";
                    strTable += $"<td class='usertd'>{usersTable.Rows[i]["prefix"]}-{usersTable.Rows[i]["phone"]}</td>";
                    strTable += $"<td class='usertd'>{usersTable.Rows[i]["city"]}</td>";
                    strTable += $"<td class='usertd'>{usersTable.Rows[i]["hob1"]}</td>";
                    strTable += $"<td class='usertd'>{usersTable.Rows[i]["hob2"]}</td>";
                    strTable += $"<td class='usertd'>{usersTable.Rows[i]["hob3"]}</td>";
                    strTable += $"<td class='usertd'>{usersTable.Rows[i]["hob4"]}</td>";
                    strTable += $"<td class='usertd'>{usersTable.Rows[i]["question"]}</td>";
                    strTable += $"<td class='usertd'>{usersTable.Rows[i]["answer"]}</td>";
                    strTable += "</tr>";
                }

                msg += "<div style='text-align: center;'>";
                msg += $"<h3>There are {usersTable.Rows.Count} users. </h3>";
                msg += "<a href='Cacti.aspx'>Continue</a>";
                msg += "</div>";
            }
        }
    }
}
