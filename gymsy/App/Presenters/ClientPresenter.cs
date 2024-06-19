using gymsy.Context;
using gymsy.Modelos;
using gymsy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymsy.App.Presenters
{
    internal static class ClientPresenter
    {
        private static Usuario person = AppState.person;
        private static NuevoGymsyContext gymsydb = StacticGymsyContext.GymsyContextDB;

       
        //aboutClientControl
        public static Usuario getClient(int idPerson)
        {
            using (var gymsy = new NuevoGymsyContext())
            {
                return gymsydb.Usuarios.Where(cl => cl.IdUsuario == idPerson && cl.IdRol == 3).First();
            }
        }








    }
}
