using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Category : System.Web.UI.Page
{
    public string QsId;
    public string QsModel;
    public string CatName;

    protected void Page_Load(object sender, EventArgs e)
    {

        CreateThreadLink.Visible = Per.Allowed("CreateThread");

        Session["LastPage"] = Request.Url.PathAndQuery;

        QsModel = "Category";

        QsId = Request.QueryString["Id"];
        Session["CatId"] = QsId;

        CatName = Convert.ToString(DataBaseQueries.GetModelTitle(QsModel, QsId));

        Session["CatName"] = CatName;
        Session["CatId"] = QsId;

        

        ThreadRpt.DataSource = DataBaseQueries.GetThreadInfoData(QsId);
        ThreadRpt.DataBind();
    }
    protected void CreateThreadLink_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateThread.aspx?CatId=" + QsId);
    }
}