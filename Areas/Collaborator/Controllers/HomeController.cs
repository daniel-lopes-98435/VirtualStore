using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.Libraries.Filter;
using VirtualStore.Libraries.Login;
using VirtualStore.Repositories.Contracts;

namespace VirtualStore.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    public class HomeController : Controller
    {
        private ICollaboratorRepository _collaboratorRepository;
        private CollaboratorLogin _collaboratorLogin;

        public HomeController(ICollaboratorRepository collaboratorRepository, CollaboratorLogin collaboratorLogin)
        {
            _collaboratorRepository = collaboratorRepository;
            _collaboratorLogin = collaboratorLogin;
        }


        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn([FromForm] Models.Collaborator collaborator)
        {
            Models.Collaborator collaboratorDB = _collaboratorRepository.Login(collaborator.Email, collaborator.Password);
            if (collaboratorDB != null)
            {
                _collaboratorLogin.Login(collaboratorDB);

                return new RedirectResult(Url.Action(nameof(Painel)));
            }
            else
            {
                ViewData["MSG_E"] = "Usuário ou senha inválido";
                return View();
            }
        }

        [AuthorizationCollaboratorFilter]
        public IActionResult Signout()
        {
            _collaboratorLogin.Logout();
            return RedirectToAction("SignIn","Home");
        }


        public IActionResult CreateNewPassword()
        {
            return View();
        }

        public IActionResult PasswordRecover()
        {
            return View();
        }

        [AuthorizationCollaboratorFilter]
        public IActionResult Painel()
        {
            return View();
        }

    }
}