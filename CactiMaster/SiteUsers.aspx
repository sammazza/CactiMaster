<%@ Page Title="" Language="C#" MasterPageFile="~/Cacti.Master" AutoEventWireup="true" CodeBehind="SiteUsers.aspx.cs" Inherits="CactiMaster.SiteUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <link href="CSS/UsersTablePage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubHeaderPlaceHolder" runat="server">
    <h1>Users Table</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h2><%= sqlSelect %></h2>
        <table class="usertable">
            <%=str %>
        </table>

    <%= msg %>

    <% Response.Write(Sum(5, 11)); %>

</asp:Content>
