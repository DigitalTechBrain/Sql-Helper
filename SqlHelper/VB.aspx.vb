Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Partial Class VB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.BindDataSet()
            Me.BindReader()
        End If
    End Sub

    Private Sub BindDataSet()
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim query As String = "SELECT CustomerId, Name, Country FROM Customers"
        Dim ds As DataSet = SqlHelper.ExecuteDataset(constr, CommandType.Text, query)
        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()
    End Sub

    Private Sub BindReader()
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim query As String = "SELECT CustomerId, Name, Country FROM Customers"
        Dim sdr As SqlDataReader = SqlHelper.ExecuteReader(constr, CommandType.Text, query)
        GridView2.DataSource = sdr
        GridView2.DataBind()
    End Sub

    Protected Sub ExecuteNonQuery(sender As Object, e As EventArgs)
        Dim name As String = txtName1.Text
        Dim country As String = txtCountry1.Text
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim query As String = "INSERT INTO Customers (Name, Country) VALUES (@Name, @Country)"
        Dim parameters As New List(Of SqlParameter)()
        parameters.Add(New SqlParameter("@Name", name))
        parameters.Add(New SqlParameter("@Country", country))
        Dim rowsAffected As Integer = SqlHelper.ExecuteNonQuery(constr, CommandType.Text, query, parameters.ToArray())
        Me.BindDataSet()
        Me.BindReader()
    End Sub

    Protected Sub ExecuteScalar(sender As Object, e As EventArgs)
        Dim name As String = txtName2.Text
        Dim country As String = txtCountry2.Text
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim query As String = "INSERT INTO Customers (Name, Country) VALUES (@Name, @Country);SELECT SCOPE_IDENTITY();"
        Dim parameters As New List(Of SqlParameter)()
        parameters.Add(New SqlParameter("@Name", name))
        parameters.Add(New SqlParameter("@Country", country))
        Dim customerId As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(constr, CommandType.Text, query, parameters.ToArray()))
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "alert('Inserted CustomerId: " & customerId & "');", True)
        Me.BindDataSet()
        Me.BindReader()
    End Sub

End Class



