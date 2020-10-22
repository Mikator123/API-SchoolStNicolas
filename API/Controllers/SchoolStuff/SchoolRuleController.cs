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
    public class SchoolRuleController : ControllerBase
    {
        private SchoolRuleRepository _ruleRepo;
        public SchoolRuleController(SchoolRuleRepository ruleRepo)
        {
            _ruleRepo = ruleRepo;
        }


        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
        [HttpPost] /*POSTMAN OK*/
        public IActionResult Create([FromBody] SchoolRule rule)
        {
            switch(_ruleRepo.Create(rule))
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
        [HttpPut] /*POSTMAN OK*/
        public IActionResult Update([FromBody] SchoolRule rule)
        {
            switch (_ruleRepo.Update(rule))
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
        [HttpDelete("{Id}")] /*POSTMAN OK*/
        public IActionResult Delete(int Id)
        {
            _ruleRepo.Delete(Id);
            return Ok();
        }


        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet] /*POSTMAN OK*/
        public IActionResult Get()
        {
            IEnumerable<SchoolRule> rules = _ruleRepo.GetAll();
            if (!(rules is null))
                return Ok(rules);
            else
                return NotFound();
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet("{Id}")] /*POSTMAN OK*/
        public IActionResult GetById(int Id)
        {
            SchoolRule rule = _ruleRepo.GetById(Id);
            if (!(rule is null))
                return Ok(rule);
            else
                return NotFound();
        }
    }
}
