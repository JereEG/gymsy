using gymsy.Modelos;
using gymsy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gymsy.Models;

namespace gymsy.App.Presenters
{
    internal static class AddPayPresenter
    {
        private static NuevoGymsyContext gymsydb = StacticGymsyContext.GymsyContextDB;
        public static Usuario BuscarCliente(int pIdCliente)
        {
            return gymsydb.Usuarios
                                .Where(client => client.IdUsuario == pIdCliente)
                                .First();
        }
        public static Usuario TraerAdmin()
        {
            return gymsydb.Usuarios.Where(u=>u.IdRol==1).FirstOrDefault();
        }
        public static AlumnoSuscripcion suscripcionCliente(int idCliente)
        {
            return gymsydb.AlumnoSuscripcions.FirstOrDefault(u => u.IdUsuario == idCliente);
        }
        public static void AgregarPago(int pIdCliente, float pMonto)
        {

            var admin = AddPayPresenter.TraerAdmin();
            
            //var resepcionist = this.dbContext.People.FirstOrDefault(person => person.Rol.IdRol == 4);//rol de secretaria
            var client = AddPayPresenter.BuscarCliente(pIdCliente);


            if (admin != null  && client != null)
            {

                var newPay = new Pago
                {
                    FechaCreacion = DateTime.Now,
                    Monto = (decimal)pMonto,  // Aquí debes proporcionar el monto deseado
                    InactivoPago = false,
                    IdUsuario = client.IdUsuario,
                    IdTipoPago = 1
                };
                gymsydb.Pagos.Add(newPay);
                gymsydb.SaveChanges();

                //agregar alumno suscripcion completo
                var suscripcion = gymsydb.AlumnoSuscripcions.Where(u => u.IdUsuario == client.IdUsuario);
                foreach(AlumnoSuscripcion sus in suscripcion)
                {
                    sus.FechaExpiracion =DateTime.Now.AddMonths(1);
                }
    
                gymsydb.SaveChanges();
                client.UsuarioInactivo = false;
                gymsydb.SaveChanges();
            }
        }

    }
}
