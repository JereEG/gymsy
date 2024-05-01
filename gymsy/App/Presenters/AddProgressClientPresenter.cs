using CustomControls.RJControls;
using gymsy.App.Models;
using gymsy.Context;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymsy.App.Presenters
{
    internal static class AddProgressClientPresenter
    {
        private static GymsyDbContext gymsydb = GymsyContext.GymsyContextDB;

        public static bool TituloUnico(string nuevoTitulo)
        {
            // Consulta para encontrar registros con el mismo título
            var registrosConMismoTitulo = gymsydb.DataFisics
                .Where(d => d.Title == nuevoTitulo);

            // Verificamos si se encontró algún registro con el mismo título
            bool tituloUnico = !registrosConMismoTitulo.Any();

            // Devolvemos el resultado
            return tituloUnico;
        }
        
        public static bool SaveProgress(string ptitle_dataFisic, string pnotes_dataFisic, float pweight_dataFisic, float pheight_dataFisic, string pruta_imagen, string pextension)
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



            DataFisic DataFisicModel = new DataFisic();
            DataFisicModel.CreatedAt = DateTime.Now;
            if (AppState.ClientActive == null)
            {
                DataFisicModel.IdClient = AppState.auxIdClient;
            }
            else
            {
                DataFisicModel.IdClient = AppState.ClientActive.IdClient;
            }

            DataFisicModel.Inactive = false;
            DataFisicModel.Title = ptitle_dataFisic;
            DataFisicModel.Notes = pnotes_dataFisic;
            DataFisicModel.Weight = pweight_dataFisic;
            DataFisicModel.Height = pheight_dataFisic;

            var DataFisicSave = gymsydb.Add(DataFisicModel);
            gymsydb.SaveChanges();

            if (DataFisicSave != null)
            {
                Models.Image ImageModel = new Models.Image();
                ImageModel.ImageUrl = NameImage;
                ImageModel.IdDataFisic = DataFisicSave.Entity.IdDataFisic;
                ImageModel.Inactive = false;

                gymsydb.Add(ImageModel);
                gymsydb.SaveChanges();

                return true;
            } else
            {
                return false;
            }

        }
    }
}
