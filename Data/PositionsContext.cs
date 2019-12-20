using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StatSportsTechnicalProject.Models;

namespace StatSportsTechnicalProject.Data
{
    public class PositionsContext : DbContext
    {
        public PositionsContext(DbContextOptions<PositionsContext> options)
            : base(options)
        {
        }

        public DbSet<playerpositions> playerpositions { get; set; }
    }
}