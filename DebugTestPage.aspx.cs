using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DebugTestPage : System.Web.UI.Page
{
    public string QsId;
    public string QsModel;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Til Debugging
        QsModel = "Category";
        QsId = "2";

        //QsModel = "Thread";
        //QsId = "1";

        ////Til debugging
        //Response.Write(GetEditDataFromDb(QsModel, QsId));

        DataTable NewDT = GetEditDataFromDb(QsModel, QsId);

        //Response.Write(NewDT);

        GridView1.DataSource = NewDT;
        GridView1.DataBind();
    }

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
            //case "Thread":
            //    cmd.CommandText = "GetThreadAndFirstPostSP";
            //    break;
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

    //___________________STORED PROCEDURES_____________________//

//    CREATE PROCEDURE [dbo].[GetCategoryTableDataSP]
//    (
//    @Id int
//    )
//AS

//BEGIN

//SELECT * FROM Category WHERE Category.Id = @Id

//END


    //_________________________________________________________//

//    CREATE PROCEDURE [dbo].[GetThreadAndFirstPostSP]
//    (
//    @Id int
//    )
//AS

//BEGIN

//SELECT TOP 1 t.Id AS ThreadId, T.Title, P.Id AS PostId, P.Content AS Content
//From Threads T
//INNER JOIN Posts P
//ON T.Id = P.FkThreadId
//WHERE T.Id = @Id
//ORDER BY P.CreationTime ASC

//END

}