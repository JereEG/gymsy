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
        private static NuevoGymsyContext gymsydb = ViejoGymsyContext.GymsyContextDB;

        public static bool TituloUnico(string nuevoTitulo)
        { 
           
           return EstadoFisico.TituloUnico(nuevoTitulo);
           
        }
        public static List<EstadoFisico> getProgress(int idAlumno)
        {
            using (var gymsydb=new NuevoGymsyContext())
            {
                return (List<EstadoFisico>)gymsydb.EstadoFisicos.Where(a => a.IdAlumnoSuscripcion==getSuscripcion(idAlumno).IdAlumnoSuscripcion).ToList();
            }
        }
        public static AlumnoSuscripcion getSuscripcion(int idAlumno)
        {
            using (var gymsydb=new NuevoGymsyContext())
            {
                return gymsydb.AlumnoSuscripcions.FirstOrDefault(a => a.IdAlumno == idAlumno);
            }
        }
        public static bool guardarProgreso(string ptitle_dataFisic, string pnotes_dataFisic, float pweight_dataFisic, float pheight_dataFisic, string pruta_imagen, string pextension)
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
