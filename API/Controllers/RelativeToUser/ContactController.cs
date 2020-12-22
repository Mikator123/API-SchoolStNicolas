using System.Collections.Generic;
using System.Linq;
using System.Net;
using API.Attributes;
using API.Mappers;
using API.Models.Commons;
using API.Models.Contacts;
using API.Utils.Token.Roles;
using DAL.Enumerations;
using DAL.Services.Repositories.RelativeToUser;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.RelativeToUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactRepository _contactRepo;
        private readonly UserRepository _userRepo;
        public ContactController(ContactRepository contactRepo, UserRepository userRepo)
        {
            _contactRepo = contactRepo;
            _userRepo = userRepo;
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
        [HttpPost] /*POSTMAN OK*/
        public IActionResult Create([FromBody] Contact contact)
        {
            switch (_contactRepo.Create(contact.ApitoDal()))
            {
                case DBErrors.Success:
                    return Ok();
                case DBErrors.NationalNumber_Exist:
                    return Problem("NationalNumber already exist.", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.NullExeption:
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
        [HttpPut] /*POSTMAN OK*/
        public IActionResult Update([FromBody] Contact contact)
        {
            switch (_contactRepo.Update(contact.ApitoDal()))
            {
                case DBErrors.Success:
                    return Ok();
                case DBErrors.NationalNumber_Exist:
                    return Problem("NationalNumber already exist.", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.NullExeption:
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }


        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
        [HttpDelete("{Id}")] /*POSTMAN OK*/
        public IActionResult Delete(int Id)
        {
            _contactRepo.UnlinkEntityFromALL(Id);
            _contactRepo.Delete(Id);
            return Ok();
        }


        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet] /*POSTMAN OK*/
        public IActionResult Get()
        {
            List<ContactDetailed> contactList = _contactRepo.GetAll().Select(x => x.DalToDetailedApi()).ToList();
            if (!(contactList is null))
            {
                foreach (ContactDetailed C in contactList)
                {
                    C.Users = _userRepo.GetAllByContactId(C.Id).Select(x => x.DalToForEntitiesApi());
                    if (C.Users.Count() == 0)
                        C.Users = null;
                }
                return Ok(contactList);
            }
            else
                return NotFound();
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet("{Id}")] /*POSTMAN OK*/
        public IActionResult GetbyId(int Id)
        {
            ContactDetailed contact = _contactRepo.GetById(Id).DalToDetailedApi();
            if (!(contact is null))
            {
                contact.Users = _userRepo.GetAllByContactId(contact.Id).Select(x => x.DalToForEntitiesApi());
                if (contact.Users.Count() == 0)
                    contact.Users = null;
                return Ok(contact);
            }
            else
                return NotFound();
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
        [HttpPost]
        [Route("linkToUser")] /*POSTMAN OK*/
        public IActionResult LinkToUser([FromBody] LinkWithEntity link)
        {
            switch(_contactRepo.LinkEntityWithUser(link.EntityId, link.UserId))
            {
                case DBErrors.Success:
                    return Ok();
                case DBErrors.LinkAlreadyExist:
                    return Problem("A link is already active between theses id's.", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
        [HttpDelete]
        [Route("unlinkFromUser")] /*POSTMAN OK*/
        public IActionResult UnlinkFromUser([FromBody] LinkWithEntity link)
        {
            _contactRepo.UnlinkEntityFromUser(link.EntityId, link.UserId);
            return Ok();
        }

    }
}
