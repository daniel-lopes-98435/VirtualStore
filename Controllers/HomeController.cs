using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using VirtualStore.Models;
using VirtualStore.Libraries;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VirtualStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult ContactRegister()
        {
            try
            {
                Contact contact = new Contact();

                contact.Name = HttpContext.Request.Form["Name"];
                contact.Email = HttpContext.Request.Form["Email"];
                contact.Comments = HttpContext.Request.Form["Comments"];

                //Take the list of results
                var messageList = new List<ValidationResult>(); 
                //Create a validationContext
                var context = new ValidationContext(contact);
                //Check validation
                bool isValid = Validator.TryValidateObject(contact, context, messageList,true);

                if (isValid)
                {
                    //EmailContact.SendContacByEmail(contact);

                    //return new ContentResult() { Content = string.Format( "Dados recebidos com sucesso <br/> Nome: {0} <br/> Email: {1} Comments {2} ", contact.Name , contact.Email , contact.Comments),ContentType="text/html" };

                    ViewData["MSG_S"] = "Mensagem de contato enviada com sucesso";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach(var msg in messageList)
                    {
                        sb.Append(msg.ErrorMessage + "<br />");
                    }
                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["Contact"] = contact;

                }

            }
            catch (Exception)
            {

                ViewData["MSG_E"] = "Opps! Tivemos um erro, tente novamente mais tarde!";

                //TODO - create a log
            }


            return View("Contact");
        }



        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult CustomerRegister()
        {
            return View();
        }
    }
}