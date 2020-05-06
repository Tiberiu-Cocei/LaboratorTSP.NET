using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace Asp_Cocei_Tiberiu_Rp.Data
{
    public class Asp_Cocei_Tiberiu_RpContext : DbContext
    {
        public Asp_Cocei_Tiberiu_RpContext (DbContextOptions<Asp_Cocei_Tiberiu_RpContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Movie> Movie { get; set; }
    }
}
