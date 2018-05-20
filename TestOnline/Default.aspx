<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestOnline.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Strona Główna - tesciki.pl</title>
    <link rel="stylesheet" href="css/default.css" />
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centerPanel">
        <h1>Witaj na Tesciki.pl</h1>
        <br />
        <div class="about">
            Tesciki.pl to Internetowa baza testów, na której możesz rozwiązywać testy z dużej bazy kategorii.
            Poprzez odpowiedzi i możliwość przeglądania każdego z pytań, możesz uczyć się i przyswajać wiedzę w
            sposób łatwy i przyjemny. Dołącz do nas i rywalizuj z innymi użytkownikami portalu w rankingu!
        </div>
        <br />
        <br />
        <asp:Button ID="SignIn" class="SignButton" OnClick="SignIn_Click" runat="server" Text="Dołącz do nas!" />
        <br />
    </div>
    <div class="bottomPanel">
        <fieldset class="cookiesInfo">
            <legend class="legend-cookies">Polityka Cookies</legend>
            Właściciel serwisu stara się korzystać z najlepszych praktyk i traktować wszystkich Użytkowników
            w sposób uczciwy i otwarty. Korzystając z serwisu wyrażasz zgodę na wykorzystanie przez nas plików
            cookies, w celu zapewnienia Tobie wygody podczas przeglądania stron serwisu. Żadne pliki cookie
            wykorzystywane w naszych witrynach internetowych nie gromadzą informacji umożliwiających ustalenie
            tożsamości użytkownika.
        </fieldset>
    </div>
</asp:Content>
