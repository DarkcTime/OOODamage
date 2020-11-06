using OOODamage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOODamage.Repositories
{
    class ModelRep
    {
        protected static AutoServiceEntities context = new AutoServiceEntities(); 

        protected void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
