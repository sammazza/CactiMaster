using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace CactiMaster
{
    public partial class UpdateUser : System.Web.UI.Page
    {
        public string st = "";
        public string msg = "";
        public string validYears = "";
        public string strCities = "";
        public string strPrefixes = "";
        public string sqlMsg = "";
        private string[] citiesNames = { "Ashdod", "Beer-Sheva", "Eilat", "Haifa", "Jerusalem", "Metula", "Nahariya", "Natanya", "Tebirius", "Tel-Aviv" };
        string[] prefixesCodes = { "050", "052", "053", "054", "055", "057", "058", "02", "03", "04", "08", "09", "077" };


        public string sqlUpdate = "";
        //public string sqlSelect = "";

        public string uName;
        public string fName;
        public string lName;
        public string email;
        public string yearBorn;
        public string gender;
        public string prefix;
        public string phone;
        public string city;
        public string hobby1;
        public string hobby2;
        public string hobby3;
        public string hobby4;
        public string password, verifyPassword;
        public string tzid;

        protected void Page_Load(object sender, EventArgs e)
        {

            // Make the options for the year born select field
            int year = DateTime.Now.Year;
            // range of ages of users allowed to our site
            int from = year - 30;
            int to = year - 10;
            int rowsAffected = 0;

            validYears = BuildDropDownFieldsRange(from, to, year - 16);
            strCities = BuildDropDownFields(citiesNames);
            strPrefixes = BuildDropDownFields(prefixesCodes);


            uName = Session["uName"].ToString();
            if (uName.Equals("Guest"))
            {
                msg = "You are not signed in";
                Response.Redirect("Cacti.aspx");
                return;
            }


            string sqlFindUser = $"SELECT * FROM {DBHelper.DB_USER_TABLE} WHERE uName = '{uName}'";
            DataTable table = DBHelper.ExecuteDataTable(DBHelper.DB_FILENAME, sqlFindUser);

            if (table.Rows.Count == 0) // this should really never happen
            {
                msg = "This user name is not registered";
                sqlMsg = sqlFindUser;
                Response.Redirect("Logout.aspx"); // force logout erase to all caches
                return;
            }

            uName = table.Rows[0]["uName"].ToString().Trim();
            fName = table.Rows[0]["fName"].ToString().Trim();
            lName = table.Rows[0]["lName"].ToString().Trim();
            email = table.Rows[0]["email"].ToString().Trim();
            yearBorn = table.Rows[0]["yearborn"].ToString().Trim();
            gender = table.Rows[0]["gender"].ToString().ToUpper().Substring(0, 1);
            prefix = table.Rows[0]["prefix"].ToString();
            phone = table.Rows[0]["phone"].ToString().Trim();
            city = table.Rows[0]["city"].ToString();
            hobby1 = table.Rows[0]["hob1"].ToString();// == null ? "F" : "T";
            hobby2 = table.Rows[0]["hob2"].ToString();// == null ? "F" : "T";
            hobby3 = table.Rows[0]["hob3"].ToString();// == null ? "F" : "T";
            hobby4 = table.Rows[0]["hob4"].ToString();// == null ? "F" : "T";
            password = table.Rows[0]["password"].ToString().Trim();
            verifyPassword = table.Rows[0]["password"].ToString().Trim();
            tzid = table.Rows[0]["tzid"].ToString().Trim(); 

            // rebuild with the currently selected value
            strCities = BuildDropDownFields(citiesNames, city);
            strPrefixes = BuildDropDownFields(prefixesCodes, prefix);


            // if (this.IsPostBack) / also can use this
            if (Request.Form["submit"] == null)
            {
                return;
            }
            // now the user clck submit to update his details
            // otherwise user pressed the SUBMIT button

            //st += "Server's Response is ...";
            //uName = Request.Form["uname"].ToString().Trim();
            fName = Request.Form["fname"].ToString().Trim();
            lName = Request.Form["lname"].ToString().Trim();
            email = Request.Form["email"].ToString().Trim();
            yearBorn = Request.Form["yearborn"].ToString().Trim();
            gender = Request.Form["gender"].ToString().ToUpper().Substring(0, 1);
            prefix = Request.Form["prefix"];
            phone = Request.Form["phone"].ToString().Trim();
            city = Request.Form["city"];
            hobby1 = Request.Form["hob1"] == null ? "F" : "T";
            hobby2 = Request.Form["hob2"] == null ? "F" : "T";
            hobby3 = Request.Form["hob3"] == null ? "F" : "T";
            hobby4 = Request.Form["hob4"] == null ? "F" : "T";
            password = Request.Form["password"].ToString().Trim();
            tzid = Request.Form["tzid"].ToString().Trim();

            sqlUpdate = $"UPDATE {DBHelper.DB_USER_TABLE} SET ";
            sqlUpdate += $" fName = '{fName}', ";
            sqlUpdate += $" lName = '{lName}', ";
            sqlUpdate += $" email = '{email}', ";
            sqlUpdate += $" yearBorn = '{yearBorn}', ";
            sqlUpdate += $" gender = '{gender}', ";
            sqlUpdate += $" prefix = '{prefix}', ";
            sqlUpdate += $" phone = '{phone}', ";
            sqlUpdate += $" city = '{city}', ";
            sqlUpdate += $" hob1 = '{hobby1}', ";
            sqlUpdate += $" hob2 = '{hobby2}', ";
            sqlUpdate += $" hob3 = '{hobby3}', ";
            sqlUpdate += $" hob4 = '{hobby4}', ";
            sqlUpdate += $" password = '{password}', ";
            sqlUpdate += $" tzid = '{tzid}' ";

            sqlUpdate += $"WHERE uName = '{uName}';";

            rowsAffected = DBHelper.DoQuery(DBHelper.DB_FILENAME, sqlUpdate);

            msg = $"{rowsAffected} row(s) changed. Details updated successfully";
        }

        private string BuildDropDownFields(string[] values, string selected = "none")
        {
            string str = "";
            foreach (string value in values)
            {
                if (value.Equals(selected))
                    str += $"<option value='{value}' selected >{value}</option>";
                else
                    str += $"<option value='{value}'>{value}</option>";
            }
            return str;
        }

        private string BuildDropDownFieldsRange(int minValue, int maxValue, int selectedValue = 0)
        {
            string str = "";
            for (int i = minValue; i < maxValue; i++)
            {
                if (i == selectedValue)
                    str += $"<option value='{i}' selected>{i}</option>";
                else
                    str += $"<option value='{i}'>{i}</option>";
            }

            return str;
        }
    }

}