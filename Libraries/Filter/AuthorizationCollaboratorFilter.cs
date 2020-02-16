using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VirtualStore.Libraries.Login;
using VirtualStore.Models;

namespace VirtualStore.Libraries.Filter
{
    public class AuthorizationCollaboratorFilter : Attribute, IAuthorizationFilter
    {
        CollaboratorLogin _collaboratorLogin;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _collaboratorLogin = (CollaboratorLogin)context.HttpContext.RequestServices.GetService(typeof(CollaboratorLogin));

            Collaborator collaborator = _collaboratorLogin.GetCollaborator();

            if (collaborator == null)
            {
                context.Result = new ContentResult() { Content = "Acesso negado via filtros" };
            }


        }
    }
}
