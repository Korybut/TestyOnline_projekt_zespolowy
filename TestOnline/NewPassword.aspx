<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewPassword.aspx.cs" Inherits="TestOnline.NewPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Nowe hasło</title>
    <link rel="stylesheet" href="css/login.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="all">
            <fieldset class="fieldset_przypomnij_haslo">
            <legend class="legend_przypomnij_haslo">Nowe hasło</legend>
                <table align="center">
                    <tr>
                        <td>Login: </td>
                        <td><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Nowe hasło:</td>
                        <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Powtórz nowe hasło:</td>
                        <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:Button ID="Button1" runat="server" Text="Zmień hasło" /></td>
                    </tr>
                </table>
                
                
            </fieldset>
        </div>
    </form>
</body>
</html>
