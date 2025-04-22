using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace DAL
{
    public class PacienteDAL
    {
        public static void Agregar(Paciente paciente)
        {
            using (var db = new ClinicaDentalContext())
            {
                db.Pacientes.Add(paciente);
                db.SaveChanges();
            }
        }

        public static Paciente ObtenerPorId(int id)
        {
            using (var db = new ClinicaDentalContext())
            {
                return db.Pacientes.Find(id);
            }
        }

        public static List<Paciente> ObtenerTodos()
        {
            using (var db = new ClinicaDentalContext())
            {
                return db.Pacientes.ToList();
            }
        }

        public static void Actualizar(Paciente paciente)
        {
            using (var db = new ClinicaDentalContext())
            {
                db.Entry(paciente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void Eliminar(int id)
        {
            using (var db = new ClinicaDentalContext())
            {
                var paciente = db.Pacientes.Find(id);
                if (paciente != null)
                {
                    db.Pacientes.Remove(paciente);
                    db.SaveChanges();
                }
            }
        }
    }
}
