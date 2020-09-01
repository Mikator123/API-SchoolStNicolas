using System;
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
    public class SchoolRuleController : ControllerBase
    {
        private SchoolRuleRepository _ruleRepo;
        public SchoolRuleController(SchoolRuleRepository ruleRepo)
        {
            _ruleRepo = ruleRepo;
        }

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

        [HttpDelete("{Id}")] /*POSTMAN OK*/
        public IActionResult Delete(int Id)
        {
            _ruleRepo.Delete(Id);
            return Ok();
        }

        [HttpGet] /*POSTMAN OK*/
        public IActionResult Get()
        {
            IEnumerable<SchoolRule> rules = _ruleRepo.GetAll();
            if (!(rules is null))
                return Ok(rules);
            else
                return NotFound();
        }

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
