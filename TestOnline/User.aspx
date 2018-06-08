<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" EnableEventValidation="false" Inherits="TestOnline.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Strona użytkownika - tesciki.pl</title>
    <link rel="stylesheet" href="css/user.css" />
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- PANEL UŻYTKOWNIKA -->
    <div class="user_panel">
        <div class="user_info">
            <strong>
            <asp:Label style="font-size: 1.8em" ID="NameLabel" runat="server" Text="Login użytkownika"></asp:Label>
            </strong>
            <br />
            <br />
            <br />
            <!-- Trzeba skonfigurować linkButton z rankingiem i ustawiać aktualną pozycję użytkownika -->
            <strong>
            <asp:LinkButton style="font-size: 1.1em; text-decoration: none" ID="RankPositionLabel" 
                OnClick="RankPosition_Clicked" runat="server" ForeColor="#009400">Twoja pozycja w rankingu: 142</asp:LinkButton>
            </strong>
            <br />
            <br />
            <br />
            <br />
            <strong>
                <span style="font-size: 1.1em">Twoje statystyki:</span>
            </strong>
            <br />
            <br />
            <div style="width: 8vh; height: 3px; background-color: white; display: block;"></div>
            <!-- Do podpięcia liczba punktów użytkownika -->
            <strong>
            <p><asp:Label style="font-size: 0.8em" ID="PointsLabel" runat="server" Text="Liczba zdobytych punktów: 10 025"></asp:Label></p>
            </strong>
            <strong>
            <!-- Do podpięcia liczba zaliczonych testów użytkownika -->
            <p><asp:Label style="font-size: 0.8em" ID="PassTestLabel" runat="server" Text="Zaliczone testy: 32"></asp:Label></p>
            </strong>
            <strong>
            <!-- Do podpięcia liczba poprawnych odpowiedzi -->
            <p><asp:Label style="font-size: 0.8em" ID="CorrectAnswerLabel" runat="server" Text="Poprawne odpowiedzi: 275"></asp:Label></p>
            </strong>
            <strong>
            <!-- Do podpięcia liczba błędnych odpowiedzi -->
            <p><asp:Label style="font-size: 0.8em" ID="WrongAnswerLabel" runat="server" Text="Błędne odpowiedzi: 120"></asp:Label></p>
            </strong>
            <strong>
            <!-- Do podpięcia skuteczność rozwiązywania egzaminów (obliczana ze wzoru) -->
            <asp:Label style="font-size: 0.8em" ID="EffectiveLabel" runat="server" Text="Skuteczność: 68%"></asp:Label>
            </strong>
        </div>

        <div class="add_category">
            <center>
                <a href="Categories.aspx"><img src="img/plus_button.png" /><br /></a>
                <span>wybierz test</span>
            </center>
        </div>
    </div>
    <!-- TABLICA TESTÓW UŻYTKOWNIKA -->
    <div class="user_wall_header">
        <center>
            <br />
            <br />
            <span>Testy, które rozwiązywałeś:</span>
        </center>
    </div>
    <div class="user_wall">
        <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate runat="server">
                    <div class="solvedCategory">
                        <asp:Button ID="Button1" class="button" runat="server" OnClick="LoadCategory_Click" 
                            CommandArgument='<%# Eval("id_kategorii") %>' 
                            Text='<%# Eval("nazwa") + " ( " + Eval("zdobyte_punkty") + "pkt )" %>'/>
                    </div>
                </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
