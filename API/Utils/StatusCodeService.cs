using D = DAL.Models;
using System.Collections.Generic;

namespace API.Utils
{
    public static class StatusCodeService
    {
        public static IEnumerable<D.Status> Deserialize(int statusCode)
        {
            List<D.Status> statusList = new List<D.Status>();
            int Status = statusCode;
            while (Status > 0)
            {
                if (Status >= 8)
                {
                    statusList.Add(new D.Status()
                    {
                        Id = 4,
                        Name = "Admin",
                    });
                    Status = Status - 8;
                }
                if (Status >= 4)
                {
                    statusList.Add(new D.Status()
                    {
                        Id = 3,
                        Name = "Manager",
                    });
                    Status = Status - 4;
                }
                if (Status >= 2)
                {
                    statusList.Add(new D.Status()
                    {
                        Id = 2,
                        Name = "Professor",
                    });
                    Status = Status - 2;
                }
                if (Status == 1)
                {
                    statusList.Add(new D.Status()
                    {
                        Id = 1,
                        Name = "Student",
                    });
                    Status = Status - 1;
                }
            }
            return statusList;
        }

        public static int Serialize(D.Status S)
        {
            int statusCode = 0;

            if (S.Name == "Student")
                statusCode += 1;

            if (S.Name == "Professor")
                statusCode += 2;

            if (S.Name == "Manager")
                statusCode += 4;

            if (S.Name == "Admin")
                statusCode += 8;

            return statusCode;

        }

        public static IEnumerable<string> DeserializeToStrings(int statusCode)
        {
            List<string> statusList = new List<string>();
            int Status = statusCode;
            while (Status > 0)
            {
                if (Status >= 8)
                {
                    statusList.Add("Admin");
                    Status -= - 8;
                }
                if (Status >= 4)
                {
                    statusList.Add("Manager");
                    Status -= - 4;
                }
                if (Status >= 2)
                {
                    statusList.Add("Professor");
                    Status -= - 2;
                }
                if (Status == 1)
                {
                    statusList.Add("Student");
                    Status -= - 1;
                }
            }
            return statusList;
        }

    }
}
