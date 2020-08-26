using System.Net;
using API.Mappers;
using API.Models.Users;
using API.Utils.RSA;
using API.Utils.Token;
using DAL.Enumerations;
using DAL.Services.Repositories.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private UserRepository _userRepo;
        private ContactRepository _contactRepo;
        private Decrypting _decrypting = new Decrypting();
        private KeyGenerator _key;
        public UserController(UserRepository userRepo, ContactRepository contactRepo, KeyGenerator key)
        {
            _userRepo = userRepo;
            _contactRepo = contactRepo;
            _key = key;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] FormLogin entity)
        {
            //string privateKey = _key.PrivateKey;
            //entity.Password = _decrypting.Decrypt(entity.Password, privateKey);
            UserSimplified user = _userRepo.Login(entity.Login, entity.Password)?.DalToSimplifiedUserApi();
            if (!(user is null))
            {
                user.Token = TokenService.Instance.EncodeToken(user);
                return Ok(user);
            }
            else
                return Problem("Login doesnt exist or password doenst match !", statusCode: (int)HttpStatusCode.NotFound);
        }

        [HttpGet]
        [Route("GetPublicKey")]
        public IActionResult GetPublicKey()
        {
            _key.GenerateKeys(RSAKeySize.Key2048);
            string publicKey = _key.PublicKey;

            if (!(publicKey is null))
                return Ok(publicKey);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(UserDetailed user)
        {
            switch(_userRepo.Create(user.ApiToDal()))
            {
                case (UserCodes.Success): 
                    return Ok();
                case (UserCodes.ClassId_NotFound):
                    return Problem("A valid ClassId is needed.", statusCode: (int)HttpStatusCode.BadRequest);
                case (UserCodes.NationalNumber_Exist):
                    return Problem("NationalNumber already exist.", statusCode: (int)HttpStatusCode.BadRequest);
                case (UserCodes.NullExeption):
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                case (UserCodes.StartDate_Birthdate_Error):
                    return Problem("Birthdate should be lower than StartDate.", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(UserDetailed user)
        {
            switch(_userRepo.Update(user.ApiToDal()))
            {
                case (UserCodes.Success):
                    return Ok();
                case (UserCodes.ClassId_NotFound):
                    return Problem("A valid ClassId is needed.", statusCode: (int)HttpStatusCode.BadRequest);
                case (UserCodes.NationalNumber_Exist):
                    return Problem("NationalNumber already exist.", statusCode: (int)HttpStatusCode.BadRequest);
                case (UserCodes.UserId_NotFound):
                    return Problem("A valid UserId is needed.", statusCode: (int)HttpStatusCode.BadRequest);
                case (UserCodes.NullExeption):
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                case (UserCodes.StartDate_Birthdate_Error):
                    return Problem("Birthdate should be lower than StartDate.", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            switch(_userRepo.Delete(Id))
            {
                case (UserCodes.Success):
                    return Ok();
                case (UserCodes.UserId_NotFound):
                    return Problem("A valid UserId is needed.", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }
    }
}
