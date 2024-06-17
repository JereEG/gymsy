using gymsy.Context;
using gymsy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace gymsy.App.Presenters
{
    internal static class ControlPagosAlumnoPresenter
    {
        private static GymsyContext gymsydb = StacticGymsyContext.GymsyContextDB;
        //Corregir
        public static List<Pago> listarPagosRealizados(int pIdUsuario)
        {
            return gymsydb.Pagos
                   .Where(p => p.IdUsuario == pIdUsuario)
                   .Include(p => p.IdTipoPagoNavigation)
                   .ToList();
        }
        //Corregir
        public static List<Pago> listarPagosRecibidos(int pIdUsuario)
        {
            return gymsydb.Pagos
            .Where(p => p.IdUsuario == pIdUsuario)
            .Include(p => p.IdTipoPagoNavigation)
            .ToList();
        }

        public static List<Pago> listarTodasTransferencias(int pIdUsuario)
        {
            return gymsydb.Pagos
            .Where(p => p.IdUsuario == pIdUsuario)
            .Include(p => p.IdTipoPagoNavigation)
            .ToList();
        }


    }
}
