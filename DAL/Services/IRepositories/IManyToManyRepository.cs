using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services.IRepositories
{
    public interface IManyToManyRepository
    {
        int LinkEntityWithUser(int entityId, int userId);
        int UnlinkEntityFromUser(int entityId, int userId);
        int UnlinkEntityFromALL(int entityId);
    }
}
