using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using API.Mappers;
using API.Models.Commons;
using API.Models.Contacts;
using API.Models.Users;
using DAL.Enumerations;
using DAL.Models;
using DAL.Services.Repositories.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private ContactRepository _contactRepo;
        private UserRepository _userRepo;
        public ContactController(ContactRepository contactRepo, UserRepository userRepo)
        {
            _contactRepo = contactRepo;
            _userRepo = userRepo;
        }


        [HttpPost] /*POSTMAN OK*/
        public IActionResult Create([FromBody] DAL.Models.Contact contact)
        {
            switch (_contactRepo.Create(contact))
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


        [HttpPut] /*POSTMAN OK*/
        public IActionResult Update([FromBody] DAL.Models.Contact contact)
        {
            switch (_contactRepo.Update(contact))
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

        [HttpDelete("{Id}")] /*POSTMAN OK*/
        public IActionResult Delete(int Id)
        {
            _contactRepo.UnlinkEntityFromALL(Id);
            _contactRepo.Delete(Id);
            return Ok();
        }



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

        [HttpDelete]
        [Route("unlinkFromUser")] /*POSTMAN OK*/
        public IActionResult UnlinkFromUser([FromBody] LinkWithEntity link)
        {
            _contactRepo.UnlinkEntityFromUser(link.EntityId, link.UserId);
            return Ok();
        }

    }
}
