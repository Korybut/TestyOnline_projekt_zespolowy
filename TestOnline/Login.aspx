<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TestOnline.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/style.css" /> 
    <link rel="stylesheet" href="css/login.css"/>
    <title>Login</title>
    <script src='https://www.google.com/recaptcha/api.js'></script>
    <style type="text/css">
        .auto-style1 {
            color: #F7E60D;
            font-size: 0.7em;
        }
        .auto-style2 {
            color: #FFFFFF;
            background-color: #4CA400;
        }
        .auto-style3 {
            font-size: 0.7em;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div><img src="img/logotyp.png" /></div>
        <div class="all">
            <fieldset class="fieldset-login">
            <legend class="legend-login">Logownaie</legend>
                <asp:RequiredFieldValidator ID="Error_Login" runat="server" ControlToValidate="TextBox_Llogin" ErrorMessage="Wpisz login!" ValidationGroup="Logowanie" Display="Dynamic" ForeColor="#ff9900" CssClass="auto-style1"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TextBox_Llogin" runat="server" placeholder="Login" ValidationGroup="Logowanie"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="Error_Haslo" runat="server" ControlToValidate="TextBox_Lhaslo" Display="Dynamic" ErrorMessage="Wpisz hasło!" ForeColor="#ff9900" ValidationGroup="Logowanie" CssClass="auto-style3"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TextBox_Lhaslo" runat="server" TextMode="Password" placeholder="Hasło" ValidationGroup="Logowanie"></asp:TextBox>
                <br />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="link" NavigateUrl="~/RecoveryPassword.aspx" style="color: #3399FF; font-size: 0.8em;">Przypomnij hasło</asp:HyperLink>
                <br />
                <asp:Button ID="Button_Zaloguj" runat="server" Text="Zaloguj" ValidationGroup="Logowanie" OnClick="Button_Zaloguj_Click" BorderStyle="None" CssClass="auto-style2" />
            </fieldset>
            
            <fieldset class="fieldset-register">
            <legend class="legend-register">Rejestracja</legend>
                <asp:RequiredFieldValidator ID="Error_Rlogin" runat="server" ControlToValidate="TextBox_Rlogin" Display="Dynamic" ErrorMessage="Wpisz login!" ForeColor="#ff9900" ValidationGroup="Rejestracja" CssClass="auto-style3"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBox_Rlogin" runat="server" placeholder="Login" ValidationGroup="Rejestracja"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="Error_Remail" runat="server" ControlToValidate="TextBox_Remail" Display="Dynamic" ErrorMessage="Wpisz adres e-mail!" ForeColor="#ff9900" ValidationGroup="Rejestracja" CssClass="auto-style3"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBox_Remail" runat="server" placeholder="E-mail" TextMode="Email" ValidationGroup="Rejestracja"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="Error_Rimie" runat="server" ControlToValidate="TextBox_Rimie" Display="Dynamic" ErrorMessage="Wpisz imie!" ForeColor="#ff9900" ValidationGroup="Rejestracja" CssClass="auto-style3"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBox_Rimie" runat="server" placeholder="Imię" ValidationGroup="Rejestracja"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="Error_Rhaslo" runat="server" ControlToValidate="TextBox_Rhaslo" Display="Dynamic" ErrorMessage="Wpisz hasło!" ForeColor="#ff9900" ValidationGroup="Rejestracja" CssClass="auto-style3"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBox_Rhaslo" runat="server" placeholder="Hasło" TextMode="Password" ValidationGroup="Rejestracja"></asp:TextBox>
                <br />
                <asp:CompareValidator ID="Error_Rphaslo" runat="server" ControlToCompare="TextBox_Rphaslo" ControlToValidate="TextBox_Rhaslo" Display="Dynamic" ErrorMessage="Hasła sie nie zgadzają!" ForeColor="#ff9900" ValidationGroup="Rejestracja" CssClass="auto-style3"></asp:CompareValidator>
                <asp:TextBox ID="TextBox_Rphaslo" runat="server" placeholder="Powtórz hasło" TextMode="Password" ValidationGroup="Rejestracja"></asp:TextBox>
                <br />
                <div class="g-recaptcha" data-sitekey="6Lcxj1EUAAAAAHKiqksDXYdN8t8uKq_8HwEMKWHf"></div>
                <asp:Button ID="Button_Rejestracja" runat="server" Text="Rejestruj" ValidationGroup="Rejestracja" BorderStyle="None" CssClass="auto-style2" Height="28px" />
            </fieldset>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
