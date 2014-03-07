using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Thread : System.Web.UI.Page
{
    public string QsId;

    

    protected void Page_Load(object sender, EventArgs e)
    {
        //PostCounter();

        QsId = Request.QueryString["Id"];

        PostsRpt.DataSource = DataBaseQueries.GetThreadContent(QsId);
        PostsRpt.DataBind();

        TitleRpt.DataSource = DataBaseQueries.GetThreadTitle(QsId);
        TitleRpt.DataBind();
        
    }

    //private void PostCounter()
    //{


    //    foreach (RepeaterItem item in PostsRpt)
    //    {

    //    }
    //}
}