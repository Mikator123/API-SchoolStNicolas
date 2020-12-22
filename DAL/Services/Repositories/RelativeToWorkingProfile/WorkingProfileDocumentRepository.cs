using DAL.Enumerations;
using DAL.Models.RelativeToClass;
using DAL.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ToolBoxDB;
using DAL.Services.Mappers;
using System.Linq;
using DAL.Models.RelativeToWorkingProfile;

namespace DAL.Services.Repositories.RelativeToWorkingProfile
{
    public class WorkingProfileDocumentRepository : ICRUDRepository<WorkingProfileDocument, DBErrors>
    {
        private readonly Connection _connection;
        public WorkingProfileDocumentRepository(Connection connection)
        {
            _connection = connection;

        }
        public DBErrors Create(WorkingProfileDocument entity)
        {
            Command cmd = new Command("CreateWorkingProfileDocument", true);
            cmd.AddParameter("description", entity.Description);
            cmd.AddParameter("link", entity.Link);
            cmd.AddParameter("name", entity.Name);
            cmd.AddParameter("categoryId", entity.CategoryId);
            cmd.AddParameter("schoolYear", entity.SchoolYear);
            cmd.AddParameter("trimester", entity.Trimester);
            cmd.AddParameter("schoolyearNameId", entity.SchoolYearCategoryId);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("[[FK_WorkingProfileDocuments_Categories]]"))
                    return DBErrors.TeachingCategoryId_NotFound;
                if (ex.Message.Contains("[[FK_WorkingProfileDocuments_SchoolYearCategoryNames]]"))
                    return DBErrors.YearCategoryId_NotFound;
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                if (ex.Message.Contains("[CK_WorkingProfileDocument_Trimester]"))
                    return DBErrors.IncorrectNumber;
                else
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }

        public DBErrors Delete(int Id)
        {
            Command cmd = new Command("DeleteWorkingProfileDocument", true);
            cmd.AddParameter("Id", Id);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
            
        }

        public IEnumerable<WorkingProfileDocument> GetAll()
        {
            Command cmd = new Command("Select * FROM WorkingProfileDocuments");
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalWorkDoc());
            
        }

        public WorkingProfileDocument GetById(int Id)
        {
            Command cmd = new Command("Select * FROM WorkingProfileDocuments WHERE Id = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalWorkDoc()).SingleOrDefault();
        }

        public IEnumerable<WorkingProfileDocument> GetByUserId(int userId)
        {
            throw new NotImplementedException("NotNeeded");
        }

        public DBErrors Update(WorkingProfileDocument entity)
        {
            Command cmd = new Command("UpdateWorkingProfileDocument", true);
            cmd.AddParameter("Id", entity.Id);
            cmd.AddParameter("description", entity.Description);
            cmd.AddParameter("link", entity.Link);
            cmd.AddParameter("name", entity.Name);
            cmd.AddParameter("categoryId", entity.CategoryId);
            cmd.AddParameter("schoolYear", entity.SchoolYear);
            cmd.AddParameter("trimester", entity.Trimester);
            cmd.AddParameter("schoolyearNameId", entity.SchoolYearCategoryId);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("[[FK_WorkingProfileDocuments_Categories]]"))
                    return DBErrors.TeachingCategoryId_NotFound;
                if (ex.Message.Contains("[[FK_WorkingProfileDocuments_SchoolYearCategoryNames]]"))
                    return DBErrors.YearCategoryId_NotFound;
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                else
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }
    }
}
