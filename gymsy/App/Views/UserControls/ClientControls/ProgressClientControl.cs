﻿using gymsy.App.Models;
using gymsy.App.Views.Interfaces;
using gymsy.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymsy.UserControls.ClientControls
{
    public partial class ProgressClientControl : UserControl
    {

        public ProgressClientControl()
        {
            InitializeComponent();
            InitializeGridProgress();
        }

        public void UpdateComponent()
        {
            if (AppState.ClientActive != null)
            {
                int edad = AppState.ClientActive.IdPersonNavigation.Birthday.Year - new DateTime().Year;
                TimeSpan TimeTraning = AppState.ClientActive.IdPersonNavigation.CreatedAt - DateTime.Now;

                TBDescripcionClient.Text = $"{AppState.ClientActive.IdPersonNavigation.FirstName + " " + AppState.ClientActive.IdPersonNavigation.LastName}, " +
               $"{edad} años comenzo a enrenarse hace {TimeTraning.Days} días, " +
               $"cuenta con {AppState.ClientActive.DataFisics.Count()} registros guardados ";
            }
        }

        public override void Refresh()
        {
            this.UpdateComponent();
        }

        private void InitializeGridProgress()
        {
            dataGridProgress.Rows.Add(0, "01/07/22", null, 82.5, "Construcion de volumen");
            dataGridProgress.Rows.Add(1, "01/09/22", null, 80.5, "Etapa definicion");
            dataGridProgress.Rows.Add(2, "01/11/23", null, 80.5, "Etapa definicion");
            dataGridProgress.Rows.Add(3, "01/01/23", null, 80.5, "Etapa definicion");
        }

        private void btnAddProgress_Click(object sender, EventArgs e)
        {
            MainView.navigationControl.Display(8);
        }
    }
}
