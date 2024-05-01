using gymsy.App.Models;
using gymsy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymsy.App.Presenters
{
    internal static class ClientePresenter
    {
        private static GymsyDbContext gymsydb = GymsyContext.GymsyContextDB;


       

        public static Client BuscarCliente( int pIdCliente)
        {
            return gymsydb.Clients
                                .Where(client => client.IdClient == pIdCliente)
                                .First();
        }
        public static void EliminarOActivarCliente(int pIdPersona, bool pDeleteOrAcitive)
        {

            var persona = gymsydb.People         
                .Where(p => p.IdPerson == pIdPersona).FirstOrDefault();

            if (persona != null)
            {
                persona.Inactive = pDeleteOrAcitive;
                gymsydb.SaveChanges();
            }

        }
       
    }
}
