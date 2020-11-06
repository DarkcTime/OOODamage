using OOODamage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOODamage.Repositories
{
    class ClientRep : ModelRep
    {

        public void RemoveClient(Client client)
        {
            context.Clients.Remove(client);
            SaveChanges();
        }

        public void AddClient(Client client)
        {
            context.Clients.Add(client);
            SaveChanges();

        }

        public void EditClient(Client client)
        {
            var baseClient = context.Clients.Where(i => i.IdClient == client.IdClient).FirstOrDefault();
            baseClient = client;
            SaveChanges();
        }

    }
}
