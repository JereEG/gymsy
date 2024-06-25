using gymsy.Modelos;
using gymsy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gymsy.Models;

namespace gymsy.App.Presenters
{
    internal static class AddPayPresenter
    {
        public static Usuario BuscarCliente(int pIdCliente)
        {
            return Usuario.buscarUsuario(pIdCliente,0);
               
        }
        public static Usuario TraerAdmin()
        {
            using (var gymsydb = new NuevoGymsyContext())
            {
                return gymsydb.Usuarios.Where(u => u.IdRol == 1).FirstOrDefault();
            }
        }
        public static AlumnoSuscripcion suscripcionCliente(int idCliente)
        {
            return AlumnoSuscripcion.obtenerSuscripcionPorAlumno(idCliente);
            
        }
        public static void AgregarPago(int pIdCliente, decimal pMonto)
        {

            Pago.guardarPago(pIdCliente,pMonto);
        }

        public static Usuario ObtenerAlumno(int pIdAlumno)
        {

            return Usuario.buscarUsuario(pIdAlumno,3);
            
        }
        public static PlanEntrenamiento buscarPlanEntrenamiento(int pIdPlanEntrenamiento)
        {
            return PlanEntrenamiento.buscarPlan(pIdPlanEntrenamiento);
            
        }
        public static Usuario buscarInstrutorDePlanEntrenamiento(int pIdInstructor)
        {
            //El nombre no coincide con la funcion pero ya estaba asi jaja
            return Usuario.buscarUsuario(pIdInstructor,0);
            
        }

    }
}
