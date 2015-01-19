<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageController.aspx.cs" Inherits="PageController.Customer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Handler' dan gelen ( handler da bir page controller' dır)&nbsp;&nbsp;
        <asp:Label ID="lblSayfaYuklenmeSuresi" runat="server" Text="Süre" BackColor="#66CCFF"></asp:Label><br />
        template view'den gelen&nbsp;&nbsp;
        <asp:Label ID="lblKullaniciAdi" runat="server" Text="Ad" BackColor="#99FFCC"></asp:Label><br />
        code behind' dan gelen (code behind da bir page controller' dır)&nbsp;&nbsp;
        <asp:Label ID="lblCodeBehind" runat="server" Text="Label" BackColor="Aqua"></asp:Label>
    </div>
    </form>
</body>
</html>
