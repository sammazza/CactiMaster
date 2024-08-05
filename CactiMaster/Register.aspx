<%@ Page Title="" Language="C#" MasterPageFile="~/Cacti.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CactiMaster.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <link href="CSS/Register.css" rel="stylesheet" />
    <script src="Scripts/register.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubHeaderPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <h3 style="text-align: center; font-size: 26px; font-family: Arial">User Registration </h3>

        <!-- <form name="regform" action="RegisterToDB.aspx"  method="get" onsubmit="return validateForm();" onreset="resetForm()"> -->
        <form name="regform" method="post" onsubmit="return validateForm();" onreset="resetForm();">

            <label for="uname" class="label">User Name</label>
            <input type="text" id="uname" style="float: right;" name="uname" maxlength="20" placeholder="user name...">
            <br />
            <span class="errors" id="erroruname"></span>
            <br />


            <label for="fname" class="label">First Name</label>
            <input type="text" id="fname" style="float: right;" name="fname" maxlength="20" placeholder="first name...">
            <br />
            <span class="errors" id="errorfname"></span>
            <br />

            <label for="lname" class="label">Last Name</label>
            <input type="text" id="lname" style="float: right;" name="lname" maxlength="20" placeholder="last name...">
            <br />
            <span class="errors" id="errorlname"></span>
            <br />

            <label for="tzid" class="label">Tehudat Zehut</label>
            <input type="text" id="tzid" style="float: right;" name="tzid" maxlength="9" placeholder="9 digits TZ ID number">
            <br />
            <span class="errors" id="uiderror"></span>
            <br />

            <label for="email" class="label">Email</label>
            <input type="text" id="email" style="float: right;" name="email" maxlength="20" placeholder="john.doe@xyz.com" autocomplete="off">
            <br />
            <span class="errors" id="errormail"></span>
            <br />

            <label for="password" class="label">Password</label>
            <input type="password" style="float: right;" id="password" name="password" minlength="6" maxlength="15" autocomplete="off" placeholder="password...">
            <br />
            <span class="errors" id="errorpassword"></span>
            <br />

            <label for="verifypassword" class="label">Verify Password</label>
            <input type="password" style="float: right;" id="verifypassword" name="verifypassword" minlength="6" maxlength="15" autocomplete="off" placeholder="verify password...">
            <br />
            <span class="errors" id="errorverifypassword"></span>
            <br />


            <label for="prefix" style="margin-left: 5px; margin-right: 15px;" class="label">Phone Number</label>
            <p style="display: inline">
                <select name="prefix" id="prefix" style="width: fit-content; margin-right: 15px;">
                    <%= strPrefixes %>
                </select>
                <input type="text" id="phone" style="display: inline;  width: fit-content;" name="phone" maxlength="7" placeholder="phone number...">
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
            <input style="margin-right: 15px; color: red" type="radio" name="gender" value="Male" id="gender">
            Female
            <input style="margin-right: 15px" type="radio" name="gender" value="Female">
            Other
            <input style="margin-right: 15px" type="radio" name="gender" value="Other">
            <br />
            <br />

            <label for="hob1" style="margin-left: 5px; margin-right: 15px;" class="label">Hobbies:</label>
            <input type="checkbox" id="hob1" name="hob1" style="margin-right: 15px;" value="sailing" checked>Sailing
            <input type="checkbox" id="hob2" name="hob2" style="margin-right: 15px;" value="biking">Biking  
            <input type="checkbox" id="hob3" name="hob3" style="margin-right: 15px;" value="cooking">Cooking
            <input type="checkbox" id="hob4" name="hob4" style="margin-right: 15px;" value="movies">Movies
            <br />
            <br />

            <label for="question" style="margin-left: 5px; margin-right: 15px;" class="label">Secret Question</label>
            <p style="display: inline">
                <select name="question" id="question" style="width: fit-content; margin-right: 15px;">
                    <%= strQuestions %>
                </select>
                <br />
            </p>

            <p>
            <label for="answer" style="margin-left: 5px; margin-right: 15px;" class="label">Your Answer</label>
            
                <input type="text" style="float: right;" id="answer" name="answer" maxlength="25" placeholder="remember your answer...">
                <br />
                <span class="errors" id="erroranswer"></span>
            </p>
            <br />
            <br />


            <br />
            <div style="text-align: center">
                <input type="submit" name="submit" value="Register">
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

