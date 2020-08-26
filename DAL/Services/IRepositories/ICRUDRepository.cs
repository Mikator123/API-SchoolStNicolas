using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services.IRepositories
{
    public interface ICRUDRepository<Tentity>
    {
        int Create(Tentity entity);
        int Update(Tentity entity);
        int Delete(int Id);
        Tentity GetById(int Id);
        IEnumerable<Tentity> GetAll();
    }
}
