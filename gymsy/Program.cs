using gymsy.Models;
using gymsy.App.Presenters;
using gymsy.App.Views.Interfaces;
using gymsy.Context;
using gymsy.Properties;
using Microsoft.EntityFrameworkCore;
using gymsy.Modelos;

namespace gymsy
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            //Config & Conect to database
            string stringConnection = Resources.stringConnection;
            DbContextOptionsBuilder<NuevoGymsyContext> optionsBuilder = new();

            NuevoGymsyContext GymsyContextDb = new(
               optionsBuilder.UseSqlServer(stringConnection).Options
            );

            ViejoGymsyContext.GymsyContextDB = GymsyContextDb!;
            ApplicationConfiguration.Initialize();

            IAuthView view = new AuthView();
            new AuthPresenter(view, GymsyContextDb);
          
            Application.Run((Form)view);
        }
    }
} 