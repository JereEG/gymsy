using gymsy.App.Models;
using gymsy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymsy.App.Presenters
{
    internal class ClientPresenter
    {
        Person person;
        private GymsyDbContext dbContext;

        public ClientPresenter() {
            this.dbContext = GymsyContext.GymsyContextDB;
            this.person = AppState.person;
        }

        //aboutClientControl
        public Client getClient(int idPerson)
        {
            return dbContext.Clients.Where(cl => cl.IdPerson == idPerson).First();
        }








    }
}
