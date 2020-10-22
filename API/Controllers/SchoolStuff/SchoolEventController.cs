using System.Collections.Generic;
using System.Net;
using API.Attributes;
using API.Utils.Token.Roles;
using DAL.Enumerations;
using DAL.Models.RelativeToSchool;
using DAL.Services.Repositories.RelativeToSchool;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.SchoolStuff
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolEventController : ControllerBase
    {
        private SchoolEventRepository _eventRepo;
        public SchoolEventController(SchoolEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }


        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
        [HttpPost] /*POSTMAN OK*/
        public IActionResult Create([FromBody] SchoolEvent schoolEvent)
        {
            switch (_eventRepo.Create(schoolEvent))
            {
                case DBErrors.Success:
                    return Ok();
                case DBErrors.NullExeption:
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.Name_Exist:
                    return Problem("This name already exist.", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }


        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
        [HttpPut]  /*POSTMAN OK*/
        public IActionResult Update([FromBody] SchoolEvent schoolEvent)
        {
            switch (_eventRepo.Update(schoolEvent))
            {
                case DBErrors.Success:
                    return Ok();
                case DBErrors.NullExeption:
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.Name_Exist:
                    return Problem("This name already exist.", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }


        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
        [HttpDelete] /*POSTMAN OK*/
        public IActionResult Delete([FromBody] SchoolEvent schoolEvent)
        {
            _eventRepo.Delete(schoolEvent);
            return Ok();
        }


        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet] /*POSTMAN OK*/
        public IActionResult Get()
        {
            IEnumerable<SchoolEvent> events = _eventRepo.GetAll();
            if (!(events is null))
                return Ok(events);
            else
                return NotFound();
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
        [Route("NotActive")]/*POSTMAN OK*/
        public IActionResult GetNotActive()
        {
            IEnumerable<SchoolEvent> events = _eventRepo.GetNotActive();
            if (!(events is null))
                return Ok(events);
            else
                return NotFound();
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet("{Id}")]/*POSTMAN OK*/
        public IActionResult GetById(int Id)
        {
            SchoolEvent schoolEvent = _eventRepo.GetById(Id);
            if (!(schoolEvent is null))
                return Ok(schoolEvent);
            else
                return NotFound();
        }

    
    }
}
