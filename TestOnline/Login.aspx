<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TestOnline.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/login.css"/>
    <title>Login</title>
    <script src='https://www.google.com/recaptcha/api.js'></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="all">
            <fieldset class="fieldset-login">
            <legend class="legend-login">Logownaie</legend>
                <asp:RequiredFieldValidator ID="Error_Login" runat="server" ControlToValidate="TextBox_Llogin" ErrorMessage="Wpisz login!" ValidationGroup="Logowanie" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBox_Llogin" runat="server" placeholder="Login" ValidationGroup="Logowanie"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Error_Haslo" runat="server" ControlToValidate="TextBox_Lhaslo" Display="Dynamic" ErrorMessage="Wpisz hasło!" ForeColor="Red" ValidationGroup="Logowanie"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBox_Lhaslo" runat="server" TextMode="Password" placeholder="Hasło" ValidationGroup="Logowanie"></asp:TextBox>
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="link" NavigateUrl="~/RecoveryPassword.aspx">Przypomnij hasło</asp:HyperLink>
                <br />
                <asp:Button ID="Button_Zaloguj" runat="server" Text="Zaloguj" ValidationGroup="Logowanie" />
            </fieldset>
            
            <fieldset class="fieldset-register">
            <legend class="legend-register">Rejestracja</legend>
                <asp:RequiredFieldValidator ID="Error_Rlogin" runat="server" ControlToValidate="TextBox_Rlogin" Display="Dynamic" ErrorMessage="Wpisz login!" ForeColor="Red" ValidationGroup="Rejestracja"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBox_Rlogin" runat="server" placeholder="Login" ValidationGroup="Rejestracja"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Error_Remail" runat="server" ControlToValidate="TextBox_Remail" Display="Dynamic" ErrorMessage="Wpisz adres e-mail!" ForeColor="Red" ValidationGroup="Rejestracja"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBox_Remail" runat="server" placeholder="E-mail" TextMode="Email" ValidationGroup="Rejestracja"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Error_Rimie" runat="server" ControlToValidate="TextBox_Rimie" Display="Dynamic" ErrorMessage="Wpisz imie!" ForeColor="Red" ValidationGroup="Rejestracja"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBox_Rimie" runat="server" placeholder="Imię" ValidationGroup="Rejestracja"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Error_Rhaslo" runat="server" ControlToValidate="TextBox_Rhaslo" Display="Dynamic" ErrorMessage="Wpisz hasło!" ForeColor="Red" ValidationGroup="Rejestracja"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBox_Rhaslo" runat="server" placeholder="Hasło" TextMode="Password" ValidationGroup="Rejestracja"></asp:TextBox>
                <br />
                <asp:CompareValidator ID="Error_Rphaslo" runat="server" ControlToCompare="TextBox_Rphaslo" ControlToValidate="TextBox_Rhaslo" Display="Dynamic" ErrorMessage="Hasła sie nie zgadzają!" ForeColor="Red" ValidationGroup="Rejestracja"></asp:CompareValidator>
                <asp:TextBox ID="TextBox_Rphaslo" runat="server" placeholder="Powtórz hasło" TextMode="Password" ValidationGroup="Rejestracja"></asp:TextBox>
                <br />
                <div class="g-recaptcha" data-sitekey="6Lcxj1EUAAAAAHKiqksDXYdN8t8uKq_8HwEMKWHf"></div>
                <asp:Label ID="Label1" runat="server" Text="X"></asp:Label>
                <br />
                <asp:Button ID="Button_Rejestracja" runat="server" Text="Rejestruj" ValidationGroup="Rejestracja" />
            </fieldset>
        </div>
    </form>
</body>
</html>
