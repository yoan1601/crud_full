using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using crud_full.Models;

namespace crud_full.Data
{
    public class crud_fullContext : DbContext
    {
        public crud_fullContext (DbContextOptions<crud_fullContext> options)
            : base(options)
        {
        }

        public DbSet<crud_full.Models.Employe> Employe { get; set; } = default!;
        public DbSet<crud_full.Models.Departement> Departement { get; set; } = default!;
    }
}
