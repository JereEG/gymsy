using CustomControls.RJControls;
using gymsy.Models;
using gymsy.Context;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gymsy.Modelos;

namespace gymsy.App.Presenters
{
    internal static class AddProgressClientPresenter
    {
        public static bool TituloUnico(string nuevoTitulo)
        { 
           
           return EstadoFisico.tituloUnico(nuevoTitulo);
           
        }

        public static List<EstadoFisico> ListarProgresosPorAlumno(int idAlumnoSucripcion)
        {
            
            using (var gymsydb=new NuevoGymsyContext())
            {
                return (List<EstadoFisico>)gymsydb.EstadoFisicos.Where(a => a.IdAlumnoSuscripcion==ObtenerSuscripcionPorAlumno(idAlumnoSucripcion).IdAlumnoSuscripcion).ToList();
            }
        }


        public static AlumnoSuscripcion ObtenerSuscripcionPorAlumno(int idAlumno)
        {
            return AlumnoSuscripcion.obtenerSuscripcionPorAlumno(idAlumno);
        }

        public static bool GuardarProgreso(string ptitle_dataFisic, string pnotes_dataFisic, float pweight_dataFisic, float pheight_dataFisic, string pruta_imagen, string pextension)
        {
            using (var gymsydb = new NuevoGymsyContext())
            {

                // Save image 
                System.Drawing.Image File;
                File = System.Drawing.Image.FromFile(pruta_imagen);

                string directory = AppDomain.CurrentDomain.BaseDirectory;
                string directoryPublic = Path.GetFullPath(Path.Combine(directory, @"..\..\..\App\Public"));

                string RandomName = Guid.NewGuid().ToString();
                string NameImage = $"{RandomName}{pextension}";
                string rutaCompleta = Path.Combine(directoryPublic, NameImage);
                File.Save(rutaCompleta, ImageFormat.Png);


                return EstadoFisico.guardarProgreso(ptitle_dataFisic, pnotes_dataFisic, pweight_dataFisic, pheight_dataFisic, NameImage);
            }
        }
    }
}
