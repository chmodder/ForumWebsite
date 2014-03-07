using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Category : System.Web.UI.Page
{
    public string QsId;

    protected void Page_Load(object sender, EventArgs e)
    {
        QsId = Request.QueryString["Id"];
        ThreadRpt.DataSource = DataBaseQueries.GetThreadInfoData(QsId);
        ThreadRpt.DataBind();
    }
}