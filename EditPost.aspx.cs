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
    protected string LastPageThread;


    protected void Page_Load(object sender, EventArgs e)
    {
        LastPageThread = Convert.ToString(Session["LastPageThread"]);

        CatId = Convert.ToString(Session["CatId"]);
        CatName = Convert.ToString(Session["CatName"]);
        QsId = Convert.ToString(Session["ThreadId"]);


        //PostCounter();

        PostId = Request.QueryString["Id"];

        PostsRpt.DataSource = DataBaseQueries.GetThreadContent(QsId);
        PostsRpt.DataBind();

        TitleRpt.DataSource = DataBaseQueries.GetThreadTitle(QsId);
        TitleRpt.DataBind();

        TitleRpt2.DataSource = DataBaseQueries.GetThreadTitle(QsId);
        TitleRpt2.DataBind();

        if (!IsPostBack)
        {
            EditPostTextAreaRpt.DataSource = DataBaseQueries.GetPostContent(PostId);
            EditPostTextAreaRpt.DataBind();
        }

    }
    protected void DiscardBtn_Click(object sender, EventArgs e)
    {

        Response.Redirect(LastPageThread);
    }
    protected void SubmitPostBtn_Click(object sender, EventArgs e)
    {
        //Makes it possible to read values from textboxes inside a repeater. Also calls Update method
        foreach (RepeaterItem item in EditPostTextAreaRpt.Items)
        {
            //Creates empty string varibles
            //Post Content
            string EditedPost;

            //Fetches value from the textbox "SubmitPostTA", and puts it inside a TEXTBOX VARIBLE called "SubmitPostTA"
            TextBox SubmitPostTA = (TextBox)item.FindControl("SubmitPostTA");
            EditedPost = SubmitPostTA.Text;

            DataBaseQueries.UpdatePostContent(PostId, EditedPost);
            Response.Redirect(LastPageThread);

        }
    }
}