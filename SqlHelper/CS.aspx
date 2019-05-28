<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CS.aspx.cs" Inherits="CS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            width: 450px;
            margin-bottom: -1px;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <u>Bind using DataSet</u><br /><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText="No records has been added.">
        <Columns>
            <asp:BoundField DataField="CustomerId" HeaderText="Id" ItemStyle-Width="80" />
            <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
            <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="150" />
        </Columns>
    </asp:GridView>
    <hr />
     <u>Bind using DataReader</u><br /><br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" EmptyDataText="No records has been added.">
        <Columns>
            <asp:BoundField DataField="CustomerId" HeaderText="Id" ItemStyle-Width="80" />
            <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
            <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="150" />
        </Columns>
    </asp:GridView>
    <hr />
     <u>Insert using ExecuteNonQuery</u><br /><br />
    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
        <tr>
            <td style="width: 150px">
                Name:<br />
                <asp:TextBox ID="txtName1" runat="server" Width="140" />
            </td>
            <td style="width: 150px">
                Country:<br />
                <asp:TextBox ID="txtCountry1" runat="server" Width="140" />
            </td>
            <td style="width: 100px">
                <asp:Button runat="server" Text="Add" OnClick="ExecuteNonQuery" />
            </td>
        </tr>
    </table>
    <hr />
      <u>Insert using ExecuteScalar</u><br /><br />
    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
        <tr>
            <td style="width: 150px">
                Name:<br />
                <asp:TextBox ID="txtName2" runat="server" Width="140" />
            </td>
            <td style="width: 150px">
                Country:<br />
                <asp:TextBox ID="txtCountry2" runat="server" Width="140" />
            </td>
            <td style="width: 100px">
                <asp:Button runat="server" Text="Add" OnClick="ExecuteScalar" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
