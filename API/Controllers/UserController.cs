using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using API.Mappers;
using API.Models;
using API.Models.Users;
using API.Utils;
using API.Utils.RSA;
using API.Utils.Token;
using DAL.Enumerations;
using D = DAL.Models;
using DAL.Services.Repositories.Users;
using DAL.Utils;
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
        private StatusRepository _statusRepo;
        public UserController(UserRepository userRepo, ContactRepository contactRepo, KeyGenerator key, StatusRepository statusRepo)
        {
            _userRepo = userRepo;
            _contactRepo = contactRepo;
            _key = key;
            _statusRepo = statusRepo;
        }

        [HttpPost]
        [Route("login")] // * POSTMAN OK * //
        public IActionResult Login([FromBody] FormLogin entity)
        {
            //string privateKey = _key.PrivateKey;
            //entity.Password = _decrypting.Decrypt(entity.Password, privateKey);
            UserSimplified user = _userRepo.Login(entity.Login, entity.Password)?.DalToSimplifiedUserApi();
            if (user.LoginError == 0)
            {
                user.Token = TokenService.Instance.EncodeToken(user);
                return Ok(user);
            }
            else if (user.LoginError == 1)
                return Problem("Login doesnt exist", statusCode: (int)HttpStatusCode.NotFound);
            else if (user.LoginError == 2)
                return Problem("Password doesnt match with the current login", statusCode: (int)HttpStatusCode.NotFound);
            else
                return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
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
        public IActionResult Create([FromBody] UserDetailed user)
        {
            switch (_userRepo.Create(user.ApiToDal()))
            {

                case (DBErrors.Success):
                    user.Id = _userRepo.getIdWithNN(user.NationalNumber);
                    if (!(user.Contacts is null))
                    {
                        foreach (Contact C in user.Contacts)
                        {
                            switch (_contactRepo.LinkEntityWithUser(C.Id, user.Id))
                            {
                                case (DBErrors.Success):
                                    break;
                                case (DBErrors.LinkAlreadyExist):
                                    return Problem("A link is already active between theses id's.", statusCode: (int)HttpStatusCode.BadRequest);
                                default:
                                    break;
                            }
                        }
                    }
                    IEnumerable<D.Status> statusList = StatusCodeService.Deserialize(user.StatusCode);
                    if (!(statusList is null))
                    {
                        foreach (D.Status s in statusList)
                        {
                            switch (_statusRepo.LinkEntityWithUser(s.Id, user.Id))
                            {
                                case (DBErrors.Success):
                                    break;
                                case (DBErrors.LinkAlreadyExist):
                                    return Problem("A link is already active between theses id's.", statusCode: (int)HttpStatusCode.BadRequest);
                                default:
                                    break;
                            }
                        }
                    }
                    return Ok();
                case (DBErrors.ClassId_NotFound):
                    return Problem("A valid ClassId is needed.", statusCode: (int)HttpStatusCode.BadRequest);
                case (DBErrors.NationalNumber_Exist):
                    return Problem("NationalNumber already exist.", statusCode: (int)HttpStatusCode.BadRequest);
                case (DBErrors.NullExeption):
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                case (DBErrors.StartDate_Birthdate_Error):
                    return Problem("Birthdate should be lower than StartDate.", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] UserDetailed user)
        {
            switch (_userRepo.Update(user.ApiToDal()))
            {
                case (DBErrors.Success):
                    _userRepo.UnlinkUserFromContacts(user.Id);
                    if (!(user.Contacts is null))
                    {
                        foreach (Contact C in user.Contacts)
                        {
                            switch (_contactRepo.LinkEntityWithUser(C.Id, user.Id))
                            {
                                case (DBErrors.Success):
                                    break;
                                case (DBErrors.LinkAlreadyExist):
                                    return Problem("A link is already active between theses id's.", statusCode: (int)HttpStatusCode.BadRequest);
                                default:
                                    break;
                            }
                        }
                    }
                    _userRepo.UnlinkUserFromStatus(user.Id);
                    IEnumerable<D.Status> statusList = StatusCodeService.Deserialize(user.StatusCode);
                    if (!(statusList is null))
                    {
                        foreach (D.Status s in statusList)
                        {
                            switch (_statusRepo.LinkEntityWithUser(s.Id, user.Id))
                            {
                                case (DBErrors.Success):
                                    break;
                                case (DBErrors.LinkAlreadyExist):
                                    return Problem("A link is already active between theses id's.", statusCode: (int)HttpStatusCode.BadRequest);
                                default:
                                    break;
                            }
                        }
                    }
                    return Ok();
                case (DBErrors.ClassId_NotFound):
                    return Problem("A valid ClassId is needed.", statusCode: (int)HttpStatusCode.BadRequest);
                case (DBErrors.NationalNumber_Exist):
                    return Problem("NationalNumber already exist.", statusCode: (int)HttpStatusCode.BadRequest);
                case (DBErrors.UserId_NotFound):
                    return Problem("A valid UserId is needed.", statusCode: (int)HttpStatusCode.BadRequest);
                case (DBErrors.NullExeption):
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                case (DBErrors.StartDate_Birthdate_Error):
                    return Problem("Birthdate should be lower than StartDate.", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        [HttpDelete]
        [Route("Delete/{Id}")]  // * POSTMAN OK * //
        public IActionResult Delete(int Id)
        {
            switch (_userRepo.Delete(Id))
            {
                case (DBErrors.Success):
                    _userRepo.UnlinkUserFromContacts(Id);
                    _userRepo.UnlinkUserFromLunches(Id);
                    _userRepo.UnlinkUserFromStatus(Id);
                    return Ok();
                case (DBErrors.UserId_NotFound):
                    return Problem("A valid UserId is needed.", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            List<UserDetailed> userList = _userRepo.GetAll().Select(x => x.DalToDetailedUserApi()).ToList();
            if (!(userList is null))
            {
                foreach (UserDetailed user in userList)
                {
                    user.Contacts = _contactRepo.GetByUserId(user.Id).Select(x => x.DalToApi());
                    if (user.Contacts.Count() == 0)
                        user.Contacts = null;
                    //add les lunchs
                }
                return Ok(userList);
            }
            else
                return NotFound();

        }


        [HttpGet]
        [Route("getbyId/{Id}")]
        public IActionResult GetById(int Id) /*POSTMAN OK*/
        {
            UserDetailed user = _userRepo.GetById(Id).DalToDetailedUserApi();
            if (!(user is null))
            {
                user.Contacts = _contactRepo.GetByUserId(Id).Select(x => x.DalToApi());
                if (user.Contacts.Count() == 0)
                    user.Contacts = null;
                //add les lunchs
                return Ok(user);
            }
            else
                return NotFound();

        }


        [HttpGet]
        [Route("getByStatusId/{Id}")]

        public IActionResult GetByStatusId(int Id) /*POSTMAN OK*/
        {
            List<UserDetailed> userList = _userRepo.GetAllByStatusId(Id).Select(x => x.DalToDetailedUserApi()).ToList();
            if (!(userList is null))
            {
                foreach (UserDetailed user in userList)
                {
                    user.Contacts = _contactRepo.GetByUserId(user.Id).Select(x => x.DalToApi());
                    if (user.Contacts.Count() == 0)
                        user.Contacts = null;
                    //add les lunchs
                }
                return Ok(userList);
            }
            else
                return NotFound();
        }


        [HttpGet]
        [Route("getByClassId/{Id}")]

        public IActionResult GetByClassId(int Id) /*POSTMAN OK*/
        {
            List<UserDetailed> userList = _userRepo.GetAllByClassId(Id).Select(x => x.DalToDetailedUserApi()).ToList();
            if (!(userList is null))
            {
                foreach (UserDetailed user in userList)
                {
                    user.Contacts = _contactRepo.GetByUserId(user.Id).Select(x => x.DalToApi());
                    if (user.Contacts.Count() == 0)
                        user.Contacts = null;
                    //add les lunchs
                }
                return Ok(userList);
            }
            else
                return NotFound();
        }

    }
}
