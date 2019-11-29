using as_webforms_webApi_sklep;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace as_webforms_sklep.services
{
    public class EmailService
    {

        internal static void ProductBought(string email, string orderId, List<BasketItem> items)
        {
            using (MailMessage mm = new MailMessage("store@f3b.com", email))
            {
                mm.Subject = "Zamówienie #" + orderId + " w serwisie F3B.com";
                mm.Body = "Dziękujemy za korzystanie z naszych usług. Oto pańskie klucze:";
                mm.Body += "<ul>";
                foreach(var item in items)
                {
                    int iteration = 1;
                    while(iteration < item.Amount) {
                        string itemName = DatabaseHandler.selectQuery("SELECT name FROM product_info WHERE id LIKE '" + item.ProductId + "'").Rows[0]["name"].ToString();
                        mm.Body += "<li>" + itemName + ": <b>" + KeyGen.randomKey() + "</b></li>";
                        iteration++;
                    }
                }
                mm.Body += "</ul>";
                mm.Body += "Życzymy miłej zabawy!";
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("projektsklepkoszalka@gmail.com", "zaq1@WSX");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
        internal static void UserRegisterConfirmation(string email, string username)
        {
            using (MailMessage mm = new MailMessage("accounts@f3b.com", email))
            {
                var id = DatabaseHandler.selectQuery("SELECT id FROM users WHERE username LIKE '" + username + "'");
                var idTrue = "";
                if (id.Rows.Count == 1)
                    idTrue = id.Rows[0]["id"].ToString();
                Debug.WriteLine(idTrue);
                Debug.WriteLine(username);
                mm.Subject = "Aktywacja konta: "+ username + " w serwisie F3B.com";
                string body = "Witaj " + username + ",";
                body += "<br /><br />Aby aktywować konto należy użyć tego liku.";
                body += "<br /><a href = 'http://localhost:54291/Verify.aspx/?ActivationCode=" + idTrue + "'>Aktywuj konto</a>";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("projektsklepkoszalka@gmail.com", "zaq1@WSX");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }

        }
    }
}