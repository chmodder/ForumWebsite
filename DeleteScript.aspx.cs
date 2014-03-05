using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteScript : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string QsModel = Request.QueryString["Model"];
        string QsId = Request.QueryString["Id"];

        switch (QsModel)
        {
            //case "Category": Response.Write(QsId);
            //    break;
            case "Category": DataBaseQueries.DeleteCategory(QsId);
                break;
            //case "Thread": DataBaseQueries.DeleteThread(QsId);
            //    break;
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