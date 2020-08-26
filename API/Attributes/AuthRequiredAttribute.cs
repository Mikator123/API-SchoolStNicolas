using API.Models;
using API.Models.Users;
using API.Utils.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace API.Attributes
{
    public class AuthRequiredAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            actionContext.Request.Headers.TryGetValues("Authorization", out IEnumerable<string> authorisations); // recupere les valeurs d'Authorization -> bearer blablabla



            string token = authorisations.SingleOrDefault(t => t.StartsWith("Bearer ")); // n'en retourner qu'un seul qui commence par Bearer .



            if (token is null) // si pas de valeur trouvée
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized); //défini la réponse si le token est null
            }
            else
            {
                UserSimplified user = TokenService.Instance.DecodeToken(token); // décode le token et le met dans le user

                if (user is null) // plus valide dans le temps par exemple
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
                else
                {
                    // ????????????? quel action ?
                }
            }



        }
    }
}
