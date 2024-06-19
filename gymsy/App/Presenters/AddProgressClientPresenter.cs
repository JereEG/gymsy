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
            using (var gymsydb = new NuevoGymsyContext())
            {
                // Consulta para encontrar registros con el mismo título
                var registrosConMismoTitulo = gymsydb.EstadoFisicos
                .Where(d => d.Titulo == nuevoTitulo);

                // Verificamos si se encontró algún registro con el mismo título
                bool tituloUnico = !registrosConMismoTitulo.Any();

                // Devolvemos el resultado
                return tituloUnico;
            }
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



                EstadoFisico DataFisicModel = new EstadoFisico();
                DataFisicModel.FechaCreacion = DateTime.Now;
               
                if (AppState.ClientActive == null)
                {
                    DataFisicModel.IdAlumnoSuscripcion = getSuscripcion(AppState.auxIdClient).IdAlumnoSuscripcion ;
                }
                else
                {
                    DataFisicModel.IdAlumnoSuscripcion =getSuscripcion(AppState.ClientActive.IdUsuario).IdAlumnoSuscripcion;
                }

                DataFisicModel.EstadoFisicoInactivo = false;
                DataFisicModel.Titulo = ptitle_dataFisic;
                DataFisicModel.Notas = pnotes_dataFisic;
                DataFisicModel.Peso = (decimal)pweight_dataFisic;
                DataFisicModel.Altura = (decimal)pheight_dataFisic;
                DataFisicModel.ImagenUrl = NameImage;
                var DataFisicSave = gymsydb.Add(DataFisicModel);
                gymsydb.SaveChanges();

                if (DataFisicSave != null)
                {

                    gymsydb.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
