using gymsy.Models;
using gymsy.App.Presenters;
using gymsy.App.Views;
using gymsy.App.Views.Interfaces;
using gymsy.App.Views.UserControls.AdminControls;
using gymsy.App.Views.UserControls.ClientControls;
using gymsy.App.Views.UserControls.receptionist;
using gymsy.Context;
using gymsy.Properties;
using gymsy.UserControls;
using gymsy.UserControls.AdminControls;
using gymsy.UserControls.ClientControls;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace gymsy
{
    public partial class MainView : Form, IMainView
    {

        // Roles de usuario 
        List<string> rols = new List<string>() { "", "admin", "instructor", "client", "receptionist" };

        public static NavigationControl navigationControl;
        NavigationButtons navigationButtons;
        bool sidebarExpand = true;
        bool btnAddExpand = false;
        bool btnNotificationsExpand = false;

        // Set colors buttons
        Color btnDefaultColor = Color.Transparent;
        Color btnSelectedColor = Color.DarkCyan;

        public event EventHandler SettingView;

        // properties
        private bool IsSuccessful;
        private Usuario person;
        private string Message;

        public MainView()
        {
            this.person = AppState.person;
            InitializeComponent();
            InitializeUser();
            InitializeNavigationControl(this.rols[person.IdRol ?? 0] );
            InitializeNavigationButtons(this.rols[person.IdRol ?? 0] );
            InitializeUserRol(this.rols[person.IdRol ?? 0]);

            try
            {
                string ruta = "";
                if (person.IdRol == 2)
                {
                    ruta = AppState.pathDestinationFolder + AppState.nameCarpetImageInstructor;
                }
                else if (person.IdRol == 3)
                {
                    ruta = AppState.pathDestinationFolder + AppState.nameCarpetImageClient;
                }
                else
                {
                    ruta = AppState.pathDestinationFolder;
                }
                ruta += "\\" + person.AvatarUrl;
                PimagenPerson.BackgroundImage = System.Drawing.Image.FromFile(ruta);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                PimagenPerson.BackgroundImage = Resources.gorilla_avatar;
            }
        }

        // Getters and Setters
        Usuario IMainView.person
        {
            get { return person; }
            set { person = value; }
        }

        bool IMainView.IsSuccessful
        {
            get { return IsSuccessful; }
            set { IsSuccessful = value; }
        }

        string IMainView.Message
        {
            get { return Message; }
            set { Message = value; }
        }

        private void InitializeUser()
        {
            BtnUserAvatar.Text = this.person.Apodo;
            LabelNavRol.Text = this.rols[this.person.IdRol ?? 0].ToUpper();
            if (this.person.IdRol != 3)
            {
                LabelAmuntWallet.Text = "0";//$"${this.person.Wallets.First().Retirable}K";
                //ya no existe
            }
            else
            {
                Panel1.Visible = false;
            }
        }

        // Inicializamos el controlador con la navegacion, pasando los controles y en panel mainWrapper en donde se renderizar?
        private void InitializeNavigationControl(string rol = "instructor")
        {


            List<UserControl> userControlsList = new List<UserControl>();

            if (rol == "admin")
            {
                userControlsList = new List<UserControl>()
                { new DashboardAdminControl(), new InstructorsAdminControl(), new PaymentsUserControl(), new SettingsUserControl(),
                new AddInstructorControl(), new DashboardAdminControl(), new WalletUserControl(), new EditInstructor(),
                    new adminControl()
                };
            }
            else if (rol == "client")
            {
                userControlsList = new List<UserControl>()
                 { new AboutClientControl(), new ProgressClientControl(), new PaymentsUserControl(), new SettingsUserControl(),
                  new AddProgressClientControl() 
                };
            }
            else if (rol == "receptionist")
            {
                userControlsList = new List<UserControl>()
                {
                    new addPay(), new addPay(), new addPay(), new SettingsUserControl(),
                };
            }
            else
            {
                userControlsList = new List<UserControl>()
                { new DashboardUserControl(), new ClientsUserControl(), new PaymentsUserControl(), new SettingsUserControl(),
                  new AddClientUserControl(), new AddPlanUserControl(), new WalletUserControl(), new ProgressClientControl(),
                    new AddProgressClientControl(), new EditClient()
                };

            }

            navigationControl = new NavigationControl(userControlsList, mainWrapper);
            navigationControl.Display(0);
        }

        // Inicializamos los botones asociados a la navegacion y manejamos el btn activo (HIghlight)
        private void InitializeNavigationButtons(string rol = "instructor")
        {
            List<Button> buttonsRol = new List<Button>();

            List<Button> buttons = new List<Button>()
            { btnNavDashboard, btnNavPayments, btnNavClients, btnNavAddClient, btnNavAddPlan};

            List<Button> buttonsAdmin = new List<Button>()
            { btnNavDashAdmin, btnNavInstructorAdmin, btnNavPaysAdmin, btnAddInstructor};

            List<Button> buttonsClient = new List<Button>()
            { btnNavAboutme, btnNavProgress, btnNavPaysClient};


            if (rol == "admin") buttonsRol = buttonsAdmin;
            else if (rol == "client") buttonsRol = buttonsClient;
            else buttonsRol = buttons;


            navigationButtons = new NavigationButtons(buttonsRol, btnDefaultColor, btnSelectedColor);
            navigationButtons.Highlight(buttonsRol[0]);
        }

        private void InitializeUserRol(string rol)
        {
            switch (rol)
            {
                case "admin":
                    Panel1.Visible = true;
                    panelNavRight.Visible = true;
                    tableLayoutAdmin.Visible = true;
                    panelAddAdmin.Visible = true;
                    break;
                case "instructor":
                    Panel1.Visible = true;
                    panelNavRight.Visible = true;
                    tableLayout.Visible = true;
                    panelBtnAdd.Visible = true;
                    break;
                case "client":
                    panelNavRight.Visible = false;
                    tableLayoutClient.Visible = true;
                    break;
                default:
                    tableLayoutClient.Visible = false;
                    break;
            }
        }

        // Handle BTN Navegatios
        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            navigationControl.Display(0);
            navigationButtons.Highlight(btnNavDashboard);
        }

        private void btnNavClients_Click(object sender, EventArgs e)
        {
            navigationControl.Display(1, true);
            navigationButtons.Highlight(btnNavClients);
        }

        private void btnNavPayments_Click(object sender, EventArgs e)
        {
            navigationControl.Display(2, true);
            navigationButtons.Highlight(btnNavPayments);
        }

        private void btnNavSettings_Click(object sender, EventArgs e)
        {
            navigationControl.Display(3);
            navigationButtons.Highlight(btnNavSettings);
        }

        private void btnNavAddPlan_Click(object sender, EventArgs e)
        {
            navigationControl.Display(5);
            navigationButtons.Highlight(btnNavAddPlan);
        }

        private void btnNavAddClient_Click(object sender, EventArgs e)
        {
            navigationControl.Display(4);
            navigationButtons.Highlight(btnNavAddClient);
        }
        private void BtnNavWallet_Click(object sender, EventArgs e)
        {
            navigationControl.Display(6);
            navigationButtons.Highlight(new Button());
        }



        // ------------------------------------------------------------------
        // BTN ADMIN
        private void btnNavDashAdmin_Click(object sender, EventArgs e)
        {
            navigationControl.Display(0);
            navigationButtons.Highlight(btnNavDashAdmin);
        }

        private void btnNavInstructorAdmin_Click(object sender, EventArgs e)
        {
            navigationControl.Display(1, true);
            navigationButtons.Highlight(btnNavInstructorAdmin);
        }

        private void btnNavPaysAdmin_Click(object sender, EventArgs e)
        {
            navigationControl.Display(2);
            navigationButtons.Highlight(btnNavPaysAdmin);
        }
        private void btnAddInstructor_Click(object sender, EventArgs e)
        {
            navigationControl.Display(4);
            navigationButtons.Highlight(btnAddInstructor);
        }

        // ------ btn client nav
        private void btnNavAboutme_Click(object sender, EventArgs e)
        {
            navigationControl.Display(0);
            navigationButtons.Highlight(btnNavAboutme);
        }

        private void btnNavProgress_Click(object sender, EventArgs e)
        {
            navigationControl.Display(1, true);
            navigationButtons.Highlight(btnNavProgress);
        }

        private void btnNavPaysClient_Click(object sender, EventArgs e)
        {
            navigationControl.Display(2);
            navigationButtons.Highlight(btnNavPaysClient);
        }




        // START TIMERS
        private void menuButton_Click(object sender, EventArgs e) // Timer despligue panel 
        {
            sidebarTimer.Start();
        }

        private void btnAdd_Click(object sender, EventArgs e) // Timer dropdown btn add
        {
            btnAddTimer.Start();
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            timerAddAdmin.Start();
        }


        // Control timer for panel
        private void timer1_Tick(object sender, EventArgs e)
        {
            // asignamos que el sidebar ocupe la menor anchura y modificamos el padding del main
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    mainWrapper.Padding = new Padding(70, 0, 0, 0);
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            // asignamos que el sidebar ocupe la mayor anchura y modificamos el padding del main
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    mainWrapper.Padding = new Padding(260, 0, 0, 0);
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        // Control timer for dropdown btn add
        private void btnAddTimer_Tick(object sender, EventArgs e)
        {
            if (btnAddExpand)
            {
                panelBtnAdd.Height -= 10;
                if (panelBtnAdd.Height == panelBtnAdd.MinimumSize.Height)
                {
                    btnAddExpand = false;
                    btnAddTimer.Stop();
                }
            }
            else
            {
                panelBtnAdd.Height += 10;
                if (panelBtnAdd.Height == panelBtnAdd.MaximumSize.Height)
                {
                    btnAddExpand = true;
                    btnAddTimer.Stop();
                }
            }
        }

        // Control timer for dropdown  notifications
        private void timerNavbarNotifications_Tick(object sender, EventArgs e)
        {
            if (btnNotificationsExpand)
            {
                panelNotifications.BorderStyle = BorderStyle.None;
                panelNotifications.Height -= 10;
                if (panelNotifications.Height == panelNotifications.MinimumSize.Height)
                {
                    btnNotificationsExpand = false;
                    timerNavbarNotifications.Stop();
                }
            }
            else
            {
                panelNotifications.BorderStyle = BorderStyle.FixedSingle;
                panelNotifications.Height += 10;
                if (panelNotifications.Height == panelNotifications.MaximumSize.Height)
                {
                    btnNotificationsExpand = true;
                    timerNavbarNotifications.Stop();
                }
            }
        }

        //Control add admin btn
        private void btnAddAdminTimer_Tick(object sender, EventArgs e)
        {
            if (btnAddExpand)
            {
                panelAddAdmin.Height -= 10;
                if (panelAddAdmin.Height == panelAddAdmin.MinimumSize.Height)
                {
                    btnAddExpand = false;
                    timerAddAdmin.Stop();
                }
            }
            else
            {
                panelAddAdmin.Height += 10;
                if (panelAddAdmin.Height == panelAddAdmin.MaximumSize.Height)
                {
                    btnAddExpand = true;
                    timerAddAdmin.Stop();
                }
            }
        }

        // SIGNOUT SESSION BTN
        private void btnNavSignout_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            navigationControl.Display(8);
            navigationButtons.Highlight(button3);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}