<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResultTest.aspx.cs" Inherits="TestOnline.ResultTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Wynik testu - tesciki.pl</title>
    <link rel="stylesheet" href="css/resultTest.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel">
        <asp:Label ID="HeadLabel" class="headLabel" runat="server" Text="Tutaj będzie słowna ocena wyniku"></asp:Label><br />
        <asp:Label ID="ResultLabel" class="resultLabel" runat="server" Text="Twój wynik to: 10/20."></asp:Label><br />
        <asp:Label ID="StatusLabel" class="statusLabel" runat="server" Text="TEST NIEZALICZONY!"></asp:Label><br />
        <asp:Button ID="ShowTestButton" class="showTestButton" runat="server" OnClick="Show_Click" Text="Sprawdź odpowiedzi" /><br />
        <asp:LinkButton ID="HomeButton" class="linkButton" style="right: 5%" runat="server" OnClick="Home_Click">Strona Główna</asp:LinkButton>
        <asp:LinkButton ID="RestartButton" class="linkButton" style="left: 5%" runat="server" OnClick="Restart_Click">Rozwiąż ponownie</asp:LinkButton>
    </div>
</asp:Content>
