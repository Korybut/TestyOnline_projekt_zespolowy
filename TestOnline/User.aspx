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
                <asp:Label style="font-size: 1.4em" ID="LoginLabel" runat="server" Text="Login użytkownika"></asp:Label>
                </strong>
                <br />
                <!-- Należy przypiąć imie użytkownika -->
                <asp:Label style="font-size: 1.1em" ID="NameLabel" runat="server" Text="Imię użytkownika"></asp:Label>
                <br />
                <br />
                <!-- Trzeba skonfigurować linkButton z rankingiem i ustawiać aktualną pozycję użytkownika -->
                <strong>
                <asp:LinkButton ID="RankPositionLabel" runat="server" ForeColor="#009400">Pozycja w rankingu: 142</asp:LinkButton>
                </strong>
            </div>
        </div>
        <div class="user_wall">sdasdas a</div>
    </body>
</asp:Content>
