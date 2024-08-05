<%@ Page Title="" Language="C#" MasterPageFile="~/Cacti.Master" AutoEventWireup="true" CodeBehind="CactiAbout.aspx.cs" Inherits="CactiMaster.CactiAbout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
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
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubHeaderPlaceHolder" runat="server">
    <h1 style="text-align: center">We love cacti</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>For more inforamtion about our cacti, please send us an email.</h2>
</asp:Content>
