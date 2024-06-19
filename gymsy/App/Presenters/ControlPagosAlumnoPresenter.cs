using gymsy.Context;
using gymsy.Modelos;
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
        private static NuevoGymsyContext gymsydb = StacticGymsyContext.GymsyContextDB;
        //Corregir
        public static List<Pago> listarPagosRealizados(int pIdUsuario)
        {
            using (var gymsy = new NuevoGymsyContext())
            {
                return gymsydb.Pagos
                   .Where(p => p.IdUsuario == pIdUsuario)
                   .Include(p => p.IdTipoPagoNavigation)
                   .ToList();
            }
        }
        //Corregir
        public static List<Pago> listarPagosRecibidos(int pIdUsuario)
        {
            using (var gymsy = new NuevoGymsyContext())
            {
                return gymsydb.Pagos
            .Where(p => p.IdUsuario == pIdUsuario)
            .Include(p => p.IdTipoPagoNavigation)
            .ToList();
            }
        }

        public static List<Pago> listarTodasTransferencias(int pIdUsuario)
        {
            using (var gymsydb=new NuevoGymsyContext())
            {
                return gymsydb.Pagos
                .Where(p => p.IdUsuario == pIdUsuario)
                .Include(p => p.IdTipoPagoNavigation)
                .ToList();
            }
                
        }



    }
}
