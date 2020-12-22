using DAL.Enumerations;
using DAL.Models;
using DAL.Models.RelativeToSchool;
using DAL.Services.IRepositories;
using DAL.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ToolBoxDB;

namespace DAL.Services.Repositories.RelativeToSchool
{

    public class SchoolRuleRepository : ICRUDRepository<SchoolRule, DBErrors>
    {
        private readonly Connection _connection;
        public SchoolRuleRepository(Connection connection)
        {
            _connection = connection;
        }
        public DBErrors Create(SchoolRule entity)
        {
            Command cmd = new Command("CreateSchoolRule",true);
            cmd.AddParameter("name", entity.Name);
            cmd.AddParameter("description", entity.Description);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch(SqlException ex)
            {
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                if (ex.Message.Contains("UK_SchoolRules_RuleDescritption"))
                    return DBErrors.Name_Exist;
                else
                    return DBErrors.NotKnowedError;

            }
            return DBErrors.Success;
        }

        public DBErrors Delete(int Id)
        {
            Command cmd = new Command("DeleteSchoolRule", true);
            cmd.AddParameter("id", Id);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }

        public IEnumerable<SchoolRule> GetAll()
        {
            Command cmd = new Command("SELECT * FROM SchoolRules");
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalRule());
        }

        public SchoolRule GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM SchoolRules WHERE Id = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalRule()).SingleOrDefault();
        }

        public IEnumerable<SchoolRule> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public DBErrors Update(SchoolRule entity)
        {
            Command cmd = new Command("UpdateSchoolRule", true);
            cmd.AddParameter("id", entity.Id);
            cmd.AddParameter("name", entity.Name);
            cmd.AddParameter("description", entity.Description);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                if (ex.Message.Contains("UK_SchoolRules_RuleDescritption"))
                    return DBErrors.Name_Exist;
                else
                    return DBErrors.NotKnowedError;

            }
            return DBErrors.Success;
        }
    }
}
