<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyData.aspx.cs" Inherits="TestOnline.MyData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Moje dane - tesciki.pl</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 150px;">
        <center>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server"></asp:ValidationSummary>
        </center>
        
        <br />
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="id_uzytkownika" DataSourceID="SqlDataSource1" Height="50px" Width="125px">
            <Fields>
                <asp:TemplateField HeaderText="email" SortExpression="email">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="imie" SortExpression="imie">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("imie") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("imie") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("imie") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
            </Fields>
        </asp:DetailsView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TestyOnlineConnectionString %>" DeleteCommand="DELETE FROM [UZYTKOWNICY] WHERE [id_uzytkownika] = @id_uzytkownika" InsertCommand="INSERT INTO [UZYTKOWNICY] ([poziom], [login], [haslo], [email], [imie], [data_rejestracji]) VALUES (@poziom, @login, @haslo, @email, @imie, @data_rejestracji)" SelectCommand="SELECT * FROM [UZYTKOWNICY] WHERE ([login] = @login)" UpdateCommand="UPDATE [UZYTKOWNICY] SET [poziom] = @poziom, [login] = @login, [haslo] = @haslo, [email] = @email, [imie] = @imie, [data_rejestracji] = @data_rejestracji WHERE [id_uzytkownika] = @id_uzytkownika">
            <DeleteParameters>
                <asp:Parameter Name="id_uzytkownika" Type="Decimal" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="poziom" Type="String" />
                <asp:Parameter Name="login" Type="String" />
                <asp:Parameter Name="haslo" Type="String" />
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="imie" Type="String" />
                <asp:Parameter Name="data_rejestracji" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:CookieParameter CookieName="userLogin" DefaultValue="0" Name="login" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="poziom" Type="String" />
                <asp:Parameter Name="login" Type="String" />
                <asp:Parameter Name="haslo" Type="String" />
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="imie" Type="String" />
                <asp:Parameter Name="data_rejestracji" Type="String" />
                <asp:Parameter Name="id_uzytkownika" Type="Decimal" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
