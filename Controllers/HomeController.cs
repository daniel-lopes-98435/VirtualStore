using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using VirtualStore.Models;
using VirtualStore.Libraries;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VirtualStore.Database;

namespace VirtualStore.Controllers
{
    public class HomeController : Controller
    {
        //Declare context, this maps the connection with database
        private VirtualStoreContext _context;
        public HomeController(VirtualStoreContext contex)
        {
            _context = contex;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm] NewsletterEmail newsletter)
        {
            if (ModelState.IsValid)
            {
                //TODO - Save data on Database
                _context.newsletters.Add(newsletter);
                _context.SaveChanges();

                TempData["MSG_S"] = "Email cadastrado com sucesso, a partir de agora você receberá nossa promoções, fique atento";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
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
                    EmailContact.SendContacByEmail(contact);

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

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult CustomerRegister()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult CustomerRegister([FromForm] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                TempData["MSG_S"] = "Cadastro realizado com sucesso";
                //TODO - Implementar redirecionamentos diferentes (Painel, Carrinho de compra, outros)
                //TODO - Ajustar a formatação da data
                return RedirectToAction(nameof(CustomerRegister));

            }
            else
            {
                return View();
            }
            
        }


        public IActionResult Cart()
        {
            return View();
        }

    }
}