<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OneQuestion.aspx.cs" Inherits="TestOnline.OneQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Test - tesciki.pl</title>
    <link rel="stylesheet" href="css/activeTest.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="category_title_panel">
        <span>
            <asp:Label ID="LabelNameCategory" runat="server" Text="Nazwa kategorii testu"></asp:Label>
        </span>

    </div>

    <div class="question_panel">
        <!-- treść pytania -->
        <div class="question_content" style="top: 12vh; left: 16%">
            <asp:Label ID="ContentLabel" runat="server" Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt
            ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip
            ex ea commodo consequat."></asp:Label>
        </div>
        <!-- radiobutton list do podpięcia z widoku -->
        <asp:radiobuttonlist class="radio_list" ID="RadioBTN" style="left: 25%" runat="server"></asp:radiobuttonlist>
        <br />
        <!-- przyciski wstecz i następne pytanie -->
        <asp:Button ID="CheckButton" class="resultButton" OnClick="Check_Click" runat="server" style="font-size: 18px" Text="Sprawdź odpowiedź" />
        <asp:Button ID="ReturnButton" class="resultButton" OnClick="Return_Click" style="left: 3%; font-size: 18px" runat="server" Text="Wróć do kategorii" />
    </div>
</asp:Content>

