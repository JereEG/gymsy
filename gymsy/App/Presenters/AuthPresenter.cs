using gymsy.App.Views.Interfaces;
using gymsy.Context;
using gymsy.Properties;
using gymsy.utilities;
using gymsy.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gymsy.Modelos;
//using GymsyContext = gymsy.Models.GymsyContext;



namespace gymsy.App.Presenters
{
    public class AuthPresenter
    {
        private IAuthView authView;
        private GymsyContext gymsydb;

        public AuthPresenter(IAuthView authView, GymsyContext gymsydb)
        {

            this.authView = authView;
            this.gymsydb = gymsydb;

            // Subscribe event handler methods to view events


            this.authView.Signin += Signin;
            inactivarClientes();
            // Show view
            this.authView.Show();
        }

        private void  inactivarClientes()
        {
            
            var clients = this.gymsydb.Usuarios.Where(u=>u.IdRol==3).ToList();
            var persons = this.gymsydb.Usuarios.ToList();
            
            foreach(Usuario cliente in clients)
            {
                var sus = this.gymsydb.AlumnoSuscripcions.Where(s => s.IdAlumno == cliente.IdUsuario).FirstOrDefault();
                if (sus.FechaExpiracion < DateTime.Now)
                {
                    cliente.UsuarioInactivo = true;
                }
            }
        }

        private void Signin(object? sender, EventArgs e)
        {
            try
            {
                //SI DICE SECUENSE NO CONTAINS ES QUE NO HAY UNA PERSONA CON ESE NICKNAME
                // Signin to database
                var peopleFound = this.gymsydb.Usuarios
                                              .Where(p => p.Apodo == this.authView.Nickname)
                                              .First();

                // validar existencia del usuario
                if (peopleFound != null)
                {

                    //- Validar password
                    if (!Bcrypt.ComparePassowrd(this.authView.Password, peopleFound.Contrasena))
                    {
                        this.authView.IsSuccessful = false;
                        this.authView.Message = "Nickname o Contraseña Incorrecto";
                        this.authView.HandleResponseDBMessage();
                        return;
                    }
                    else
                    {
                        if (!peopleFound.UsuarioInactivo)
                        {
                            this.authView.IsSuccessful = true;
                            this.authView.Message = "Hola, " + peopleFound.Nombre + "    ;)";

                            // Delay
                            this.authView.HandleResponseDBMessage();
                            //Thread.Sleep(3000);

                            // Update global state
                            AppState.person = peopleFound;

                            this.asignMethods(peopleFound);

                            this.authView.Hide();

                            // Open form
                            IMainView view = new MainView();
                            new MainPresenter(view, gymsydb);

                            return;
                        }
                        else
                        {
                            this.authView.IsSuccessful = false;
                            this.authView.Message = "Usuario inactivo!";
                            this.authView.HandleResponseDBMessage();
                            return;
                        }

                    }
                }
                else return;
            }
            catch (Exception ex)
            {
                this.authView.IsSuccessful = false;
                this.authView.Message = "Error inesperdado";
                this.authView.HandleResponseDBMessage();
                // Muestra un MessageBox con el mensaje de error
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.authView.Loading = false;
            }
        }


        private void asignMethods(Usuario personFound)
        {
            try
            {
                switch (personFound.IdRol)
                {
                    // this person is admin
                    case 1:

                        var instructorsFound = this.gymsydb.Usuarios
                                                .Where(u => u.IdRol == 2)
                                                .ToList();

                        var personss = this.gymsydb.Usuarios.ToList();
                        this.gymsydb.Pagos.ToList();
                        this.gymsydb.TipoDePagos.ToList();
                        this.gymsydb.PlanEntrenamientos.ToList();


                        AppState.instructors = instructorsFound;
                        AppState.persons = personss;
                        AppState.Instructor = new Usuario() { IdRol = 2};
                        //nota mental: hacer un constructor en usuario que
                        //permita discriminar el rol desde el mismo

                        break;

                    // this person is an instructor
                    case 2:
                        var instructorFound = this.gymsydb.Usuarios
                                                .Where(instructor => instructor.IdUsuario == personFound.IdUsuario)
                                                .First();

                        var planesFound = this.gymsydb.PlanEntrenamientos.ToList();
                        var clientsFound = this.gymsydb.Usuarios.Where(u=>u.IdRol==3).ToList();

                        var dataFisico = this.gymsydb.EstadoFisicos.ToList();
                        var Images = this.gymsydb.Usuarios.Select(u=>u.AvatarUrl).ToList();

                        this.gymsydb.Pagos.ToList();
                        this.gymsydb.TipoDePagos.ToList();
                        //this.gymsydb.Wallets.ToList();

                        var usuario= this.gymsydb.Usuarios.ToList();

                        AppState.clients = usuario;
                        AppState.persons = usuario;
                        AppState.Instructor = instructorFound;

                        break;

                    // this person is client
                    case 3:

                        this.gymsydb.EstadoFisicos.ToList();
                        this.gymsydb.Usuarios.Select(u => u.AvatarUrl).ToList();
                        this.gymsydb.Pagos.ToList();
                        this.gymsydb.TipoDePagos.ToList();
                        this.gymsydb.PlanEntrenamientos.ToList();
                        var clientFound = this.gymsydb.Usuarios
                                                .Where(cl => cl.IdUsuario == personFound.IdUsuario)
                                                .First();

                        AppState.ClientActive = clientFound;

                        break;

                    // this person is a receptionist
                    case 4:
                        /*
                        var personsss = this.gymsydb.People.ToList();
                        var planes = this.gymsydb.TrainingPlans
                            .Where(plan => plan.Inactive == false)
                            .ToList();
                        this.gymsydb.Clients.ToList();
                        this.gymsydb.TrainingPlans.ToList();
                        this.gymsydb.Instructors.ToList();
                        this.gymsydb.Admins.ToList();
                        this.gymsydb.PayTypes.ToList();
                        this.gymsydb.Pays.ToList();
                        this.gymsydb.Wallets.ToList();

                        MessageBox.Show(planes.Count().ToString());
                        AppState.planes = planes;
                        AppState.clients = personsss;
                        AppState.persons = personsss;
                        AppState.Instructor = new Instructor();
                        */
                        var personsss = this.gymsydb.Usuarios.ToList();
                        var planes = this.gymsydb.PlanEntrenamientos
                            .Where(plan => plan.PlanEntrenamientoInactivo == false)
                            .ToList();
                        this.gymsydb.Usuarios.Where(u=>u.IdRol==3).ToList();
                        this.gymsydb.PlanEntrenamientos.ToList();
                        this.gymsydb.Usuarios.Where(u=>u.IdUsuario==2).ToList();
                        this.gymsydb.Usuarios.Where(u=>u.IdUsuario==1).ToList();
                        this.gymsydb.TipoDePagos.ToList();
                        this.gymsydb.Pagos.ToList();
                       // this.gymsydb.Wallets.ToList();

                        MessageBox.Show(planes.Count().ToString());
                        AppState.planes = planes;
                        AppState.clients = personsss;
                        AppState.persons = personsss;
                        AppState.Instructor = new Usuario() { IdRol = 2 };//nota: hacer un constructor por cada rol en la clase usuarios
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}