using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CactiMaster
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string msg =  "123";

        protected void Page_Load(object sender, EventArgs e)
        {
            msg += "z";
        }
    }
}