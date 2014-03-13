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
    //public Per()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}   
    
    public static bool Allowed(string CodeName)
    {
        ArrayList Privileges = new ArrayList();
        Privileges = (ArrayList)HttpContext.Current.Session["Privileges"];
        return Privileges.Contains(CodeName) ? true : false;

    }

    public static void CreatePrivilegeSession()
    {
        object RoleId = HttpContext.Current.Session["RoleId"];
        //Check user privileges Privileges (Arraylist)
        HttpContext.Current.Session["Privileges"] = DataBaseQueries.Privileges(RoleId);
    }





    public static bool EditPostPrivilege(object PostId)
    {
        int NewPostId = Convert.ToInt32(PostId);
        return (Per.IsPostMine("EditPost", NewPostId) || Per.IsPostMine("IsPostOwner", NewPostId))?true:false;
        
    }

    public static bool IsPostMine(string CodeName, object PostId)
    {
        int UserId = Convert.ToInt32(HttpContext.Current.Session["UserId"]);
        //Tjekke rettigheder
        if (Allowed(CodeName))
        {
            //PostOwner ejer ALLE indlæg. Bruges til fx. Admin eller moderator, som skal kunne slette alle indlæg
            if (CodeName == "IsPostOwner")
            {
                return true;
            }
            else
            {
                //Tjekke ejerskab            
                return DataBaseQueries.IsPostMine(UserId, PostId);
            }
        }
        else
        {
            return false;
        }
    }


    #region EditThread
    public static bool EditThreadPrivilege(object ThreadId)
    {
        if (ThreadId.ToString() != "")
        {
            int NewThreadId = Convert.ToInt32(ThreadId);
        return (Per.IsThreadMine("EditThread", NewThreadId) || Per.IsThreadMine("IsThreadOwner", NewThreadId)) ? true : false;
        }
        else
        {
            return false;
        }
    }

    public static bool IsThreadMine(string CodeName, object ThreadId)
    {
        int UserId = Convert.ToInt32(HttpContext.Current.Session["UserId"]);
        //Tjekke rettigheder
        if (Allowed(CodeName))
        {
            //PostOwner ejer ALLE indlæg. Bruges til fx. Admin eller moderator, som skal kunne slette alle indlæg
            if (CodeName == "IsThreadOwner")
            {
                return true;
            }
            else
            {
                //Tjekke ejerskab            
                return DataBaseQueries.IsPostMine(UserId, ThreadId);
            }
        }
        else
        {
            return false;
        }
    }
    #endregion
}