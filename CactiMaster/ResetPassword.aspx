<%@ Page Title="" Language="C#" MasterPageFile="~/Cacti.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="CactiMaster.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <link href="CSS/Register.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubHeaderPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <h3 style="text-align: center; font-size: 26px; font-family: Arial">Password Reset Form</h3>

        <!-- <form name="regform" action="RegisterToDB.aspx"  method="get" onsubmit="return validateForm();" onreset="resetForm()"> -->
        <form name="resetpassword" method="post" onsubmit="return validateResetForm();" onreset="resetForm();" runat="server">

            <label for="uname" class="label">User Name</label>
            <input type="text" id="uname" style="float: right;" name="uname" maxlength="20" placeholder="user name...">
            <br />
            <span class="errors" id="erroruname"></span>
            <br />

            <label for="password" class="label">New Password</label>
            <input type="password" style="float: right;" id="password" name="password" minlength="6" maxlength="15" placeholder="password...">
            <br />
            <span class="errors" id="errorpassword"></span>
            <br />

            <label for="verifypassword" class="label">Verify Password</label>
            <input type="password" style="float: right;" id="verifypassword" name="verifypassword" minlength="6" maxlength="15" placeholder="verify password...">
            <br />
            <span class="errors" id="errorverifypassword"></span>
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
                <input type="submit" name="submit" value="Save">
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
