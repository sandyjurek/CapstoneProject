
using CapstoneProject.Context;
using CapstoneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Services
{
    public interface IModelMaker
    {
        public Models.CheckoutModel MakeModel(CapstoneShoppingListDBContext c);
    }
}