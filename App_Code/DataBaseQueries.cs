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

    public static void CreateCategory(string CatName, string CatDesc)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "CreateCategorySP";

        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = CatName;
        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = CatDesc;

        cmd.Connection = conn;

        conn.Open();

        cmd.ExecuteNonQuery();

        conn.Close();
    }

    public static void DeleteCategory(string QsId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DeleteCategorySP";

        cmd.Parameters.Add("@QsId", SqlDbType.Int).Value = Convert.ToInt32(QsId);

        cmd.Connection = conn;

        conn.Open();

        cmd.ExecuteNonQuery();

        conn.Close();
    }

    public static void DeleteThread(string QsId)
    {
        throw new NotImplementedException();
    }

    public static void DeletePost(string QsId)
    {
        throw new NotImplementedException();
    }

    public static void DeleteUser(string QsId)
    {
        throw new NotImplementedException();
    }

}