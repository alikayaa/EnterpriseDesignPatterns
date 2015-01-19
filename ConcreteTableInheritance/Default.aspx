<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConcreteTableInheritance.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>Kategoriler</h4>
            <ul>
                <li>
                    <a href="?Id=1">Filmler</a>
                </li>
                <li>
                    <a href="?Id=2">Elektronik</a>
                    <ul>
                        <li>
                            <a href="?Id=3">Bilgisayar</a>
                        </li>
                        <li>
                            <a href="?Id=4">Telefon</a>
                        </li>
                    </ul>
                </li>
            </ul>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div runat="server" id="dai">
            <strong>Kategori</strong> >> 
            <asp:Label runat="server" ID="adi"></asp:Label>
            <br />
            <strong>
                4G Desteği : 
            </strong>
            <asp:Label runat="server" ID="fourG"></asp:Label>
            <br />
            <strong>
                Ekran Genişliği : 
            </strong>
            <asp:Label runat="server" ID="EkranGenisligi"></asp:Label>
            <br />
            <strong>
                Açıklama : 
            </strong>
            <asp:Label runat="server" ID="Aciklama"></asp:Label>
        </div>
    </form>
</body>
</html>
