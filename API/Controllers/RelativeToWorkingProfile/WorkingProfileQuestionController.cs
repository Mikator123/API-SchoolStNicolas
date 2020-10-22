using API.Attributes;
using API.Mappers;
using API.Models.Classes;
using API.Models.DistancialTest;
using API.Models.Users;
using API.Utils.Token.Roles;
using DAL.Enumerations;
using DAL.Services.Repositories.RelativeToClass;
using DAL.Services.Repositories.RelativeToUser;
using DAL.Services.Repositories.RelativeToWorkingProfile;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace API.Controllers.RelativeToWorkingProfile
{
    [Route("api/[controller]")]
    [ApiController]

    public class WorkingProfileQuestionController : ControllerBase
    {
        private WorkingProfileQuestionRepository _testRepo;
        public WorkingProfileQuestionController(WorkingProfileQuestionRepository testRepo)
        {
            _testRepo = testRepo;
        }


        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor)]
        [HttpPost]/*POSTMAN OK*/
        public IActionResult Create([FromBody] WorkingProfileQuestion test)
        {
            switch(_testRepo.Create(test.ApiToDal()))
            {
                case DBErrors.Success:
                    return Ok();
                case DBErrors.TeachingCategoryId_NotFound:
                    return Problem("A valid TeachingCategoryId is needed.", statusCode: (int)HttpStatusCode.NotFound);
                case DBErrors.YearCategoryId_NotFound:
                    return Problem("A valid YearCategoryId is needed.", statusCode: (int)HttpStatusCode.NotFound);
                case DBErrors.IncorrectNumber:
                    return Problem("A Trimester should be between 1 and 3.", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.NullExeption:
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                 default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }


        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor)]
        [HttpPut]/*POSTMAN OK*/
        public IActionResult Update([FromBody] WorkingProfileQuestion test)
        {
            switch (_testRepo.Update(test.ApiToDal()))
            {
                case DBErrors.Success:
                    return Ok();
                case DBErrors.TeachingCategoryId_NotFound:
                    return Problem("A valid TeachingCategoryId is needed.", statusCode: (int)HttpStatusCode.NotFound);
                case DBErrors.YearCategoryId_NotFound:
                    return Problem("A valid YearCategoryId is needed.", statusCode: (int)HttpStatusCode.NotFound);
                case DBErrors.IncorrectNumber:
                    return Problem("A Trimester should be between 0 and 4.", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.NullExeption:
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }


        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor)]
        [HttpDelete("{Id}")]/*POSTMAN OK*/
        public IActionResult Delete(int Id)
        {
            _testRepo.Delete(Id);
            return Ok();
        }


        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet]/*POSTMAN OK*/
        public IActionResult Get()
        {
            IEnumerable<WorkingProfileQuestion> tests = _testRepo.GetAll().Select(x => x.DalToAPI());
            if (!(tests is null))
                return Ok(tests);
            else
                return NotFound();
        }


        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet("{Id}")]/*POSTMAN OK*/
        public IActionResult GetById(int Id)
        {
            WorkingProfileQuestion test = _testRepo.GetById(Id).DalToAPI();
            if (!(test is null))
                return Ok(test);
            else
                return NotFound();
        }




    }
}
