<%@ Page Title="" Language="C#" MasterPageFile="~/Cacti.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CactiMaster.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <link href="CSS/Register.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SubHeaderPlaceHolder" runat="server">
    <!-- <h1>User Login</h1> -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 style="text-align: center; font-size: 26px; font-family: Arial">User Login</h3>

        <form name="loginform" method="post" runat="server">

            <label for="uname" class="label">User Name</label>
            <input type="text" id="uname" style="float: right;" name="uname" maxlength="20" placeholder="user name...">
            <br />
            <br />
            <br />
            <br />

            <label for="password" class="label">Password</label>
            <input type="password" style="float: right;" id="password" name="password" minlength="6" maxlength="15" placeholder="password...">

            <br />
            <br />
            <br />
            <br />
            <label for="query" style="margin-left: 5px; margin-right: 15px;" class="label">Query:</label>

                    <input style="margin-left: 15px;" type="radio" name="query" value="vulnerable" checked>
                    Vulnerable &nbsp;&nbsp;&nbsp;

                    <input style="margin-left: 30px" type="radio" name="query" value="parametrized">
                    Parametrized &nbsp;&nbsp;&nbsp;

                    <input style="margin-left: 30px" type="radio" name="query" value="stored">
                    Stored Procedure
            <br />
            <br />
            <br />
            <div style="text-align: center">
                <input type="submit" name="submit" value="Login">
                &nbsp &nbsp &nbsp
            <input type="reset" id="resetpassword" value="Reset Password" onclick="window.location.href='ResetPassword.aspx';" />
            </div>
        </form>
    </div>
    <%= msg %>
</asp:Content>
