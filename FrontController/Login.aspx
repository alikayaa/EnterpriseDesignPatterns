<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FrontController.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı"></asp:Label>
        <asp:TextBox ID="txtKullaniciAdi" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="Şifre"></asp:Label>
        <asp:TextBox ID="txtSifre" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    </div>
    </form>
</body>
</html>
