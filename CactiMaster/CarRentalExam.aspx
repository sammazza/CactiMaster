<%@ Page Title="" Language="C#" MasterPageFile="~/Cacti.Master" AutoEventWireup="true" CodeBehind="CarRentalExam.aspx.cs" Inherits="CactiMaster.CarRentalExam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
      <link href="CSS/UsersTablePage.css" rel="stylesheet" />
    <script src="Scripts/CarRentalExam.js"></script>
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
    <h1>Requested Cars Queries</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div>
       <h3>Display Cars by one or two filters</h3>
       <form id="querybuilder" method="post" runat="server">
           <table class="form_table">
               <tr>
                   <td class="form_table" style="width: 30px;">
                       <select name="filter1" id="filter1" onclick="filter1Click();">
                           <option value="Brand">Brand</option>
                           <option value="Model">Model</option>
                           <option value="Doors">Number of doors</option>
                           <option value="Type">Type</option>
                           <option value="YearOnRoad">Year on road</option>
                           <option value="DailyRate">Daily Rate</option>
                       </select>
                   </td>
                   <td class="form_table" style="width: 250px">
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
                           <option value="Brand">Brand</option>
                           <option value="Model">Model</option>
                           <option value="Doors">Number of doors</option>
                           <option value="Type">Type</option>
                           <option value="YearOnRoad">Year on road</option>
                           <option value="DailyRate">Daily Rate</option>
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
       <h3>Show SQL Query here</h3>
   </div>
   <table>
       <%=strTable %>
   </table>
   <%=msg %>
</asp:Content>
