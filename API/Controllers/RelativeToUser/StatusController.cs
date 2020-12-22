using System.Collections.Generic;
using System.Linq;
using API.Attributes;
using API.Utils.Token.Roles;
using DAL.Models.RelativeToUser;
using DAL.Services.Repositories.RelativeToUser;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.RelativeToUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly UserStatusRepository _statusRepo;
        public StatusController(UserStatusRepository statusRepo)
        {
            _statusRepo = statusRepo;
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
        [HttpGet] /*POSTMAN OK*/
        public IActionResult Get()
        {
            List<Status> statusList = _statusRepo.GetAll().ToList();
            if (!(statusList is null))
                return Ok(statusList);
            else
                return NotFound();
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
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
