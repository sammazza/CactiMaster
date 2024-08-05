using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Activities;
using System.Activities.Statements;

public static class Helper
{
    public const string DBName = "Database.mdf";   //Name of the MSSQL Database.
    public const string tblName = "Users";      // Name of the user Table in the Database
    public const string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Desktop\Gali\recipy2\recipy2\App_Data\"
                                    + DBName + ";Integrated Security=True";   // The Data Base is in the App_Data = |DataDirectory|

    //public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True";
    //public static string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

    public static bool IsExist(string query)
    {
        SqlConnection sql = new SqlConnection(conString);
        sql.Open();
        SqlCommand cmmd = new SqlCommand(query, sql);
        SqlDataReader data = cmmd.ExecuteReader();
        bool found = data.Read();
        sql.Close();
        return found;
    }
    
    public static DataSet RetrieveTable(string SQLStr)
    // Gets A table from the data base acording to the SELECT Command in SQLStr;
    // Returns DataSet with the Table.
    {
        // connect to DataBase
        SqlConnection con = new SqlConnection(conString);

        // Build SQL Query
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        // Build DataAdapter
        SqlDataAdapter ad = new SqlDataAdapter(cmd);

        // Build DataSet to store the data
        DataSet ds = new DataSet();

        // Get Data form DataBase into the DataSet
        ad.Fill(ds, tblName);
       
        return ds;
    }

    public static object GetScalar(string SQL)
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        object scalar = cmd.ExecuteScalar();
        con.Close();

