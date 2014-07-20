using System;
using System.Collections;
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

    #region Create
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


    public static string CreateNewUser(string UserName, string PassWord, string Email, int RoleId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "CreateNewUserSP";

        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName;
        cmd.Parameters.Add("@PassWord", SqlDbType.NVarChar).Value = PassWord;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;

        cmd.Connection = conn;

        conn.Open();

        string UserId = Convert.ToString(cmd.ExecuteScalar());

        conn.Close();

        return UserId;
    }
    #endregion

    #region Read
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
                cmd.Parameters.Add("@QsId", SqlDbType.Int).Value = Convert.ToInt32(QsId);
                cmd.CommandText = "GetCategoryTitleSP";
                break;
            case "Thread":
                cmd.Parameters.Add("@QsId", SqlDbType.Int).Value = Convert.ToInt32(QsId);
                cmd.CommandText = "GetThreadTitleSP";
                break;
            //case "Post": DataBaseQueries.GetModelTitle(QsId);
            //    break;
            case "User":
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt32(QsId);
                cmd.CommandText = "GetAllUserInfoSP";
                break;
        }


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

    public static object GetUserInfo(int UserId)
    {


        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetAllUserInfoSP";

        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt32(UserId);

        cmd.Connection = conn;

        conn.Open();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        return dt;
    }

    //Virker, men kan ikke bruges til DropDownList endnu pga. blandet datatyper
    public static ArrayList GetRoles()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetRolesSP";

        //cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = Convert.ToInt32(UserId);

        cmd.Connection = conn;

        ArrayList Roles = new ArrayList();

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        foreach (var item in reader)
        {
            Roles.Add((int)reader["Id"]);
            Roles.Add((string)reader["RoleName"]);
            Roles.Add((string)reader["Description"]);
        }
        
        conn.Close();
        return Roles;
    }


    public static int GetRoleIdByUserId(int UserId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

        cmd.CommandText = "GetRoleIdByUserIdSP";

        cmd.Connection = conn;

        conn.Open();

        int RoleId = Convert.ToInt32(cmd.ExecuteScalar());

        conn.Close();

        return RoleId;
    }

    public static object GetUserListInfo()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetUserListInfoSP";


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

    public static bool AuthenticateUserCredentials(string UserName, string PassWord)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "AuthenticateUserCredentialsSP";

        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName;
        cmd.Parameters.Add("@PassWord", SqlDbType.NVarChar).Value = PassWord;

        cmd.Connection = conn;

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            HttpContext.Current.Session["UserId"] = reader["UserId"];
            HttpContext.Current.Session["UserRole"] = reader["UserRole"];
            HttpContext.Current.Session["RoleId"] = reader["RoleId"];
            conn.Close();
            return true;

        }

        else
        {
            return false;
        }

    }


    //public static ArrayList GetAllPrivileges()
    //{
    //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    //    SqlCommand cmd = new SqlCommand();

    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandText = "GetAllPrivilegesSP";


    //    cmd.Connection = conn;

    //    conn.Open();

    //    ArrayList PrivilegesList = new ArrayList();

    //    SqlDataReader reader = cmd.ExecuteReader();

    //    foreach (var Privilege in reader)
    //    {
    //        PrivilegesList.Add(reader["Id"]);
    //        PrivilegesList.Add(reader["Privilege"]);
    //    }

    //    conn.Close();
    //    return PrivilegesList;
    //}

    public static DataTable GetAllPrivileges()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetAllPrivilegesSP";


        cmd.Connection = conn;

        conn.Open();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        return dt;
    }

     internal static object Privileges(object RoleId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetCurrentUserPrivilegesSP";

        cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = Convert.ToInt32(RoleId);

        cmd.Connection = conn;

        conn.Open();

        ArrayList PrivilegesList = new ArrayList();

        SqlDataReader reader = cmd.ExecuteReader();

        foreach (var Privilege in reader)
        {
            PrivilegesList.Add(reader["CodeName"]);
        }

        conn.Close();
        return PrivilegesList;
    }


    internal static bool IsPostMine(int UserId, object PostId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = Convert.ToInt32(PostId);
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = Convert.ToInt32(UserId);

        cmd.CommandText = "IsPostMineSP";

        cmd.Connection = conn;

        conn.Open();

        int PostFound = Convert.ToInt32(cmd.ExecuteScalar());

        conn.Close();

        return PostFound==1?true:false;
    }
    #endregion

    #region Update
    //__________________________________Update_________________________________________//

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


    public static void UpdateEditedUserDataInDB(int UserId, string UserName, string Email, string Password, int UserRole)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.CommandText = "UpdateUserInfoSP";

        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = UserId;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = UserName;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password;
        cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = UserRole;

        cmd.Connection = conn;

        conn.Open();

        cmd.ExecuteNonQuery();

        conn.Close();
    }
    #endregion

    #region Delete
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
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DeleteUserSP";

        cmd.Parameters.Add("@QsId", SqlDbType.Int).Value = Convert.ToInt32(QsId);

        cmd.Connection = conn;

        conn.Open();

        cmd.ExecuteNonQuery();

        conn.Close();
    }
    #endregion






    public static ArrayList GetSelectedItemsForThisRole(string RoleId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetPrivilegesWithInfoByRoleIdSP";

        cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = Convert.ToInt32(RoleId);

        cmd.Connection = conn;

        conn.Open();

        ArrayList PrivilegesList = new ArrayList();

        SqlDataReader reader = cmd.ExecuteReader();

        foreach (var Privilege in reader)
        {
            PrivilegesList.Add(reader["Id"]);
        }

        conn.Close();
        return PrivilegesList;
    }

}