using API.Models.Users;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Utils.Token
{
    public sealed class TokenService 
    {
        #region Singleton
        private static TokenService _instance;

        public static TokenService Instance
        {
            get
            {
                return _instance ?? (_instance = new TokenService()); 
            }
        }
        #endregion


        private const string PassPhrase = @"?*w*92%&+d_pxTU8j3gUMsDDkU*pr@fvva*u5CBMV&Qpju$xsbx2s#UM3uhSrCB^2=pk&53JDB69SYV*48=YaQFjRTcQLPLA#sFVjZjb5ja=mkAuh?Yb*T5!G6mHf_+Zy$e5km@*fjEBBzcK8g!H4QCU*vYrEAE^p9TBUmCfPQSyC!f6tpQyBYKrT!AaMLycJL@94m94-tNmWa6b&Jw@s+2hqF2YB_G_+3k?uZU4L*gT5f5aK2F5_TvnEvtr7vE&";
        
        private JwtSecurityTokenHandler _handler;

        public JwtSecurityTokenHandler Handler
        {
            get
            {
                return _handler ?? (_handler = new JwtSecurityTokenHandler());
            }
        } 
        private JwtHeader _header;
        public JwtHeader Header
        {
            get
            {
                return _header ?? (_header = new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(PassPhrase)),
                        SecurityAlgorithms.HmacSha512))); 
            }
        }
        public string EncodeToken(UserSimplified user)
        {
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                Header,
                new JwtPayload(
                    issuer: null,
                    audience: null,
                    claims: new Claim[]
                    {
                        new Claim("Id", user.Id.ToString()),
                        new Claim("LastName", user.LastName),
                        new Claim("FirstName", user.FirstName),
                        new Claim("Birthdate", user.Birthdate.ToString()),
                        new Claim("Login", user.Login),
                        new Claim("Gender", user.Gender),
                        new Claim("FirstLogin", user.FirstLogin.ToString()),          
                    },
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddHours(5)
                    )
                ) ;



            return Handler.WriteToken(jwtSecurityToken); 
        }



        public UserSimplified DecodeToken(string token)
        {
            UserSimplified user = null; 
            token = token.Replace("Bearer ", ""); 
            JwtSecurityToken jwtSecurityToken = Handler.ReadJwtToken(token); 
            if (jwtSecurityToken.ValidFrom <= DateTime.Now && jwtSecurityToken.ValidTo >= DateTime.Now)  
            {
                JwtPayload payload = jwtSecurityToken.Payload; 
                string test = Handler.WriteToken(new JwtSecurityToken(Header, payload));

                if (token == test) 
                {
                    payload.TryGetValue("Id", out object id); 
                    payload.TryGetValue("LastName", out object lastName);
                    payload.TryGetValue("FirstName", out object firstName);
                    payload.TryGetValue("Birthdate", out object Birthdate);
                    payload.TryGetValue("Login", out object login);
                    payload.TryGetValue("Gender", out object gender);
                    payload.TryGetValue("FirstLogin", out object firstLogin);

                    user = new UserSimplified()
                    {
                        Id = int.Parse((string)id),
                        LastName = (string)lastName,
                        FirstName = (string)firstName,
                        Birthdate = (DateTime)Birthdate,
                        Login = (string)login,
                        Gender = (string)gender,
                        FirstLogin = (DateTime)firstLogin
                    };
                }
            }
            return user; 
        }
    }
}
