using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using VirtualStore.Models;

namespace VirtualStore.Libraries
{
    public class EmailContact
    {
        public static void SendContacByEmail(Contact contact)
        {

            //Configure Email Server
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("daniel.lopes.codbr@gmail.com", "codbr98435");
            smtp.EnableSsl = true;

            //Define message

            string msgbody = string.Format
                (
                    "<h2> Virtual Store Contact </h2>" +
                    "<b>Name:       </b> {0} <br>" +
                    "<b>Email:      </b> {1} <br>" +
                    "<b>Comments:   </b> {2} <br>" +
                    "<br>This e-mail was sent automaticaly by Virtual Store",
                    contact.Name,
                    contact.Email,
                    contact.Comments

                );

            MailMessage message = new MailMessage();
            message.From = new MailAddress("daniel.lopes.codbr@gmail.com");
            message.To.Add("daniel.lopes.codbr@gmail.com");
            message.Subject = "Virtual Store contact email: " + contact.Email;
            message.Body = msgbody;
            message.IsBodyHtml = true;

            //Send message
            smtp.Send(message);

        }
    }
}
