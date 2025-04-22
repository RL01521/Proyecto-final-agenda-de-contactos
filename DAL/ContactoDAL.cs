using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace DAL
{
    public class ContactoDAL
    {
        public static void Agregar(Contacto contacto)
        {
            using (var db = new ClinicaDentalContext())
            {
                db.Contactos.Add(contacto);
                db.SaveChanges();
            }
        }

        public static Contacto ObtenerPorId(int id)
        {
            using (var db = new ClinicaDentalContext())
            {
                return db.Contactos.Find(id);
            }
        }

        public static List<Contacto> ObtenerTodos()
        {
            using (var db = new ClinicaDentalContext())
            {
                return db.Contactos.ToList();
            }
        }

        public static void Actualizar(Contacto contacto)
        {
            using (var db = new ClinicaDentalContext())
            {
                db.Entry(contacto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void Eliminar(int id)
        {
            using (var db = new ClinicaDentalContext())
            {
                var contacto = db.Contactos.Find(id);
                if (contacto != null)
                {
                    db.Contactos.Remove(contacto);
                    db.SaveChanges();
                }
            }
        }
    }
}
