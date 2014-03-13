using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Hvis bruger er logget ind
        if (Session["UserId"] != null)
        {
            // log bruger ud. Test om besked virker. Ellers lav "Abandon" om til "UserId = null"
            Session.Abandon();

            Session["FlashMsgSuccess"] = "<strong>Tak</strong> for dit besøg. Du er nu logget ud.";
            Session["RoleId"] = 3;
        }
        // Send brugeren tilbage til forsiden

        Response.Redirect("Default.aspx");
    }
}