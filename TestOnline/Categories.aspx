<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="TestOnline.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Kategorie - tesciki.pl</title>
    <link rel="stylesheet" href="css/categories.css" />
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="categoryPanel">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate runat="server">
                    <div class="category">
                        <asp:Button ID="Button1" class="button" runat="server" OnClick="LoadCategory_Click" CommandArgument='<%# Eval("id_kategorii") %>' Text='<%# Eval("nazwa") %>'/>
                        <div class="content">
                            <%# Eval("opis") %>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
</asp:Content>