using System.Data.SqlClient;

namespace DAL
{
    public class ContactoDALBase
    {

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