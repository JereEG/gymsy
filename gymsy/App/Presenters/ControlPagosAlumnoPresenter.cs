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
        public static List<Pago> ListarPagosPorUsuario(int idUsuario)
        {
            return Pago.listarPagosPorUsuario(idUsuario);
        }

    }
}
