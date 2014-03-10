using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditUser : System.Web.UI.Page
{
    //This page
    string MyUserUrl;

    //Current user
    int UserId;

    protected void Page_Load(object sender, EventArgs e)
    {
        MyUserUrl = Convert.ToString(Session["MyUserPage"]);

        UserId = Convert.ToInt32(Request.QueryString["Id"]);

        if (!IsPostBack)
        {
            EditUserInfoRpt.DataSource = DataBaseQueries.GetUserInfo(UserId);
            EditUserInfoRpt.DataBind();
        }

    }

    protected void Discard_Click(object sender, EventArgs e)
    {
        Response.Redirect(MyUserUrl);
    }

    protected void SaveEditedUserBtn_Click(object sender, EventArgs e)
    {
        //Makes it possible to read values from textboxes inside a repeater. Also calls Update method
        foreach (RepeaterItem item in EditUserInfoRpt.Items)
        {
            //Creates empty string varibles
            //Thread Title
            string UserName;

            //Thread Content
            string Email;

            //Thread Title
            string Password;

            //Fetches value from the textbox "UserNameTxt", and puts it inside a TEXTBOX VARIBLE called "UserNameTxt"
            TextBox UserNameTxt = (TextBox)item.FindControl("UserNameTxt");
            //Fetches value from the TEXTBOX VARIBLE "UserNameTxt", and puts it inside the empty STRING VARIABLE called "UserName"
            UserName = UserNameTxt.Text;

            //Same principle as above
            TextBox EmailTxt = (TextBox)item.FindControl("EmailTxt");
            Email = EmailTxt.Text;

            //Same principle as above
            TextBox UserPasswordTxt = (TextBox)item.FindControl("UserPasswordTxt");
            Password = UserPasswordTxt.Text;

            //Calls Update method, which updates the table in the DB
            DataBaseQueries.UpdateEditedUserDataInDB(UserId, UserName, Email, Password);
        }

        //DataBaseQueries.EditUserInfoRpt();

        Response.Redirect(MyUserUrl);
    }
}