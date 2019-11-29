using System;
using System.Web.UI;

namespace f3b_store
{
    public partial class LoginPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void bLogIn_Click(object sender, EventArgs e)
        {
            string token = AccountOperations.tryToLogIn(tbUsername.Text, tbPassword.Text);
            if(token == "fail")
            {
                lMsg.Text = "Nieprawidłowy login lub hasło, albo konto nie zostało jeszcze aktywowane.";
            } else
            {
                Session["usertoken"] = token;
                Response.Redirect("MainPage.aspx");
            }
        }

        protected void bGoToRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }

        protected void btToMainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }
}