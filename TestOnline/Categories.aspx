<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="TestOnline.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Kategorie - tesciki.pl</title>
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="category_panel">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="category">
                        <div class="label">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("nazwa") %>'></asp:Label>
                        </div>
                        <div class="download"><a href="link?<%# Eval("id_kategorii") %>"><img src="img/load.png" /></a></div>
                        <div class="content">
                            <%# Eval("opis") %>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            
    </div>
</asp:Content>