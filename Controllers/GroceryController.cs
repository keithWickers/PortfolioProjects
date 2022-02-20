using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GroceryList.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.Controllers
{
    public class GroceryController : Controller
    {
        private GroceryContext Context { get; set; }
        public GroceryController(GroceryContext ctx)
        {
            Context = ctx;

        }


        [HttpGet]

        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
            return View("Edit", new Grocery());
        }
        [HttpGet]

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
            var Grocery = Context.Grocerys.Find(id);
            return View(Grocery);
        }
        [HttpPost]
        public IActionResult Edit(Grocery Grocery)
        {
            if (ModelState.IsValid)
            {
                if (Grocery.Id == 0)
                    Context.Grocerys.Add(Grocery);
                else
                    Context.Grocerys.Update(Grocery);
                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (Grocery.Id == 0) ? "ADD" : "Edit";
                ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
                return View(Grocery);
            }

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";
            var Grocery = Context.Grocerys.Find(id);
            return View(Grocery);
        }

        [HttpPost]
        public IActionResult Delete(Grocery Grocery)
        {
            Context.Grocerys.Remove(Grocery);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }

}

                






            









            
        

    
