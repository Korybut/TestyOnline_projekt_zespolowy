<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ranking.aspx.cs" Inherits="TestOnline.Ranking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/ranking.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="podiumPanel">
        
        <div class="places2">
            <img src="img/second_place.png" /><br />
            <asp:Label ID="LabelSecond" runat="server" Text="LoginDrugi"></asp:Label><br />
            <asp:Label ID="LabelSecondPoints" runat="server" Text="1234" style="font-size: 2vh" ForeColor="#39AB00"></asp:Label>
        </div>
        <div class="places1" style="">
            <img src="img/first_place.png" /><br />
            <asp:Label ID="LabelFirst" runat="server" Text="LoginPierwszy"></asp:Label><br />
            <asp:Label ID="LabelFirstPoints" runat="server" Text="1840" style="font-size: 3vh" ForeColor="#39AB00"></asp:Label>
        </div>
        <div class="places2">
            <img src="img/third_place.png" /><br />
            <asp:Label ID="LabelThird" runat="server" Text="LoginTrzeci"></asp:Label><br />
            <asp:Label ID="LabelThirdPoints" runat="server" Text="895" style="font-size: 2vh" ForeColor="#39AB00"></asp:Label>
        </div>
        
    </div>
    <div class="rank">
        <asp:Label ID="above0" runat="server" Text="..."></asp:Label><br />
        <asp:Label ID="above1" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="above2" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="above3" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="UserPosition" runat="server" Text="TWOJA POZYCJA - punkty" style="font-size: 3.3vh; font-weight: 600" ForeColor="#39AB00"></asp:Label><br />
        <asp:Label ID="below1" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="below2" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="below3" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="below0" runat="server" Text="..."></asp:Label>
    </div>
</asp:Content>
