using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CactiMaster
{
    public partial class FormExercise : System.Web.UI.Page
    {
        public string msg = "";
        public string table = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Form["submit"] != null)
            {
                string licensePlate = Request.Form["licensePlate"].ToString();
                string year = Request.Form["carYear"].ToString();
                int fee = calculateFee(licensePlate, year);

                table += "<table border='1'>";

                table += "<tr>";
                table += "<td>";
                    table += "License Plate";
                table += "</td>";
                table += "<td>";
                    table += $"{licensePlate}";
                table += "</td>";
                table += "</tr>";

                table += "<tr>";
                table += "<td>";
                    table += "Registration Year";
                table += "</td>";
                table += "<td>";
                    table += $"{year}";
                table += "</td>";
                table += "</tr>";

                table += "<tr>";
                table += "<td>";
                    table += $"TZ ID";
                table += "</td>";
                table += "<td>";
                    table += $"{Request.Form["israelID"]}{Request.Form["checkDigit"]}";
                table += "</td>";
                table += "</tr>";

                table += "<tr>";
                table += "<td>";
                    table += $"Fee";
                table += "</td>";
                table += "<td>";
                    table += $"{fee}";
                table += "</td>";
                table += "</tr>";

                table += "</table>";
            }

        }
        private int calculateFee(string licensePlate, string year)
        {
            int length = licensePlate.Length;
            int frontDigits = 0;

            if (length == 7 || length == 9) // old style XX-XXX-XX, XXXXXXX: 9, 7
            {
                frontDigits = int.Parse(licensePlate.Substring(0, 2));
            }
            else // new style XXX-XX-XXX XXXXXXXX: 10, 8
            {
                frontDigits = int.Parse(licensePlate.Substring(0, 3));
            }
            int fee = 50 * frontDigits;
            int discount = (2024 - int.Parse(year)) * 50;
            return fee - discount;
        }
    }
}