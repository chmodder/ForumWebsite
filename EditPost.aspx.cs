using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditPost : System.Web.UI.Page
{
    public string QsId;

    public string CatId;
    public string CatName;
    public string ThreadId;
    public string PostId;


    protected void Page_Load(object sender, EventArgs e)
    {
        CatId = Convert.ToString(Session["CatId"]);
        CatName = Convert.ToString(Session["CatName"]);
        QsId = Convert.ToString(Session["ThreadId"]);
        

        //Hvis bruger er logget ind skal ShpwEditor-knappen fjernes, og editoren skal vises.

        //PostCounter();

        PostId = Request.QueryString["Id"];

        PostsRpt.DataSource = DataBaseQueries.GetThreadContent(QsId);
        PostsRpt.DataBind();

        TitleRpt.DataSource = DataBaseQueries.GetThreadTitle(QsId);
        TitleRpt.DataBind();

        TitleRpt2.DataSource = DataBaseQueries.GetThreadTitle(QsId);
        TitleRpt2.DataBind();
    }
}