using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyUser.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
    }
    public class UserJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }

        public void Initialize(User user, Company companyVal)
        {
            Id = user.Id;
            Name = user.Name;
            Company = companyVal;
        }
    }
}
