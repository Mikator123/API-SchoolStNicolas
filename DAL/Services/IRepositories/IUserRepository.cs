using DAL.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services.IRepositories
{
    public interface IUserRepository<Tentity>
    {
        Tentity Login(string login, string password);
        UserCodes Create(Tentity entity);
        UserCodes Update(Tentity entity);
        UserCodes Delete(int Id);
        UserCodes UnlinkUserFromLunches (int Id);
        UserCodes UnlinkUserFromContacts(int Id);
        UserCodes UnlinkUserFromStatus(int Id);
        Tentity GetById(int Id);
        IEnumerable<Tentity> GetAll();
        IEnumerable<Tentity> GetAllStudents();
        IEnumerable<Tentity> GetAllProfessors();
        IEnumerable<Tentity> GetAllManagers();
        IEnumerable<Tentity> GetAllAdmins();
        IEnumerable<Tentity> GetAllProfessorsByClassId(int classId);
        IEnumerable<Tentity> GetAllStudentsByClassId(int classId);

    }
}
