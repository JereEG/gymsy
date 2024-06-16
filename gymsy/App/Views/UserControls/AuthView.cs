using gymsy.Models;
using gymsy.App.Views.Interfaces;
using gymsy.Properties;
using gymsy.utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace gymsy
{
    public partial class AuthView : Form, IAuthView
    {

        // Fields
        private string Message;
        private bool IsSuccessful;
        private bool Loading;

        // Properties
        public string Nickname
        {
            get { return textBoxEmailUser.Text; }
            set { textBoxEmailUser.Text = value; }
        }
        public string Password
        {
            get { return textBoxPasswordUser.Text; }
            set { textBoxPasswordUser.Text = value; }
        }

        bool IAuthView.IsSuccessful
        {
            get { return IsSuccessful; }
            set { IsSuccessful = value; }
        }
        string IAuthView.Message
        {
            get { return Message; }
            set { Message = value; }
        }
        bool IAuthView.Loading
        {
            get { return Loading; }
            set { Loading = value; }
        }


        // Constructor
        public AuthView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            button2.Click += delegate { this.Close(); };
        }

        private void AssociateAndRaiseViewEvents()
        {

            ButtonSignIn.Click += delegate
            {

                ButtonSignIn.Enabled = false;
                ButtonSignIn.Text = "...";
                this.Refresh();

                // Reset errors
                labelErrorNickname.Visible = false;
                labelErrorPass.Visible = false;

                // Validate
                if (!this.IsValidTextBox()) return;

                // Delegamos funcionalidad signin
                Signin?.Invoke(this, EventArgs.Empty);

                ButtonSignIn.Enabled = true;
                ButtonSignIn.Text = "Iniciar sesión";
            };



            textBoxPasswordUser.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ButtonSignIn.Enabled = false;
                    ButtonSignIn.Text = "...";

                    this.Refresh();

                    // Reset errors
                    labelErrorNickname.Visible = false;
                    labelErrorPass.Visible = false;

                    if (!this.IsValidTextBox()) return;
                    Signin?.Invoke(this, EventArgs.Empty);

                    ButtonSignIn.Enabled = true;
                    ButtonSignIn.Text = "Iniciar sesión";

                }
            };


        }

        // Events
        public event EventHandler Signin;

        // Methods
        private bool IsValidTextBox()
        {
            return Utility.IsValidTextBox(textBoxEmailUser, labelErrorNickname) && Utility.IsValidTextBox(textBoxPasswordUser, labelErrorPass);
        }

        void IAuthView.HandleResponseDBMessage()
        {
            BtnMessageDB.Visible = false;

            if (this.IsSuccessful)
            {
                TBNameUser.Text = this.Message;
                panelWelcome.Visible = true;
            }
            else
            {
                BtnMessageDB.ForeColor = Color.Red;
                BtnMessageDB.BorderColor = Color.Red;
                BtnMessageDB.Text = this.Message;
                BtnMessageDB.Visible = true;
            }

            this.Refresh();
        }
    }
}