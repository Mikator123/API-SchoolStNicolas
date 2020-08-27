using DAL.Enumerations;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Utils
{
    public static class DeserializeStatusCode
    {
        public static IEnumerable<Status> Deserialize(int statusCode)
        {
            List<Status> statusList = new List<Status>();
            int Status = statusCode;
            if (Status > 8)
            {
                statusList.Add(new Status()
                {
                    Id = 4,
                    Name = "Admin",
                });
                Status -= -8;
            }
            if (Status > 4)
            {
                statusList.Add(new Status()
                {
                    Id = 3,
                    Name = "Manager",
                });
                Status -= -4;
            }
            if (Status > 2)
            {
                statusList.Add(new Status()
                {
                    Id = 2,
                    Name = "Professor",
                });
                Status -= -2;
            }
            if (Status == 1)
            {
                statusList.Add(new Status()
                {
                    Id = 2,
                    Name = "Student",
                });
            }
            return statusList;


        }

    }
}
