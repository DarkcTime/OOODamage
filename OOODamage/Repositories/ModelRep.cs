using OOODamage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOODamage.Repositories
{
    /// <summary>
    /// Common class for work with Model 
    /// </summary>
    class ModelRep
    {
        /// <summary>
        /// Model object 
        /// </summary>
        protected static AutoServiceEntities context = new AutoServiceEntities(); 

        /// <summary>
        /// Save changes method
        /// </summary>
        protected void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
