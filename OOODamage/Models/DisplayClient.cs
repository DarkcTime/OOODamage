using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOODamage.Models
{
    class DisplayClient
    {
        public ClientService ClientService { get; set; }

        public string BirthDate { get; set; }
        public string RegDate { get; set; }

        public string DateTimeStart { get; set; }
        public int CountService { get; set; }


    }
}
