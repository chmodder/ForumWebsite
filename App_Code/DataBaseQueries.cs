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


    //__________________________________EDIT_________________________________________//

    //Returns data from the model that needs to be edited.
    public static DataTable GetEditDataFromDb(string QsModel, string QsId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;


        switch (QsModel)
        {

            case "Category":
                cmd.CommandText = "GetCategoryTableDataSP";
                break;
            case "Thread":
                cmd.CommandText = "GetThreadAndFirstPostSP";
                break;
            //case "Post":
            //    cmd.CommandText = "GetPostEditDataSP";
            //    break;
            //case "User":
            //    cmd.CommandText = "GetUserEditDataSP";
            //    break;

        }

        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt32(QsId);

        cmd.Connection = conn;

        conn.Open();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        return dt;
    }

    //Updates table with new data (Category, Thread)
    public static DataTable UpdateEditDataInBD(string QsModel, string QsId, string Param1, string Param2)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;

        switch (QsModel)
        {

            case "Category":
                cmd.CommandText = "UpdateCategoryTableDataSP";
                cmd.Parameters.Add("@CatName", SqlDbType.NVarChar).Value = Param1;
                cmd.Parameters.Add("@CatDesc", SqlDbType.NVarChar).Value = Param2;
                break;
            case "Thread":
                cmd.CommandText = "UpdateThreadTableDataSP";
                cmd.Parameters.Add("@ThreadTitle", SqlDbType.NVarChar).Value = Param1;
                cmd.Parameters.Add("@ThreadContent", SqlDbType.NText).Value = Param2;
                break;
            //case "Post":
            //    cmd.CommandText = "GetPostEditDataSP";
            //    break;
            //case "User":
            //    cmd.CommandText = "GetUserEditDataSP";
            //    break;

        }

        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt32(QsId);

        cmd.Connection = conn;

        conn.Open();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        return dt;
    }

    public static void UpdatePostContent(string PostId, string EditedPost)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.CommandText = "UpdatePostContentSP";

        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt32(PostId);
        cmd.Parameters.Add("@Content", SqlDbType.NText).Value = EditedPost;

        cmd.Connection = conn;

        conn.Open();

        cmd.ExecuteNonQuery();

        conn.Close();
    }

    //____________________________READ________________________________________//


    //Returns data for Frontpage/Categorylist with info about number of threads and posts for each category
    public static DataTable GetCategoriesInfoForCategoryList()
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

    public static object GetModelTitle(String QsModel, string QsId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;

        switch (QsModel)
        {

            case "Category":
                cmd.CommandText = "GetCategoryTitleSP";
                break;
            case "Thread":
                cmd.CommandText = "GetThreadTitleSP";
                break;
            //case "Post": DataBaseQueries.GetModelTitle(QsId);
            //    break;
            //case "User": DataBaseQueries.GetModelTitle(QsId);
            //    break;
        }

        cmd.Parameters.Add("@QsId", SqlDbType.Int).Value = Convert.ToInt32(QsId);

        cmd.Connection = conn;

        conn.Open();

        object ModelFromDb = cmd.ExecuteScalar();

        conn.Close();


        return ModelFromDb;
    }


    public static object GetThreadInfoData(string QsId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetThreadInfoSP";

        cmd.Parameters.Add("@CatId", SqlDbType.Int).Value = Convert.ToInt32(QsId);

        cmd.Connection = conn;

        conn.Open();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        return dt;
    }

    public static object GetThreadContent(string QsId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetThreadContentSP";

        cmd.Parameters.Add("@QsId", SqlDbType.Int).Value = Convert.ToInt32(QsId);

        cmd.Connection = conn;

        conn.Open();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        return dt;
    }


    public static object GetPostContent(string PostId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetPostContentSP";

        cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = Convert.ToInt32(PostId);

        cmd.Connection = conn;

        conn.Open();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        return dt;
    }


    public static object GetThreadTitle(string QsId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetThreadTitleSP";

        cmd.Parameters.Add("@QsId", SqlDbType.Int).Value = Convert.ToInt32(QsId);

        cmd.Connection = conn;

        conn.Open();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        return dt;
    }

    //____________________________CREATE________________________________________//

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

    public static string CreateThread(int UserId, string CatId, string ThreadTitle, string ThreadContent)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "CreateThreadSP";

        cmd.Parameters.Add("@CatId", SqlDbType.Int).Value = Convert.ToInt32(CatId);
        cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ThreadTitle;
        cmd.Parameters.Add("@Content", SqlDbType.NText).Value = ThreadContent;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

        cmd.Connection = conn;

        conn.Open();

        string ThreadId = Convert.ToString(cmd.ExecuteScalar());

        conn.Close();

        return ThreadId;
    }

    public static void CreateNewPost(int UserId, string QsId, string NewPost)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "CreateNewPostSP";

        cmd.Parameters.Add("@Content", SqlDbType.NText).Value = NewPost;
        cmd.Parameters.Add("@ThreadId", SqlDbType.Int).Value = QsId;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

        cmd.Connection = conn;

        conn.Open();

        cmd.ExecuteNonQuery();

        conn.Close();
    }

    //____________________________DELETE________________________________________//

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

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DeleteThreadSP";

        cmd.Parameters.Add("@QsId", SqlDbType.Int).Value = Convert.ToInt32(QsId);

        cmd.Connection = conn;

        conn.Open();

        cmd.ExecuteNonQuery();

        conn.Close();
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