using OOODamage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOODamage.Repositories
{
    class DisplayClientRep : ModelRep
    {

        public  List<DisplayClient> GetDisplayClients(int gender, string search)
        {
            //get uniqu records for clients
            List<Client> clients = context.Clients.ToList();

            switch (gender)
            {
                case 0:
                    break; 
                case 1:
                    clients = clients.Where(i => i.IdGender == "м").ToList();
                    break;
                case 2:
                    clients = clients.Where(i => i.IdGender == "ж").ToList();
                    break;
            }
          
            if (!string.IsNullOrWhiteSpace(search))
            {
                clients = clients.Where(i => i.FirstName.Contains(search)
                 || i.MiddleName.Contains(search)
                 || i.LastName.Contains(search)
                 || i.Email.Contains(search)).ToList(); 
                 //|| i.Client.Phone.Contains(search)).ToList();
            }

        
            return clients.Select(i => new DisplayClient()
            {
                Client = i,
                BirthDate = i.BirhDate.ToString(),
                RegDate = i.RegDate.ToString()                
            }).ToList()
            .OrderByDescending(i => i.CountService)
            .OrderBy(i => i.Client.LastName)
            .ToList(); 
        }


        public Client GetClient(DisplayClient displayClient)
        {
            return context.Clients.ToList().Where(i => i.IdClient == displayClient.Client.IdClient).FirstOrDefault();
        }


        private List<ClientService> OrderClients(List<ClientService> clientServices)
        {
            return clientServices.ToList().OrderBy(i => i.Client.MiddleName)
                .ToList()
                .OrderByDescending(i => i.DateTimeStart)
                .ToList();
        }

        public int CountRecords(List<DisplayClient> clients)
        {
            return clients.Count(); 
        }

      
    }
}
