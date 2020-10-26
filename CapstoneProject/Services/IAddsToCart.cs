using CapstoneProject.Context;
using CapstoneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone4ShoppingList.Services
{
    public interface IAddsToCart
    {
        public ProductList AddToCart(CapstoneShoppingListDBContext context, int id);
    }
}