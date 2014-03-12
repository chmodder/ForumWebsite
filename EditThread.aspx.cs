using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditThread : System.Web.UI.Page
{
    public string QsId;
    public string QsModel;
    public string BackToCategory;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Adds value to BackToCategory variable
        BackToCategory = Convert.ToString(Session["LastPage"]);

        QsModel = Request.QueryString["Model"];
        QsId = Request.QueryString["Id"];

        ////Til debugging
        //Response.Write(DataBaseQueries.GetEditDataFromDb(QsModel, QsId));

        
        BreadCrumbRpt.DataSource = DataBaseQueries.GetEditDataFromDb(QsModel, QsId);
        BreadCrumbRpt.DataBind();

        if (!IsPostBack)
        {
            InsertThreadToTextBoxes();
        }



    }

    private void InsertThreadToTextBoxes()
    {
        EditThreadRpt.DataSource = DataBaseQueries.GetEditDataFromDb(QsModel, QsId);
        EditThreadRpt.DataBind();
    }


    protected void Discard_Click(object sender, EventArgs e)
    {
        Response.Redirect(BackToCategory);
    }

    protected void EditThreadBtn_Click(object sender, EventArgs e)
    {
        //Makes it possible to read values from textboxes inside a repeater. Also calls Update method
        foreach (RepeaterItem item in EditThreadRpt.Items)
        {
            //Creates empty string varibles
            //Thread Title
            string Param1;

            //Thread Content
            string Param2;

            //Fetches value from the textbox "EditThreadTitleTxt", and puts it inside a TEXTBOX VARIBLE called "EditThreadTitleTxt"
            TextBox EditThreadTitleTxt = (TextBox)item.FindControl("EditThreadTitleTxt");
            //Fetches value from the TEXTBOX VARIBLE "EditThreadTitleTxt", and puts it inside the empty STRING VARIABLE called "ThreadTitle"
            Param1 = EditThreadTitleTxt.Text;

            //Same principle as above
            TextBox EditThreadContentTxt = (TextBox)item.FindControl("EditThreadContentTxt");
            Param2 = EditThreadContentTxt.Text;

            //Calls Update method, which updates the table in the DB
            DataBaseQueries.UpdateEditDataInBD(QsModel, QsId, Param1, Param2);
        }

        //Link needs fixing.
        Response.Redirect(BackToCategory);
    }
}