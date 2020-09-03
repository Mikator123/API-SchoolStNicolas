using DAL.Enumerations;
using DAL.Models;
using DAL.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using ToolBoxDB;
using DAL.Services.Mappers;
using System.Linq;
using DAL.Models.RelativeToClass;

namespace DAL.Services.Repositories.RelativeToClass
{
    public class SchoolYearCategoryRepository : ICRUDRepository<SchoolYearCategory, DBErrors>
    {
        private Connection _connection;
        public SchoolYearCategoryRepository(Connection connection)
        {
            _connection = connection;
        }
        public DBErrors Create(SchoolYearCategory entity)
        {
            throw new NotImplementedException("Not needed.");
        }

        public DBErrors Delete(int Id)
        {
            throw new NotImplementedException("Not needed.");
        }

        public IEnumerable<SchoolYearCategory> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [SchoolYearCategoryNames]");
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalYearCategory());
        }

        public SchoolYearCategory GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM [SchoolYearCategoryNames] WHERE Id = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalYearCategory()).SingleOrDefault();
        }

        public IEnumerable<SchoolYearCategory> GetByUserId(int userId)
        {
            throw new NotImplementedException("Not needed.");
        }

        public DBErrors Update(SchoolYearCategory entity)
        {
            throw new NotImplementedException("Not needed.");
        }
    }
}
