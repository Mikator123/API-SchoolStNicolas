using System.Collections.Generic;
using DAL.Models.RelativeToClass;
using DAL.Services.Repositories.RelativeToClass;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.RelativeToClass
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolYearCategoryController : ControllerBase
    {
        private SchoolYearCategoryRepository _yearCatRepo;
        public SchoolYearCategoryController(SchoolYearCategoryRepository yearCatRepo)
        {
            _yearCatRepo = yearCatRepo;
        }

        [HttpGet] /*POSTMAN OK*/
        public IActionResult Get()
        {
            IEnumerable<SchoolYearCategory> list = _yearCatRepo.GetAll();
            if (!(list is null))
                return Ok(list);
            else
                return NotFound();
        }

        [HttpGet("{Id}")] /*POSTMAN OK*/
        public IActionResult GetById(int Id)
        {
            SchoolYearCategory cat = _yearCatRepo.GetById(Id);
            if (!(cat is null))
                return Ok(cat);
            else
                return NotFound();
        }
    }
}
