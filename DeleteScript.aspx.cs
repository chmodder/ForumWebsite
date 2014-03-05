using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteScript : System.Web.UI.Page
{
    protected string QsModel;
    protected string QsId;

    //Variablen der kaldes ved bekræftelse af sletning
    public string ModelTitleText;

    protected void Page_Load(object sender, EventArgs e)
    {
        QsModel = Request.QueryString["Model"];
        QsId = Request.QueryString["Id"];

        //Her defineres variablen der kaldes ved bekræftelse af sletning. Den indeholder Navnet på det der slettes
        ModelTitleText = Convert.ToString(DataBaseQueries.GetModelTitle(QsModel, QsId));
        
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
            //case "User": DataBaseQueries.DeleteUser(QsId);
            //    break;

        }


        switch (QsModel)
        {
            case "Category": Response.Redirect("Default.aspx");
                break;
            //case "Thread": DataBaseQueries.DeleteThread(QsId);
            //    break;
            //case "Post": DataBaseQueries.DeletePost(QsId);
            //    break;
            //case "User": DataBaseQueries.DeleteUser(QsId);
            //    break;
        }
    }
}