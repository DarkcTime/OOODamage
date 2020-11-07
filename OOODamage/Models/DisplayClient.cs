using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOODamage.Models
{
    class DisplayClient
    {
        public Client Client { get; set; }

        public string BirthDate { get; set; }
            
        public string RegDate { get; set; }
        
        public string DateTimeStart
        {
            get
            {
                if(Client.ClientServices.Count > 0)
                {
                    return Client.ClientServices.Max(d => d.DateTimeStart).Value.ToString("yyyy-MM-dd");
                }
                return null;
            }
        }
        public int CountService
        {
            get
            {
                return Client.ClientServices.Count;
            }
        }


    }
}
