﻿using System;
using System.Collections.Generic;
using System.Net;
using API.Mappers;
using API.Models.Commons;
using API.Models.Users;
using API.Utils.RSA;
using API.Utils.Token;
using DAL.Services.Repositories.RelativeToUser;
using Microsoft.AspNetCore.Mvc;
using ToolBox.SecurityToken;

namespace API.Controllers.RelativeToUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ITokenService _token;
        private readonly Decrypting _decrypting = new Decrypting();
        private readonly KeyGenerator _key;
        private readonly AuthRepository _authRepo;

        public AuthController(ITokenService token, KeyGenerator key, AuthRepository authRepo)
        {
            _token = token;
            _key = key;
            _authRepo = authRepo;
        }

        [HttpPost]
        /*POSTMAN OK*/
        public IActionResult Login([FromBody] FormLogin entity)
        {
            //string privateKey = _key.PrivateKey;
            //entity.Password = _decrypting.Decrypt(entity.Password, privateKey);
            UserSimplified user = new UserSimplified();
            try
            {
                user = _authRepo.Login(entity.Login, entity.Password)?.DalToSimplifiedUserApi();
            }
            catch (Exception e)
            {
                if (e.Message.Contains("LoginNotFound"))
                    return Problem("Login doesnt exist", statusCode: (int)HttpStatusCode.NotFound);
                if (e.Message.Contains("PasswordDoesntMatch"))
                    return Problem("Password doesnt match with the current login", statusCode: (int)HttpStatusCode.NotFound);
                else
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
            if (!(user is null))
            {

                user.Token = _token.EncodeToken(user, (u) => u.ToCLaims());
                if (string.IsNullOrWhiteSpace(user.Token))
                    return Problem("Invalid token !", statusCode: (int)HttpStatusCode.MethodNotAllowed);
                else
                {
                    return Ok(user);
                }
            }
            else
            {
                return Problem("User is null", statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        [HttpPut]
        public IActionResult ResetPwd([FromBody] RestePwd RP)
        {
            _authRepo.ResetPwd(RP.Password, RP.Id, RP.lastResetPwd);
            return Ok();
        }

        [HttpPost]
        [Route("userVerification")]
        public IActionResult VerifyUser([FromBody] UserVerification user)
        {
            int Id = 0;
            try
            {
                Id = _authRepo.userVerification(user.Login, user.UserNationalNumber, user.ContactNationalNumber);
            }
            catch(Exception e)
            {
                return Problem(e.Message, statusCode: (int)HttpStatusCode.NotFound);
            }
            if (Id != 0)
                return Ok(Id);
            else
                return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
        }

        [HttpGet]
        public IActionResult GetPublicKey()
        {
            _key.GenerateKeys(RSAKeySize.Key2048);
            string publicKey = _key.PublicKey;

            if (!(publicKey is null))
                return Ok(publicKey);
            else
                return NotFound();
        }



    }
}
