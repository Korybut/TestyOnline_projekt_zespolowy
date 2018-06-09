<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExchangePassword.aspx.cs" Inherits="TestOnline.ExchangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 150px;">
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" DataKeyNames="id_uzytkownika" DataSourceID="SqlDataSource1" OnItemUpdated="DetailsView1_ItemUpdated">
            <Fields>
                <asp:TemplateField HeaderText="hasło" SortExpression="haslo">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text=""></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1a" runat="server" Text='<%# Bind("haslo") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text="********"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="powtórz hasło">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text="********"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
            </Fields>
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TestyOnlineConnectionString %>" DeleteCommand="DELETE FROM [UZYTKOWNICY] WHERE [id_uzytkownika] = @id_uzytkownika" InsertCommand="INSERT INTO [UZYTKOWNICY] ([haslo]) VALUES (@haslo)" SelectCommand="SELECT [haslo], [id_uzytkownika] FROM [UZYTKOWNICY] WHERE ([login] = @login)" UpdateCommand="UPDATE [UZYTKOWNICY] SET [haslo] = @haslo WHERE [id_uzytkownika] = @id_uzytkownika">
            <DeleteParameters>
                <asp:Parameter Name="id_uzytkownika" Type="Decimal" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="haslo" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:CookieParameter CookieName="userLogin" DefaultValue="0" Name="login" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="haslo" Type="String" />
                <asp:Parameter Name="id_uzytkownika" Type="Decimal" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
    </div>
</asp:Content>
