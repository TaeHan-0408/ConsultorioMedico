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
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Cita> Citas { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Medico>();

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(m => m.IdMedico); // Explicitly set IdMedico as the primary key
            });
            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(m => m.IdPaciente); // Explicitly set IdPaciente as the primary key
            });
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(m => m.IdCita); // Explicitly set IdCita as the primary key
                entity.HasOne(c => c.Medico)
               .WithMany(m => m.Citas).HasForeignKey(c => c.IdMedico);

                entity.HasOne(c => c.Paciente).WithMany(c => c.Citas).HasForeignKey(c => c.IdPaciente); 

            });

            modelBuilder.Entity<Medic>(entity =>
            {
                entity.HasNoKey();
            });
            /*
            modelBuilder.Entity<Citas>()
            .HasOne(c => c.Citas)
            .WithOne(m => m.Medico)
            .HasForeignKey<Citas>(c => c.IdMedico);
        */
        }
    }
}
