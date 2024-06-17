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
        private static NuevoGymsyContext gymsydb = StacticGymsyContext.GymsyContextDB;
        public static Usuario BuscarCliente(int pIdCliente)
        {
            return gymsydb.Usuarios
                                .Where(client => client.IdUsuario == pIdCliente && client.IdRol == 3)
                                .First();
        }
        public static void EliminarOActivarCliente(int pIdPersona, bool pDeleteOrAcitive)
        {

            var persona = gymsydb.Usuarios
                .Where(p => p.IdUsuario == pIdPersona).FirstOrDefault();

            if (persona != null)
            {
                persona.UsuarioInactivo = pDeleteOrAcitive;
                gymsydb.SaveChanges();
            }

        }
    }
}
