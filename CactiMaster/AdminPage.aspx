<%@ Page Title="" Language="C#" MasterPageFile="~/Cacti.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="CactiMaster.AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        input{
            font-size: larger;
        }
        h1 {
            text-align: center;
        }

        h2 {
            text-align: center;
        }

        .usertable, userth, usertd {
            border: 1px solid black;
        }

        .userth, .usertd {
            text-align: center;
            border: 1px solid black;
        }



        table {
            margin-left: auto;
            margin-right: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubHeaderPlaceHolder" runat="server">
    <h2>Administrator Managing Page</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center;">
        <%= msg %>
        <h2>Admin Functions</h2>
        <form runat="server">
            <input id="Button1" type="button" runat="server" value="Rename Table" onserverclick="RenameTable" />
            <br />
            <br />
            <input id="btnGetSchema" type="button" runat="server" value="Get Schema" onserverclick="GetSchema" />
        </form>
    </div>

</asp:Content>
