using FontAwesome.Sharp;

namespace gymsy.UserControls
{
    partial class AddClientUserControl
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
            label12 = new Label();
            newClientOrEditClient = new Label();
            panel2 = new Panel();
            label9 = new Label();
            DPVencimiento = new DateTimePicker();
            LidPlan = new Label();
            LRuraImagen = new Label();
            TBNombreInstructor = new TextBox();
            TBDescripcion = new TextBox();
            TBPrecio = new TextBox();
            TBRutaImagen = new TextBox();
            label5 = new Label();
            IPImagenUsuario = new PictureBox();
            TBNombre = new CustomControls.RJControls.RJTextBox();
            CBPlanes = new CustomControls.RJControls.RJComboBox();
            LFechaNacimiento = new Label();
            BGuardarCliente = new ClassCustom.RJButton();
            label2 = new Label();
            LPlanRequerido = new Label();
            label20 = new Label();
            label23 = new Label();
            label18 = new Label();
            RBFemenino = new RadioButton();
            label16 = new Label();
            label22 = new Label();
            label14 = new Label();
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
            label10 = new Label();
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
            ((System.ComponentModel.ISupportInitialize)IPImagenUsuario).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(2075, 572);
            label1.Name = "label1";
            label1.Size = new Size(277, 37);
            label1.TabIndex = 0;
            label1.Text = "AddClientUserControl";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(16, 8, 23);
            panel1.Controls.Add(BBack);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(newClientOrEditClient);
            panel1.Controls.Add(panel2);
            panel1.ForeColor = Color.FromArgb(230, 237, 243);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(2436, 674);
            panel1.TabIndex = 1;
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
            BBack.IconChar = IconChar.ArrowLeftLong;
            BBack.IconColor = Color.FromArgb(230, 237, 243);
            BBack.IconFont = IconFont.Auto;
            BBack.IconSize = 90;
            BBack.ImageAlign = ContentAlignment.MiddleRight;
            BBack.Location = new Point(0, 0);
            BBack.Name = "BBack";
            BBack.Padding = new Padding(10, 0, 0, 0);
            BBack.Size = new Size(103, 64);
            BBack.TabIndex = 98;
            BBack.TextAlign = ContentAlignment.MiddleLeft;
            BBack.TextColor = Color.White;
            BBack.UseVisualStyleBackColor = false;
            BBack.Visible = false;
            BBack.Click += BBack_Click;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = SystemColors.ActiveCaptionText;
            label12.Location = new Point(1425, 112);
            label12.Name = "label12";
            label12.Size = new Size(153, 25);
            label12.TabIndex = 50;
            label12.Text = "Asignale un plan";
            // 
            // newClientOrEditClient
            // 
            newClientOrEditClient.Anchor = AnchorStyles.Top;
            newClientOrEditClient.AutoSize = true;
            newClientOrEditClient.Font = new Font("Segoe UI", 29F, FontStyle.Regular, GraphicsUnit.Point);
            newClientOrEditClient.ForeColor = Color.FromArgb(230, 237, 243);
            newClientOrEditClient.Location = new Point(402, 18);
            newClientOrEditClient.Name = "newClientOrEditClient";
            newClientOrEditClient.Size = new Size(281, 52);
            newClientOrEditClient.TabIndex = 33;
            newClientOrEditClient.Text = "Nuevo Alumno";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.AutoSize = true;
            panel2.Controls.Add(label9);
            panel2.Controls.Add(DPVencimiento);
            panel2.Controls.Add(LidPlan);
            panel2.Controls.Add(LRuraImagen);
            panel2.Controls.Add(TBNombreInstructor);
            panel2.Controls.Add(TBDescripcion);
            panel2.Controls.Add(TBPrecio);
            panel2.Controls.Add(TBRutaImagen);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(IPImagenUsuario);
            panel2.Controls.Add(TBNombre);
            panel2.Controls.Add(CBPlanes);
            panel2.Controls.Add(LFechaNacimiento);
            panel2.Controls.Add(BGuardarCliente);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(LPlanRequerido);
            panel2.Controls.Add(label20);
            panel2.Controls.Add(label23);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(RBFemenino);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(label22);
            panel2.Controls.Add(label14);
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
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(LTelefonoRequerido);
            panel2.Controls.Add(LNombreRequerido);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(LUsurioRequerido);
            panel2.Controls.Add(LApellidoRequerido);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(3, 73);
            panel2.Name = "panel2";
            panel2.Size = new Size(1215, 533);
            panel2.TabIndex = 51;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.FromArgb(230, 237, 243);
            label9.Location = new Point(766, 311);
            label9.Name = "label9";
            label9.Size = new Size(123, 15);
            label9.TabIndex = 97;
            label9.Text = "Fecha de vencimiento";
            // 
            // DPVencimiento
            // 
            DPVencimiento.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DPVencimiento.CalendarForeColor = Color.FromArgb(230, 237, 243);
            DPVencimiento.CalendarMonthBackground = Color.FromArgb(16, 8, 23);
            DPVencimiento.CalendarTitleBackColor = Color.DarkOrange;
            DPVencimiento.CalendarTitleForeColor = Color.FromArgb(9, 0, 20);
            DPVencimiento.Format = DateTimePickerFormat.Short;
            DPVencimiento.Location = new Point(769, 338);
            DPVencimiento.MaxDate = new DateTime(5023, 10, 17, 0, 0, 0, 0);
            DPVencimiento.MinDate = new DateTime(2023, 10, 28, 0, 0, 0, 0);
            DPVencimiento.Name = "DPVencimiento";
            DPVencimiento.Size = new Size(117, 23);
            DPVencimiento.TabIndex = 96;
            DPVencimiento.Value = new DateTime(2023, 10, 28, 0, 0, 0, 0);
            // 
            // LidPlan
            // 
            LidPlan.AutoSize = true;
            LidPlan.Location = new Point(897, 50);
            LidPlan.Name = "LidPlan";
            LidPlan.Size = new Size(120, 15);
            LidPlan.TabIndex = 92;
            LidPlan.Text = "aux_id_plan(invisible)";
            LidPlan.Visible = false;
            // 
            // LRuraImagen
            // 
            LRuraImagen.AutoSize = true;
            LRuraImagen.ForeColor = Color.Red;
            LRuraImagen.Location = new Point(511, 363);
            LRuraImagen.Name = "LRuraImagen";
            LRuraImagen.Size = new Size(139, 15);
            LRuraImagen.TabIndex = 91;
            LRuraImagen.Text = "*Debes subir una imagen";
            LRuraImagen.Visible = false;
            // 
            // TBNombreInstructor
            // 
            TBNombreInstructor.BackColor = Color.FromArgb(69, 34, 99);
            TBNombreInstructor.BorderStyle = BorderStyle.None;
            TBNombreInstructor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TBNombreInstructor.ForeColor = Color.FromArgb(230, 237, 243);
            TBNombreInstructor.Location = new Point(740, 268);
            TBNombreInstructor.Name = "TBNombreInstructor";
            TBNombreInstructor.PlaceholderText = "...";
            TBNombreInstructor.ReadOnly = true;
            TBNombreInstructor.Size = new Size(186, 22);
            TBNombreInstructor.TabIndex = 90;
            // 
            // TBDescripcion
            // 
            TBDescripcion.BackColor = Color.FromArgb(69, 34, 99);
            TBDescripcion.BorderStyle = BorderStyle.None;
            TBDescripcion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TBDescripcion.ForeColor = Color.FromArgb(230, 237, 243);
            TBDescripcion.Location = new Point(740, 213);
            TBDescripcion.Name = "TBDescripcion";
            TBDescripcion.PlaceholderText = "...";
            TBDescripcion.ReadOnly = true;
            TBDescripcion.Size = new Size(186, 22);
            TBDescripcion.TabIndex = 89;
            // 
            // TBPrecio
            // 
            TBPrecio.BackColor = Color.FromArgb(69, 34, 99);
            TBPrecio.BorderStyle = BorderStyle.None;
            TBPrecio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TBPrecio.ForeColor = Color.FromArgb(230, 237, 243);
            TBPrecio.Location = new Point(740, 158);
            TBPrecio.Name = "TBPrecio";
            TBPrecio.PlaceholderText = "...";
            TBPrecio.ReadOnly = true;
            TBPrecio.Size = new Size(186, 22);
            TBPrecio.TabIndex = 88;
            // 
            // TBRutaImagen
            // 
            TBRutaImagen.BackColor = Color.FromArgb(69, 34, 99);
            TBRutaImagen.BorderStyle = BorderStyle.None;
            TBRutaImagen.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TBRutaImagen.ForeColor = Color.FromArgb(230, 237, 243);
            TBRutaImagen.Location = new Point(507, 326);
            TBRutaImagen.Name = "TBRutaImagen";
            TBRutaImagen.PlaceholderText = "Ruta...";
            TBRutaImagen.ReadOnly = true;
            TBRutaImagen.Size = new Size(186, 22);
            TBRutaImagen.TabIndex = 87;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(230, 237, 243);
            label5.Location = new Point(542, 48);
            label5.Name = "label5";
            label5.Size = new Size(106, 15);
            label5.TabIndex = 86;
            label5.Text = "Imagen del Cliente";
            // 
            // IPImagenUsuario
            // 
            IPImagenUsuario.Image = Properties.Resources.vector_fitness_couple_doing_exercise1;
            IPImagenUsuario.Location = new Point(497, 68);
            IPImagenUsuario.Name = "IPImagenUsuario";
            IPImagenUsuario.Size = new Size(207, 177);
            IPImagenUsuario.SizeMode = PictureBoxSizeMode.Zoom;
            IPImagenUsuario.TabIndex = 85;
            IPImagenUsuario.TabStop = false;
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
            TBNombre.Location = new Point(23, 70);
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
            // CBPlanes
            // 
            CBPlanes.BackColor = Color.FromArgb(69, 34, 99);
            CBPlanes.BorderColor = Color.MediumSlateBlue;
            CBPlanes.BorderSize = 1;
            CBPlanes.DropDownStyle = ComboBoxStyle.DropDownList;
            CBPlanes.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            CBPlanes.ForeColor = Color.FromArgb(230, 237, 243);
            CBPlanes.IconColor = Color.MediumSlateBlue;
            CBPlanes.ListBackColor = Color.FromArgb(69, 34, 99);
            CBPlanes.ListTextColor = Color.DimGray;
            CBPlanes.Location = new Point(724, 71);
            CBPlanes.MinimumSize = new Size(200, 30);
            CBPlanes.Name = "CBPlanes";
            CBPlanes.Padding = new Padding(1);
            CBPlanes.Size = new Size(219, 30);
            CBPlanes.TabIndex = 77;
            CBPlanes.Texts = "Ver planes";
            CBPlanes.OnSelectedIndexChanged += CBPlanes_OnSelectedIndexChanged;
            // 
            // LFechaNacimiento
            // 
            LFechaNacimiento.AutoSize = true;
            LFechaNacimiento.ForeColor = Color.Red;
            LFechaNacimiento.Location = new Point(312, 95);
            LFechaNacimiento.Name = "LFechaNacimiento";
            LFechaNacimiento.Size = new Size(105, 15);
            LFechaNacimiento.TabIndex = 83;
            LFechaNacimiento.Text = "*Campo requerido";
            LFechaNacimiento.Visible = false;
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
            BGuardarCliente.IconChar = IconChar.FloppyDisk;
            BGuardarCliente.IconColor = Color.FromArgb(230, 237, 243);
            BGuardarCliente.IconFont = IconFont.Auto;
            BGuardarCliente.ImageAlign = ContentAlignment.MiddleRight;
            BGuardarCliente.Location = new Point(780, 423);
            BGuardarCliente.Name = "BGuardarCliente";
            BGuardarCliente.Padding = new Padding(10, 0, 0, 0);
            BGuardarCliente.Size = new Size(202, 63);
            BGuardarCliente.TabIndex = 76;
            BGuardarCliente.Text = "Guardar Alumno";
            BGuardarCliente.TextAlign = ContentAlignment.MiddleLeft;
            BGuardarCliente.TextColor = Color.White;
            BGuardarCliente.UseVisualStyleBackColor = false;
            BGuardarCliente.Click += BGuardarCliente_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(230, 237, 243);
            label2.Location = new Point(549, 308);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 82;
            label2.Text = "Ruta de la imagen";
            // 
            // LPlanRequerido
            // 
            LPlanRequerido.AutoSize = true;
            LPlanRequerido.ForeColor = Color.Red;
            LPlanRequerido.Location = new Point(769, 106);
            LPlanRequerido.Name = "LPlanRequerido";
            LPlanRequerido.Size = new Size(125, 15);
            LPlanRequerido.TabIndex = 74;
            LPlanRequerido.Text = "*Debe agregar un plan";
            LPlanRequerido.Visible = false;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.ForeColor = Color.FromArgb(230, 237, 243);
            label20.Location = new Point(773, 244);
            label20.Name = "label20";
            label20.Size = new Size(121, 15);
            label20.TabIndex = 75;
            label20.Text = "Nombre de Instructor";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.ForeColor = Color.FromArgb(230, 237, 243);
            label23.Location = new Point(306, 49);
            label23.Name = "label23";
            label23.Size = new Size(117, 15);
            label23.TabIndex = 80;
            label23.Text = "Fecha de nacimiento";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.ForeColor = Color.FromArgb(230, 237, 243);
            label18.Location = new Point(799, 189);
            label18.Name = "label18";
            label18.Size = new Size(69, 15);
            label18.TabIndex = 73;
            label18.Text = "Descripcion";
            // 
            // RBFemenino
            // 
            RBFemenino.AutoSize = true;
            RBFemenino.Location = new Point(149, 301);
            RBFemenino.Name = "RBFemenino";
            RBFemenino.Size = new Size(78, 19);
            RBFemenino.TabIndex = 79;
            RBFemenino.Text = "Femenino";
            RBFemenino.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = Color.FromArgb(230, 237, 243);
            label16.Location = new Point(813, 134);
            label16.Name = "label16";
            label16.Size = new Size(40, 15);
            label16.TabIndex = 72;
            label16.Text = "Precio";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.ForeColor = Color.FromArgb(230, 237, 243);
            label22.Location = new Point(109, 278);
            label22.Name = "label22";
            label22.Size = new Size(32, 15);
            label22.TabIndex = 78;
            label22.Text = "Sexo";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top;
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label14.ForeColor = Color.FromArgb(230, 237, 243);
            label14.Location = new Point(773, 36);
            label14.Name = "label14";
            label14.Size = new Size(118, 25);
            label14.TabIndex = 71;
            label14.Text = "Asignar plan";
            // 
            // DPFechaNacimiento
            // 
            DPFechaNacimiento.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DPFechaNacimiento.CalendarForeColor = Color.FromArgb(230, 237, 243);
            DPFechaNacimiento.CalendarMonthBackground = Color.FromArgb(16, 8, 23);
            DPFechaNacimiento.CalendarTitleBackColor = Color.DarkOrange;
            DPFechaNacimiento.CalendarTitleForeColor = Color.FromArgb(9, 0, 20);
            DPFechaNacimiento.Format = DateTimePickerFormat.Short;
            DPFechaNacimiento.Location = new Point(306, 68);
            DPFechaNacimiento.MaxDate = new DateTime(5023, 10, 28, 0, 0, 0, 0);
            DPFechaNacimiento.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            DPFechaNacimiento.Name = "DPFechaNacimiento";
            DPFechaNacimiento.Size = new Size(117, 23);
            DPFechaNacimiento.TabIndex = 77;
            DPFechaNacimiento.Value = new DateTime(2023, 10, 28, 0, 0, 0, 0);
            // 
            // RBMasculino
            // 
            RBMasculino.AutoSize = true;
            RBMasculino.Checked = true;
            RBMasculino.Location = new Point(35, 301);
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
            TBContraseña.Location = new Point(262, 206);
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
            label17.Location = new Point(331, 187);
            label17.Name = "label17";
            label17.Size = new Size(67, 15);
            label17.TabIndex = 74;
            label17.Text = "Contraseña";
            // 
            // LContraseñaRequerido
            // 
            LContraseñaRequerido.AutoSize = true;
            LContraseñaRequerido.ForeColor = Color.Red;
            LContraseñaRequerido.Location = new Point(312, 241);
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
            label15.Location = new Point(311, 10);
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
            TBTelefono.Location = new Point(23, 222);
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
            TBUsuario.Location = new Point(262, 133);
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
            TBApellido.Location = new Point(23, 146);
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
            BTAgregarImagen.IconChar = IconChar.FileImage;
            BTAgregarImagen.IconColor = Color.FromArgb(230, 237, 243);
            BTAgregarImagen.IconFont = IconFont.Auto;
            BTAgregarImagen.ImageAlign = ContentAlignment.MiddleRight;
            BTAgregarImagen.Location = new Point(507, 250);
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
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.ActiveCaptionText;
            label10.Location = new Point(-457, 40);
            label10.Name = "label10";
            label10.Size = new Size(155, 25);
            label10.TabIndex = 48;
            label10.Text = "Datos del Cliente";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.FromArgb(230, 237, 243);
            label8.Location = new Point(72, 202);
            label8.Name = "label8";
            label8.Size = new Size(107, 15);
            label8.TabIndex = 47;
            label8.Text = "Número telefónico";
            // 
            // LTelefonoRequerido
            // 
            LTelefonoRequerido.AutoSize = true;
            LTelefonoRequerido.ForeColor = Color.Red;
            LTelefonoRequerido.Location = new Point(73, 258);
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
            LNombreRequerido.Location = new Point(73, 106);
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
            label6.Location = new Point(344, 114);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 44;
            label6.Text = "Usurio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(230, 237, 243);
            label3.Location = new Point(100, 50);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 38;
            label3.Text = "Nombre";
            // 
            // LUsurioRequerido
            // 
            LUsurioRequerido.AutoSize = true;
            LUsurioRequerido.ForeColor = Color.Red;
            LUsurioRequerido.Location = new Point(312, 168);
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
            LApellidoRequerido.Location = new Point(73, 182);
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
            label4.Location = new Point(100, 126);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 41;
            label4.Text = "Apellido";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddClientUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(panel1);
            Controls.Add(label1);
            Margin = new Padding(0);
            Name = "AddClientUserControl";
            Size = new Size(1218, 609);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IPImagenUsuario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label newClientOrEditClient;
        private Label LNombreRequerido;
        private Label label4;
        private Label LApellidoRequerido;
        private Label label3;
        private Label label12;
        private Label LRuraImagen;
        private Label label10;
        private Label label8;
        private Label LTelefonoRequerido;
        private Label label6;
        private Label LUsurioRequerido;
        private Panel panel2;
        private ClassCustom.RJButton BTAgregarImagen;
        private CustomControls.RJControls.RJTextBox TBTelefono;
        private CustomControls.RJControls.RJTextBox TBUsuario;
        private CustomControls.RJControls.RJTextBox TBApellido;
        private Label label15;
        private CustomControls.RJControls.RJTextBox TBContraseña;
        private Label label17;
        private Label LContraseñaRequerido;
        private Label label23;
        private RadioButton RBFemenino;
        private Label label22;
        private DateTimePicker DPFechaNacimiento;
        private RadioButton RBMasculino;
        private OpenFileDialog openFileDialog1;
        private Label label2;
        private Label LFechaNacimiento;
        private CustomControls.RJControls.RJTextBox TBNombre;
        private PictureBox IPImagenUsuario;
        private Label label5;
        private CustomControls.RJControls.RJComboBox CBPlanes;
        private ClassCustom.RJButton BGuardarCliente;
        private Label LPlanRequerido;
        private Label label20;
        private Label label18;
        private Label label16;
        private Label label14;
        private TextBox TBRutaImagen;
        private TextBox TBNombreInstructor;
        private TextBox TBDescripcion;
        private TextBox TBPrecio;
        private Label label7;
        private Label LidPlan;
        private Label label9;
        private DateTimePicker DPVencimiento;
        private ClassCustom.RJButton BBack;
    }
}
