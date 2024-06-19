namespace gymsy.UserControls.AdminControls
{
    partial class AddInstructorControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel1 = new Panel();
            BBack = new ClassCustom.RJButton();
            newClientOrEditClient = new Label();
            panel2 = new Panel();
            TBRutaImagen = new TextBox();
            label5 = new Label();
            IPImagenInstructor = new PictureBox();
            TBNombre = new CustomControls.RJControls.RJTextBox();
            LFechaNacimiento = new Label();
            label2 = new Label();
            BGuardarCliente = new ClassCustom.RJButton();
            label23 = new Label();
            RBFemenino = new RadioButton();
            label22 = new Label();
            DPFechaNacimiento = new DateTimePicker();
            RBMasculino = new RadioButton();
            TBContraseña = new CustomControls.RJControls.RJTextBox();
            label17 = new Label();
            LContraseñaRequerido = new Label();
            label15 = new Label();
            TBTelefono = new CustomControls.RJControls.RJTextBox();
            TBUsuario = new CustomControls.RJControls.RJTextBox();
            TBApellido = new CustomControls.RJControls.RJTextBox();
            BTAgregarImagen = new ClassCustom.RJButton();
            LRuraImagen = new Label();
            label8 = new Label();
            LTelefonoRequerido = new Label();
            LNombreRequerido = new Label();
            label6 = new Label();
            label3 = new Label();
            LUsurioRequerido = new Label();
            LApellidoRequerido = new Label();
            label4 = new Label();
            openFileDialog1 = new OpenFileDialog();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IPImagenInstructor).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(278, 161);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 1;
            label1.Text = "AddInstructorControl";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(16, 8, 23);
            panel1.Controls.Add(BBack);
            panel1.Controls.Add(newClientOrEditClient);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 530);
            panel1.TabIndex = 2;
            // 
            // BBack
            // 
            BBack.BackColor = Color.DarkOrange;
            BBack.BackgroundColor = Color.DarkOrange;
            BBack.BorderColor = Color.PaleVioletRed;
            BBack.BorderRadius = 15;
            BBack.BorderSize = 0;
            BBack.FlatAppearance.BorderSize = 0;
            BBack.FlatStyle = FlatStyle.Flat;
            BBack.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BBack.ForeColor = Color.White;
            BBack.IconChar = FontAwesome.Sharp.IconChar.ArrowLeftLong;
            BBack.IconColor = Color.FromArgb(230, 237, 243);
            BBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BBack.IconSize = 90;
            BBack.ImageAlign = ContentAlignment.MiddleRight;
            BBack.Location = new Point(3, 3);
            BBack.Name = "BBack";
            BBack.Padding = new Padding(10, 0, 0, 0);
            BBack.Size = new Size(103, 64);
            BBack.TabIndex = 99;
            BBack.TextAlign = ContentAlignment.MiddleLeft;
            BBack.TextColor = Color.White;
            BBack.UseVisualStyleBackColor = false;
            BBack.Visible = false;
            BBack.Click += BBack_Click;
            // 
            // newClientOrEditClient
            // 
            newClientOrEditClient.Anchor = AnchorStyles.Top;
            newClientOrEditClient.AutoSize = true;
            newClientOrEditClient.Font = new Font("Segoe UI", 29F, FontStyle.Regular, GraphicsUnit.Point);
            newClientOrEditClient.ForeColor = Color.FromArgb(230, 237, 243);
            newClientOrEditClient.Location = new Point(367, 13);
            newClientOrEditClient.Name = "newClientOrEditClient";
            newClientOrEditClient.Size = new Size(312, 52);
            newClientOrEditClient.TabIndex = 53;
            newClientOrEditClient.Text = "Nuevo Instructor";
            // 
            // panel2
            // 
            panel2.Controls.Add(TBRutaImagen);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(IPImagenInstructor);
            panel2.Controls.Add(TBNombre);
            panel2.Controls.Add(LFechaNacimiento);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(BGuardarCliente);
            panel2.Controls.Add(label23);
            panel2.Controls.Add(RBFemenino);
            panel2.Controls.Add(label22);
            panel2.Controls.Add(DPFechaNacimiento);
            panel2.Controls.Add(RBMasculino);
            panel2.Controls.Add(TBContraseña);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(LContraseñaRequerido);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(TBTelefono);
            panel2.Controls.Add(TBUsuario);
            panel2.Controls.Add(TBApellido);
            panel2.Controls.Add(BTAgregarImagen);
            panel2.Controls.Add(LRuraImagen);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(LTelefonoRequerido);
            panel2.Controls.Add(LNombreRequerido);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(LUsurioRequerido);
            panel2.Controls.Add(LApellidoRequerido);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(33, 68);
            panel2.Name = "panel2";
            panel2.Size = new Size(934, 439);
            panel2.TabIndex = 54;
            // 
            // TBRutaImagen
            // 
            TBRutaImagen.BackColor = Color.FromArgb(69, 34, 99);
            TBRutaImagen.BorderStyle = BorderStyle.None;
            TBRutaImagen.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TBRutaImagen.ForeColor = Color.FromArgb(230, 237, 243);
            TBRutaImagen.Location = new Point(564, 321);
            TBRutaImagen.Name = "TBRutaImagen";
            TBRutaImagen.PlaceholderText = "Ruta...";
            TBRutaImagen.ReadOnly = true;
            TBRutaImagen.Size = new Size(186, 22);
            TBRutaImagen.TabIndex = 88;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(230, 237, 243);
            label5.Location = new Point(549, 13);
            label5.Name = "label5";
            label5.Size = new Size(192, 25);
            label5.TabIndex = 86;
            label5.Text = "Imagen del Instructor";
            // 
            // IPImagenInstructor
            // 
            IPImagenInstructor.Image = Properties.Resources.instructor1;
            IPImagenInstructor.Location = new Point(525, 41);
            IPImagenInstructor.Name = "IPImagenInstructor";
            IPImagenInstructor.Size = new Size(240, 183);
            IPImagenInstructor.SizeMode = PictureBoxSizeMode.Zoom;
            IPImagenInstructor.TabIndex = 85;
            IPImagenInstructor.TabStop = false;
            // 
            // TBNombre
            // 
            TBNombre.BackColor = Color.FromArgb(69, 34, 99);
            TBNombre.BorderColor = Color.Transparent;
            TBNombre.BorderFocusColor = Color.HotPink;
            TBNombre.BorderRadius = 15;
            TBNombre.BorderSize = 2;
            TBNombre.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            TBNombre.ForeColor = Color.FromArgb(230, 237, 243);
            TBNombre.Location = new Point(50, 77);
            TBNombre.Margin = new Padding(4);
            TBNombre.Multiline = false;
            TBNombre.Name = "TBNombre";
            TBNombre.Padding = new Padding(10, 7, 10, 7);
            TBNombre.PasswordChar = false;
            TBNombre.PlaceholderColor = Color.DarkGray;
            TBNombre.PlaceholderText = "Ingrese un nombre...";
            TBNombre.ReadOnly = false;
            TBNombre.Size = new Size(204, 31);
            TBNombre.TabIndex = 84;
            TBNombre.UnderlinedStyle = false;
            TBNombre.KeyPress += TBNombre_KeyPress;
            // 
            // LFechaNacimiento
            // 
            LFechaNacimiento.AutoSize = true;
            LFechaNacimiento.ForeColor = Color.Red;
            LFechaNacimiento.Location = new Point(350, 112);
            LFechaNacimiento.Name = "LFechaNacimiento";
            LFechaNacimiento.Size = new Size(105, 15);
            LFechaNacimiento.TabIndex = 83;
            LFechaNacimiento.Text = "*Campo requerido";
            LFechaNacimiento.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(230, 237, 243);
            label2.Location = new Point(594, 292);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 82;
            label2.Text = "Ruta de la imagen";
            // 
            // BGuardarCliente
            // 
            BGuardarCliente.BackColor = Color.FromArgb(41, 147, 45);
            BGuardarCliente.BackgroundColor = Color.FromArgb(41, 147, 45);
            BGuardarCliente.BorderColor = Color.PaleVioletRed;
            BGuardarCliente.BorderRadius = 15;
            BGuardarCliente.BorderSize = 0;
            BGuardarCliente.FlatAppearance.BorderSize = 0;
            BGuardarCliente.FlatStyle = FlatStyle.Flat;
            BGuardarCliente.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BGuardarCliente.ForeColor = Color.White;
            BGuardarCliente.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            BGuardarCliente.IconColor = Color.FromArgb(230, 237, 243);
            BGuardarCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BGuardarCliente.ImageAlign = ContentAlignment.MiddleRight;
            BGuardarCliente.Location = new Point(723, 368);
            BGuardarCliente.Name = "BGuardarCliente";
            BGuardarCliente.Padding = new Padding(10, 0, 0, 0);
            BGuardarCliente.Size = new Size(208, 53);
            BGuardarCliente.TabIndex = 64;
            BGuardarCliente.Text = "Guardar Instructor";
            BGuardarCliente.TextAlign = ContentAlignment.MiddleLeft;
            BGuardarCliente.TextColor = Color.White;
            BGuardarCliente.UseVisualStyleBackColor = false;
            BGuardarCliente.Click += BGuardarCliente_Click;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.ForeColor = Color.FromArgb(230, 237, 243);
            label23.Location = new Point(344, 66);
            label23.Name = "label23";
            label23.Size = new Size(117, 15);
            label23.TabIndex = 80;
            label23.Text = "Fecha de nacimiento";
            // 
            // RBFemenino
            // 
            RBFemenino.AutoSize = true;
            RBFemenino.ForeColor = Color.FromArgb(230, 237, 243);
            RBFemenino.Location = new Point(157, 292);
            RBFemenino.Name = "RBFemenino";
            RBFemenino.Size = new Size(78, 19);
            RBFemenino.TabIndex = 79;
            RBFemenino.Text = "Femenino";
            RBFemenino.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.ForeColor = Color.FromArgb(230, 237, 243);
            label22.Location = new Point(128, 274);
            label22.Name = "label22";
            label22.Size = new Size(32, 15);
            label22.TabIndex = 78;
            label22.Text = "Sexo";
            // 
            // DPFechaNacimiento
            // 
            DPFechaNacimiento.Format = DateTimePickerFormat.Short;
            DPFechaNacimiento.Location = new Point(344, 85);
            DPFechaNacimiento.Name = "DPFechaNacimiento";
            DPFechaNacimiento.Size = new Size(117, 23);
            DPFechaNacimiento.TabIndex = 77;
            // 
            // RBMasculino
            // 
            RBMasculino.AutoSize = true;
            RBMasculino.Checked = true;
            RBMasculino.ForeColor = Color.FromArgb(230, 237, 243);
            RBMasculino.Location = new Point(71, 292);
            RBMasculino.Name = "RBMasculino";
            RBMasculino.Size = new Size(80, 19);
            RBMasculino.TabIndex = 76;
            RBMasculino.TabStop = true;
            RBMasculino.Text = "Masculino";
            RBMasculino.UseVisualStyleBackColor = true;
            // 
            // TBContraseña
            // 
            TBContraseña.BackColor = Color.FromArgb(69, 34, 99);
            TBContraseña.BorderColor = Color.Transparent;
            TBContraseña.BorderFocusColor = Color.HotPink;
            TBContraseña.BorderRadius = 15;
            TBContraseña.BorderSize = 2;
            TBContraseña.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            TBContraseña.ForeColor = Color.FromArgb(230, 237, 243);
            TBContraseña.Location = new Point(300, 223);
            TBContraseña.Margin = new Padding(4);
            TBContraseña.Multiline = false;
            TBContraseña.Name = "TBContraseña";
            TBContraseña.Padding = new Padding(10, 7, 10, 7);
            TBContraseña.PasswordChar = false;
            TBContraseña.PlaceholderColor = Color.DarkGray;
            TBContraseña.PlaceholderText = "Ingrese una contraseña...";
            TBContraseña.ReadOnly = false;
            TBContraseña.Size = new Size(204, 31);
            TBContraseña.TabIndex = 75;
            TBContraseña.UnderlinedStyle = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ForeColor = Color.FromArgb(230, 237, 243);
            label17.Location = new Point(369, 204);
            label17.Name = "label17";
            label17.Size = new Size(67, 15);
            label17.TabIndex = 74;
            label17.Text = "Contraseña";
            // 
            // LContraseñaRequerido
            // 
            LContraseñaRequerido.AutoSize = true;
            LContraseñaRequerido.ForeColor = Color.Red;
            LContraseñaRequerido.Location = new Point(350, 258);
            LContraseñaRequerido.Name = "LContraseñaRequerido";
            LContraseñaRequerido.Size = new Size(105, 15);
            LContraseñaRequerido.TabIndex = 73;
            LContraseñaRequerido.Text = "*Campo requerido";
            LContraseñaRequerido.Visible = false;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top;
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label15.ForeColor = Color.FromArgb(230, 237, 243);
            label15.Location = new Point(189, 13);
            label15.Name = "label15";
            label15.Size = new Size(155, 25);
            label15.TabIndex = 72;
            label15.Text = "Datos del Cliente";
            // 
            // TBTelefono
            // 
            TBTelefono.BackColor = Color.FromArgb(69, 34, 99);
            TBTelefono.BorderColor = Color.Transparent;
            TBTelefono.BorderFocusColor = Color.HotPink;
            TBTelefono.BorderRadius = 15;
            TBTelefono.BorderSize = 2;
            TBTelefono.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            TBTelefono.ForeColor = Color.FromArgb(230, 237, 243);
            TBTelefono.Location = new Point(50, 217);
            TBTelefono.Margin = new Padding(4);
            TBTelefono.Multiline = true;
            TBTelefono.Name = "TBTelefono";
            TBTelefono.Padding = new Padding(10, 7, 10, 7);
            TBTelefono.PasswordChar = false;
            TBTelefono.PlaceholderColor = Color.DarkGray;
            TBTelefono.PlaceholderText = "Ingrese un número telefónico...";
            TBTelefono.ReadOnly = false;
            TBTelefono.Size = new Size(204, 31);
            TBTelefono.TabIndex = 70;
            TBTelefono.UnderlinedStyle = false;
            TBTelefono.KeyPress += TBTelefono_KeyPress;
            // 
            // TBUsuario
            // 
            TBUsuario.BackColor = Color.FromArgb(69, 34, 99);
            TBUsuario.BorderColor = Color.Transparent;
            TBUsuario.BorderFocusColor = Color.HotPink;
            TBUsuario.BorderRadius = 15;
            TBUsuario.BorderSize = 2;
            TBUsuario.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            TBUsuario.ForeColor = Color.FromArgb(230, 237, 243);
            TBUsuario.Location = new Point(300, 150);
            TBUsuario.Margin = new Padding(4);
            TBUsuario.Multiline = false;
            TBUsuario.Name = "TBUsuario";
            TBUsuario.Padding = new Padding(10, 7, 10, 7);
            TBUsuario.PasswordChar = false;
            TBUsuario.PlaceholderColor = Color.DarkGray;
            TBUsuario.PlaceholderText = "Ingrese un usuario...";
            TBUsuario.ReadOnly = false;
            TBUsuario.Size = new Size(204, 31);
            TBUsuario.TabIndex = 69;
            TBUsuario.UnderlinedStyle = false;
            // 
            // TBApellido
            // 
            TBApellido.BackColor = Color.FromArgb(69, 34, 99);
            TBApellido.BorderColor = Color.Transparent;
            TBApellido.BorderFocusColor = Color.HotPink;
            TBApellido.BorderRadius = 15;
            TBApellido.BorderSize = 2;
            TBApellido.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            TBApellido.ForeColor = Color.FromArgb(230, 237, 243);
            TBApellido.Location = new Point(50, 147);
            TBApellido.Margin = new Padding(4);
            TBApellido.Multiline = false;
            TBApellido.Name = "TBApellido";
            TBApellido.Padding = new Padding(10, 7, 10, 7);
            TBApellido.PasswordChar = false;
            TBApellido.PlaceholderColor = Color.DarkGray;
            TBApellido.PlaceholderText = "Ingrese un apellido...";
            TBApellido.ReadOnly = false;
            TBApellido.Size = new Size(204, 31);
            TBApellido.TabIndex = 68;
            TBApellido.UnderlinedStyle = false;
            TBApellido.KeyPress += TBApellido_KeyPress;
            // 
            // BTAgregarImagen
            // 
            BTAgregarImagen.BackColor = Color.DarkOrange;
            BTAgregarImagen.BackgroundColor = Color.DarkOrange;
            BTAgregarImagen.BorderColor = Color.PaleVioletRed;
            BTAgregarImagen.BorderRadius = 15;
            BTAgregarImagen.BorderSize = 0;
            BTAgregarImagen.FlatAppearance.BorderSize = 0;
            BTAgregarImagen.FlatStyle = FlatStyle.Flat;
            BTAgregarImagen.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BTAgregarImagen.ForeColor = Color.White;
            BTAgregarImagen.IconChar = FontAwesome.Sharp.IconChar.FileImage;
            BTAgregarImagen.IconColor = Color.FromArgb(230, 237, 243);
            BTAgregarImagen.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BTAgregarImagen.ImageAlign = ContentAlignment.MiddleRight;
            BTAgregarImagen.Location = new Point(552, 230);
            BTAgregarImagen.Name = "BTAgregarImagen";
            BTAgregarImagen.Padding = new Padding(10, 0, 0, 0);
            BTAgregarImagen.Size = new Size(186, 53);
            BTAgregarImagen.TabIndex = 66;
            BTAgregarImagen.Text = "Agregar Imagen";
            BTAgregarImagen.TextAlign = ContentAlignment.MiddleLeft;
            BTAgregarImagen.TextColor = Color.White;
            BTAgregarImagen.UseVisualStyleBackColor = false;
            BTAgregarImagen.Click += BTAgregarImagen_Click;
            // 
            // LRuraImagen
            // 
            LRuraImagen.AutoSize = true;
            LRuraImagen.ForeColor = Color.Red;
            LRuraImagen.Location = new Point(593, 346);
            LRuraImagen.Name = "LRuraImagen";
            LRuraImagen.Size = new Size(105, 15);
            LRuraImagen.TabIndex = 49;
            LRuraImagen.Text = "*Campo requerido";
            LRuraImagen.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.FromArgb(230, 237, 243);
            label8.Location = new Point(99, 199);
            label8.Name = "label8";
            label8.Size = new Size(107, 15);
            label8.TabIndex = 47;
            label8.Text = "Número telefónico";
            // 
            // LTelefonoRequerido
            // 
            LTelefonoRequerido.AutoSize = true;
            LTelefonoRequerido.ForeColor = Color.Red;
            LTelefonoRequerido.Location = new Point(100, 251);
            LTelefonoRequerido.Name = "LTelefonoRequerido";
            LTelefonoRequerido.Size = new Size(105, 15);
            LTelefonoRequerido.TabIndex = 46;
            LTelefonoRequerido.Text = "*Campo requerido";
            LTelefonoRequerido.Visible = false;
            // 
            // LNombreRequerido
            // 
            LNombreRequerido.AutoSize = true;
            LNombreRequerido.ForeColor = Color.Red;
            LNombreRequerido.Location = new Point(100, 111);
            LNombreRequerido.Name = "LNombreRequerido";
            LNombreRequerido.Size = new Size(105, 15);
            LNombreRequerido.TabIndex = 37;
            LNombreRequerido.Text = "*Campo requerido";
            LNombreRequerido.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.FromArgb(230, 237, 243);
            label6.Location = new Point(382, 131);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 44;
            label6.Text = "Usurio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(230, 237, 243);
            label3.Location = new Point(127, 59);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 38;
            label3.Text = "Nombre";
            // 
            // LUsurioRequerido
            // 
            LUsurioRequerido.AutoSize = true;
            LUsurioRequerido.ForeColor = Color.Red;
            LUsurioRequerido.Location = new Point(350, 185);
            LUsurioRequerido.Name = "LUsurioRequerido";
            LUsurioRequerido.Size = new Size(105, 15);
            LUsurioRequerido.TabIndex = 43;
            LUsurioRequerido.Text = "*Campo requerido";
            LUsurioRequerido.Visible = false;
            // 
            // LApellidoRequerido
            // 
            LApellidoRequerido.AutoSize = true;
            LApellidoRequerido.ForeColor = Color.Red;
            LApellidoRequerido.Location = new Point(100, 181);
            LApellidoRequerido.Name = "LApellidoRequerido";
            LApellidoRequerido.Size = new Size(105, 15);
            LApellidoRequerido.TabIndex = 40;
            LApellidoRequerido.Text = "*Campo requerido";
            LApellidoRequerido.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(230, 237, 243);
            label4.Location = new Point(127, 129);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 41;
            label4.Text = "Apellido";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddInstructorControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "AddInstructorControl";
            Size = new Size(1000, 530);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IPImagenInstructor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private ClassCustom.RJButton BGuardarCliente;
        private Label newClientOrEditClient;
        private Panel panel2;
        private CustomControls.RJControls.RJTextBox TBNombre;
        private Label LFechaNacimiento;
        private Label label2;
        private Label label23;
        private RadioButton RBFemenino;
        private Label label22;
        private DateTimePicker DPFechaNacimiento;
        private RadioButton RBMasculino;
        private CustomControls.RJControls.RJTextBox TBContraseña;
        private Label label17;
        private Label LContraseñaRequerido;
        private CustomControls.RJControls.RJTextBox TBTelefono;
        private CustomControls.RJControls.RJTextBox TBUsuario;
        private CustomControls.RJControls.RJTextBox TBApellido;
        private ClassCustom.RJButton BTAgregarImagen;
        private Label LRuraImagen;
        private Label label8;
        private Label LTelefonoRequerido;
        private Label LNombreRequerido;
        private Label label6;
        private Label label3;
        private Label LUsurioRequerido;
        private Label LApellidoRequerido;
        private Label label4;
        private PictureBox IPImagenInstructor;
        private Label label5;
        private Label label15;
        private TextBox TBRutaImagen;
        private OpenFileDialog openFileDialog1;
        private ClassCustom.RJButton BBack;
    }
}
