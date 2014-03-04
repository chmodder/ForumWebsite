using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        CategoriesRpt.DataSource = DataBaseQueries.GetCategoriesInfoData();
        CategoriesRpt.DataBind();

        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        //SqlCommand cmd = new SqlCommand();

        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.CommandText = "GetCategoriesInfo";

        //cmd.Connection = conn;

        //conn.Open();

        //SqlDataReader reader = cmd.ExecuteReader();

        //CategoriesRpt.DataSource = reader;
        //CategoriesRpt.DataBind();

        //conn.Close();

    }

}