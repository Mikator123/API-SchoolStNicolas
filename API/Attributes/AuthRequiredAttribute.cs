using API.Models.Enumerations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using ToolBox.SecurityToken;
using IAuthorizationFilter = Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter;

namespace API.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthRequiredAttribute : TypeFilterAttribute
    {
        public AuthRequiredAttribute(UserStatus status = UserStatus.Undefined) : base(typeof(AuthRequiredFilter))
        {
            Arguments = new object[] { status };
        }
    }

    public class AuthRequiredFilter : IAuthorizationFilter
    {
        private UserStatus RequiredStatus { get; set; }
        private UserStatus UserStatus { get; set; }

        public AuthRequiredFilter(UserStatus status = UserStatus.Undefined)
        {
            RequiredStatus = status;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ITokenService _tokenService = (ITokenService)context.HttpContext.RequestServices.GetService(typeof(ITokenService));

            context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorizations);

            string token = authorizations.SingleOrDefault(t => t.StartsWith("Bearer "));

            if (token is null)
                context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
            else
            {
                IEnumerable<string> properties = new List<string>() { "Id", "LastName", "FirstName", "Birthdate", "Login", "Gender", "StatusCode", "FirstLogin"};
                IDictionary<string, string> user = _tokenService.DecodeToken(token, properties);

                if (user is null)
                    context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                else
                {
                    UserStatus = (UserStatus)int.Parse(user["StatusCode"]);

                    if (!UserStatus.HasFlag(RequiredStatus))
                        context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                    else
                        context.RouteData.Values.Add("UserId", user["Id"]);
                }
            }

        }

        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            throw new NotImplementedException();
        }
    }
}
