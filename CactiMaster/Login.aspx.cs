using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace CactiMaster
{
    public partial class Login : System.Web.UI.Page
    {
        // SQL Injection Demo
        private const string QUERY_TYPE_VULNERABLE = "vulnerable";
        private const string QUERY_TYPE_PARAMETRIZED = "parametrized";
        private const string QUERY_TYPE_STORED = "stored";

        public string sqlLogin = "";
        public string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["submit"] != null)
            {
                string uName = Request.Form["uName"];
                string password = Request.Form["password"];

                // SQL Injection Demo
                string queryType = Request.Form["query"].ToString().ToLower();

                DataTable table;

                if (queryType.Equals(QUERY_TYPE_VULNERABLE))
                {


                    sqlLogin = $"SELECT managerTbl.isAdmin, * FROM {DBHelper.DB_USER_TABLE} LEFT JOIN managerTbl ON usersTbl.uName = managerTbl.uName WHERE usersTbl.uName = '{uName}' AND usersTbl.password = '{password}';";


                    // sqlLogin = $"SELECT * FROM {DBHelper.DB_USER_TABLE} WHERE uName = '{uName}' AND password = '{password}'";

                    table = DBHelper.ExecuteDataTable(DBHelper.DB_FILENAME, sqlLogin);
                }
                else if (queryType.Equals(QUERY_TYPE_PARAMETRIZED))
                {
                    table = DBHelper.Login(DBHelper.DB_FILENAME, sqlLogin, uName, password);
                }
                else // Store Procedure
                {
                    table = DBHelper.Login(DBHelper.DB_FILENAME, uName, password);
                }


                int length = table.Rows.Count;
                if (length != 1) // make sure we are getting just one row !!!
                {
                    msg = "User Name or password did not match. Please try again";
                }
                else
                {
                    Application.Lock();
                    Application["loggedInUsers"] = (int)Application["loggedInUsers"] + 1;
                    Application.UnLock();

                    // from Global
                    Session["uName"] = table.Rows[0]["uName"];
                    Session["uFirstName"] = table.Rows[0]["fName"];

                    if (table.Rows[0]["isAdmin"] != null)
                    {
                        Session["isAdmin"] = table.Rows[0]["isAdmin"].ToString().ToUpper().Equals("T");
                    }


                    //// This system using a separate QUERY to the managerTbl to find out if user is Admin
                    //string sqlAdmin = $"SELECT * FROM {DBHelper.DB_ADMIN_TABLE} WHERE uName = '{uName}'";
                    //DataTable adminTable = DBHelper.ExecuteDataTable(DBHelper.DB_FILENAME, sqlAdmin);
                    //if (adminTable.Rows.Count == 1)
                    //    Session["isAdmin"] = adminTable.Rows[0]["isAdmin"].ToString().ToUpper().Equals("T"); // true or false
                    
                    //// or use this with field/column in usersTbl
                    //Session["isAdmin"] = table.Rows[0]["isAdmin"].ToString().ToUpper().Equals("T"); // true or false

                    //Server.Transfer("Cacti.aspx", true);
                    Response.Redirect("Cacti.aspx", true);
                }
            }
        }
    }
}