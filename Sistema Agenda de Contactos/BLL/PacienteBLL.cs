using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EL;

namespace BLL
{
    public class PacienteBLL
    {
        public void Insertar(Paciente paciente)
        {
            using (var context = new ClinicaDentalContext())
            {
                context.Pacientes.Add(paciente);
                context.SaveChanges();
            }
        }

        public void Actualizar(Paciente paciente)
        {
            using (var context = new ClinicaDentalContext())
            {
                var existente = context.Pacientes.Find(paciente.Id);
                if (existente != null)
                {
                    existente.Nombre = paciente.Nombre;
                    existente.Apellido = paciente.Apellido;
                    existente.Telefono = paciente.Telefono;
                    existente.Correo = paciente.Correo;
                    existente.FechaNacimiento = paciente.FechaNacimiento;
                    existente.HistorialClinico = paciente.HistorialClinico;
                    context.SaveChanges();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var context = new ClinicaDentalContext())
            {
                var paciente = context.Pacientes.Find(id);
                if (paciente != null)
                {
                    context.Pacientes.Remove(paciente);
                    context.SaveChanges();
                }
            }
        }

        public List<Paciente> ObtenerTodos()
        {
            using (var context = new ClinicaDentalContext())
            {
                return context.Pacientes.ToList();
            }
        }
    }
}
