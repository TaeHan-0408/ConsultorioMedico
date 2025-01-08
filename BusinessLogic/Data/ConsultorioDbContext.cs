using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Data
{
    public class ConsultorioDbContext : DbContext
    {
        public ConsultorioDbContext(DbContextOptions<ConsultorioDbContext> options) : base(options) { }

        public DbSet<Medico> Medico { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Medico>().Ignore(m => m.Medic);

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(m => m.IdMedico); // Explicitly set IdMedico as the primary key
            });

            modelBuilder.Entity<Medic>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
