using System.Collections.Generic;
using System.Linq;
using System.Net;
using DAL.Enumerations;
using DAL.Models.RelativeToUser;
using DAL.Services.Repositories.RelativeToClass;
using DAL.Services.Repositories.RelativeToUser;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.RelativeToUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrimestrialInfoController : ControllerBase
    {
        private TrimestrialInfoRepository _trimRepo;
        public TrimestrialInfoController(TrimestrialInfoRepository trimRepo)
        {
            _trimRepo = trimRepo;
        }

        [HttpPost] /*POSTMAN OK*/
        public IActionResult Create([FromBody] TrimestrialInfo info)
        {
            switch(_trimRepo.Create(info))
            {
                case DBErrors.Success:
                    return Ok();
                case DBErrors.NullExeption:
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.UserId_NotFound:
                    return Problem("A valid UserId is needed.", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.YearQuarter_NotFound:
                    return Problem("A Correct YearQuarter is needed (1-2-3).", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        [HttpPut] /*POSTMAN OK*/
        public IActionResult Update([FromBody] TrimestrialInfo info)
        {
            switch(_trimRepo.Update(info))
            {
                case DBErrors.Success:
                    return Ok();
                case DBErrors.NullExeption:
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.UserId_NotFound:
                    return Problem("A valid UserId is needed.", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.YearQuarter_NotFound:
                    return Problem("A Correct YearQuarter is needed (1-2-3).", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }


        [HttpDelete("{Id}")] /*POSTMAN OK*/
        public IActionResult Delete(int Id)
        {
            _trimRepo.Delete(Id);
            return Ok();
        }

        [HttpGet("{Id}")] /*POSTMAN OK*/
        public IActionResult GetById(int Id)
        {
            TrimestrialInfo info = _trimRepo.GetById(Id);
            if (!(info is null))
                return Ok(info);
            else
                return NotFound();
        }

        [Route("GetbyuserId/{Id}")] /*POSTMAN OK*/
        public IActionResult GetByUserId(int Id)
        {
            List<TrimestrialInfo> infoList = _trimRepo.GetByUserId(Id).ToList();
            if (!(infoList is null))
                return Ok(infoList);
            else
                return NotFound();
        }
    }
}
