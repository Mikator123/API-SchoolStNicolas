using API.Attributes;
using API.Mappers;
using API.Models.Classes;
using API.Models.DistancialTest;
using API.Models.Users;
using API.Models.WorkingProfile;
using API.Utils.Token.Roles;
using DAL.Enumerations;
using DAL.Models.RelativeToClass;
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
    public class WorkingProfileDocumentController : ControllerBase
    {
        private WorkingProfileDocumentRepository _workDocRepo;
        public WorkingProfileDocumentController(WorkingProfileDocumentRepository workDocRepo)
        {
            _workDocRepo = workDocRepo;
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor)]
        [HttpPost]/*POSTMAN OK*/
        public IActionResult Create([FromBody] WorkingProfileDocument doc )
        {
            switch(_workDocRepo.Create(doc.ApiToDal()))
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
        public IActionResult Update([FromBody] WorkingProfileDocument doc)
        {
            switch (_workDocRepo.Update(doc.ApiToDal()))
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
        [HttpDelete("{Id}")]/*POSTMAN OK*/
        public IActionResult Delete(int Id)
        {
            _workDocRepo.Delete(Id);
            return Ok();
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet]/*POSTMAN OK*/
        public IActionResult Get()
        {
            IEnumerable<WorkingProfileDocument> docs = _workDocRepo.GetAll().Select(x => x.DalToApi());
            if (!(docs is null))
                return Ok(docs);
            else
                return NotFound();
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet("{Id}")]/*POSTMAN OK*/
        public IActionResult GetById(int Id)
        {
            WorkingProfileDocument doc = _workDocRepo.GetById(Id).DalToApi();
            if (!(doc is null))
                return Ok(doc);
            else
                return NotFound();
        }
    }
}
