using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CactiMaster
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        public string strQuestions = "";
        public string sqlMsg= "";
        public string msg = "";

        private string[] questions= { "pet", "grandma", "sport" };
        public string secretQuestions;

        protected void Page_Load(object sender, EventArgs e)
        {
            int rowsAffected;

            strQuestions = BuildDropDownFields(questions);
            if (Request.Form["submit"] == null)
            {
                return;
            }

            string uName = Request.Form["uName"].ToString().Trim();
            string password = Request.Form["password"].ToString().Trim();
            string question = Request.Form["question"].ToString().Trim();
            string answer = Request.Form["answer"].ToString().Trim();

            string sqlFindUser = $"SELECT * FROM {DBHelper.DB_USER_TABLE} WHERE uName='{uName}' AND question='{question}' AND answer='{answer}';";
            if (!DBHelper.Find(DBHelper.DB_FILENAME, sqlFindUser))
            {
                msg = "Incorrect details.";
                sqlMsg = sqlFindUser;
                Request.Form.Clear();
                return;
            }

            // update password
            string sqlUpdate = $"UPDATE {DBHelper.DB_USER_TABLE} SET ";
            sqlUpdate += $" password = '{password}' ";
            sqlUpdate += $"WHERE uName = '{uName}';";

            rowsAffected = DBHelper.DoQuery(DBHelper.DB_FILENAME, sqlUpdate);
            sqlMsg = sqlUpdate;
            msg = $"{rowsAffected} row(s): Password reset successfully.  Please <a href='Login.aspx'>Login</a>";
        }

        private string BuildDropDownFields(string[] values)
        {
            string str = "";
            for (int i = 0; i < values.Length; i++)
            {
                string selected = i == 0 ? " selected " : "";
                str += $"<option value='{values[i]}' {selected}>{values[i]}</option>";
            }
            return str;
        }
    }
}