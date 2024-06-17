using gymsy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymsy.Context
{
 
    public static class AppState
    {
        private static Models.GymsyContext gymsydb = new GymsyContext();
        public static Usuario person { get; set; }
        public static List<PlanEntrenamiento> planes { get; set; }
        public static Array planess { get; set; }
        public static List<Usuario> clients { get ; set; }
        public static List<Usuario> persons { get; set; }
        public static Usuario userActive { get; set; }
        public static List<Usuario> instructors { get; set; }

        public static List<Usuario> clientesDeRes { get; set; }

        // Now
        public static Usuario Instructor { get; set; }
        public static Usuario ClientActive { get; set; }

        public static Usuario InstructorActive { get; set; }
        public static AlumnoSuscripcion AlumnoSuscripcion { get; set; }
        public static List<AlumnoSuscripcion> AlumnoSuscripciones { get; set; }
        public static bool isModeAdd { get; set; } = false;

       
        public static string pathDestinationFolder { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        public static string nameCarpetImageClient { get; set; } = "\\Gymsy\\ClientImage";
        public static string nameCarpetImageInstructor { get; set; } = "\\Gymsy\\InstructorImage";

        public static string nameCarpetBackUp { get; set; } = "\\Gymsy\\BackUp";
        public static bool needRefreshClientsUserControl { get; set; } = false;

        public static bool isModeEdit { get; set; } = false;

        public static int auxIdClient = 0;



    }
}
