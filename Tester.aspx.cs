using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tester : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CheckBoxList1_DataBound(object sender, EventArgs e)
    {
        
        ArrayList NyList = DataBaseQueries.GetSelectedItemsForThisRole("3");

        foreach (ListItem item in CheckBoxList1.Items)
        {
            if (NyList.Contains(Convert.ToInt32(item.Value)))
            {
                item.Selected = true;
            }
        }

    }
}