<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoveryPassword.aspx.cs" Inherits="TestOnline.RecoveryPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Przypomnienie hasła</title>
    <link rel="stylesheet" href="css/login.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="all">
            <fieldset class="fieldset_przypomnij_haslo">
            <legend class="legend_przypomnij_haslo">Przypomnienie hasła</legend>
                <table>
                    <tr>
                        <td><asp:Label ID="Label1" runat="server" Text="Podaj adres e-mail:"></asp:Label></td>
                        <td><asp:TextBox ID="TextBox_email" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:Button ID="Button1" runat="server" Text="Przypomnij hasło" OnClick="Button1_Click" /></td>
                    </tr>
                </table>
                
                
            </fieldset>
        </div>
    </form>
</body>
</html>
