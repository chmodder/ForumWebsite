using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyPage : System.Web.UI.Page
{
    protected int UserId;

    protected void Page_Load(object sender, EventArgs e)
    {

        Session["LastPage"] = Request.Url.PathAndQuery;

        UserId = Convert.ToInt32(Session["UserId"]);

        //temp until login works
        if (UserId <= 0)
        {
            UserId = 3;
        }
        //____//

        MyInfoRpt.DataSource = DataBaseQueries.GetUserInfo(UserId);
        MyInfoRpt.DataBind();

    }

    protected void EditUserBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditUser.aspx?Id=" + UserId);
    }

    protected void DeleteUserBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("DeleteScript.aspx?Model=User&Id=" + UserId);
    }
}