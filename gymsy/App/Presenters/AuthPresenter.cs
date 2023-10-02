﻿using gymsy.App.Models;
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

namespace gymsy.App.Presenters
{
    public class AuthPresenter
    {
        private IAuthView authView;
        private GymsyDbContext gymsydb;

        public AuthPresenter(IAuthView authView, GymsyDbContext gymsydb) {
            
            this.authView = authView;
            this.gymsydb = gymsydb;

            // Subscribe event handler methods to view events
            this.authView.Signin += Signin;

            // Show view
            this.authView.Show();
        }

       async private void Signin(object? sender, EventArgs e)
        {
            try
            {
                
                // Signin to database
                var peopleFound = this.gymsydb.People
                                              .Where(people => people.Nickname == this.authView.Nickname)
                                              .First();
                
                // validar existencia del usuario
                if (peopleFound != null) {

                    //- Validar password
                    if(!Bcrypt.ComparePassowrd(this.authView.Password, peopleFound.Password))
                    {
                        this.authView.IsSuccessful = false;
                        this.authView.Message = "Nickname o Contraseña Incorrecto";
                        this.authView.HandleResponseDBMessage();
                    }
                    else
                    {



                        this.authView.IsSuccessful = true;
                        this.authView.Message = "Hola, "+peopleFound.FirstName+" :)";
                        this.authView.HandleResponseDBMessage();
                        this.authView.Refresh();
      
                        // Delay
                        Thread.Sleep(2000);

                        AppState.person = peopleFound;
                        //AppState.clients = clients;

                        //Lo mismo deveria ser para clientes

                        var planes = this.gymsydb.TrainingPlans
                                .Where(plan => plan.IdInstructor == peopleFound.IdPerson)
                                .ToList();

                      


                        AppState.planes = planes;

                        this.authView.Hide();

                        // Open form
                        IMainView view = new MainView(peopleFound);
                        new MainPresenter(view, gymsydb);

                        view.Show();
                    }
                }
            }
            catch (Exception ex)
            {
               this.authView.IsSuccessful = false;
               this.authView.Message = "Error inesperdado";
               this.authView.HandleResponseDBMessage();
                // Muestra un MessageBox con el mensaje de error
                MessageBox.Show("Ocurrió un error: " + Resources.stringConnection, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.authView.Loading = false;
            }
        }
    }
}