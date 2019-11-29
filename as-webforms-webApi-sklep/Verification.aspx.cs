using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using f3b_store;

namespace f3b_store
{
    public partial class Verification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ActivationCode"])) {
                    string activationCode = Request.QueryString["ActivationCode"];
                    ltMessage.Text = "Konto zostało aktywowane. Możesz się teraz zalogować.";
                    DBOperations.updateVerificationStatus(activationCode);
                } else
                {
                    ltMessage.Text = "Wystąpił błąd podczas próby aktywacji konta.";
                }
            }
        }
    }
}