using CapstoneProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Services
{
    public interface IDBSetup
    {
        public void createNew(CapstoneShoppingListDBContext context);
    }
}
