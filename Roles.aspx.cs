using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Roles : System.Web.UI.Page
{
    ArrayList Selected;
    //ArrayList AllPrivileges;

    protected void Page_Load(object sender, EventArgs e)
    {

        PrivilegesCbl.DataSource = DataBaseQueries.GetAllPrivileges();
        PrivilegesCbl.DataBind();

        Selected = DataBaseQueries.GetSelectedItemsForThisRole(RolesDdl.SelectedValue);
        foreach (ListItem item in PrivilegesCbl.Items)
        {
            if (Selected.Contains(Convert.ToInt32(item.Value)))
            {
                item.Selected = true;
            }

        }
    }

    protected void UpdateRoleBtn_Click(object sender, EventArgs e)
    {
        //DataBaseQueries.UpdateRolePrivileges();
    }

    //protected void PrivilegesCbl_DataBound(object sender, EventArgs e)
    //{
    //    Selected = DataBaseQueries.GetSelectedItemsForThisRole(RolesDdl.SelectedValue);

    //    foreach (ListItem item in PrivilegesCbl.Items)
    //    {
    //        if (Selected.Contains(Convert.ToInt32(item.Value)))
    //        {
    //            item.Selected = true;
    //        }

    //    }
    //}

}

