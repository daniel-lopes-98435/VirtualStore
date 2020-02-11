using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Filters;
using VirtualStore.Libraries.Login;
using VirtualStore.Models;

namespace VirtualStore.Libraries.Filter
{
    public class AuthorizationClientFilter : Attribute, IAuthorizationFilter
    {
        /*
         * Autorização
         * Recurso
         * Ação
         * Exceção
         * Resultado
         */
        ClientLogin _clientLogin;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _clientLogin = (ClientLogin)context.HttpContext.RequestServices.GetService(typeof(ClientLogin));

            Client client = _clientLogin.GetClient();

            if (client == null)
            {
                context.Result = new ContentResult() { Content = "Acesso negado via filtros" };
            }


        }
    }
}
