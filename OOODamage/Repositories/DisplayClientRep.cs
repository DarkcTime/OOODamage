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
            List<ClientService> clientServices = context.ClientServices.GroupBy(x => x.Client).Select(x => x.FirstOrDefault()).ToList();

            switch (gender)
            {
                case 0:
                    break; 
                case 1:
                    clientServices = clientServices.Where(i => i.Client.IdGender == "м").ToList();
                    break;
                case 2:
                    clientServices = clientServices.Where(i => i.Client.IdGender == "ж").ToList();
                    break;
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                clientServices = clientServices.Where(i => i.Client.FirstName.Contains(search)
                 || i.Client.MiddleName.Contains(search)
                 || i.Client.LastName.Contains(search)
                 || i.Client.Email.Contains(search)
                 || i.Client.Phone.Contains(search)).ToList();
            }

            clientServices = OrderClients(clientServices);

            return clientServices.Select(i => new DisplayClient()
            {
                ClientService = i,
                BirthDate = i.Client.BirhDate.ToString(),
                RegDate = i.Client.RegDate.ToString(),
                DateTimeStart = i.DateTimeStart.ToString(),
                CountService = context.ClientServices.Where(b => b.IdClient == i.IdClient).Count()
            }).ToList()
            .OrderByDescending(i => i.CountService)
            .OrderByDescending(i => i.ClientService.DateTimeStart)
            .OrderBy(i => i.ClientService.Client.LastName)
            .ToList(); 
        }


        public Client GetClient(DisplayClient displayClient)
        {
            return context.Clients.ToList().Where(i => i.IdClient == displayClient.ClientService.Client.IdClient).FirstOrDefault();
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
