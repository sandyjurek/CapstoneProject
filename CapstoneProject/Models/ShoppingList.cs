using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    public partial class ShoppingList
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? ShoppingListDetailId { get; set; }
        public decimal? Total { get; set; }

        public virtual ShoppingListDetails ShoppingListDetail { get; set; }
    }
}