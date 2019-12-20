using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StatSportsTechnicalProject.Models;

namespace StatSportsTechnicalProject.Data
{
    public class PlayersContext : DbContext
    {
        public PlayersContext (DbContextOptions<PlayersContext> options)
            : base(options)
        {
        }

        public DbSet<Players> Players { get; set; }
    }
}