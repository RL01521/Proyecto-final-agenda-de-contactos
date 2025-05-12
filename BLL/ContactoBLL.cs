using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using EL;

namespace BLL
{
    public class ContactoBLL : IDisposable
    {
        private readonly ClinicaDentalContext _context;

        public ContactoBLL()
        {
            _context = new ClinicaDentalContext(); 
        }

        // Método para insertar un nuevo contacto
        public void Insertar(Contacto contacto)
        {
            _context.Contactos.Add(contacto);
            _context.SaveChanges(); 
        }

        // Método para actualizar un contacto existente en la base de datos
        public void Actualizar(Contacto contacto)
        {
            var existente = _context.Contactos.Find(contacto.Id); // Buscar el contacto por su ID
            if (existente != null)
            {
                existente.Nombre = contacto.Nombre;
                existente.Apellido = contacto.Apellido;
                existente.Telefono = contacto.Telefono;
                existente.Correo = contacto.Correo;

                // Si ambos son pacientes, actualiza también los campos específicos
                if (existente is Paciente pacienteExistente && contacto is Paciente pacienteNuevo)
                {
                    pacienteExistente.FechaNacimiento = pacienteNuevo.FechaNacimiento;
                    pacienteExistente.HistorialClinico = pacienteNuevo.HistorialClinico;
                }

                _context.SaveChanges();
            }
        }

        // Método para eliminar un contacto de la base de datos según su ID
        public void Eliminar(int id)
        {
            var contacto = _context.Contactos.Find(id);
            if (contacto != null) 
            {
                _context.Contactos.Remove(contacto); // Eliminar
                _context.SaveChanges(); 
            }
        }

        // Version 2 Eliminar descartada
        //public void EliminarPaciente(int id)
        //{
        //    // Llama a la capa de acceso a datos (DAL)
        //    new DAL.ContactoDAL().Eliminar(id); // O el nombre correcto según tu estructura
        //}

        // Método para obtener un contacto específico por su ID
        public Contacto ObtenerPorId(int id)
        {
            return _context.Contactos.Find(id); // Devolver el contacto encontrado
        }

        // Método para obtener una lista de todos los contactos
        public List<Contacto> ObtenerTodos()
        {
            return _context.Contactos.ToList(); // Obtener la lista completa de contactos
        }

        public List<Contacto> Buscar(string filtro)
        {
            // 1) Si filtro es un número, búsqueda exacta por ID
            if (int.TryParse(filtro, out int id))
            {
                var contacto = _context.Contactos
                                       .AsNoTracking()
                                       .FirstOrDefault(c => c.Id == id);
                return contacto != null
                    ? new List<Contacto> { contacto }
                    : new List<Contacto>();
            }

            // 2) Si no es número, búsqueda de texto en los otros campos
            return _context.Contactos
                           .AsNoTracking()
                           .Where(c =>
                               c.Nombre.Contains(filtro) ||
                               c.Apellido.Contains(filtro) ||
                               c.Correo.Contains(filtro) ||
                               c.Telefono.Contains(filtro))
                           .ToList();
        }

        // Método para obtener solo los contactos que son pacientes
        public List<Paciente> ObtenerTodosPacientes()
        {
            return _context.Contactos.OfType<Paciente>().ToList(); // Filtrar y devolver pacientes
        }

        // Método para obtener solo los contactos que son empleados
        public List<Empleado> ObtenerTodosEmpleados()
        {
            return _context.Contactos.OfType<Empleado>().ToList(); // Filtrar y devolver empleados
        }

        public void Dispose()
        {
            _context.Dispose(); // Liberar el contexto de la base de datos
        }
    }
}