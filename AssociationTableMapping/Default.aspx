<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AssociationTableMapping.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      Müşteri Adı : <asp:Label ID="musteri" runat="server" />
        <br />
       <fieldset>

           <legend>
               Aldığı Ürünler
           </legend>
           <asp:ListBox ID="urunler" runat="server" Width="386px" Border="0"/>
       </fieldset>
    </div>
    </form>
</body>
</html>
