<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestOnline.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Strona Główna - tesciki.pl</title>
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id_kategorii" DataSourceID="SqlDataSource1" ShowHeader="False">
        <Columns>
            <asp:BoundField DataField="id_kategorii" HeaderText="id_kategorii" InsertVisible="False" ReadOnly="True" SortExpression="id_kategorii" Visible="False" />
            <asp:BoundField DataField="nazwa" HeaderText="nazwa" SortExpression="nazwa" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TestyOnlineConnectionString %>" SelectCommand="SELECT [id_kategorii], [nazwa] FROM [KATEGORIE]"></asp:SqlDataSource>
</asp:Content>
