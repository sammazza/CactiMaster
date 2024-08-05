<%@ Page Title="" Language="C#" MasterPageFile="~/Cacti.Master" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="CactiMaster.UpdateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <script src="Scripts/register.js"></script>
    <style>
        h1 {
            text-align: center;
        }

        h2 {
            text-align: center;
        }

        table {
            margin-left: auto;
            margin-right: auto;
            padding: 5px;
        }
        .container {
            width: 80%;
            margin-left: auto;
            margin-right: auto;
            border-radius: 10px;
            background-color: #eecccccc;
            padding: 20px;
            margin-top: 10px;
            margin-bottom: 80px;
        }

        .container1 {
            width: 20%;
            margin: auto;
            border-radius: 10px;
            background-color: #cccccc;
            padding: 15px;
            margin-top: 5px;
            margin-bottom: 80px;
        }

            .container1 input[type=text], input[type=password],
            select, textarea {
                width: 40%;
                padding: 5px;
                border: 1px solid #ccc;
                border-radius: 10px;
                box-sizing: border-box;
                margin-top: 6px;
                margin-bottom: 5px;
                resize: vertical;
                font-family: Arial;
                font-size: 18px;
            }

        .container input[type=text], input[type=password],
        select, textarea {
            width: 100%;
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 10px;
            box-sizing: border-box;
            margin-top: 6px;
            margin-bottom: 5px;
            resize: vertical;
            font-family: Arial;
            font-size: 18px;
        }

        .errors {
            width: 50%;
            padding: 5px;
            color: red;
            margin-top: 0px;
            margin-bottom: 5px;
            font-family: Arial;
            font-size: 18px;
        }

        input[type=submit] {
            background-color: burlywood;
            color: white;
            padding: 10px 10px;
            border: none;
            border-radius: 10px;
            cursor: pointer;
            font-family: Arial;
            font-size: 18px;
        }

        input[type=reset] {
            background-color: burlywood;
            color: white;
            padding: 10px 10px;
            margin-right: 20px;
            border: none;
            border-radius: 10px;
            cursor: pointer;
            font-family: Arial;
            font-size: 18px;
        }

        .label {
            font-family: Arial;
            font-size: 18px;
            color: saddlebrown;
            font-weight: bold;
        }

        input[type=submit]:hover {
            background-color: #45a049;
        }

        input[type=reset]:hover {
            background-color: #45a049;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubHeaderPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <h3 style="text-align: center; font-size: 26px; font-family: Arial">User Update</h3>

        <!-- <form name="regform" action="RegisterToDB.aspx"  method="get" onsubmit="return validateForm();" onreset="resetForm()"> -->
        <form name="regform" method="post" onsubmit="return validateForm();" onreset="resetForm();">

            <label for="uname" class="label">User Name</label>
            <input type="text" id="uname" style="float: right;" name="uname" maxlength="20" disabled="disabled" placeholder="user name..." value="<%= uName %>">
            <br />
            <span class="errors" id="erroruname"></span>
            <br />


            <label for="fname" class="label">First Name</label>
            <input type="text" id="fname" style="float: right;" name="fname" maxlength="20" placeholder="first name..." value="<%= fName %>">
            <br />
            <span class="errors" id="errorfname"></span>
            <br />

            <label for="lname" class="label">Last Name</label>
            <input type="text" id="lname" style="float: right;" name="lname" maxlength="20" placeholder="last name..." value="<%= lName %>">
            <br />
            <span class="errors" id="errorlname"></span>
            <br />

            <label for="uid" class="label">Tehudat Zehut</label>
            <input type="text" id="tzid" style="float: right;" name="tzid" maxlength="9" placeholder="9 digits TZ ID number" value="<%= tzid %>">
            <br />
            <span class="errors" id="uiderror"></span>
            <br />

            <label for="email" class="label">Email</label>
            <input type="text" id="email" style="float: right;" name="email" maxlength="20" placeholder="john.doe@xyz.com" value="<%= email %>">
            <br />
            <span class="errors" id="errormail"></span>
            <br />

            <label for="password" class="label">Password</label>
            <input type="password" style="float: right;" id="password" name="password" minlength="6" maxlength="15" placeholder="password..." value="<%= password %>">
            <br />
            <span class="errors" id="errorpassword"></span>
            <br />

            <label for="verifypassword" class="label">Verify Password</label>
            <input type="password" style="float: right;" id="verifypassword" name="verifypassword" minlength="6" maxlength="15" placeholder="verify password..." value="<%= verifyPassword %>">
            <br />
            <span class="errors" id="errorverifypassword"></span>
            <br />


            <label for="prefix" style="margin-left: 5px; margin-right: 15px;" class="label">Phone Number</label>
            <p style="display: inline">
                <select name="prefix" id="prefix" style="width: fit-content; margin-right: 15px;">
                    <%= strPrefixes %>
                </select>
                <input type="text" id="phone" style="display: inline; float: inline-end; width: fit-content;" name="phone" maxlength="7" placeholder="phone number..." value="<%= phone %>">
                <br />
                <span class="errors" id="errorphone"></span>

            </p>
            <br />

            <label for="city" style="margin-left: 5px; margin-right: 15px;" class="label">City</label>
            <p style="display: inline">
                <select name="city" id="city" style="width: fit-content;">
                    <%= strCities %>
                </select>
                <br />
                <span class="errors" id="errorcity"></span>
            </p>
            <br />

            <label for="yearborn" style="margin-left: 5px; margin-right: 15px;" class="label">Year Born:</label>
            <!-- <label style="display: inline"> -->
            <select name="yearborn" id="yearborn" style="width: fit-content;">
                <option value="choose">choose</option>
                <%= validYears %>
            </select>
            <br />

            <span class="errors" id="erroryearborn"></span>
            <br />
            <br />

            <label for="gender" style="margin-left: 5px; margin-right: 15px;" class="label">Gender:</label>
            Male
            <% if (gender.Equals("M"))
                { %>
            <input style="margin-right: 15px; color: red" type="radio" name="gender" value="Male" checked>
            Female
                <input style="margin-right: 15px" type="radio" name="gender" value="Female">
            Other
                <input style="margin-right: 15px" type="radio" name="gender" value="Other">
            <% }
            else
            { %>

            <input style="margin-right: 15px; color: red" type="radio" name="gender" value="Male">
            Female
                <input style="margin-right: 15px" type="radio" name="gender" value="Female" checked>
            Other
                <input style="margin-right: 15px" type="radio" name="gender" value="Other">
            <% } %>
            <br />
            <br />

            <label for="checkbox" style="margin-left: 5px; margin-right: 15px;" class="label">Hobbies:</label>

            <% if (hobby1.Equals("T"))
                { %>
            <input type="checkbox" id="hob1" name="hob1" style="margin-right: 15px;" value="sailing" checked>
            <% }
                else
                { %>
            <input type="checkbox" id="hob1" name="hob1" style="margin-right: 15px;" value="sailing">
            <% } %>Sailing

            <% if (hobby2.Equals("T"))
                { %>
            <input type="checkbox" id="hob2" name="hob2" style="margin-right: 15px;" value="biking" checked>
            <% }
                else
                { %>
            <input type="checkbox" id="hob2" name="hob2" style="margin-right: 15px;" value="biking">
            <% } %>Biking  


            <% if (hobby3.Equals("T"))
                { %>
            <input type="checkbox" id="hob3" name="hob3" style="margin-right: 15px;" value="cooking" checked>
            <% }
                else
                { %>
            <input type="checkbox" id="hob3" name="hob3" style="margin-right: 15px;" value="cooking">Cooking
            <% } %>
            <% if (hobby4.Equals("T"))
                { %>
            <input type="checkbox" id="hob4" name="hob4" style="margin-right: 15px;" value="movies" checked>
            <% }
                else
                { %>
            <input type="checkbox" id="hob4" name="hob4" style="margin-right: 15px;" value="movies">Movies
            <% } %>
            <br />
            <br />
            <div style="text-align: center">
                <input type="submit" name="submit" value="Update">
                &nbsp &nbsp &nbsp
                <input type="reset" name="reset" value="Clear Form">
            </div>
        </form>
    </div>
    <h3 style="text-align: center">
        <%= sqlMsg %>
        <br />
        <%= msg %>
    </h3>
</asp:Content>

