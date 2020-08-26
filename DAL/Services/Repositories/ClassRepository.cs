using DAL.Models;
using DAL.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ToolBoxDB;

namespace DAL.Services.Repositories
{
    public class ClassRepository : ICRUDRepository<Class>
    {
        private Connection _connection;

        public ClassRepository(Connection connection)
        {
            _connection = connection;
        }

        public int Create(Class entity)
        {
            Command cmd = new Command("CreateClass", true);
            cmd.AddParameter("name", entity.Name);
            cmd.AddParameter("description", entity.Description);
            cmd.AddParameter("schoolYear", entity.SchoolYear);
            cmd.AddParameter("schoolYearCategoryId", entity.SchoolYearCategoryId);
            return _connection.ExecuteNonQuery(cmd);
        }

        public int Delete(int Id)
        {
            Command cmd = new Command("DeleteClass", true);
            cmd.AddParameter("id", Id);
            return _connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<Class> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Classes");
            return _connection.ExecuteReader(cmd, r => new Class()
            {
                Id = (int)r["Id"],
                Name = r["ClassName"].ToString(),
                Description = r["ClassDescription"].ToString(),
                SchoolYear = (int)r["SchoolYear"],
                SchoolYearCategoryId = (int)r["SchoolYearCategoryId"]
            });
        }

        public Class GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM Classes WHERE Id = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, r => new Class()
            {
                Id = (int)r["Id"],
                Name = r["ClassName"].ToString(),
                Description = r["ClassDescription"].ToString(),
                SchoolYear = (int)r["SchoolYear"],
                SchoolYearCategoryId = (int)r["SchoolYearCategoryId"]
            }).SingleOrDefault();
        }

        public IEnumerable<Class> GetByCategoryId(int Id)
        {
            Command cmd = new Command("SELECT * FROM Classes WHERE SchoolYearCategoryId = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, r => new Class()
            {
                Id = (int)r["Id"],
                Name = r["ClassName"].ToString(),
                Description = r["ClassDescription"].ToString(),
                SchoolYear = (int)r["SchoolYear"],
                SchoolYearCategoryId = (int)r["SchoolYearCategoryId"]
            });
        }

        public int Update(Class entity)
        {
            Command cmd = new Command("UpdateClass", true);
            cmd.AddParameter("id", entity.Id);
            cmd.AddParameter("name", entity.Name);
            cmd.AddParameter("description", entity.Description);
            cmd.AddParameter("schoolYear", entity.SchoolYear);
            cmd.AddParameter("schoolYearCategoryId", entity.SchoolYearCategoryId);
            return _connection.ExecuteNonQuery(cmd);
        }


    }
}
