<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="Optimistic.CustomerList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="DeleteConflictMessage" runat="server" Visible="False" ForeColor="Red"
        EnableViewState="False" CssClass="Warning"
        Text="Silmeye çalıştığınız kayıt başkası tarafından değiştirildi. Sayfayı yenileyip işleminizi tekrarlayınız." />
    </div>
    <div>
        <asp:Label ID="UpdateConflictMessage" runat="server" Visible="False" ForeColor="Red"
        EnableViewState="False" CssClass="Warning"
        Text="Güncellemeye çalıştığınız kayıt başkası tarafından değiştirildi. Sayfayı yenileyip işleminizi tekrarlayınız." />
    </div>

    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="CustomerID" 
            DataSourceID="ObjectDataSource1" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating"
             OnRowDeleted="GridView1_RowDeleted" OnRowUpdated="GridView1_RowUpdated" >
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" InsertVisible="False" ReadOnly="True" 
                    SortExpression="CustomerID" />
                <asp:TemplateField HeaderText="Customer Name" SortExpression="CustomerName">
                    <EditItemTemplate>
                        <asp:TextBox ID="EditCustomerName" runat="server"
                            Text='<%# Bind("CustomerName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            ControlToValidate="EditCustomerName"
                            ErrorMessage="Müşteri adını girmelisiniz!!"
                            runat="server">*</asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCustomerName" runat="server"
                            Text='<%# Bind("CustomerName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Customer Surname" SortExpression="CustomerSurname">
                    <EditItemTemplate>
                        <asp:TextBox ID="EditCustomerSurname" runat="server"
                            Text='<%# Bind("CustomerSurname") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            ControlToValidate="EditCustomerSurname"
                            ErrorMessage="Müşteri soyadını girmelisiniz!!"
                            runat="server">*</asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCustomerSurname" runat="server"
                            Text='<%# Bind("CustomerSurname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>



    </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteCustomer" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetCustomers" TypeName="Optimistic.BLL" UpdateMethod="UpdateCustomer" OnDeleted="ObjectDataSource1_Deleted">
            <DeleteParameters>
                <asp:Parameter Name="original_customerID" Type="Int32" />
                <asp:Parameter Name="original_customerName" Type="String" />
                <asp:Parameter Name="original_customerSurname" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="customerName" Type="String" />
                <asp:Parameter Name="customerSurname" Type="String" />
                <asp:Parameter Name="original_customerName" Type="String" />
                <asp:Parameter Name="original_customerSurname" Type="String" />
                <asp:Parameter Name="original_customerID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
