using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginScript : System.Web.UI.Page
{
    private string UserName;
    private string PassWord;
    protected string LastPage;

    protected void Page_Load(object sender, EventArgs e)
    {
        LastPage = Convert.ToString(Session["LastPage"]).Trim();
        UserName = Convert.ToString(Session["UserName"]);
        PassWord = Convert.ToString(Session["PassWord"]);
        string RoleId;

        //Authenticate
        if (DataBaseQueries.AuthenticateUserCredentials(UserName, PassWord))
        {
            //Build Session:
            //UserId, RoleId
            RoleId = Convert.ToString(Session["RoleId"]);

            //Get privileges
            Per.CreatePrivilegeSession();

            //Return to last page or frontpage?___//
            if (LastPage != null && LastPage != "")
            {
                //Back to the last page
                Response.Redirect(LastPage);
            }
            else
            {
                //Til Forsiden
                Response.Redirect("Default.aspx");
            }

            //____________________________________//
        }
        else
        {

            //sæt brugerens rolle til gæst
            RoleId = "3";
            //Get privileges
            Per.CreatePrivilegeSession();

            //Fejl. Brugeren findes ikke
            Session["FlashMsgDanger"] = "Fejl i brugernavn eller password";

            //Tilbage til Login-siden
            Response.Redirect("Login.aspx");
        }
    }
}