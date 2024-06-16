using gymsy.Models;
using gymsy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymsy.App.Presenters
{
    internal static class AddPayPresenter
    {
        private static GymsyContext gymsydb = ViejoGymsyContext.GymsyContextDB;
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
        public static void AgregarPago(int pIdCliente, float pMonto)
        {

            var admin = AddPayPresenter.TraerAdmin();
            var walletAdmin = gymsydb.Wallets.FirstOrDefault(wallet => wallet.IdPerson == 1);
            //var resepcionist = this.dbContext.People.FirstOrDefault(person => person.Rol.IdRol == 4);//rol de secretaria
            var client = AddPayPresenter.BuscarCliente(pIdCliente);


            if (admin != null && walletAdmin != null && client != null)
            {

                var newPay = new Pago
                {
                    FechaCreacion = DateTime.Now,
                    Monto = (decimal)pMonto,  // Aquí debes proporcionar el monto deseado
                    InactivoPago = false,
                    DestinatarioId = admin.IdUsuario,
                    RemitenteId = client.IdUsuario,
                    IdTipoPago = 1
                };
                gymsydb.Pagos.Add(newPay);
                gymsydb.SaveChanges();

                client.LastExpiration = DateTime.Now.AddMonths(1);
                gymsydb.SaveChanges();

                admin.Recaudacion += pMonto;
                gymsydb.SaveChanges();
                //walletAdmin.Total += monto;
                walletAdmin.Retirable += pMonto;
                gymsydb.SaveChanges();
                client.IdPersonNavigation.Inactive = false;
                gymsydb.SaveChanges();
            }
        }

    }
}
