using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

public partial class CS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindDataSet();
            this.BindReader();
        }
    }

private void BindDataSet()
{
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    string query = "SELECT CustomerId, Name, Country FROM Customers";
    DataSet ds = SqlHelper.ExecuteDataset(constr, CommandType.Text, query);
    GridView1.DataSource = ds.Tables[0];
    GridView1.DataBind();
}

private void BindReader()
{
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    string query = "SELECT CustomerId, Name, Country FROM Customers";
    SqlDataReader sdr = SqlHelper.ExecuteReader(constr, CommandType.Text, query);
    GridView2.DataSource = sdr;
    GridView2.DataBind();
}

protected void ExecuteNonQuery(object sender, EventArgs e)
{
    string name = txtName1.Text;
    string country = txtCountry1.Text;
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    string query = "INSERT INTO Customers (Name, Country) VALUES (@Name, @Country)";
    List<SqlParameter> parameters = new List<SqlParameter>();
    parameters.Add(new SqlParameter("@Name", name));
    parameters.Add(new SqlParameter("@Country", country));
    int rowsAffected = SqlHelper.ExecuteNonQuery(constr, CommandType.Text, query, parameters.ToArray());
    this.BindDataSet();
    this.BindReader();
}

protected void ExecuteScalar(object sender, EventArgs e)
{
    string name = txtName2.Text;
    string country = txtCountry2.Text;
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    string query = "INSERT INTO Customers (Name, Country) VALUES (@Name, @Country);SELECT SCOPE_IDENTITY();";
    List<SqlParameter> parameters = new List<SqlParameter>();
    parameters.Add(new SqlParameter("@Name", name));
    parameters.Add(new SqlParameter("@Country", country));
    int customerId = Convert.ToInt32(SqlHelper.ExecuteScalar(constr, CommandType.Text, query, parameters.ToArray()));
    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Inserted CustomerId: " + customerId + "');", true);
    this.BindDataSet(); 
    this.BindReader();
}
}