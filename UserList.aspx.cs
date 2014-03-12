using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Per.Allowed("ShowUserList"))
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Session["LastPage"] = Request.Url.PathAndQuery;

            if (!IsPostBack)
            {
                UserListRpt.DataSource = DataBaseQueries.GetUserListInfo();
                UserListRpt.DataBind();
            }
        }


    }
}