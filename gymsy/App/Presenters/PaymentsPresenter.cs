using gymsy.Models;
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
        private static GymsyDbContext gymsydb = ViejoGymsyContext.GymsyContextDB;

       public static Pago BuscarPago(int pIdPaySelected)
        {
            return gymsydb.Pagos
                                .Where(pay => pay.IdPago == pIdPaySelected)
                                .First();
        }
    }
}
