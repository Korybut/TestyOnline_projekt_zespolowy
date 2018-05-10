<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActiveTest.aspx.cs" Inherits="TestOnline.ActiveTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Nazwa testu - numer pytania</title>
    <link rel="stylesheet" href="css/activeTest.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="category_title_panel"><span>Nazwa kategorii testu</span></div>

    <div class="question_panel">
        <!-- numer pytania -->
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
        <asp:radiobuttonlist class="radio_list" runat="server">
            <asp:ListItem class="rbtn" ID="AnswerRB1">sed do eiusmod tempor incididunt ut labore</asp:ListItem>
            <asp:ListItem class="rbtn" ID="AnswerRB2">Ut enim ad minim veniam, quis nostrud</asp:ListItem>
            <asp:ListItem class="rbtn" ID="AnswerRB3">laboris nisi ut aliquip ex ea commodo consequat</asp:ListItem>
            <asp:ListItem class="rbtn" ID="AnswerRB4">sed do eiusmod tempor incididunt</asp:ListItem>
        </asp:radiobuttonlist><br />
        <!-- przyciski wstecz i następne pytanie -->
        <asp:Button ID="Button1" class="prevNextButton" style="left: 3%" runat="server" Text="<" />
        <asp:Button ID="Button2" class="prevNextButton" style="right: 3%" runat="server" Text=">" />
        <!-- pasek postępu testu -->
        <div class="progresBar_border"></div>
        <div class="progresBar_fill" ID="ProgresBar" runat="server"></div>
    </div>


</asp:Content>
