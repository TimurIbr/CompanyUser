using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
 
namespace CompanyUser.Models
{
    public class CompanyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}