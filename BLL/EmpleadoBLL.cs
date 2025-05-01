using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EL;

namespace BLL
{
    public class EmpleadoBLL : IDisposable
    {
        private readonly ClinicaDentalContext _context;

        public EmpleadoBLL()
        {
            _context = new ClinicaDentalContext();
        }

        // Método para insertar un nuevo empleado
        public void Insertar(Empleado empleado)
        {
            _context.Contactos.Add(empleado); // Agregar el empleado a la colección de contactos
            _context.SaveChanges(); // Guardar cambios en la base de datos
        }

        // Método para actualizar un empleado existente en la base de datos
        public void Actualizar(Empleado empleado)
        {
            var existente = _context.Contactos.Find(empleado.Id); // Buscar el empleado por su ID
            if (existente != null && existente is Empleado) // Si el empleado existe y es del tipo correcto
            {
                // Actualizar los valores del empleado existente
                var empleadoExistente = (Empleado)existente;
                empleadoExistente.Nombre = empleado.Nombre;
                empleadoExistente.Apellido = empleado.Apellido;
                empleadoExistente.Telefono = empleado.Telefono;
                empleadoExistente.Correo = empleado.Correo;
                empleadoExistente.CargoEmpleado = empleado.CargoEmpleado;
                empleadoExistente.FechaContratacion = empleado.FechaContratacion;
                _context.SaveChanges(); // Guardar cambios en la base de datos
            }
        }

        // Método para eliminar un empleado de la base de datos según su ID
        public void Eliminar(int id)
        {
            var empleado = _context.Contactos.Find(id);
            if (empleado != null && empleado is Empleado)
            {
                _context.Contactos.Remove(empleado); // Eliminar
                _context.SaveChanges(); // Guardar cambios en la base de datos
            }
        }

        // Método para obtener un empleado específico por su ID
        public Empleado ObtenerPorId(int id)
        {
            return _context.Contactos.Find(id) as Empleado; // Devolver el empleado encontrado
        }

        // Método para obtener una lista de todos los empleados
        public List<Empleado> ObtenerTodos()
        {
            return _context.Contactos.OfType<Empleado>().ToList(); // Obtener la lista completa de empleados
        }

        public void Dispose()
        {
            _context.Dispose(); // Liberar el contexto de la base de datos
        }
    }
}