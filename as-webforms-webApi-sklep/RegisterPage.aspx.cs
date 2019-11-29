using f3b_store.services;
using System;
using System.Web.UI;

namespace f3b_store
{
    public partial class RegisterPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bRegister_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                var query = DBOperations.selectQuery("SELECT username FROM users WHERE username LIKE '" + tbUsername.Text + "'");
                if(query.Rows.Count == 1)
                {
                    lMsg.Text = "Nazwa użytkownika zajęta.";
                } else
                {
                    if (AccountOperations.tryToRegister(tbUsername.Text, tbPassword.Text, tbEmail.Text, new string[3] { tbFirstName.Text, tbLastName.Text, tbAddress.Text}))
                    {
                        EmailService.UserRegisterConfirmation(tbEmail.Text, tbUsername.Text);
                        lMsg.Text = "Pomyślnie zarejestrowano. Na podany email wysłana została wiadomość z linkiem aktywacyjnym.";
                    } else
                    {
                        lMsg.Text = "Błąd podczas rejestracji.";
                    }
                }
            }
        }

        protected void bGotToLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void btToMainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }
}