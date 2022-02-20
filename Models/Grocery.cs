using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GroceryList.Models
{
       public class Grocery
       {
        
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage =" Please enter a number")]
        public double? UnitPrice { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }

       
        
               
                
    }
}
