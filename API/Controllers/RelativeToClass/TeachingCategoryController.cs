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
    public class TeachingCategoryController : ControllerBase
    {
        private readonly TeachingCategoryRepository _categoryRepo;
        public TeachingCategoryController(TeachingCategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
        [HttpPost]/*POSTMAN OK*/
        public IActionResult Create([FromBody] TeachingCategory cat)
        {
            switch(_categoryRepo.Create(cat))
            {
                case DBErrors.Success:
                    return Ok();
                case DBErrors.Name_Exist:
                    return Problem("This name already exist.", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.NullExeption:
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
        [HttpPut]/*POSTMAN OK*/
        public IActionResult Update([FromBody] TeachingCategory cat)
        {
            switch (_categoryRepo.Update(cat))
            {
                case DBErrors.Success:
                    return Ok();
                case DBErrors.Name_Exist:
                    return Problem("This name already exist.", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.NullExeption:
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager)]
        [HttpDelete("{Id}")]/*POSTMAN OK*/
        public IActionResult Delete(int Id)
        {
            _categoryRepo.Delete(Id);
            return Ok();
        }


        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet]/*POSTMAN OK*/
        public IActionResult Get()
        {
            IEnumerable<TeachingCategory> list = _categoryRepo.GetAll();
            if (!(list is null))
                return Ok(list);
            else
                return NotFound();
              
        }

        [AuthRequired(RoleName.Admin + "|" + RoleName.Manager + "|" + RoleName.Professor + "|" + RoleName.Student)]
        [HttpGet("{Id}")]/*POSTMAN OK*/
        public IActionResult GetById(int Id)
        {
            TeachingCategory cat = _categoryRepo.GetById(Id);
            if (!(cat is null))
                return Ok(cat);
            else
                return NotFound();
        }
    }
}
