using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Ajax.Utilities;

namespace CactiMaster
{
    public partial class CarRentalExam : System.Web.UI.Page
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
            string tableName = "CarFleet";
            string query1 = string.Empty;
            string query2 = string.Empty;

            sqlSelect = string.Empty;
            strTable = string.Empty;
            if (value1 != null)
            {
                if ("Type".Equals(filter1))
                {
                    bool isCommercial = value1 == "Commercial";
                    query1 = $"Commercial = '{isCommercial}'"; // string values
                }
                if ("Model".Equals(filter1))
                    query1 = $"{filter1} = '{value1}'"; // string values
                // it's a number (BRAND is foreign key ID)
                else if ("YearOnRoad".Equals(filter1) || "Brand".Equals(filter1) ||
                    "DailyRate".Equals(filter1) || "Doors".Equals(filter1))
                    query1 = $"{filter1} = {value1}";
            }
            if (value2 != null)
            {
                if ("Type".Equals(filter2))
                {
                    bool isCommercial = value2 == "Commercial";
                    query2 = $"Commercial = '{isCommercial}'"; // string values
                }
                if ("Model".Equals(filter2))
                    query2 = $"{filter2} = '{value2}'"; // string values

                // it's a number (BRAND is foreign key ID)
                else if ("YearOnRoad".Equals(filter2) || "Brand".Equals(filter2) ||
                    "DailyRate".Equals(filter2) || "Doors".Equals(filter2))
                    query2 = $"{filter2} = {value2}";
            }

            // both parts are EMPTY
            if (query1.Equals(string.Empty) && query2.Equals(string.Empty))
                return;

            // both parts have info
            if (!query1.Equals(string.Empty) && !query2.Equals(string.Empty))
            {
                sqlSelect = $"SELECT *, CarBrands.Name FROM {tableName} INNER JOIN CarBrands ON CarBrands.Id = CarFleet.Brand WHERE ({query1} {sqlOperator.ToUpper()} {query2});";
                #region                
                //if ("AND".Equals(sqlOperator))
                //    sqlSelect = $"SELECT * FROM {DBHelper.DB_USER_TABLE} WHERE ({query1} AND {query2});";
                //else // OR
                //    sqlSelect = $"SELECT * FROM {DBHelper.DB_USER_TABLE} WHERE ({query1} OR {query2});";
                #endregion
            }
            else if (!query1.Equals(string.Empty)) // only Query 1 has data
            {
                sqlSelect = $"SELECT *, CarBrands.Name FROM {tableName} INNER JOIN CarBrands ON CarBrands.Id = CarFleet.Brand WHERE ({query1});";
            }
            else if (!query2.Equals(string.Empty)) // only Query 2 has data
            {
                sqlSelect = $"SELECT *, CarBrands.Name FROM {tableName} INNER JOIN CarBrands ON CarBrands.Id = CarFleet.Brand WHERE ({query2});";
            }
            else // both are empty - show the whole table
                sqlSelect = $"SELECT *, CarBrands.Name FROM {tableName} INNER JOIN CarBrands ON CarBrands.Id = CarFleet.Brand;";


            DataTable carsTable = DBHelper.ExecuteDataTable(DBHelper.DB_FILENAME, sqlSelect);
            int length = carsTable.Rows.Count;
            if (length == 0)
                msg = "No matching cars found";
            else
            {
                strTable += "<tr>";
                strTable += "<th class='userth'>Brand</th>";
                strTable += "<th class='userth'>Model</th>";
                strTable += "<th class='userth'>Num Doors</th>";
                strTable += "<th class='userth'>Year On Road</th>";
                strTable += "<th class='userth'>Type</th>";
                strTable += "<th class='userth'>Daily Rate</th>";

                strTable += "</tr>";
                for (int i = 0; i < carsTable.Rows.Count; i++)
                {
                    strTable += "<tr>";
                    strTable += $"<td class='usertd'>{carsTable.Rows[i]["Name"]}</td>";
                    strTable += $"<td class='usertd'>{carsTable.Rows[i]["Model"]}</td>";
                    strTable += $"<td class='usertd'>{carsTable.Rows[i]["Doors"]}</td>";
                    string carType = (bool)carsTable.Rows[i]["Commercial"] ? "Commercial" : "Private";
                    strTable += $"<td class='usertd'>{carType}</td>";
                    strTable += $"<td class='usertd'>{carsTable.Rows[i]["YearOnRoad"]}</td>";
                    strTable += $"<td class='usertd'>{carsTable.Rows[i]["DailyRate"]}</td>";
                    strTable += "</tr>";
                }

                msg = "<div style='text-align: center;'>";
                msg += $"<h3>There are {carsTable.Rows.Count} matching cars. </h3>";
                msg += "</div>";
            }
        }
    }
}
