using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Discard_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void CreateUserBtn_Click(object sender, EventArgs e)
    {



        //Validate og opret i DB
        if (ValidateInput())
        {
            //Insert into DB
            string UserName = CreateUserNameTxt.Text;
            string PassWord = CreateUserPassWordTxt.Text;
            string Email = CreateUserEmailTxt.Text;
            int RoleId = 2;
            DataBaseQueries.CreateNewUser(UserName, PassWord, Email, RoleId);
            //Succes message
            Session["FlashMsgSucces"] = "<strong>Succes!</strong><br /> Du er nu oprettet";
            //Gemmer brugernavn og password i session og sender brugeren videre til Login, hvor session bliver brugt til at udfylde tekstfelterne
            Session["UserName"] = UserName;
            Session["PassWord"] = PassWord;
            Response.Redirect("Login.aspx");
        }

        //Errormessage if not ok
        else
        {
            PanelMsgFejl.Visible = true;
            
            //Session metoden virker kun, hvis man refresher siden. Derfor er den deaktiveret.
            //Har ikke slettet den, hvis der skulle dukke en god metode op til at refreshe uden, at man mister inputtet
            //Session["FlashMsgDanger"] = "<strong>Fejl!</strong><br /> Tjek din indtastning";
        }

    }

    private bool ValidateInput()
    {
        string ConfirmEmailTextBox = ConfirmUserEmailTxt.Text;
        string EmailTextBox = CreateUserEmailTxt.Text;
        string EmailRegEx = @"^[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,5}$";

        if (!Regex.IsMatch(EmailTextBox, EmailRegEx))
        {
            ErrorLbl.Text = "Forkert email format i Email-feltet";
            return false;
        }
        if (ConfirmEmailTextBox.Trim() != EmailTextBox.Trim())
        {
            ErrorLbl.Text = "Email felternes tekst er ikke ens";
            return false;
        }
        else
        {
            return true;
        }
    }
}