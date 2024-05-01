using gymsy.App.Models;
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
        private static GymsyDbContext gymsydb = GymsyContext.GymsyContextDB;
        public static Client BuscarCliente(int pIdCliente)
        {
            return gymsydb.Clients
                                .Where(client => client.IdClient == pIdCliente)
                                .First();
        }
        public static Admin TraerAdmin()
        {
            return gymsydb.Admins.FirstOrDefault();
        }
        public static void AgregarPago(int pIdCliente, float pMonto)
        {

            var admin = AddPayPresenter.TraerAdmin();
            var walletAdmin = gymsydb.Wallets.FirstOrDefault(wallet => wallet.IdPerson == 1);
            //var resepcionist = this.dbContext.People.FirstOrDefault(person => person.Rol.IdRol == 4);//rol de secretaria
            var client = AddPayPresenter.BuscarCliente(pIdCliente);


            if (admin != null && walletAdmin != null && client != null)
            {

                var newPay = new Pay
                {
                    CreatedAt = DateTime.Now,
                    Amount = pMonto,  // Aquí debes proporcionar el monto deseado
                    Inactive = false,
                    DestinatarioId = admin.IdPersonNavigation.IdPerson,
                    RemitenteId = client.IdPerson,
                    IdPayType = 1
                };
                gymsydb.Pays.Add(newPay);
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
