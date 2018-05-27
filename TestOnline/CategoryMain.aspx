<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryMain.aspx.cs" Inherits="TestOnline.CategoryMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Kategorie - tesciki.pl</title>
    <link rel="stylesheet" href="css/categoryMain.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="category_title_panel">
        <span>
            <asp:Label ID="LabelNameCategory" runat="server" Text="Nazwa kategorii testu"></asp:Label>
        </span>
    </div><br />
    <asp:Button ID="StartTest20" OnClick="StartTest20_Click" class="btnCat" runat="server" Text="Rozpocznij nowy test (20 pytań)" /><br />
    <asp:Button ID="Button2" class="btnCat" runat="server" Text="Wylosuj pytanie" /><br />
    <asp:Button ID="Button3" class="btnCat" runat="server" Text="Przeglądaj wszystkie pytania" /><br />
</asp:Content>
