namespace gymsy.UserControls.ClientControls
{
    partial class ProgressClientControl
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressClientControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            panel6 = new Panel();
            panelWalletWrapper = new Panel();
            panel2 = new Panel();
            panel5 = new Panel();
            BtnInactiveReg = new ClassCustom.RJButton();
            TBRegDescription = new TextBox();
            TBRegFecha = new Label();
            panelGallery = new Panel();
            PhotoActive = new PictureBox();
            panel3 = new Panel();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            TBDescripcionClient = new TextBox();
            panel7 = new Panel();
            PanelMessageCount = new Panel();
            rjButton1 = new ClassCustom.RJButton();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            btnAddProgress = new ClassCustom.RJButton();
            label4 = new Label();
            dataGridProgress = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            gridDate = new DataGridViewTextBoxColumn();
            ShowData = new DataGridViewButtonColumn();
            Peso = new DataGridViewTextBoxColumn();
            gridTitle = new DataGridViewTextBoxColumn();
            estadoFisicoBindingSource = new BindingSource(components);
            idEstadoFisicoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tituloDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pesoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            alturaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaCreacionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            notasDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoFisicoInactivoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            idAlumnoSuscripcionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            imagenUrlDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idAlumnoSuscripcionNavigationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            panel6.SuspendLayout();
            panelWalletWrapper.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panelGallery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PhotoActive).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel7.SuspendLayout();
            PanelMessageCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProgress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)estadoFisicoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel6
            // 
            panel6.Controls.Add(panelWalletWrapper);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(990, 576);
            panel6.TabIndex = 44;
            // 
            // panelWalletWrapper
            // 
            panelWalletWrapper.Controls.Add(panel2);
            panelWalletWrapper.Controls.Add(panel3);
            panelWalletWrapper.Dock = DockStyle.Fill;
            panelWalletWrapper.Location = new Point(0, 0);
            panelWalletWrapper.Name = "panelWalletWrapper";
            panelWalletWrapper.Size = new Size(990, 576);
            panelWalletWrapper.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panelGallery);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(642, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(348, 576);
            panel2.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(BtnInactiveReg);
            panel5.Controls.Add(TBRegDescription);
            panel5.Controls.Add(TBRegFecha);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(348, 189);
            panel5.TabIndex = 38;
            // 
            // BtnInactiveReg
            // 
            BtnInactiveReg.BackColor = Color.Crimson;
            BtnInactiveReg.BackgroundColor = Color.Crimson;
            BtnInactiveReg.BorderColor = Color.PaleVioletRed;
            BtnInactiveReg.BorderRadius = 12;
            BtnInactiveReg.BorderSize = 0;
            BtnInactiveReg.Cursor = Cursors.Hand;
            BtnInactiveReg.FlatAppearance.BorderSize = 0;
            BtnInactiveReg.FlatStyle = FlatStyle.Flat;
            BtnInactiveReg.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            BtnInactiveReg.ForeColor = Color.White;
            BtnInactiveReg.IconChar = FontAwesome.Sharp.IconChar.TrashRestoreAlt;
            BtnInactiveReg.IconColor = Color.White;
            BtnInactiveReg.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnInactiveReg.IconSize = 25;
            BtnInactiveReg.Location = new Point(304, 156);
            BtnInactiveReg.Margin = new Padding(0);
            BtnInactiveReg.Name = "BtnInactiveReg";
            BtnInactiveReg.Padding = new Padding(4, 0, 0, 0);
            BtnInactiveReg.Size = new Size(39, 30);
            BtnInactiveReg.TabIndex = 46;
            BtnInactiveReg.TextColor = Color.White;
            BtnInactiveReg.UseVisualStyleBackColor = false;
            BtnInactiveReg.Click += BtnInactiveReg_Click;
            // 
            // TBRegDescription
            // 
            TBRegDescription.BackColor = Color.White;
            TBRegDescription.Enabled = false;
            TBRegDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TBRegDescription.ForeColor = Color.FromArgb(16, 8, 30);
            TBRegDescription.Location = new Point(5, 83);
            TBRegDescription.Margin = new Padding(10);
            TBRegDescription.Multiline = true;
            TBRegDescription.Name = "TBRegDescription";
            TBRegDescription.ReadOnly = true;
            TBRegDescription.Size = new Size(338, 79);
            TBRegDescription.TabIndex = 7;
            TBRegDescription.Text = "Descripcion de cuando se tomo estos datos asfasdfasdfasdfsdsfsfdf, do se tomo estos datos asfasdfasdfasdfsdsfsfdf";
            // 
            // TBRegFecha
            // 
            TBRegFecha.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TBRegFecha.AutoSize = true;
            TBRegFecha.BackColor = Color.Transparent;
            TBRegFecha.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            TBRegFecha.ForeColor = Color.FromArgb(16, 8, 30);
            TBRegFecha.ImageAlign = ContentAlignment.MiddleLeft;
            TBRegFecha.Location = new Point(67, 32);
            TBRegFecha.Name = "TBRegFecha";
            TBRegFecha.Size = new Size(235, 37);
            TBRegFecha.TabIndex = 4;
            TBRegFecha.Text = "Datos 24/55/2021";
            TBRegFecha.TextAlign = ContentAlignment.TopCenter;
            // 
            // panelGallery
            // 
            panelGallery.Controls.Add(PhotoActive);
            panelGallery.Dock = DockStyle.Bottom;
            panelGallery.Location = new Point(0, 193);
            panelGallery.Name = "panelGallery";
            panelGallery.Size = new Size(348, 383);
            panelGallery.TabIndex = 43;
            // 
            // PhotoActive
            // 
            PhotoActive.BackColor = Color.FromArgb(16, 8, 30);
            PhotoActive.Dock = DockStyle.Fill;
            PhotoActive.Image = (Image)resources.GetObject("PhotoActive.Image");
            PhotoActive.Location = new Point(0, 0);
            PhotoActive.Name = "PhotoActive";
            PhotoActive.Size = new Size(348, 383);
            PhotoActive.SizeMode = PictureBoxSizeMode.StretchImage;
            PhotoActive.TabIndex = 46;
            PhotoActive.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(16, 8, 23);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(TBDescripcionClient);
            panel3.Controls.Add(panel7);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(990, 576);
            panel3.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(70, 20);
            label3.Name = "label3";
            label3.Size = new Size(136, 41);
            label3.TabIndex = 3;
            label3.Text = "Pregreso";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-14, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 58);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // TBDescripcionClient
            // 
            TBDescripcionClient.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TBDescripcionClient.BackColor = Color.FromArgb(16, 8, 23);
            TBDescripcionClient.Enabled = false;
            TBDescripcionClient.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TBDescripcionClient.ForeColor = Color.White;
            TBDescripcionClient.Location = new Point(10, 83);
            TBDescripcionClient.Margin = new Padding(10);
            TBDescripcionClient.Multiline = true;
            TBDescripcionClient.Name = "TBDescripcionClient";
            TBDescripcionClient.ReadOnly = true;
            TBDescripcionClient.Size = new Size(633, 60);
            TBDescripcionClient.TabIndex = 8;
            TBDescripcionClient.Text = "Cristiano Ronaldo, 37 años comenzo a enrenarse 23/08/2007 (17 años), cuenta con 14 registros guardados ";
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(16, 8, 23);
            panel7.Controls.Add(PanelMessageCount);
            panel7.Controls.Add(btnAddProgress);
            panel7.Controls.Add(label4);
            panel7.Controls.Add(dataGridProgress);
            panel7.Dock = DockStyle.Bottom;
            panel7.Location = new Point(0, 126);
            panel7.MinimumSize = new Size(0, 450);
            panel7.Name = "panel7";
            panel7.Size = new Size(990, 450);
            panel7.TabIndex = 2;
            // 
            // PanelMessageCount
            // 
            PanelMessageCount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PanelMessageCount.Controls.Add(rjButton1);
            PanelMessageCount.Controls.Add(label1);
            PanelMessageCount.Controls.Add(pictureBox2);
            PanelMessageCount.Location = new Point(111, 206);
            PanelMessageCount.Name = "PanelMessageCount";
            PanelMessageCount.Size = new Size(384, 75);
            PanelMessageCount.TabIndex = 47;
            PanelMessageCount.Visible = false;
            // 
            // rjButton1
            // 
            rjButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rjButton1.BackColor = Color.DarkCyan;
            rjButton1.BackgroundColor = Color.DarkCyan;
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 0;
            rjButton1.Cursor = Cursors.Hand;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Flip = FontAwesome.Sharp.FlipOrientation.Vertical;
            rjButton1.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.White;
            rjButton1.IconChar = FontAwesome.Sharp.IconChar.Add;
            rjButton1.IconColor = Color.White;
            rjButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            rjButton1.IconSize = 30;
            rjButton1.ImageAlign = ContentAlignment.MiddleRight;
            rjButton1.Location = new Point(338, 21);
            rjButton1.Margin = new Padding(0);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(40, 40);
            rjButton1.TabIndex = 48;
            rjButton1.TextAlign = ContentAlignment.BottomLeft;
            rjButton1.TextColor = Color.White;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += btnAddProgress_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(53, 29);
            label1.Name = "label1";
            label1.Size = new Size(286, 25);
            label1.TabIndex = 47;
            label1.Text = "No se ha registrado seguimiento";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(4, 18);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 43);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 46;
            pictureBox2.TabStop = false;
            // 
            // btnAddProgress
            // 
            btnAddProgress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddProgress.BackColor = Color.DarkCyan;
            btnAddProgress.BackgroundColor = Color.DarkCyan;
            btnAddProgress.BorderColor = Color.PaleVioletRed;
            btnAddProgress.BorderRadius = 20;
            btnAddProgress.BorderSize = 0;
            btnAddProgress.Cursor = Cursors.Hand;
            btnAddProgress.FlatAppearance.BorderSize = 0;
            btnAddProgress.FlatStyle = FlatStyle.Flat;
            btnAddProgress.Flip = FontAwesome.Sharp.FlipOrientation.Vertical;
            btnAddProgress.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddProgress.ForeColor = Color.White;
            btnAddProgress.IconChar = FontAwesome.Sharp.IconChar.Add;
            btnAddProgress.IconColor = Color.White;
            btnAddProgress.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddProgress.IconSize = 30;
            btnAddProgress.ImageAlign = ContentAlignment.MiddleRight;
            btnAddProgress.Location = new Point(597, 22);
            btnAddProgress.Margin = new Padding(0);
            btnAddProgress.Name = "btnAddProgress";
            btnAddProgress.Size = new Size(40, 40);
            btnAddProgress.TabIndex = 45;
            btnAddProgress.TextAlign = ContentAlignment.BottomLeft;
            btnAddProgress.TextColor = Color.White;
            btnAddProgress.UseVisualStyleBackColor = false;
            btnAddProgress.Click += btnAddProgress_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 24);
            label4.Name = "label4";
            label4.Size = new Size(155, 37);
            label4.TabIndex = 4;
            label4.Text = "Registrados";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dataGridProgress
            // 
            dataGridProgress.AllowUserToAddRows = false;
            dataGridProgress.AllowUserToDeleteRows = false;
            dataGridProgress.AllowUserToResizeColumns = false;
            dataGridProgress.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.Transparent;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridProgress.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridProgress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridProgress.AutoGenerateColumns = false;
            dataGridProgress.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridProgress.BackgroundColor = Color.FromArgb(16, 8, 30);
            dataGridProgress.CausesValidation = false;
            dataGridProgress.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Transparent;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridProgress.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridProgress.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProgress.Columns.AddRange(new DataGridViewColumn[] { ID, gridDate, ShowData, Peso, gridTitle, idEstadoFisicoDataGridViewTextBoxColumn, tituloDataGridViewTextBoxColumn, pesoDataGridViewTextBoxColumn, alturaDataGridViewTextBoxColumn, fechaCreacionDataGridViewTextBoxColumn, notasDataGridViewTextBoxColumn, estadoFisicoInactivoDataGridViewCheckBoxColumn, idAlumnoSuscripcionDataGridViewTextBoxColumn, imagenUrlDataGridViewTextBoxColumn, idAlumnoSuscripcionNavigationDataGridViewTextBoxColumn });
            dataGridProgress.DataSource = estadoFisicoBindingSource;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridProgress.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridProgress.GridColor = Color.Black;
            dataGridProgress.Location = new Point(-2, 66);
            dataGridProgress.Margin = new Padding(0);
            dataGridProgress.MultiSelect = false;
            dataGridProgress.Name = "dataGridProgress";
            dataGridProgress.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.IndianRed;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.GrayText;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridProgress.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridProgress.RowHeadersVisible = false;
            dataGridProgress.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = Color.White;
            dataGridViewCellStyle8.Padding = new Padding(0, 10, 0, 10);
            dataGridViewCellStyle8.SelectionBackColor = Color.White;
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dataGridProgress.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dataGridProgress.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(16, 8, 30);
            dataGridProgress.RowTemplate.DefaultCellStyle.ForeColor = Color.White;
            dataGridProgress.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.DarkSlateBlue;
            dataGridProgress.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridProgress.RowTemplate.Height = 30;
            dataGridProgress.ScrollBars = ScrollBars.None;
            dataGridProgress.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProgress.Size = new Size(807, 383);
            dataGridProgress.TabIndex = 2;
            dataGridProgress.CellContentClick += dataGridProgress_CellContentClick_1;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Resizable = DataGridViewTriState.True;
            ID.Visible = false;
            // 
            // gridDate
            // 
            gridDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.BackColor = Color.Transparent;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = Color.Transparent;
            gridDate.DefaultCellStyle = dataGridViewCellStyle3;
            gridDate.HeaderText = "Fecha";
            gridDate.Name = "gridDate";
            gridDate.ReadOnly = true;
            gridDate.Width = 150;
            // 
            // ShowData
            // 
            ShowData.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.Cyan;
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.Cyan;
            dataGridViewCellStyle4.SelectionForeColor = Color.Cyan;
            ShowData.DefaultCellStyle = dataGridViewCellStyle4;
            ShowData.HeaderText = "Ver";
            ShowData.Name = "ShowData";
            ShowData.ReadOnly = true;
            ShowData.Text = ".";
            ShowData.ToolTipText = "Ver Detalles";
            ShowData.Width = 40;
            // 
            // Peso
            // 
            Peso.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Peso.HeaderText = "Peso (KG)";
            Peso.Name = "Peso";
            Peso.ReadOnly = true;
            Peso.Width = 120;
            // 
            // gridTitle
            // 
            gridTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.BackColor = Color.Transparent;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = Color.Transparent;
            gridTitle.DefaultCellStyle = dataGridViewCellStyle5;
            gridTitle.HeaderText = "Titulo";
            gridTitle.Name = "gridTitle";
            gridTitle.ReadOnly = true;
            // 
            // estadoFisicoBindingSource
            // 
            estadoFisicoBindingSource.DataSource = typeof(Modelos.EstadoFisico);
            // 
            // idEstadoFisicoDataGridViewTextBoxColumn
            // 
            idEstadoFisicoDataGridViewTextBoxColumn.DataPropertyName = "IdEstadoFisico";
            idEstadoFisicoDataGridViewTextBoxColumn.HeaderText = "IdEstadoFisico";
            idEstadoFisicoDataGridViewTextBoxColumn.Name = "idEstadoFisicoDataGridViewTextBoxColumn";
            idEstadoFisicoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tituloDataGridViewTextBoxColumn
            // 
            tituloDataGridViewTextBoxColumn.DataPropertyName = "Titulo";
            tituloDataGridViewTextBoxColumn.HeaderText = "Titulo";
            tituloDataGridViewTextBoxColumn.Name = "tituloDataGridViewTextBoxColumn";
            tituloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pesoDataGridViewTextBoxColumn
            // 
            pesoDataGridViewTextBoxColumn.DataPropertyName = "Peso";
            pesoDataGridViewTextBoxColumn.HeaderText = "Peso";
            pesoDataGridViewTextBoxColumn.Name = "pesoDataGridViewTextBoxColumn";
            pesoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // alturaDataGridViewTextBoxColumn
            // 
            alturaDataGridViewTextBoxColumn.DataPropertyName = "Altura";
            alturaDataGridViewTextBoxColumn.HeaderText = "Altura";
            alturaDataGridViewTextBoxColumn.Name = "alturaDataGridViewTextBoxColumn";
            alturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaCreacionDataGridViewTextBoxColumn
            // 
            fechaCreacionDataGridViewTextBoxColumn.DataPropertyName = "FechaCreacion";
            fechaCreacionDataGridViewTextBoxColumn.HeaderText = "FechaCreacion";
            fechaCreacionDataGridViewTextBoxColumn.Name = "fechaCreacionDataGridViewTextBoxColumn";
            fechaCreacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // notasDataGridViewTextBoxColumn
            // 
            notasDataGridViewTextBoxColumn.DataPropertyName = "Notas";
            notasDataGridViewTextBoxColumn.HeaderText = "Notas";
            notasDataGridViewTextBoxColumn.Name = "notasDataGridViewTextBoxColumn";
            notasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoFisicoInactivoDataGridViewCheckBoxColumn
            // 
            estadoFisicoInactivoDataGridViewCheckBoxColumn.DataPropertyName = "EstadoFisicoInactivo";
            estadoFisicoInactivoDataGridViewCheckBoxColumn.HeaderText = "EstadoFisicoInactivo";
            estadoFisicoInactivoDataGridViewCheckBoxColumn.Name = "estadoFisicoInactivoDataGridViewCheckBoxColumn";
            estadoFisicoInactivoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // idAlumnoSuscripcionDataGridViewTextBoxColumn
            // 
            idAlumnoSuscripcionDataGridViewTextBoxColumn.DataPropertyName = "IdAlumnoSuscripcion";
            idAlumnoSuscripcionDataGridViewTextBoxColumn.HeaderText = "IdAlumnoSuscripcion";
            idAlumnoSuscripcionDataGridViewTextBoxColumn.Name = "idAlumnoSuscripcionDataGridViewTextBoxColumn";
            idAlumnoSuscripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // imagenUrlDataGridViewTextBoxColumn
            // 
            imagenUrlDataGridViewTextBoxColumn.DataPropertyName = "ImagenUrl";
            imagenUrlDataGridViewTextBoxColumn.HeaderText = "ImagenUrl";
            imagenUrlDataGridViewTextBoxColumn.Name = "imagenUrlDataGridViewTextBoxColumn";
            imagenUrlDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idAlumnoSuscripcionNavigationDataGridViewTextBoxColumn
            // 
            idAlumnoSuscripcionNavigationDataGridViewTextBoxColumn.DataPropertyName = "IdAlumnoSuscripcionNavigation";
            idAlumnoSuscripcionNavigationDataGridViewTextBoxColumn.HeaderText = "IdAlumnoSuscripcionNavigation";
            idAlumnoSuscripcionNavigationDataGridViewTextBoxColumn.Name = "idAlumnoSuscripcionNavigationDataGridViewTextBoxColumn";
            idAlumnoSuscripcionNavigationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ProgressClientControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel6);
            Name = "ProgressClientControl";
            Size = new Size(990, 576);
            panel6.ResumeLayout(false);
            panelWalletWrapper.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panelGallery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PhotoActive).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            PanelMessageCount.ResumeLayout(false);
            PanelMessageCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProgress).EndInit();
            ((System.ComponentModel.ISupportInitialize)estadoFisicoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel6;
        private Panel panelWalletWrapper;
        private Panel panel2;
        private Panel panel5;
        private Label TBRegFecha;
        private Panel panelGallery;
        private Panel panel3;
        private Label label3;
        private Panel panel7;
        private Label label4;
        private DataGridView dataGridProgress;
        private TextBox TBRegDescription;
        private PictureBox PhotoActive;
        private TextBox TBDescripcionClient;
        private ClassCustom.RJButton btnAddProgress;
        private PictureBox pictureBox1;
        private Panel PanelMessageCount;
        private Label label1;
        private PictureBox pictureBox2;
        private ClassCustom.RJButton rjButton1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn gridDate;
        private DataGridViewButtonColumn ShowData;
        private DataGridViewTextBoxColumn Peso;
        private DataGridViewTextBoxColumn gridTitle;
        private ClassCustom.RJButton BtnInactiveReg;
        private DataGridViewTextBoxColumn idEstadoFisicoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pesoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn alturaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaCreacionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn notasDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn estadoFisicoInactivoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn idAlumnoSuscripcionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn imagenUrlDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idAlumnoSuscripcionNavigationDataGridViewTextBoxColumn;
        private BindingSource estadoFisicoBindingSource;
    }
}
