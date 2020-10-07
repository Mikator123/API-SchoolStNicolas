using API.Mappers;
using API.Models.Commons;
using API.Models.Lunch;
using DAL.Enumerations;
using D = DAL.Models.RelativeToSchool;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DAL.Services.Repositories.RelativeToSchool;
using DAL.Services.Repositories.RelativeToUser;

namespace API.Controllers.SchoolStuff
{
    [Route("api/[controller]")]
    [ApiController]
    public class LunchController : Controller
    {
        private LunchRepository _lunchRepo;
        private UserRepository _userRepo;

        public LunchController(LunchRepository lunchRepo, UserRepository userRepo)
        {
            _lunchRepo = lunchRepo;
            _userRepo = userRepo;
        }



        [HttpPost] /*POSTMAN OK*/
        public IActionResult Create([FromBody] D.Lunch entity)
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



        [HttpPut] /*POSTMAN OK*/
        public IActionResult Update([FromBody] D.Lunch entity)
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


        [HttpDelete("{Id}")] /*POSTMAN OK*/
        public IActionResult Delete(int Id)
        {
            _lunchRepo.UnlinkEntityFromALL(Id);
            _lunchRepo.Delete(Id);
            return Ok();
        }



        [HttpGet] /*POSTMAN OK*/
        public IActionResult Get()
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


        [HttpGet("{lunchId}")] /*POSTMAN OK*/
        public IActionResult GetLunchById(int lunchId)
        {
            Lunch lunch = _lunchRepo.GetById(lunchId).DaltoSimplifiedApi();
            if (!(lunch is null))
                return Ok(lunch);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("linkToUser")] /*POSTMAN OK*/
        public IActionResult LinkToUser([FromBody] LinkWithEntity link)
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
        [Route("unlinkFromUser")] /*POSTMAN OK*/
        public IActionResult UnlinkFromUser([FromBody] LinkWithEntity link)
        {
            _lunchRepo.UnlinkEntityFromUser(link.EntityId, link.UserId);
            return Ok();
        }
    }
}