        return scalar;
    }

    public static int ExecuteNonQuery(string SQL)
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        int n = cmd.ExecuteNonQuery();
        con.Close();

        // return the number of rows affected
        return n;
    }

    public static void Delete(string  useNameToDelete)
    // The Array "userIdToDelete" contain the id of the users to delete. 
    // Delets all the users in the array "userIdToDelete".
    {

        string SQL = $"DELETE FROM {tblName} WHERE userName = '{useNameToDelete}'";
        ExecuteNonQuery(SQL);
    }


    public static void Delete(int [] userIdToDelete)
    // The Array "userIdToDelete" contain the id of the users to delete. 
    // Delets all the users in the array "userIdToDelete".
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // טעינת הנתונים
        string SQL = "SELECT * FROM " + tblName;
        SqlCommand cmd = new SqlCommand(SQL, con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds, tblName);

        // מחיקת שורות שנבחרו מתוך הדאטה סט
        for (int i = 0; i < userIdToDelete.Length; i++)
        {
            {
                DataRow[] dr = ds.Tables[tblName].Select(String.Format("userId = {0}", userIdToDelete[i]));
                dr[0].Delete();
            }
        }

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetDeleteCommand();
        adapter.Update(ds, tblName);
    }

    public static void Update(User user)
        // The Method recieve a user objects. Find the user in the DataBase acording to his userId and update all the other properties in DB.
    {
        // HttpRequest Request
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = "SELECT * FROM " + Helper.tblName + String.Format(" Where userid={0}", user.userId);
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        //  טעינת הנתונים לתוך DataSet
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, tblName);

        // בניית השורה להוספה
        DataRow dr = ds.Tables[tblName].Rows[0];
        dr["firstName"] = user.firstName;
        dr["lastName"] = user.lastName;
        dr["userName"] = user.userName;
        dr["password"] = user.password;
        dr["birthday"] = user.birthday;
        dr["city"] = user.city;

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.Update(ds, tblName);

    }

    public static void Insert (User user )
    // The Method recieve a user objects and insert it to the Database as new row. 
    // The Method does't check if the user is already taken.
    {
        //HttpRequest Request
        // התחברות למסד הנתונים
        //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = String.Format("SELECT * FROM " + tblName+ " WHERE 0=1");
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        // בניית DataSet
        DataSet ds = new DataSet();

        // טעינת סכימת הנתונים
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, tblName);

        // בניית השורה להוספה
        DataRow dr = ds.Tables[tblName].NewRow();
        dr["firstName"] = user.firstName;
        dr["lastName"] = user.lastName;
        dr["userName"] = user.userName;
        dr["password"] = user.password;
        dr["birthday"] = user.birthday;
        dr["city"] = user.city;
        ds.Tables[tblName].Rows.Add(dr);

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetInsertCommand();
        adapter.Update(ds, tblName);
    }

    public static User GetRow(string userName, string password)
        // The Method check if there is a user with userName and Password. 
        // If true the Method return a user with the first Name and Admin property.
        // If not the Method return a user wuth first name "Visitor" and Admin = false

    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQL = String.Format("SELECT userName, admin FROM " + tblName +
                " WHERE userName='{0}' AND password = '{1}'", userName, password);
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // שימוש בנתונים שהתקבלו
        User user = new User();
        if (reader.HasRows)
        {
            reader.Read();
            user.userName = reader.GetString(0);
            user.Admin= reader.GetBoolean(1);
        }
        else
        {
            user.userName = "Visitor";
            user. Admin = false;
        }
        reader.Close();
        con.Close();
        return user;
    }

    public static string BuildSimpleUsersTable(DataTable dt)
        // the Method Build HTML user Table using the users in the DataTable dt.
    {
        string str = "<table border='1' class='usersTable' align='center'>";
        str += "<tr>";
        foreach (DataColumn column in dt.Columns)
        {
            str += "<td>" + column.ColumnName + "</td>";
        }

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";
            foreach (DataColumn column in dt.Columns)
            {
				if (column.ColumnName.Equals("birth"))
				{
					string birth = row[column].ToString().Split(' ')[0];
					str += "<td>" + birth + "</td>";
				}
				else
					str += "<td>" + row[column] + "</td>";
			}
            str += "</tr>";
        }
        str += "</tr>";
        str += "</Table>";
        return str;
    }

    public static string BuildUsersTable(DataTable dt)
    // the Method Build HTML user Table with checkBoxes using the users in the DataTable dt.
    {

        string str = "<table border='1' class='usersTable' align='center'>";
        str += "<tr>";
        str += "<td> </td>";
        foreach (DataColumn column in dt.Columns)
        {
            str += "<td>" + column.ColumnName + "</td>";
        }

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";
            str += "<td>" + CreateRadioBtn(row["username"].ToString()) + "</td>";
            foreach (DataColumn column in dt.Columns)
            {
                if (column.ColumnName.Equals("birth"))
                {
                    string birth = row[column].ToString().Split(' ')[0];
                    str += "<td>" + birth + "</td>";
                }
                else
                    str += "<td>" + row[column] + "</td>";
            }
            str += "</tr>";
        }
        str += "</tr>";
        str += "</Table>";
        return str;
    }

    public static string CreateRadioBtn(string id)
    {
        return String.Format("<input type='checkbox' name='chk{0}' id='chk{0}' runat='server' />", id);
    }

    public static DataTable SortTable(DataTable dt, string column, string dir)
    {
        dt.DefaultView.Sort = column + " " + dir;
        return dt.DefaultView.ToTable();
    }

    public static DataTable FilterTable(DataTable dt, string column, string criteria)
    {
        dt.DefaultView.RowFilter = column + "=" + criteria;
        return dt.DefaultView.ToTable();
    }

    public static DataTable ExecuteDataTable(string query)
    {
        SqlConnection sql = new SqlConnection(conString);
        sql.Open();
        SqlDataAdapter sda = new SqlDataAdapter(query, sql);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        sql.Close();
        return dt;
    }

    public static string PrintDataTable(string query)
    {
        DataTable dt = ExecuteDataTable(query);
        string tbl = "<table>";
        tbl += "<tr> <th> username </th> <th> password </th> <th> first name </th> <th>FirstName <th/> <th>LastName</th> <th>DateOfBirth</th> <th>City</th> <th>phoneNumber</th> <th>Email</th> <th>Gender<th/> <th>SQ</th> <th>SA</th> <th>admin</th>" +
            "";

        foreach(DataRow dr in dt.Rows)
        {
            tbl += " <tr>";
            foreach(Object data in dr.ItemArray)
            {
                tbl += " <td> " + data + " </td>";
            }
            tbl += "<tr>";
        }
        tbl += "</table>";
        return tbl;
    }
}