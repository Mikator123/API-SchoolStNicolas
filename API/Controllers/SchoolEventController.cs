﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DAL.Enumerations;
using DAL.Models;
using DAL.Services.Repositories.SchoolInfos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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

        [HttpDelete] /*POSTMAN OK*/
        public IActionResult Delete([FromBody] SchoolEvent schoolEvent)
        {
            _eventRepo.Delete(schoolEvent);
            return Ok();
        }

        [HttpGet] /*POSTMAN OK*/
        public IActionResult Get()
        {
            IEnumerable<SchoolEvent> events = _eventRepo.GetAll();
            if (!(events is null))
                return Ok(events);
            else
                return NotFound();
        }

        [Route("NotActive")]/*POSTMAN OK*/
        public IActionResult GetNotActive()
        {
            IEnumerable<SchoolEvent> events = _eventRepo.GetNotActive();
            if (!(events is null))
                return Ok(events);
            else
                return NotFound();
        }

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
