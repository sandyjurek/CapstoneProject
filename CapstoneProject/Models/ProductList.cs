using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Models
{
    public partial class ProductList
    {
        public ProductList()
        {
            ShoppingListDetails = new HashSet<ShoppingListDetails>();
        }
        public int Id { get; set; }
        public string Product { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<ShoppingListDetails> ShoppingListDetails { get; set; }
    }
}
