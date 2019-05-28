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

namespace SqlHelperTesting
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = "Jack";
            string country = "India";
            string constr = ConfigurationManager.ConnectionStrings["DfltConnection"].ConnectionString;
            string query = "INSERT INTO testingCustomers (cName, CAddress) VALUES (@Name, @Country)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Name", name));
            parameters.Add(new SqlParameter("@Country", country));
            int rowsAffected = SqlHelper.ExecuteNonQuery(constr, CommandType.Text, query, parameters.ToArray());
        }

       
            protected void ExecuteScalar(object sender, EventArgs e)
            {
                string name = "";
                string country = "";
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                string query = "INSERT INTO Customers (Name, Country) VALUES (@Name, @Country);SELECT SCOPE_IDENTITY();";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Name", name));
                parameters.Add(new SqlParameter("@Country", country));
                int customerId = Convert.ToInt32(SqlHelper.ExecuteScalar(constr, CommandType.Text, query, parameters.ToArray()));
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Inserted CustomerId: " + customerId + "');", true);
            }
      

        private void BindReader()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string query = "SELECT CustomerId, Name, Country FROM Customers";
            SqlDataReader sdr = SqlHelper.ExecuteReader(constr, CommandType.Text, query);
            GridView1.DataSource = sdr;
            GridView1.DataBind();
        }
    }
}