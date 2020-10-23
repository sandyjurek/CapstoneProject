using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    public partial class ShoppingListDetails
    {
        public ShoppingListDetails()
        {
            ShoppingList = new HashSet<ShoppingList>();
        }

        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
       // public IEnumerable joinShoppingListDetails { get; set; }

        public virtual ProductList Product { get; set; }
        public virtual ICollection<ShoppingList> ShoppingList { get; set; }
    }
}