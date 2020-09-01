using API.Mappers;
using API.Models.Classes;
using API.Models.Users;
using DAL.Enumerations;
using DAL.Services.Repositories.Classes;
using DAL.Services.Repositories.Users;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : Controller
    {
        private ClassRepository _classRepo;
        private UserRepository _userRepo;

        public ClassController(ClassRepository classRepo, UserRepository userRepo)
        {
            _classRepo = classRepo;
            _userRepo = userRepo;
        }


        [HttpPost] /*POSTMAN OK*/
        public IActionResult Create([FromBody] Class studentClass)
        {
            switch(_classRepo.Create(studentClass.ApiToDal()))
            {
                case DBErrors.Success:
                    return Ok();
                case DBErrors.Name_Exist:
                    return Problem("This name already exist.", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.YearCategoryId_NotFound:
                    return Problem("A valid CategoryId is needed.", statusCode: (int)HttpStatusCode.NotFound);
                case DBErrors.NullExeption:
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        [HttpPut] /*POSTMAN OK*/
        public IActionResult Update([FromBody] Class studentClass)
        {
            switch(_classRepo.Update(studentClass.ApiToDal()))
            {
                case DBErrors.Success:
                    return Ok();
                case DBErrors.Name_Exist:
                    return Problem("This name already exist.", statusCode: (int)HttpStatusCode.BadRequest);
                case DBErrors.YearCategoryId_NotFound:
                    return Problem("A valid CategoryId is needed.", statusCode: (int)HttpStatusCode.NotFound);
                case DBErrors.NullExeption:
                    return Problem("A mandatory field does not support 'null' value or is missing", statusCode: (int)HttpStatusCode.BadRequest);
                default:
                    return Problem("?", statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        [HttpDelete("{Id}")]  /*POSTMAN OK*/
        public IActionResult Delete(int Id)
        {
            List<UserForEntities> classUsers = _userRepo.GetAllByClassId(Id).Select(x => x.DalToForEntitiesApi()).ToList();
            foreach (UserForEntities U in classUsers)
            {
                U.ClassId = 0;
                _userRepo.Update(U.DalToApi());
            }
            _classRepo.Delete(Id);
            return Ok();
        }

        [HttpGet] /*POSTMAN OK*/
        public IActionResult Get()
        {
            List<ClassDetailed> classList = _classRepo.GetAll().Select(x => x.DaltoDetailedApi()).ToList();
            if (!(classList is null))
            {
                foreach (ClassDetailed CD in classList)
                {
                    CD.Users = _userRepo.GetAllByClassId(CD.Id).Select(x => x.DalToForEntitiesApi());
                    if (CD.Users.Count() == 0)
                        CD.Users = null;
                }
                return Ok(classList);
            }
            else
                return NotFound();
        }

        [HttpGet("{Id}")] /*POSTMAN OK*/
        public IActionResult GetById(int Id)
        {
            ClassDetailed studentClass = _classRepo.GetById(Id).DaltoDetailedApi();
            if (!(studentClass is null))
            {
                studentClass.Users = _userRepo.GetAllByClassId(studentClass.Id).Select(x => x.DalToForEntitiesApi());
                if (studentClass.Users.Count() == 0)
                    studentClass.Users = null;
                return Ok(studentClass);
            }
            else
                return NotFound();
        }


        [Route("byCategoryId/{Id}")] /*POSTMAN OK*/
        public IActionResult GetByCategoryId (int Id)
        {
            List<ClassDetailed> classList = _classRepo.GetByCategoryId(Id).Select(x => x.DaltoDetailedApi()).ToList();
            if (!(classList is null))
            {
                foreach (ClassDetailed CD in classList)
                {
                    CD.Users = _userRepo.GetAllByClassId(CD.Id).Select(x => x.DalToForEntitiesApi());
                    if (CD.Users.Count() == 0)
                        CD.Users = null;
                }
                return Ok(classList);
            }
            else
                return NotFound();
        }

         
        
    }
}
