<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="CactiMaster.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/FormExercise.js"></script>
    <link href="CSS/Register.css" rel="stylesheet" />

    <style>
        h3 {
            text-align: center;
            font-size: 26px;
            font-family: Arial;
        }


        /*  input {
         display: initial;
     }*/
    </style>
    <title></title>
</head>
<body>
    <div class="container" style="width:50%">
        <h3>Car Registration</h3>

        <form name="ExerciseForm" method="post" runat="server" onsubmit="return checkCarRegistration();">

            <label for="licensePlate" class="label">Car License Plate</label><br />
            <input type="text" id="licensePlate" style="width:150px;" name="licensePlate" maxlength="10" placeholder="car license plate"/>
            <br />
            <span class="errors" id="errorLicensePlate"></span>
            <br />
            <br />
            <label for="carYear" class="label">Year On Road</label><br />
            <select name="carYear" id="carYear" style="width: fit-content;">
                <option value="none">Choose Year</option>
                <option value="2015">2015</option>
                <option value="2016">2016</option>
                <option value="2017">2017</option>
                <option value="2018">2018</option>
                <option value="2019">2019</option>
                <option value="2020">2020</option>
                <option value="2021">2021</option>
                <option value="2022">2022</option>
                <option value="2023">2023</option>
                <option value="2024">2024</option>
            </select>
            <br />
            <span class="errors" id="errorCarYear"></span>

            <br />
            <br />

            <label for="israelID" class="label">Tehudat Zehut</label><br />
            <input type="text" style="width: 110px" id="israelID" name="israelID" minlength="7" maxlength="8"/>
            <input type="text" style="width: 30px" id="checkDigit" name="checkDigit" minlength="1" maxlength="1"/>
            <br />
            <span class="errors" id="errorTZID"></span>

            <br />
            <br />

            <div style="text-align: center">
                <input type="submit" name="submit" value="Pay Car License"/>
                &nbsp &nbsp &nbsp
         <input type="reset" id="resetform" value="Reset" onclick="window.location.href='WebForm2.aspx';" />
            </div>
        </form>
    </div>

</body>
</html>
