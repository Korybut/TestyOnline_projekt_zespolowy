<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyData.aspx.cs" Inherits="TestOnline.MyData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Moje dane - tesciki.pl</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 150px;">
        <center>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server"></asp:ValidationSummary>
        </center>
        <table align="center">
            <tr>
                <th>Login:</th>
                <td>
                    <asp:TextBox ID="TextBox_Login" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>Imie:</th>
                <td>
                    <asp:TextBox ID="TextBox_Imie" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Wpisz imie!" ControlToValidate="TextBox_Imie" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>Adres e-mail:</th>
                <td>
                    <asp:TextBox ID="TextBox_Email" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Wpisz adres e-mail!" ControlToValidate="TextBox_Email" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="To nie jest adres e-mail!" ControlToValidate="TextBox_Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button1" runat="server" Text="zmień" OnClick="Button1_Click" /></td>
            </tr>
        </table>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TestyOnlineConnectionString %>" DeleteCommand="DELETE FROM [UZYTKOWNICY] WHERE [id_uzytkownika] = @id_uzytkownika" InsertCommand="INSERT INTO [UZYTKOWNICY] ([email], [imie]) VALUES (@email, @imie)" SelectCommand="SELECT [email], [imie], [id_uzytkownika] FROM [UZYTKOWNICY] WHERE ([id_uzytkownika] = @id_uzytkownika)" UpdateCommand="UPDATE [UZYTKOWNICY] SET [email] = @email, [imie] = @imie WHERE [id_uzytkownika] = @id_uzytkownika">
            <DeleteParameters>
                <asp:Parameter Name="id_uzytkownika" Type="Decimal" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="imie" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:CookieParameter CookieName="userLogin" DefaultValue="0" Name="id_uzytkownika" Type="Decimal" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="imie" Type="String" />
                <asp:Parameter Name="id_uzytkownika" Type="Decimal" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
