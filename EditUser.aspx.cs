using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditUser : System.Web.UI.Page
{
    //This page
    string LastPage;

    //Current user
    int UserId;

    int UserRole;

    //int ThisUsersRoleId;

    protected void Page_Load(object sender, EventArgs e)
    {
        LastPage = Convert.ToString(Session["LastPage"]);

        UserId = Convert.ToInt32(Request.QueryString["Id"]);





        if (!IsPostBack)
        {
            EditUserInfoRpt.DataSource = DataBaseQueries.GetUserInfo(UserId);
            EditUserInfoRpt.DataBind();

            //UserRoleDdl.DataTextField = "RoleName";
            //UserRoleDdl.DataValueField = "RoleId";

            //Not yet used. Plan to use it for itemselector in dropdownlist
            //SelectorForRoleDropDownList(UserId);

            //ArrayList Roles = new ArrayList();
            //Roles = DataBaseQueries.GetRoles();

            //foreach (int item in Roles)
            //{
                
            //}


            //UserRoleDdl.SelectedValue = 
            //UserRoleDdl.DataSource = Roles;
            //UserRoleDdl.DataBind();


        }

    }

    //private void SelectorForRoleDropDownList(int UserId)
    //{
    //    ThisUsersRoleId = DataBaseQueries.GetRoleIdByUserId(UserId);
    //}

    protected void Discard_Click(object sender, EventArgs e)
    {
        Response.Redirect(LastPage);
    }

    protected void SaveEditedUserBtn_Click(object sender, EventArgs e)
    {
        UserRole = Convert.ToInt32(UserRoleDdl.SelectedValue);

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

            //string UserRole;

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

            //TextBox UserRoleTxt = (TextBox)item.FindControl("UserRoleTxt");
            //UserRole = UserRoleTxt.Text;

            //Calls Update method, which updates the table in the DB
            DataBaseQueries.UpdateEditedUserDataInDB(UserId, UserName, Email, Password, UserRole);
        }

        //DataBaseQueries.EditUserInfoRpt();


        Response.Redirect(LastPage);
    }
}