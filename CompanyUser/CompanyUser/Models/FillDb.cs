using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyUser.Models
{
    public class FillDb
    {
        public static void Initialize(CompanyContext context)
        {
            if (!context.Companies.Any())
            {
                context.Companies.AddRange(
                    new Company
                    {
                        //Id = 1,
                        Name = "Default",
                    },
                 new Company
                 {
                    // Id = 2,
                     Name = "KPMG",
                 }
                );
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                       // Id = 1,
                        Name = "Admin",
                        CompanyId = 1
                    },
                    new User
                    {
                      //  Id = 2,
                        Name = "Alexander",
                        CompanyId = 2
                    },
                    new User
                    {
                      //  Id = 3,
                        Name = "Tim",
                        CompanyId = 2
                    }
                );
                context.SaveChanges();
            }
        }
    }
}