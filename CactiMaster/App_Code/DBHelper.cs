using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

// using Dapper; // !!!!!!!!!!!!!!

/// <summary>
/// Summary description for Helper
/// </summary>
/// 
// create foreigh keys
// https://learn.microsoft.com/en-us/sql/ssms/visual-db-tools/design-database-diagrams-visual-database-tools?view=sql-server-ver16

public class DBHelper
{

    // LOCAL DB
    //public const string DB_FILENAME = "CactiDB.mdf";

    // SQL SERVER DB
    public const string DB_FILENAME = "CactiDBServer.dbo";
    public const string DB_USER_TABLE = "usersTbl";
    public const string DB_ADMIN_TABLE = "managerTbl";

    public static SqlConnection ConnectToDb(string fileName)
    {
        string path = HttpContext.Current.Server.MapPath("App_Data/") + fileName;
        //string connString = @"Data Source = (localdb)\ProjectsV13;Initial Catalog=CactiDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\Sam\Teaching\Internet\Code\CactiMaster\CactiMaster\App_Data\CactiDB.mdf; Integrated Security = True";

        // GOOD for LOCALDB
        //string connString = $"Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = {path}; Integrated Security = True";

        // GOOD FOR SQL-SERVER DB
        string connString = $"Data Source = DESKTOP-MDMBQ4I;Initial Catalog = CactiDBServer; Integrated Security = True;";
         //data source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|aspnetdb.mdf;User Instance=true

        //string connString = @"Data Source=.\SQLEXPRESS;AttachDbFileName=" + path + ";Integrated Security=True;User Instance=True";
        //string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\" + fileName + " Integrated Security = True";
        //string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + path + " Integrated Security = True";

        //string s =          @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\Sam\Teaching\Internet\Code\CactiMaster\CactiMaster\App_Data\CactiDB.mdf; Integrated Security = True";

        //string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True;Connect Timeout=30";

        SqlConnection conn = new SqlConnection(connString);
        return conn;
    }

    // Used for UPDATE, DELETE - ExecuteNonQuery
    public static int DoQuery(string fileName, string sql)
    {
        SqlConnection connection = ConnectToDb(fileName);
        connection.Open();
        SqlCommand com = new SqlCommand(sql, connection);

        int numRowsAffected = com.ExecuteNonQuery();
        connection.Close();
        connection.Dispose();
        return numRowsAffected;
    }


    // Parametrized ExecuteNonQuery - Update first name, last name by Id
    // string sql: parameter to function not used in this version!
    // TBD:  Change to use Dictionary and more generic UPDATE and add WHERE parameter to function
    public static void UpdateUserNameById(string fileName, string sql, params string[] parameters)
    {

        using (SqlConnection connection = ConnectToDb(fileName))
        {
            connection.Open();

            string updateSql = "UPDATE UsersTbl SET fName = @fName, lName = @lName WHERE uName = @uName";
            using (SqlCommand command = new SqlCommand(updateSql, connection))
            {
                command.Parameters.AddWithValue("@fName", parameters[0]);
                command.Parameters.AddWithValue("@lName", parameters[1]);
                command.Parameters.AddWithValue("@uName", parameters[2]);
                command.ExecuteNonQuery();
            }

            // USING code-block automatically closes the connection
            //connection.Close();
            //connection.Dispose();
        }
    }

    // IsExists() ==> Changed name to Find()
    public static bool Find(string fileName, string sql)
    {
        SqlConnection conn = ConnectToDb(fileName);
        conn.Open();
        SqlCommand com = new SqlCommand(sql, conn);
        SqlDataReader data = com.ExecuteReader();

        bool found = Convert.ToBoolean(data.Read());
        conn.Close();
        conn.Dispose();
        return found;
    }

    // Normal Query: Returns a table with rows as per sql query
    public static DataTable ExecuteDataTable(string fileName, string sql)
    {
        SqlConnection conn = ConnectToDb(fileName);
        conn.Open();

        DataTable dataTable = new DataTable();

        SqlDataAdapter tableAdapter = new SqlDataAdapter(sql, conn);
        tableAdapter.Fill(dataTable);

        conn.Close();
        conn.Dispose();

        return dataTable;
    }


    // https://visualstudiomagazine.com/articles/2017/07/01/parameterized-queries.aspx
    // https://www.c-sharpcorner.com/UploadFile/a20beb/why-should-always-use-the-parameterized-query-to-avoid-sql-i/
    //    using (SqlConnection connection = new SqlConnection(connectionString))
    //{
    //    connection.Open();

