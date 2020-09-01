using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Users;
using DAL.Models;
using DAL.Services.Repositories.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private StatusRepository _statusRepo;
        public StatusController(StatusRepository statusRepo)
        {
            _statusRepo = statusRepo;
        }

        [HttpGet] /*POSTMAN OK*/
        public IActionResult Get()
        {
            List<Status> statusList = _statusRepo.GetAll().ToList();
            if (!(statusList is null))
                return Ok(statusList);
            else
                return NotFound();
        }

        [HttpGet("{Id}")] /*POSTMAN OK*/
        public IActionResult GetById(int Id)
        {
            Status status = _statusRepo.GetById(Id);
            if (!(status is null))
                return Ok(status);
            else
                return NotFound();
        }
    }
}
