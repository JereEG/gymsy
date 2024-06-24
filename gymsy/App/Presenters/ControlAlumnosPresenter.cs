using gymsy.Modelos;
using gymsy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymsy.App.Presenters
{
    internal static class ControlAlumnosPresenter
    {

        public static Usuario BuscarCliente(int pIdCliente)
        {
            Usuario.buscarCliente(pIdCliente);
        }
        
        public static void DesactivarOActivarCliente(int idUsuario, bool estado)
        {
            Usuario.desactivarOActivarUsuario(idUsuario,estado);
        }
    }
}
