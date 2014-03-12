using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string UserName = Convert.ToString(Session["UserName"]);
            string PassWord = Convert.ToString(Session["PassWord"]);
            if (UserName != null)
            {
                UserNameTxt.Text = UserName;
            }
            if (PassWord != null)
            {
                UserPasswordTxt.Text = PassWord;
            }
        }


    }

    protected void Discard_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void LoginBtn_Click(object sender, EventArgs e)
    {
        Session["UserName"] = UserNameTxt.Text;
        Session["PassWord"] = UserPasswordTxt.Text;
        Response.Redirect("LoginScript.aspx");
    }

}