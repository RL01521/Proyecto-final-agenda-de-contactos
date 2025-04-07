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
                if (contacto is Paciente paciente)
                {
                    context.Pacientes.Add(paciente);
                }
                else if (contacto is Empleado empleado)
                {
                    context.Empleados.Add(empleado);
                }
                else
                {
                    throw new ArgumentException("Tipo de contacto no soportado.");
                }
                context.SaveChanges();
            }

        }
    }

}

