<%@ Page Title="Strona użytkownika" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="TestOnline.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Strona użytkownika - tesciki.pl</title>
    <head>
        <link rel="stylesheet" href="css/user.css"/>
    </head>
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <div class="user_panel">
            <div class="user_info">
                <!-- Należy przypiąć login użytkownika -->
                <strong>
                <asp:Label style="font-size: 1.5em" ID="LoginLabel" runat="server" Text="Login użytkownika"></asp:Label>
                </strong>
                <br />
                <!-- Należy przypiąć login użytkownika -->
                <asp:Label style="font-size: 1.2em" ID="NameLabel" runat="server" Text="Imię użytkownika"></asp:Label>
                <br />
                <br />
                <!-- Trzeba skonfigurować linkButton z rankingiem i ustawiać aktualną pozycję użytkownika -->
                <strong>
                <asp:LinkButton style="font-size: 1.1em" ID="RankPositionLabel" runat="server" ForeColor="#009400">Pozycja w rankingu: 142</asp:LinkButton>
                </strong>
                <br />
                <br /> 
                <strong>
                <asp:Label style="font-size: 1.0em" ID="PointsLabel" runat="server" Text="Liczba zdobytych punktów: 10 025"></asp:Label>
                </strong>
                <br />
                <br />
                <strong>
                <asp:Label style="font-size: 1.0em" ID="PassTestLabel" runat="server" Text="Zaliczone testy: 32"></asp:Label>
                </strong>
            </div>
        </div>
        <div class="user_wall">sdasdas a</div>
    </body>
</asp:Content>
