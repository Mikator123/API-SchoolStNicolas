using DAL.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services.IRepositories
{
    public interface IUserRepository<Tentity>
    {
        Tentity Login(string login, string password);
        DBErrors Create(Tentity entity);
        DBErrors Update(Tentity entity);
        DBErrors Delete(int Id);
        DBErrors UnlinkUserFromLunches (int Id);
        DBErrors UnlinkUserFromContacts(int Id);
        DBErrors UnlinkUserFromStatus(int Id);
        Tentity GetById(int Id);
        IEnumerable<Tentity> GetAll();
        IEnumerable<Tentity> GetAllByStatusId(int statusId);
        IEnumerable<Tentity> GetAllByClassId(int classId);
        IEnumerable<Tentity> GetAllByLunchId(int lunchId);
    }
}
