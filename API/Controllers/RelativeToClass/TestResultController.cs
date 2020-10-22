using System.Collections.Generic;
using DAL.Services.Repositories.RelativeToClass;
using Microsoft.AspNetCore.Mvc;
using DAL.Enumerations;
using System.Net;
using DAL.Models.RelativeToClass;
using API.Utils.Token.Roles;
using API.Attributes;

namespace API.Controllers.RelativeToClass
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestResultController : ControllerBase
    {
        private TestResultRepository _testRepo;
        public TestResultController(TestResultRepository testRepo)
        {
            _testRepo = testRepo;
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor)]
        [HttpPost]
        public IActionResult Create([FromBody] TestResult test)
        {
            switch(_testRepo.Create(test))
            {
                case DBErrors.Success:
                    return Ok();
                case DBErrors.UserId_NotFound:
                    return Problem("A valid UserId is needed.", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.TeachingCategoryId_NotFound:
                    return Problem("A valid TeachingCategoryId is needed.", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.NullExeption:
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.IncorrectNumber:
                    return Problem("A result should be between 0 to 20.", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor)]
        [HttpPut]
        public IActionResult Update([FromBody] TestResult test)
        {
            switch (_testRepo.Update(test))
            {
                case DBErrors.Success:
                    return Ok();
                case DBErrors.UserId_NotFound:
                    return Problem("A valid UserId is needed.", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.TeachingCategoryId_NotFound:
                    return Problem("A valid TeachingCategoryId is needed.", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.NullExeption:
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.IncorrectNumber:
                    return Problem("A result should be between 0 to 20.", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor)]
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _testRepo.Delete(Id);
            return Ok();
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<TestResult> tests = _testRepo.GetAll();
            if (!(tests is null))
                return Ok(tests);
            else
                return NotFound();
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            TestResult test = _testRepo.GetById(Id);
            if (!(test is null))
                return Ok(test);
            else return NotFound();
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet]
        [Route("byStudentId/{Id}")]
        public IActionResult GetByUserId(int Id)
        {
            IEnumerable<TestResult> tests = _testRepo.GetByUserId(Id);
            if (!(tests is null))
                return Ok(tests);
            else
                return NotFound();
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet]
        [Route("byCategoryId/{Id}")]
        public IActionResult GetByCategoryId(int Id)
        {
            IEnumerable<TestResult> tests = _testRepo.GetByUserId(Id);
            if (!(tests is null))
                return Ok(tests);
            else
                return NotFound();
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet]
        [Route("byClassId/{Id}")]
        public IActionResult GetByClassId(int Id)
        {
            IEnumerable<TestResult> tests = _testRepo.GetByClassId(Id);
            if (!(tests is null))
                return Ok(tests);
            else
                return NotFound();
        }
    }
}
