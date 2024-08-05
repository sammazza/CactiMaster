<%@ Page Title="" Language="C#" MasterPageFile="~/Cacti.Master" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="CactiMaster.Calculator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">

    <script src="Scripts/Calculator.js"></script>


    <style>
        table {
            margin-left: auto;
            margin-right: auto;
        }

        table, th, td, tr {
            /*border: 1px solid grey;  */
            text-align: center;
        }

        td, img, p {
            text-align: center;
            height: 20px;
        }

        img {
            margin-right: 0px ;
            margin-left: 10px;
        }

        .centertxt {
            text-align: center;
            width: 50px;
        }

        .inputmsg {
            background: rgba(0, 0, 0, 0);
            border: none;
            outline: none;
        }

        .hide {
            display: none;
        }

        .myDIV:hover + .hide {
            display: block;
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubHeaderPlaceHolder" runat="server">
    <h2>Java Script Exercises</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="display: inline-table">
        <tr>
            <td>
                <input class="centertxt" type="number" size="5" id="num11" disabled />
            <td style="width: 20px;">+</td>
            <td>
                <input class="centertxt" type="number" size="5" id="num12" disabled />
            </td>
            <td style="width: 20px;">=</td>
            <td>
                <input class="centertxt" type="text" size="5" maxlength="5" id="anwser1" name="answer1" />
            </td>
            <td style="width: 20px;height:20px;">
                <img id="imgresult1" />
            </td>
        </tr>
    </table>
    <table style="display:inline-table">
        <tr>
            <td>
                <input class="inputmsg" type="text" name="msg1" disabled id="msg1"/>
            </td>
        </tr>
    </table>
    <br />
    <table style="display: inline-table">
        <tr>
            <td>
                <input class="centertxt" type="number" size="5" id="num21" disabled />
            <td style="width: 20px;">-</td>
            <td>
                <input class="centertxt" type="number" size="5" id="num22" disabled />
            </td>
            <td style="width: 20px;">=</td>
            <td>
                <input class="centertxt" type="text" size="5" maxlength="5" id="anwser2" name="answer2" />
            </td>
            <td style="width: 20px;height:20px;">
                <img id="imgresult2" />
            </td>
        </tr>
    </table>
    <table style="display:inline-table">
        <tr>
            <td>
                <input class="inputmsg" type="text" name="msg2" disabled id="msg2"/>
            </td>
        </tr>
    </table>
    <br />
    <table style="display: inline-table">
        <tr>
            <td>
                <input class="centertxt" type="number" size="5" id="num31" disabled />
            <td style="width: 20px;">*</td>
            <td>
                <input class="centertxt" type="number" size="5" id="num32" disabled />
            </td>
            <td style="width: 20px;">=</td>
            <td>
                <input class="centertxt" type="text" size="5" maxlength="5" id="anwser3" name="answer3" />
            </td>
            <td style="width: 20px;height:20px;">
                <img id="imgresult3" />
            </td>
        </tr>
    </table>
    <table style="display:inline-table">
        <tr>
            <td>
                <input class="inputmsg" type="text" name="msg" disabled id="msg3"/>
            </td>
        </tr>
    </table>

    <br />
    <table style="display: inline-table">
        <tr>
            <td>
                <input class="centertxt" type="number" size="5" id="num41" disabled />
            <td style="width: 20px;">/</td>
            <td>
                <input class="centertxt" type="number" size="5" id="num42" disabled />
            </td>
            <td style="width: 20px;">=</td>
            <td>
                <input class="centertxt" type="text" size="5" maxlength="5" id="anwser4" name="answer4" />
            </td>
            <td style="width: 20px;height:20px;">
                <img id="imgresult4" />
            </td>
        </tr>
    </table>
    <table style="display:inline-table">
        <tr>
            <td>
                <input class="inputmsg" type="text" name="msg" disabled id="msg4"/>
            </td>
        </tr>
    </table>

    <br />
    <table style="display: inline-table">
        <tr>
            <td>
                <input class="centertxt" type="number" size="5" id="num51" disabled />
            <td style="width: 20px;">%</td>
            <td>
                <input class="centertxt" type="number" size="5" id="num52" disabled />
            </td>
            <td style="width: 20px;">=</td>
            <td>
                <input class="centertxt" type="text" size="5" maxlength="5" id="anwser5" name="answer5" />
            </td>
            <td style="width: 20px;height:20px;">
                <img id="imgresult5" />
            </td>
        </tr>
    </table>
    <table style="display:inline-table">
        <tr>
            <td>
                <input class="inputmsg" type="text" name="msg" disabled id="msg5"/>
            </td>
        </tr>
    </table>
    <br /><br />
    <table>
        <tr>
            <td style="text-align: center" colspan="7">
                <input type="button" value="check" onclick="checkAnswers();" />
                <input type="button" value="more exerises" onclick="fillNumbers();" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="7">
                <h3 id="score"></h3>
            </td>
        </tr>
    </table>

    <!-- hover : to show students not used here
    <div class="myDIV" style="display: inline">
        Hover over me.
    </div>
    <p class="hide" style="display: inline">I am shown when someone hovers over the div above.</p>
    -->
</asp:Content>
