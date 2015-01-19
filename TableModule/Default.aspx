<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TableModule.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        C# ile Tasarım Kalıpları&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Satın Al" OnClick="Button1_Click" />
        <br />
        <br />
        Toplam Satış
        <asp:Label ID="totalAmount" runat="server">0</asp:Label>
    </div>
    </form>
</body>
</html>
