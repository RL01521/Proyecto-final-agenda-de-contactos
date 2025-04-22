using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace DAL
{
    public class EmpleadoDAL
    {
        public static void Agregar(Empleado empleado)
        {
            using (var db = new ClinicaDentalContext())
            {
                db.Empleados.Add(empleado);
                db.SaveChanges();
            }
        }

        public static Empleado ObtenerPorId(int id)
        {
            using (var db = new ClinicaDentalContext())
            {
                return db.Empleados.Find(id);
            }
        }

        public static List<Empleado> ObtenerTodos()
        {
            using (var db = new ClinicaDentalContext())
            {
                return db.Empleados.ToList();
            }
        }

        public static void Actualizar(Empleado empleado)
        {
            using (var db = new ClinicaDentalContext())
            {
                db.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void Eliminar(int id)
        {
            using (var db = new ClinicaDentalContext())
            {
                var empleado = db.Empleados.Find(id);
                if (empleado != null)
                {
                    db.Empleados.Remove(empleado);
                    db.SaveChanges();
                }
            }
        }
    }
}
