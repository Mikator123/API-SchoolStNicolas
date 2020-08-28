using API.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Utils.Token
{
    public static class TokenClaims

    {
        internal static IEnumerable<Claim> ToCLaims(this UserSimplified user)
        {
            yield return new Claim("Id", user.Id.ToString());
            yield return new Claim("LastName", user.LastName);
            yield return new Claim("FirstName", user.FirstName);
            yield return new Claim("Birthdate", user.Birthdate.ToString());
            yield return new Claim("Login", user.Login);
            yield return new Claim("Gender", user.Gender);
            yield return new Claim("StatusCode", user.StatusCode.ToString());
            yield return new Claim("FirstLogin", user.FirstLogin.ToString());
        }
    }
}
