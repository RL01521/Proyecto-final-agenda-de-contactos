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
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configuración de herencia TPH
            modelBuilder.Entity<Contacto>()
                .Map<Paciente>(m => m.Requires("TipoContacto").HasValue("Paciente"))
                .Map<Empleado>(m => m.Requires("TipoContacto").HasValue("Empleado"));

            // Configuraciones comunes
            modelBuilder.Entity<Contacto>()
                .Property(c => c.Nombre).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Contacto>()
                .Property(c => c.Apellido).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Contacto>()
                .Property(c => c.Telefono).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Contacto>()
                .Property(c => c.Correo).HasMaxLength(100);
        

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
            
            modelBuilder.Entity<Contacto>()
                .Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Contacto>()
                .Property(c => c.Apellido)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Contacto>()
                .Property(c => c.Telefono)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Contacto>()
                .Property(c => c.Correo)
                .IsOptional()
                .HasMaxLength(100);
            }
        }
}