    //    string selectSql = "SELECT * FROM users WHERE id = @id";
    //    using (SqlCommand command = new SqlCommand(selectSql, connection))
    //    {
    //        command.Parameters.AddWithValue("@id", 1);
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                Console.WriteLine("ID: {0}, Name: {1} {2}", reader["id"], reader["fname"], reader["lname"]);
    //            }
    //        }
    //    }
    //}

    // Advanced
    // using DAPPER
    //    using (SqlConnection connection = new SqlConnection(connectionString))
    //{
    //    string selectSql = "SELECT * FROM users WHERE id = @id";
    //    IEnumerable<User> users = connection.Query<User>(selectSql, new { id = 1 });
    //    foreach (User user in users)
    //    {
    //        Console.WriteLine("ID: {0}, Name: {1} {2}", user.Id, user.FirstName, user.LastName);
    //    }
    //}

    // Parametrized Login Query
    public static DataTable Login(string fileName, string sql, params string[] parameters)
    {
        SqlConnection conn = ConnectToDb(fileName);
        conn.Open();

        DataTable dataTable = new DataTable();

        //string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
        //SqlConnection con = new SqlConnection(constr);

        // use sql with parameters
        string safeSQL = $"SELECT * FROM {DBHelper.DB_USER_TABLE} WHERE uname=@uname and password=@password";

        //string safeSQL = $"SELECT COUNT(uName) FROM {DBHelper.DB_USER_TABLE} WHERE uName=@uName AND password=@password";

        SqlCommand cmd = new SqlCommand(safeSQL, conn);

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@uName", parameters[0]);
        param[1] = new SqlParameter("@password", parameters[1]);
        cmd.Parameters.Add(param[0]);
        cmd.Parameters.Add(param[1]);


        SqlDataAdapter tableAdapter = new SqlDataAdapter();
        tableAdapter.SelectCommand = cmd;
        tableAdapter.Fill(dataTable);


        // OR THIS ???
        // object res = cmd.ExecuteReader(); // .ExecuteScalar();
        // loop the reader to fill the table
        //  TBD

        conn.Close();
        conn.Dispose();
        return dataTable;
    }

    //    //if (Convert.ToInt32(res) > 0) Response.Redirect("Home.aspx");
    //    //else
    //    //{
    //    //    Response.Write("Invalid Credentials");
    //    //    return;
    //    //}
    //}


    // Stored Procedure
    // https://social.technet.microsoft.com/wiki/contents/articles/53361.sql-server-stored-procedures-for-c-windows-forms.aspx
    public static DataTable Login(string fileName, params string[] parameters)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection connection = ConnectToDb(fileName)) // new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.Login";

                command.Parameters.AddWithValue("@uName", parameters[0]);
                command.Parameters.AddWithValue("@password", parameters[1]);

                // 3 types of EXECUTE: command ExeceuteNonQuery, ExecuteReader, ExecuteScalar
                // or user DataAdapter to return a table for SELECT
                SqlDataAdapter tableAdapter = new SqlDataAdapter(command);

                tableAdapter.Fill(dataTable);
            }
        }
        return dataTable;
    }

    // Advanced
    public static void RenameTable(string dbFileName, string oldName, string newName)
    {
        SqlConnection conn = ConnectToDb(dbFileName);
        conn.Open();
        string sql = $"EXEC sp_rename @objname = '{oldName}', @newname = '{newName}', @objtype = 'OBJECT';";
        SqlCommand com = new SqlCommand(sql, conn);
        int result = com.ExecuteNonQuery(); // returns -1, but WORKS!!!
    }

    //https://stackoverflow.com/questions/18298433/how-can-i-show-the-table-structure-in-sql-server-query
    public static DataTable GetSchema(string dbFileName, string tableName)
    {
        DataTable dataTable = new DataTable();

        SqlConnection conn = ConnectToDb(dbFileName);
        conn.Open();
        //string sql = $"EXEC sp_columns '{tableName}'";
        string sql = $"SELECT COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='{tableName}'";
        //string sql = $"SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('{tableName}')";
        // SYNTAX ERROR IN SQL: string sql = $"SHOW COLUMNS FROM '{dbFileName}.{tableName}';";



        SqlCommand com = new SqlCommand(sql, conn);
        var reader = com.ExecuteReader(); // returns -1, but WORKS!!!

        // I think this gets the schema of the resulting table that is stored in reader
        //var schema = reader.GetSchemaTable();
        //foreach (DataRow row in schema.Rows)
        //{
        //Debug.WriteLine(row["ColumnName"] + " - " + row["DataTypeName"]);
        //}

        string names = "";
        while (reader.Read())
        {
            names += $"{reader["column_name"]}, ";
        }

        return dataTable;
    }
}



