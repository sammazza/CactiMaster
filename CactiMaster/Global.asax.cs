using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace CactiMaster
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            Application["loggedInUsers"] = 0;
        }

        void Session_Start(object sender, EventArgs e)
        {
            Session["uName"] = "Guest";
            Session["uFirstName"] = "Guest";
            Session["isAdmin"] = false;
        }
        void Session_End(object sender, EventArgs e)
        {
            Session["uName"] = "Guest";
            Session["uFirstName"] = "Guest";
            Session["isAdmin"] = false;
        }

    }
}