using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using System.Text;
using System.Web.Razor.Tokenizer;

public partial class aspx_Bind_Data_Html : System.Web.UI.Page
{
    public string tbl = "";

    public string BuildSQLStr { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("home.aspx");

        }
        if (!(bool)Session["admin"])
        {
            Response.Redirect("home.aspx");
        }



        string deleteUName = string.Empty;
        if (Request.Form["userName"] != null)
        {
            deleteUName = Request.Form["userName"].ToString();
        }
        if (Request.QueryString["userName"] != null)
        {
            deleteUName = Request.QueryString["userName"].ToString();
        }

        if (!deleteUName.Equals(String.Empty))
        {
            Helper.Delete(deleteUName);
        }


        string sortBy = string.Empty;
        if (Request.Form["sort"] != null)
        {
            sortBy = Request.Form["sort"].ToString();
        }
        if (Request.QueryString["sort"] != null)
        {
            sortBy = Request.QueryString["sort"].ToString();
        }

        


       // string query = "SELECT * FROM Users";
       // if (!sortBy.Equals(String.Empty))
       // {
       //     query += $" ORDER BY {sortBy}";
       
       // }
       // tbl = Helper.PrintDataTable(query);


        if (!Page.IsPostBack)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select * from [dbo].[Users]";
            if (!sortBy.Equals(String.Empty))
            {
                sqlquery += $" ORDER BY {sortBy}";

            }

            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            StringBuilder sb = new StringBuilder();
            sb.Append("<center>");
            sb.Append("<h1>users</h1>");
            sb.Append("<h2>users</h2>");
            sb.Append("<hr/>");
            sb.Append("<table border=1>");
            sb.Append("<tr>");

            sb.Append("<th>");
            sb.Append("Delete");
            sb.Append("</th>");
            foreach (DataColumn dc in dt.Columns)
            {
                sb.Append("<th>");
                sb.Append(dc.ColumnName.ToUpper());
                sb.Append("</th>");
            }
            sb.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");

                string uName = dr["userName"].ToString();

                sb.Append("<th>");
                string deleteLink = $"<a href='admin.aspx?userName={uName}'>Delete</a>";
                sb.Append(deleteLink);
                sb.Append("</th>");
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append("<th>");
                    sb.Append(dr[dc.ColumnName].ToString());
                    sb.Append("</th>");

                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            sb.Append("</center>");
            panel1.Controls.Add(new Label { Text = sb.ToString() });
            sqlconn.Close();

        }
    }
    

}