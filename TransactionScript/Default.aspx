<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TransactionScript.Default" %>

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
            Maaş Hesaplama
        </legend>
        <br />
        Toplam Çalışan Sayısı :&nbsp;
        <asp:Label ID="calisanSayisi" runat="server"></asp:Label>
        <br />
        <br />
        Toplam Ödenen Maaş :&nbsp;
        <asp:Label ID="maas" runat="server"></asp:Label>
    </fieldset>
    </div>
    </form>
</body>
</html>
