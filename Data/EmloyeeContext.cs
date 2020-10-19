using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

    public class EmloyeeContext : DbContext
    {
        public EmloyeeContext (DbContextOptions<EmloyeeContext> options)
            : base(options)
        {
        }

        public DbSet<Employe> Employe { get; set; }
    }
