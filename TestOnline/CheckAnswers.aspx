<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckAnswers.aspx.cs" Inherits="TestOnline.CheckAnswers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Sprawdź odpowiedzi - tesciki.pl</title>
    <link rel="stylesheet" href="css/activeTest.css" />
    <link rel="stylesheet" href="css/checkAnswers.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="category_title_panel">
        <span>
            <asp:Label ID="LabelNameCategory" runat="server" Text="Nazwa kategorii testu"></asp:Label>
        </span>

    </div>

    <div class="question_panel">
        <!-- numer pytania -->
        <div id="question_number"><asp:Label ID="NumberLabel" runat="server" Text="0"></asp:Label></div>
        <!-- treść pytania -->
        <div class="question_content">
            <asp:Label ID="ContentLabel" runat="server" Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt
            ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip
            ex ea commodo consequat."></asp:Label>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <!-- radiobutton list do podpięcia z widoku -->
        <asp:Label ID="UserSelectedAnswer" runat="server" class="answerLabels" Text="Twoja odpowiedź"></asp:Label>
        <br />
        <asp:Label ID="CorrectAnswer" runat="server" class="answerLabels" Text="Poprawna odpowiedź"></asp:Label>
        <br />
        <!-- przyciski wstecz i następne pytanie -->
        <asp:Button ID="PrevButton" class="prevButton" OnClick="Prev_Click" style="left: 3%" runat="server" Text="<" />
        <asp:Button ID="NextButton" class="nextButton" OnClick="Next_Click" style="right: 3%" runat="server" Text=">" />
    </div>
</asp:Content>
