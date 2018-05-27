<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActiveTest.aspx.cs" Inherits="TestOnline.ActiveTest" %>
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
        <!-- numer pytania sdaskda -->
        <div id="question_number"><asp:Label ID="NumberLabel" runat="server" Text="0"></asp:Label></div>
        <!-- opcjonalnie (ustawić show/hide) przycisk do wyświetlenia obrazka -->
        <asp:imagebutton runat="server" class="image_icon" ImageUrl="~/img/image_icon.png" AlternateText="Zobacz obrazek"></asp:imagebutton>
        <div class="image_txt">Zobacz<br />obrazek</div>
        <!-- treść pytania -->
        <div class="question_content">
            <asp:Label ID="ContentLabel" runat="server" Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt
            ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip
            ex ea commodo consequat."></asp:Label>
        </div>
        <!-- radiobutton list do podpięcia z widoku -->
        <asp:radiobuttonlist class="radio_list" ID="RadioBTN" runat="server"></asp:radiobuttonlist>
        <br />
        <!-- przyciski wstecz i następne pytanie -->
        <asp:Button ID="PrevButton" class="prevButton" OnClick="Prev_Click" style="left: 3%" runat="server" Text="<" />
        <asp:Button ID="NextButton" class="nextButton" OnClick="Next_Click" style="right: 3%" runat="server" Text=">" />
        <asp:Button ID="ResultButton" class="resultButton" OnClick="Result_Click" runat="server" Text="Sprawdź wynik" />
    </div>
</asp:Content>
