<%@ Page Title="" Language="C#" MasterPageFile="~/Cacti.Master" AutoEventWireup="true" CodeBehind="SelectGmailAndYear.aspx.cs" Inherits="CactiMaster.SelectGmailAndYear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
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
    <h2>Users with gmail and born between 2000 and 2005</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="text-align: center"><%= sqlSelect %></h3>
    <table class="usertable">
        <%= str %>
    </table>
    <%= msg %>
</asp:Content>
