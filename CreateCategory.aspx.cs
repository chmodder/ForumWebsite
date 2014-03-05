using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Discard_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void CreateCategoriesBtn_Click(object sender, EventArgs e)
    {
        DataBaseQueries.CreateCategory(CreateCategoryNameTxt.Text, CreateCategoryDescriptionTxt.Text);
        CreateCategoryNameTxt.Text = "";
        CreateCategoryDescriptionTxt.Text = "";
        Response.Redirect("Default.aspx");

    }
}