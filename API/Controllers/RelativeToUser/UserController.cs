using System.Collections.Generic;
using System.Linq;
using System.Net;
using API.Mappers;
using API.Models.Users;
using API.Utils;
using DAL.Enumerations;
using D = DAL.Models;
using Microsoft.AspNetCore.Mvc;
using A = API.Models.Contacts;
using ToolBox.SecurityToken;
using DAL.Services.Repositories.RelativeToUser;
using DAL.Services.Repositories.RelativeToSchool;
using DAL.Services.Repositories.RelativeToClass;
using DAL.Models.RelativeToUser;
using API.Attributes;
using Microsoft.AspNetCore.Authorization;
using API.Utils.Token.Roles;

namespace API.Controllers.RelativeToUser
{

    [Route("api/[controller]")]
    [ApiController]
    //[AuthRequired(RoleName.Admin + "|" + RoleName.Professor)]
    public class UserController : Controller
    {
        private UserRepository _userRepo;
        private ContactRepository _contactRepo;
        private UserStatusRepository _statusRepo;
        private LunchRepository _lunchRepo;
        private TrimestrialInfoRepository _trimestrialRepo;
        public UserController( TrimestrialInfoRepository trimestrialRepo, UserRepository userRepo, ContactRepository contactRepo, UserStatusRepository statusRepo, LunchRepository lunchRepo, ITokenService token)
        {
            _userRepo = userRepo;
            _contactRepo = contactRepo;
            _statusRepo = statusRepo;
            _lunchRepo = lunchRepo;
            _trimestrialRepo = trimestrialRepo;
        }


        [HttpPost] /*POSTMAN OK*/
        public IActionResult Create([FromBody] UserDetailed user)
        {
            switch (_userRepo.Create(user.ApiToDal()))
            {

                case (DBErrors.Success):
                    user.Id = _userRepo.getIdWithNN(user.NationalNumber);
                    if (!(user.Contacts is null))
                    {
                        foreach (A.Contact C in user.Contacts)
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
                    IEnumerable<Status> statusList = StatusCodeService.Deserialize(user.StatusCode);
                    if (!(statusList is null))
                    {
                        foreach (Status s in statusList)
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

        [HttpPut] /*POSTMAN OK*/
        public IActionResult Update([FromBody] UserDetailed user)
        {
            switch (_userRepo.Update(user.ApiToDal()))
            {
                case (DBErrors.Success):
                    _userRepo.UnlinkUserFromContacts(user.Id);
                    if (!(user.Contacts is null))
                    {
                        foreach (A.Contact C in user.Contacts)
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
                    IEnumerable<Status> statusList = StatusCodeService.Deserialize(user.StatusCode);
                    if (!(statusList is null))
                    {
                        foreach (Status s in statusList)
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


        [HttpDelete("{Id}")]  /*POSTMAN OK*/
        public IActionResult Delete(int Id)
        {
            
            _userRepo.UnlinkUserFromContacts(Id);
            _userRepo.UnlinkUserFromLunches(Id);
            _userRepo.UnlinkUserFromStatus(Id);
            _userRepo.Delete(Id);
            return Ok();
        }


        
        [HttpGet]
        public IActionResult Get() /*POSTMAN OK*/
        {
            List<UserDetailed> userList = _userRepo.GetAll().Select(x => x.DalToDetailedUserApi()).ToList();
            if (!(userList is null))
            {
                foreach (UserDetailed user in userList)
                {
                    user.Contacts = _contactRepo.GetByUserId(user.Id).Select(x => x.DalToForUserApi());
                    if (user.Contacts.Count() == 0)
                        user.Contacts = null;
                    user.Lunches = _lunchRepo.GetByUserId(user.Id).Select(x => x.DaltoSimplifiedApi());
                    if (user.Lunches.Count() == 0)
                        user.Lunches = null;
                }
                return Ok(userList);
            }
            else
                return NotFound();
        }

        


        [HttpGet("{Id}")]
        public IActionResult GetById(int Id) /*POSTMAN OK*/
        {
            UserDetailed user = _userRepo.GetById(Id).DalToDetailedUserApi();
            if (!(user is null))
            {
                user.Contacts = _contactRepo.GetByUserId(Id).Select(x => x.DalToForUserApi());
                if (user.Contacts.Count() == 0)
                    user.Contacts = null;
                user.Lunches = _lunchRepo.GetByUserId(user.Id).Select(x => x.DaltoSimplifiedApi());
                if (user.Lunches.Count() == 0)
                    user.Lunches = null;
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
                    user.Contacts = _contactRepo.GetByUserId(user.Id).Select(x => x.DalToForUserApi());
                    if (user.Contacts.Count() == 0)
                        user.Contacts = null;
                    user.Lunches = _lunchRepo.GetByUserId(user.Id).Select(x => x.DaltoSimplifiedApi());
                    if (user.Lunches.Count() == 0)
                        user.Lunches = null;
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
                    user.Contacts = _contactRepo.GetByUserId(user.Id).Select(x => x.DalToForUserApi());
                    if (user.Contacts.Count() == 0)
                        user.Contacts = null;

                    user.Lunches = _lunchRepo.GetByUserId(user.Id).Select(x => x.DaltoSimplifiedApi());
                    if (user.Lunches.Count() == 0)
                        user.Lunches = null;
                }
                return Ok(userList);
            }
            else
                return NotFound();
        }

        [HttpGet]
        [Route("getMails/{classId}")] /*POSTMAN OK*/

        public IActionResult GetMails(int classId) 
        {
            List<UserForEmails> userList = _userRepo.GetAllByClassId(classId).Select(x => x.DalToForEmailsUserApi()).Where(x => x.StatusCode == 1).ToList();
            if (!(userList is null))
            {
                foreach (UserForEmails user in userList)
                {
                    user.Contacts = _contactRepo.GetByUserId(user.Id).Select(x => x.DalToForEmailUserApi());
                    if (user.Contacts.Count() == 0)
                        user.Contacts = null;

                }
                return Ok(userList);
            }
            else
                return NotFound();
        }

    }
}
