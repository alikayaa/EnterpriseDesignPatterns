<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmbeddedValue.Default" %>

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
                İlanlar
            </legend>
            <b>İlan Adı : </b> <asp:Label ID="ilanAd" runat="server"></asp:Label><br />
            <b>İlan Tarihi : </b> <asp:Label ID="tarih" runat="server"></asp:Label><br />
            <b>İlan Fiyat : </b> <asp:Label ID="fiyat" runat="server"></asp:Label>
        </fieldset>
    </div>
    </form>
</body>
</html>
