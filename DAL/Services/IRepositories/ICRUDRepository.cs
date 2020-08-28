using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services.IRepositories
{
    public interface ICRUDRepository<Tentity, TEnum>
    {

        TEnum Create(Tentity entity);
        TEnum Update(Tentity entity);
        TEnum Delete(int Id);
        Tentity GetById(int Id);
        IEnumerable<Tentity> GetByUserId(int userId);
        IEnumerable<Tentity> GetAll();
    }
}
