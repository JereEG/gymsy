using gymsy.App.Models;
using gymsy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymsy.App.Presenters
{
    internal static class PaymentsPresenter
    {
        private static GymsyDbContext gymsydb = GymsyContext.GymsyContextDB;

       public static Pay BuscarPago(int pIdPaySelected)
        {
            return gymsydb.Pays
                                .Where(pay => pay.IdPay == pIdPaySelected)
                                .First();
        }
    }
}
