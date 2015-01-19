<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="UnitOfWork.Sales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset>
        <legend>
            Kitabı Panoya Ekle
        </legend>
        Enterprise Arc.&nbsp;&nbsp;&nbsp;
        Fiyatı : <asp:Label ID="fiyat" runat="server" /><br />
        Tipi : <asp:Label ID="tip" runat="server" /> <br />
        <asp:Button ID="btnEkle" runat="server" BorderStyle="None" OnClick="btnEkle_Click" Text="Panoya Ekle" />
        <asp:Button ID="Button1" runat="server" BorderStyle="None" OnClick="btnEkle_Click" Text="Kaydı İptal Et" />
    </fieldset>
    </div>
    </form>
</body>
</html>
