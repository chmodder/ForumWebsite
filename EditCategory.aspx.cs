using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edit : System.Web.UI.Page
{
    //QsModel og Model er den type der skal slettes. Fx. Kategori, tråd eller post

    protected string QsModel;
    protected string QsId;

    protected void Page_Load(object sender, EventArgs e)
    {
        QsModel = Request.QueryString["Model"];
        QsId = Request.QueryString["Id"];

        if (!IsPostBack)
        {
            InsertCategoryToTextBoxes();
        }

    }

    private void InsertCategoryToTextBoxes()
    {
        EditCategoryRpt.DataSource = DataBaseQueries.GetEditDataFromDb(QsModel, QsId);
        EditCategoryRpt.DataBind();
    }

    protected void Discard_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void EditCategoriesBtn_Click(object sender, EventArgs e)
    {

        //Makes it possible to read values from textboxes inside a repeater. Also calls Update method
        foreach (RepeaterItem item in EditCategoryRpt.Items)
        {
            //Creates empty string varibles
            string CatName;
            string CatDesc;

            //Fetches value from the textbox "EditCategoryNameTxt", and puts it inside a TEXTBOX VARIBLE called "EditCategoryNameTxt"
            TextBox EditCategoryNameTxt = (TextBox)item.FindControl("EditCategoryNameTxt");
            //Fetches value from the TEXTBOX VARIBLE "EditCategoryNameTxt", and puts it inside the empty STRING VARIABLE called "CatName"
            CatName = EditCategoryNameTxt.Text;

            //Same principle as above
            TextBox EditCategoryDescriptionTxt = (TextBox)item.FindControl("EditCategoryDescriptionTxt");
            CatDesc = EditCategoryDescriptionTxt.Text;

            //Calls Update method, which updates the table in the DB
            DataBaseQueries.UpdateEditDataInBD(QsModel, QsId, CatName, CatDesc);
        }

        Response.Redirect("Default.aspx");

    }
}