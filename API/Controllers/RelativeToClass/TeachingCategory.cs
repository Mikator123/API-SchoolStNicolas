using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Services.Repositories.RelativeToClass;
using Microsoft.AspNetCore.Http;
using D = DAL.Models.RelativeToClass;
using Microsoft.AspNetCore.Mvc;
using DAL.Enumerations;
using System.Net;

namespace API.Controllers.RelativeToClass
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingCategory : ControllerBase
    {
        private TeachingCategoryRepository _categoryRepo;
        public TeachingCategory(TeachingCategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpPost]/*POSTMAN OK*/
        public IActionResult Create([FromBody] D.TeachingCategory cat)
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

        [HttpPut]/*POSTMAN OK*/
        public IActionResult Update([FromBody] D.TeachingCategory cat)
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

        [HttpDelete("{Id}")]/*POSTMAN OK*/
        public IActionResult Delete(int Id)
        {
            _categoryRepo.Delete(Id);
            return Ok();
        }

        [HttpGet]/*POSTMAN OK*/
        public IActionResult Get()
        {
            IEnumerable<D.TeachingCategory> list = _categoryRepo.GetAll();
            if (!(list is null))
                return Ok(list);
            else
                return NotFound();
              
        }

        [HttpGet("{Id}")]/*POSTMAN OK*/
        public IActionResult GetById(int Id)
        {
            D.TeachingCategory cat = _categoryRepo.GetById(Id);
            if (!(cat is null))
                return Ok(cat);
            else
                return NotFound();
        }
    }
}
