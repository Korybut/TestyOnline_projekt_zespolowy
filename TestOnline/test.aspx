<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="TestOnline.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
            <br /><br /><br /><br /><br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" />
            <br /><br />
            <asp:TextBox ID="TextBox5" runat="server" Height="124px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="TextBox6" runat="server" Height="112px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
