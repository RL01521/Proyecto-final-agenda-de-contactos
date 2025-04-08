using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EL;

namespace BLL
{
    public class ContactoBLL
    {
        public void Insertar(Contacto contacto)
        {
            using (var context = new ClinicaDentalContext())
            {
                context.Contactos.Add(contacto);
                context.SaveChanges();
            }
        }

        public void Actualizar(Contacto contacto)
        {
            using (var context = new ClinicaDentalContext())
            {
                var existente = context.Contactos.Find(contacto.Id);
                if (existente != null)
                {
                    context.Entry(existente).CurrentValues.SetValues(contacto);
                    context.SaveChanges();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var context = new ClinicaDentalContext())
            {
                var contacto = context.Contactos.Find(id);
                if (contacto != null)
                {
                    context.Contactos.Remove(contacto);
                    context.SaveChanges();
                }
            }
        }

        public Contacto ObtenerPorId(int id)
        {
            using (var context = new ClinicaDentalContext())
            {
                return context.Contactos.Find(id);
            }
        }

        public List<Contacto> ObtenerTodos()
        {
            using (var context = new ClinicaDentalContext())
            {
                return context.Contactos.ToList();
            }
        }

        public List<Paciente> ObtenerTodosPacientes()
        {
            using (var context = new ClinicaDentalContext())
            {
                return context.Contactos.OfType<Paciente>().ToList();
            }
        }

        public List<Empleado> ObtenerTodosEmpleados()
        {
            using (var context = new ClinicaDentalContext())
            {
                return context.Contactos.OfType<Empleado>().ToList();
            }
        }
    }
}
