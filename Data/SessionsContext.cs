using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StatSportsTechnicalProject.Models;

namespace StatSportsTechnicalProject.Data
{
    public class SessionsContext : DbContext
    {
        public SessionsContext (DbContextOptions<SessionsContext> options)
            : base(options)
        {
        }

        public DbSet<Sessions> Sessions { get; set; }
    }
}
