using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuarezJhoel_PruebaProgreso1.Models;

namespace SuarezJhoel_PruebaProgreso1.Data
{
    public class SuarezJhoel_PruebaProgreso1Context : DbContext
    {
        public SuarezJhoel_PruebaProgreso1Context (DbContextOptions<SuarezJhoel_PruebaProgreso1Context> options)
            : base(options)
        {
        }

        public DbSet<SuarezJhoel_PruebaProgreso1.Models.JSuarez> JSuarez { get; set; } = default!;
        public DbSet<SuarezJhoel_PruebaProgreso1.Models.Celular> Celular { get; set; } = default!;
    }
}
