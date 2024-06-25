using gymsy.Context;
using gymsy.Modelos;
using gymsy.Models;
using gymsy.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymsy.App.Presenters
{
    internal static class ClientePresenter
    {
        public static Usuario BuscarCliente(int pIdCliente)
        {
            return Usuario.buscarUsuario(pIdCliente,3);
        }
        
        public static List<PlanEntrenamiento> BuscarPlanesPorInstructor(int id)
        {
           return PlanEntrenamiento.buscarPlanesPorInstructor(id);
               
        }
       
    }
}
