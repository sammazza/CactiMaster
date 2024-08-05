using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace CactiMaster
{
    public partial class Register : System.Web.UI.Page
    {
        public string strQuestions = "";
        private string[] questions = { "pet", "grandma", "sport" };
        public string secretQuestions;

        public string st = "";
        public string msg = "";
        public string validYears = "";
        public string strCities = "";
        public string strPrefixes = "";
        public string sqlMsg = "";
        private string[] citiesNames = { "Ashdod", "Beer-Sheva", "Eilat", "Haifa", "Jerusalem", "Metula", "Nahariya", "Natanya", "Tebirius", "Tel-Aviv" };
        string[] prefixesCodes = { "050", "052", "053", "054", "055", "057", "058", "02", "03", "04", "08", "09", "077" };

        protected void Page_Load(object sender, EventArgs e)
        {

            // Make the options for the year born select field
            int year = DateTime.Now.Year;
            // range of ages of users allowed to our site
            int from = year - 30;
            int to = year - 10;

            validYears = BuildDropDownFieldsRange(from, to, year - 16);
            strCities = BuildDropDownFields(citiesNames);
            strPrefixes = BuildDropDownFields(prefixesCodes);
            strQuestions = BuildDropDownFields(questions);

            if (Request.Form["submit"] == null)
            {
                return;
            }

            // otherwise user pressed the SUBMIT button

            //st += "Server's Response is ...";
            string uName    = Request.Form["uName"].ToString().Trim();
            string fName    = Request.Form["fName"].ToString().Trim();
            string lName    = Request.Form["lName"].ToString().Trim();
            string email    = Request.Form["email"].ToString().Trim();
            // (see below) string yearBorn = Request.Form["yearborn"].ToString().Trim();
            string gender   = Request.Form["gender"].ToString().ToUpper().Substring(0, 1);
            string prefix   = Request.Form["prefix"];
            string phone    = Request.Form["phone"].ToString().Trim();
            string city     = Request.Form["city"];
            string hobby1   = Request.Form["hob1"] == null ? "F" : "T";
            string hobby2   = Request.Form["hob2"] == null ? "F" : "T";
            string hobby3   = Request.Form["hob3"] == null ? "F" : "T";
            string hobby4   = Request.Form["hob4"] == null ? "F" : "T";
            string tzid     = Request.Form["tzid"].ToString().Trim();
            string question = Request.Form["question"].ToString().Trim();
            string answer   = Request.Form["answer"].ToString().Trim();

            string password = Request.Form["password"].ToString().Trim();

            // YEAR BORN
            int yearBorn = int.Parse(Request.Form["yearborn"].ToString().Trim());

            // Check if userName already exists in DB
            string sqlFindUser = $"SELECT * FROM {DBHelper.DB_USER_TABLE} WHERE uName = '{uName}'";
 
            if (DBHelper.Find(DBHelper.DB_FILENAME, sqlFindUser))
            {
                msg = "This user name is already taken. Please choose another user name.";
                sqlMsg = sqlFindUser;
            }
            else
            {
                // create user default NOT Admin
                string sqlInsert = $"INSERT INTO {DBHelper.DB_USER_TABLE} " +
                    $" VALUES('{uName}', '{fName}', '{lName}', '{email}', {yearBorn}, '{gender}', '{prefix}', '{phone}', '{city}', '{hobby1}', '{hobby2}', '{hobby3}', '{hobby4}', '{password}', 'F', '{tzid}', '{question}', '{answer}', 1);";
                DBHelper.ExecuteDataTable(DBHelper.DB_FILENAME, sqlInsert);
                sqlMsg = sqlInsert;
            }


            st = "<table>";
            st += "<tr><td colspan='2' style='text-align:center'>Form Data</td></tr>";
            st += $"<tr><td>User Name</td> <td>{uName}</td></tr>";
            st += $"<tr><td>First Name</td> <td>{fName}</td></tr>";
            st += $"<tr><td>Last Name</td> <td>{lName}</td></tr>";
            st += $"<tr><td>Email</td> <td>{email}</td></tr>";
            st += "</table>";

            // Response.Write("abc");
            string Success = "";


            Success = "s";

            msg = Success;

        }

        /* 
            foreach (string _city in citiesNames)
            {
                strCities += $"<option value='{_city}'>{_city}</option>";
            }


            foreach (string _prefix in prefixesCodes)
            {
                prefixes += $"<option value='{_prefix}'>{_prefix}</option>";
            }

         */

        private string BuildDropDownFields(string[] values)
        {
            string str = "";
            foreach (string value in values)
            {
                str += $"<option value='{value}'>{value}</option>";
            }
            return str;
        }

        private string BuildDropDownFieldsRange(int minValue, int maxValue, int selectedValue)
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

        public string foo()
        {
            return "foobar";
        }
    }
}