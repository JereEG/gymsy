using gymsy.Models;
using gymsy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gymsy.Modelos;

namespace gymsy.App.Presenters
{
    internal static class PaymentsPresenter
    {
       public static Pago BuscarPago(int idPago)
        {
           return Pago.buscarPago(idPago);
        }
    }
}
