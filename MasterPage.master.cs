using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            if (Session["RoleId"] == null)
            {
                //RoleId 3 is guest-role
                Session["RoleId"] = 3;
                Per.CreatePrivilegeSession();
            }
        }

        LoginLink.Visible = Per.Allowed("Login");
        CreateUserLink.Visible = Per.Allowed("CreateUser");
        MyPageLink.Visible = Per.Allowed("MyPage");
        UserListLink.Visible = Per.Allowed("ShowUserList");
        UserListLinkDivider.Visible = Per.Allowed("ShowUserList");
        LogOutLink.Visible = Per.Allowed("LogOut");
        LogOutLinkDivider.Visible = Per.Allowed("LogOut");


        //________________________________________//
        if (Session["FlashMsgSuccess"] != null)
        {
            // Vis besked
            PanelMsg.Visible = true;
            PanelMsg.CssClass = "alert alert-success alert-dismissable";
            LabelMsg.Text = Session["FlashMsgSuccess"].ToString();

            // Fjern beskeder fra Session
            Session["FlashMsgSuccess"] = null;
            Session["FlashMsgDanger"] = null;
        }

        if (Session["FlashMsgDanger"] != null)
        {
            // Vis besked
            PanelMsg.Visible = true;
            PanelMsg.CssClass = "alert alert-danger alert-dismissable";
            LabelMsg.Text = Session["FlashMsgDanger"].ToString();

            // Fjern beskeder fra Session
            Session["FlashMsgDanger"] = null;
            Session["FlashMsgSuccess"] = null;
        }
        //_________________________________________//
    }
}
