using API.Attributes;
using API.Mappers;
using API.Models.Enumerations;
using API.Models.Lunch;
using API.Models.Users;
using DAL.Enumerations;
using DAL.Models;
using DAL.Services.Repositories.Lunches;
using DAL.Services.Repositories.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : Controller
    {
        private ContactRepository _contactRepo;
        private LunchRepository _lunchRepo;
        private UserRepository _userRepo;
        /*mettre l'event*/

        public SchoolController(ContactRepository contactRepo, LunchRepository lunchRepo, UserRepository userRepo)
        {
            _contactRepo = contactRepo;
            _lunchRepo = lunchRepo;
            _userRepo = userRepo;
        }



        [HttpPost]
        [Route("CreateLunch")]
        public IActionResult CreateLunch([FromBody] Lunch entity) /*POSTMAN OK*/
        {
            switch (_lunchRepo.Create(entity))
            {
                case (DBErrors.Success):
                    return Ok();
                case (DBErrors.NullExeption):
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }



        [HttpPut]
        [Route("UpdateLunch")] /*POSTMAN OK*/
        public IActionResult UpdateLunch([FromBody] Lunch entity)
        {
            switch (_lunchRepo.Update(entity))
            {
                case (DBErrors.Success):
                    return Ok();
                case (DBErrors.NullExeption):
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }



        [HttpDelete]
        [Route("DeleteLunch/{Id}")] /*POSTMAN OK*/
        public IActionResult DeleteLunch(int Id)
        {
            _lunchRepo.UnlinkEntityFromALL(Id);
            _lunchRepo.Delete(Id);
            return Ok();
        }



        [HttpGet]
        [Route("GetLunches")] /*POSTMAN OK*/
        public IActionResult GetLunches()
        {
            List<LunchDetailed> detailedLunches = _lunchRepo.GetAll().Select(x => x.DaltoDetailedApi()).ToList();
            if (!(detailedLunches is null))
            {
                foreach (LunchDetailed l in detailedLunches)
                {
                    l.Users = _userRepo.GetAllByLunchId(l.Id).Select(x => x.DalToForEntitiesApi());
                    if (l.Users.Count() == 0)
                        l.Users = null;
                }                
                return Ok(detailedLunches);
            }
            else
                return NotFound();

        }


        [HttpGet]
        [Route("GetLunchesByUserId/{userId}")] /*POSTMAN OK*/
        public IActionResult GetLunchesByUserId(int userId)
        {
            List<LunchSimplified> userLunches = _lunchRepo.GetByUserId(userId).Select(x => x.DaltoSimplifiedApi()).ToList();
            if (!(userLunches is null))
            {
                return Ok(userLunches);
            }
            else
                return NotFound();
        }

        [HttpGet]
        [Route("GetLunchById/{lunchId}")] /*POSTMAN OK*/
        public IActionResult GetLunchById(int lunchId)
        {
            LunchSimplified lunch = _lunchRepo.GetById(lunchId).DaltoSimplifiedApi();
            if (!(lunch is null))
                return Ok(lunch);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("linkLunchUser")] /*POSTMAN OK*/
        public IActionResult LinkLunchToUser([FromBody] LinkWithEntity link)
        {
            switch (_lunchRepo.LinkEntityWithUser(link.EntityId, link.UserId))
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
        [Route("unlinkLunchFromUser")] /*POSTMAN OK*/
        public IActionResult UnlinkLunchFromUser([FromBody] LinkWithEntity link)
        {
            _lunchRepo.UnlinkEntityFromUser(link.EntityId, link.UserId);
            return Ok();
        }
    }
}
