<%@ Page Title="" Language="C#" MasterPageFile="~/Cacti.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CactiMaster.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubHeaderPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%= msg %>
</asp:Content>
