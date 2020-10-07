using API.Models.Users;
using DAL.Models.RelativeToUser;
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
            //yield return new Claim(ClaimTypes.Role, user.StatusName.ToString());
            yield return new Claim("lastResetPwd", user.lastResetPwd.ToString());
        }

        //private static string Roles(int statusCode)
        //{
        //    string statusName = "";
        //    IEnumerable<Status> list = StatusCodeService.Deserialize(statusCode);
        //    foreach (Status s in list)
        //    {
        //        statusName += s.Name +",";
        //    }
        //    return statusName;

        //}
    }
}
