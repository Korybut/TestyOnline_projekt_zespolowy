<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="TestOnline.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Kategorie - tesciki.pl</title>
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="category_panel">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <div class="category">
                        <asp:Button ID="Button" class="button" runat="server" CommandName="LoadCategory" CommandArgument='<%# Eval("id_kategorii") %>' Text='<%# Eval("nazwa") %>'/>
                        <div class="content">
                            <%# Eval("opis") %>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
    </div>
</asp:Content>