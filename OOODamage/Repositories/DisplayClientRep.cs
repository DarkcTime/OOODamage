using OOODamage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOODamage.Repositories
{
    class DisplayClientRep : ModelRep
    {

        public  List<DisplayClient> GetDisplayClients(string gender, string search)
        {
            List<ClientService> clientServices = context.ClientServices.ToList();

            switch (gender)
            {
                case "Мужчина":
                    clientServices = clientServices.Where(i => i.Client.IdGender == "м").ToList();
                    break;
                case "Женщина":
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

            return clientServices.Select(i => new DisplayClient()
            {
                ClientService = i,
                BirthDate = i.Client.BirhDate.ToString(),
                RegDate = i.Client.RegDate.ToString(),
                DateTimeStart = i.DateTimeStart.ToString(),
                CountService = context.ClientServices.Where(b => b.IdClient == i.IdClient).Count()
            }).ToList(); 
        }


        public int CountRecords(List<DisplayClient> clients)
        {
            return clients.Count(); 
        }

      
    }
}
