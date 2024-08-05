<%@ Page Title="" Language="C#" MasterPageFile="~/Cacti.Master" AutoEventWireup="true" CodeBehind="DynamicQueries.aspx.cs" Inherits="CactiMaster.DynamicQueries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">

    <script src="Scripts/DynamicQuery.js"></script>
    <link href="CSS/UsersTablePage.css" rel="stylesheet" />

    
    <style>
        .form_table {
            border: 1px solid black;
        }

            .form_table td {
                padding: 3px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubHeaderPlaceHolder" runat="server">
    <h1>Dynamic Queries</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>Display users by one or two filters</h3>
        <!-- GET vs POST -->
        <form id="querybuilder" method="post" runat="server">

            <table class="form_table">
                <tr>
                    <td class="form_table" style="width: 30px;">
                        <select name="filter1" id="filter1" onclick="filter1Click();">
                            <option value="uName">User Name</option>
                            <option value="fName">First Name</option>
                            <option value="lName">Last Name</option>
                            <option value="email">Email</option>
                            <option value="gender">Gender</option>
                            <option value="yearBorn">Year Born</option>
                            <option value="fromYear">From Year</option>
                            <option value="prefix">Prefix</option>
                            <option value="phone">Phone</option>
                            <option value="hobby">Hobby</option>
                        </select>
                    </td>
                    <td class="form_table" style="width: 150px">
                        <div id="filter1Text" style="text-align: center"></div>
                    </td>
                </tr>
                <tr>
                    <td class="form_table" colspan="2" style="text-align: center">
                        <input type="radio" name="operator" value="AND" checked="checked" />AND
                        <input style="margin-left: 30px" type="radio" name="operator" value="OR" />OR
                    </td>
                </tr>

                <tr>
                    <td class="form_table" style="width: 30px;">
                        <select name="filter2" id="filter2" onclick="filter2Click();">
                            <option value="uName">User Name</option>
                            <option value="fName">First Name</option>
                            <option value="lName">Last Name</option>
                            <option value="email">Email</option>
                            <option value="gender">Gender</option>
                            <option value="yearBorn">Year Born</option>
                            <option value="toYear">To Year</option>
                            <option value="prefix">Prefix</option>
                            <option value="phone">Phone</option>
                            <option value="hobby">Hobby</option>
                        </select>
                    </td>
                    <td style="width: 150px" class="form_table">
                        <div id="filter2Text" style="text-align: center"></div>
                    </td>
                </tr>
                <tr>
                    <td class="form_table" colspan="2" style="text-align: center">
                        <input type="submit" name="submit" value="Search" />
                    </td>
                </tr>
            </table>
        </form>
    </div>
    <div style="text-align: center;">
        <h3><%=sqlSelect %></h3>
    </div>
    <table>
        <%=strTable %>
    </table>
    <%=msg %>
</asp:Content>
