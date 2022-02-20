using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.Models
{
    public class GroceryContext : DbContext
    {
        public GroceryContext(DbContextOptions<GroceryContext> option) : base(option)
        { }

        public DbSet<Grocery> Grocerys { get; set; }
        public DbSet<Category> Categories { get; set; }




        //add inital data to the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   CategoryId = "F",
                   Name = "Frozen"
               },

               new Category
               {
                   CategoryId = "N",
                   Name = "Not Frozen"
               }

                 );                         

            modelBuilder.Entity<Grocery>().HasData(
                new Grocery
                {
                    Id = 1,
                    Name = "Steak",
                    UnitPrice = 19.5,
                    CategoryId = "F"
                    
                },
                new Grocery
                {
                    Id = 2,
                    Name = "Cereal",
                    UnitPrice = 2.99,
                    CategoryId = "N"
                    
                }
              

            );
        }

    }

}








