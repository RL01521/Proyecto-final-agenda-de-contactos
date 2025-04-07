using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace DAL
{
   
        public class ClinicaDentalContext : DbContext
        {
            public ClinicaDentalContext()
                : base("name=ClinicaDentalDbContext")
            {
            }

            public DbSet<Paciente> Pacientes { get; set; }
            public DbSet<Empleado> Empleados { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Contacto>()
                    .Map<Paciente>(m => m.Requires("ContactoType").HasValue("Paciente"))
                    .Map<Empleado>(m => m.Requires("ContactoType").HasValue("Empleado"));

                modelBuilder.Entity<Paciente>()
                    .Property(p => p.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                modelBuilder.Entity<Paciente>()
                    .Property(p => p.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                modelBuilder.Entity<Paciente>()
                    .Property(p => p.Correo)
                    .IsOptional()
                    .HasMaxLength(100);

                modelBuilder.Entity<Empleado>()
                    .Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                modelBuilder.Entity<Empleado>()
                    .Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                modelBuilder.Entity<Empleado>()
                    .Property(e => e.Correo)
                    .IsOptional()
                    .HasMaxLength(100);
            }
        }
}
