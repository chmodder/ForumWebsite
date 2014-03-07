using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateThread : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    
    protected void Discard_Click(object sender, EventArgs e)
    {
        string CatId = Request.QueryString["CatId"];
        Response.Redirect("Category.aspx?Id=" + CatId);
    }
    
    protected void CreateThreadBtn_Click(object sender, EventArgs e)
    {
        string CatId = Request.QueryString["CatId"];
        int UserId = Convert.ToInt32(Session["UserId"]);
        string ThreadTitle = CreateThreadTitleTxt.Text;
        string ThreadContent = CreateThreadContentTxt.Text;

        string ThreadId = DataBaseQueries.CreateThread(UserId, CatId, ThreadTitle, ThreadContent);
        CreateThreadTitleTxt.Text = "";
        CreateThreadContentTxt.Text = "";
        Response.Redirect("Thread.aspx?Id=" + ThreadId);
    }
}