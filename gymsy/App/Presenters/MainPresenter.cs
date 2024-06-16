using gymsy.App.Views.Interfaces;
using gymsy.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gymsy.Models;

namespace gymsy.App.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private GymsyContext gymsydb;

        public MainPresenter(IMainView mainView, GymsyContext gymsyDb){
            
            this.mainView = mainView;
            this.gymsydb = gymsyDb;

            // subscribe

            // Show view
            this.mainView.Show();
        }

    }
}
