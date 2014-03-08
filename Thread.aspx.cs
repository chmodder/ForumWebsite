using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Thread : System.Web.UI.Page
{
    public string QsId;
    public string CatId;
    public string CatName;


    protected void Page_Load(object sender, EventArgs e)
    {
        CatId = Convert.ToString(Session["CatId"]) ;
        CatName = Convert.ToString(Session["CatName"]);

        //Hvis bruger er logget ind skal ShpwEditor-knappen fjernes, og editoren skal vises.

        //PostCounter();

        QsId = Request.QueryString["Id"];
        Session["ThreadId"] = QsId;

        PostsRpt.DataSource = DataBaseQueries.GetThreadContent(QsId);
        PostsRpt.DataBind();

        TitleRpt.DataSource = DataBaseQueries.GetThreadTitle(QsId);
        TitleRpt.DataBind();

        TitleRpt2.DataSource = DataBaseQueries.GetThreadTitle(QsId);
        TitleRpt2.DataBind();
    }

    //private void PostCounter()
    //{


    //    foreach (RepeaterItem item in PostsRpt)
    //    {

    //    }
    //}
    protected void ShowEditor_Click(object sender, EventArgs e)
    {
        //Ved Page load:
        //Tjek om bruger er logget ind.
        //Hvis ikke, så gå til Login først, og husk hvilken tråd brugeren kom fra.
        //Hvis bruger er logget ind skal ShpwEditor-knappen fjernes, og editoren skal vises.

    }
    protected void SubmitPostBtn_Click(object sender, EventArgs e)
    {
        int UserId = Convert.ToInt32(Session["UserId"]);
        string NewPost = SubmitPostTA.InnerText;
        
        DataBaseQueries.CreateNewPost(UserId, QsId, NewPost);
        SubmitPostTA.InnerText = "";
        Response.Redirect(Request.RawUrl);
    }
}