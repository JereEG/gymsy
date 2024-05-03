using gymsy.App.Models;
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

using gymsy.App.Models;

namespace gymsy.App.Presenters
{
    public class AuthPresenter
    {
        private IAuthView authView;
        private GymsyDbContext gymsydb;

        public AuthPresenter(IAuthView authView, GymsyDbContext gymsydb)
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
            var clients = this.gymsydb.Clients.ToList();
            var persons = this.gymsydb.People.ToList();

            foreach(Client cliente in clients)
            {
                if(cliente.LastExpiration < DateTime.Now)
                {
                    cliente.IdPersonNavigation.Inactive = true;
                }
            }
        }

        private void Signin(object? sender, EventArgs e)
        {
            try
            {
                //SI DICE SECUENSE NO CONTAINS ES QUE NO HAY UNA PERSONA CON ESE NICKNAME
                // Signin to database
                var peopleFound = this.gymsydb.People
                                              .Where(p => p.Nickname == this.authView.Nickname)
                                              .First();

                // validar existencia del usuario
                if (peopleFound != null)
                {

                    //- Validar password
                    if (!Bcrypt.ComparePassowrd(this.authView.Password, peopleFound.Password))
                    {
                        this.authView.IsSuccessful = false;
                        this.authView.Message = "Nickname o Contraseña Incorrecto";
                        this.authView.HandleResponseDBMessage();
                        return;
                    }
                    else
                    {
                        if (!peopleFound.Inactive && (peopleFound.RolId != 3))
                        {
                            this.authView.IsSuccessful = true;
                            this.authView.Message = "Hola, " + peopleFound.FirstName + "    ;)";

                            // Delay
                            this.authView.HandleResponseDBMessage();
                            //Thread.Sleep(3000);

                            // Update global state
                            AppState.person = peopleFound;

                            this.asignMethods(peopleFound);

                            this.authView.Hide();

                            // Open form
                            IMainView view = new MainView();
                            new MainPresenter(view, this.gymsydb);

                            return;
                        }
                        else
                        {
                            this.authView.IsSuccessful = false;
                            this.authView.Message = "No tienes permiso de ingresar al sistema!";
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


        private void asignMethods(Person personFound)
        {
            try
            {
                switch (personFound.RolId)
                {
                    // this person is admin
                    case 1:

                        var instructorsFound = this.gymsydb.People
                                                .Where(person => person.RolId == 2)
                                                .ToList();

                        var personss = this.gymsydb.People.ToList();
                        this.gymsydb.Pays.ToList();
                        this.gymsydb.PayTypes.ToList();
                        this.gymsydb.Wallets.ToList();
                        this.gymsydb.TrainingPlans.ToList();


                        AppState.instructors = instructorsFound;
                        AppState.persons = personss;
                        AppState.Instructor = new Instructor();

                        break;

                    // this person is instructor
                    case 2:
                        var instructorFound = this.gymsydb.Instructors
                                                .Where(instructor => instructor.IdPerson == personFound.IdPerson)
                                                .First();

                        var planesFound = this.gymsydb.TrainingPlans.ToList();
                        var clientsFound = this.gymsydb.Clients.ToList();

                        var dataFisico = this.gymsydb.DataFisics.ToList();
                        var Images = this.gymsydb.Images.ToList();

                        this.gymsydb.Pays.ToList();
                        this.gymsydb.PayTypes.ToList();
                        this.gymsydb.Wallets.ToList();

                        var persons = this.gymsydb.People.ToList();

                        AppState.clients = persons;
                        AppState.persons = persons;
                        AppState.Instructor = instructorFound;

                        break;

                    // this person is client
                    case 3:

                        this.gymsydb.DataFisics.ToList();
                        this.gymsydb.Images.ToList();
                        this.gymsydb.Pays.ToList();
                        this.gymsydb.PayTypes.ToList();
                        this.gymsydb.TrainingPlans.ToList();
                        var clientFound = this.gymsydb.Clients
                                                .Where(cl => cl.IdPerson == personFound.IdPerson)
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