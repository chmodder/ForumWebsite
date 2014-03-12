using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Per
/// </summary>
public class Per
{
    public static bool Allowed(string CodeName)
    {
        ArrayList Privileges = new ArrayList();
        Privileges = (ArrayList)HttpContext.Current.Session["Privileges"];
        if (Privileges.Contains(CodeName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void CreatePrivilegeSession()
    {
        object RoleId = HttpContext.Current.Session["RoleId"];
        //Check user privileges Privileges (Arraylist)
        HttpContext.Current.Session["Privileges"] = DataBaseQueries.Privileges(RoleId);
    }

    public Per()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}