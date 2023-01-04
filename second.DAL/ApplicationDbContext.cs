using Microsoft.EntityFrameworkCore;
using second.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Robot> Robot { get; set; }
    }
}
