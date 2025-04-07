using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using DAL;

namespace BLL
{
    public class EmpleadoBLL
    {
        public void Insertar(Empleado empleado)
        {
            using (var context = new ClinicaDentalContext())
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
            }
        }

        public void Actualizar(Empleado empleado)
        {
            using (var context = new ClinicaDentalContext())
            {
                var existente = context.Empleados.Find(empleado.Id);
                if (existente != null)
                {
                    existente.Nombre = empleado.Nombre;
                    existente.Apellido = empleado.Apellido;
                    existente.Telefono = empleado.Telefono;
                    existente.Correo = empleado.Correo;
                    existente.CargoEmpleado = empleado.CargoEmpleado;
                    existente.FechaContratacion = empleado.FechaContratacion;
                    context.SaveChanges();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var context = new ClinicaDentalContext())
            {
                var empleado = context.Empleados.Find(id);
                if (empleado != null)
                {
                    context.Empleados.Remove(empleado);
                    context.SaveChanges();
                }
            }
        }

        public List<Empleado> ObtenerTodos()
        {
            using (var context = new ClinicaDentalContext())
            {
                return context.Empleados.ToList();
            }
        }
    }
}
