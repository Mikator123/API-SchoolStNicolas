using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services.IRepositories
{
    public interface IManyToManyRepository<TEnum>
    {
        TEnum LinkEntityWithUser(int entityId, int userId);
        TEnum UnlinkEntityFromUser(int entityId, int userId);
        TEnum UnlinkEntityFromALL(int entityId);
    }
}
