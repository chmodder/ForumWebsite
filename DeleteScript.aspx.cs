using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteScript : System.Web.UI.Page
{
    //QsModel og Model er den type der skal slettes. Fx. Kategori, tråd eller post

    protected string QsModel;
    protected string QsId;
    public string CatId;

    //Variablen der kaldes ved bekræftelse af sletning
    public string ModelTitleText;

    protected void Page_Load(object sender, EventArgs e)
    {

        CatId = Convert.ToString(Session["CatId"]);
        QsModel = Request.QueryString["Model"];
        QsId = Request.QueryString["Id"];

        //Her defineres variablen der kaldes ved bekræftelse af sletning. Den indeholder Navnet på det der slettes
        ModelTitleText = Convert.ToString(DataBaseQueries.GetModelTitle(QsModel, QsId));

    }

    protected void Discard_Click(object sender, EventArgs e)
    {
        Session["CatId"] = null;

        switch (QsModel)
        {
            default: Response.Redirect("Default.aspx");
                break;
            case "Category": Response.Redirect("Default.aspx");
                break;
            case "Thread": Response.Redirect("Category.aspx?Id=" + CatId);
                break;
            case "User": Response.Redirect("MyPage.aspx");
                break;

        }

    }

    protected void ContinueDeletetion_Click(object sender, EventArgs e)
    {


        switch (QsModel)
        {
            //case "Category": Response.Write(QsId);
            //    break;
            case "Category": DataBaseQueries.DeleteCategory(QsId);
                break;
            case "Thread": DataBaseQueries.DeleteThread(QsId);
                break;
            //case "Post": DataBaseQueries.DeletePost(QsId);
            //    break;
            case "User": DataBaseQueries.DeleteUser(QsId);
                break;

        }


        switch (QsModel)
        {
            case "Category": Response.Redirect("Default.aspx");
                break;
            case "Thread": Response.Redirect("Category.aspx?Id=" + CatId);
                break;
            //Not sure if allowing Post-deletion in a forum is a good idea.
            //Need to find a way to paste "Post deleted" and disabling deletion of first post in thread if it should be allowed
            //case "Post": Response.Redirect("Thread.aspx?Id=" + ThreadId);
            //    break;


                ///VIRKER IKKE ENDNU
            case "User": if ((string)Session["UserId"] == QsId)
                {
                    Response.Redirect("logOut.aspx");
                }
                else
                {
                    Response.Redirect("UserList.aspx");
                }
                break;
        }
    }

}