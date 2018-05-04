<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="TestOnline.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Strona użytkownika - tesciki.pl</title>
    <head>
        <link rel="stylesheet" href="css/user.css" />
    </head>
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- PANEL UŻYTKOWNIKA -->
    <div class="user_panel">
        <div class="user_info">
            <strong>
            <asp:Label style="font-size: 1.5em" ID="LoginLabel" runat="server" Text="Login użytkownika"></asp:Label>
            </strong>
            <br />
            <asp:Label style="font-size: 1.2em" ID="NameLabel" runat="server" Text="Imię użytkownika"></asp:Label>
            <br />
            <br />
            <!-- Trzeba skonfigurować linkButton z rankingiem i ustawiać aktualną pozycję użytkownika -->
            <strong>
            <asp:LinkButton style="font-size: 1.1em" ID="RankPositionLabel" runat="server" ForeColor="#009400">Pozycja w rankingu: 142</asp:LinkButton>
            </strong>
            <br />
            <br /> 
            <!-- Do podpięcia liczba punktów użytkownika -->
            <strong>
            <asp:Label style="font-size: 1.0em" ID="PointsLabel" runat="server" Text="Liczba zdobytych punktów: 10 025"></asp:Label>
            </strong>
            <br />
            <br />
            <strong>
            <!-- Do podpięcia liczba zaliczonych testów użytkownika -->
            <asp:Label style="font-size: 1.0em" ID="PassTestLabel" runat="server" Text="Zaliczone testy: 32"></asp:Label>
            </strong>
            <br />
            <br />
            <strong>
            <!-- Do podpięcia liczba poprawnych odpowiedzi -->
            <asp:Label style="font-size: 1.0em" ID="CorrectAnswerLabel" runat="server" Text="Poprawne odpowiedzi: 275"></asp:Label>
            </strong>
            <br />
            <br />
            <strong>
            <!-- Do podpięcia liczba błędnych odpowiedzi -->
            <asp:Label style="font-size: 1.0em" ID="WrongAnswerLabel" runat="server" Text="Błędne odpowiedzi: 120"></asp:Label>
            </strong>
            <br />
            <br />
            <strong>
            <!-- Do podpięcia skuteczność rozwiązywania egzaminów (obliczana ze wzoru) -->
            <asp:Label style="font-size: 1.0em" ID="EffectiveLabel" runat="server" Text="Skuteczność: 68%"></asp:Label>
            </strong>
        </div>

        <div class="add_category">
            <center>
                <a href="Categories.aspx"><img src="img/plus_button.png" /><br /></a>
                <span>Pobierz kategorie</span>
            </center>
        </div>
    </div>
    <!-- TABLICA TESTÓW UŻYTKOWNIKA -->
    <div class="user_wall"> <span>Tutaj będzie miejsce na pobrane kategorie testów.</span></div>
</asp:Content>
