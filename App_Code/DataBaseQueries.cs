using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataBaseQueries
/// </summary>
public class DataBaseQueries
{
	public DataBaseQueries()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataTable GetCategoriesInfoData()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetCategoriesInfo";

        cmd.Connection = conn;

        conn.Open();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        return dt;

    }
}