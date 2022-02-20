using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryList.Models;

namespace GroceryList.Controllers
{
    public class HomeController : Controller
    {
        private GroceryContext Context { get; set; }
        public HomeController(GroceryContext ctx)
        {
            Context = ctx;
        }        
        public IActionResult Index()
        {
            var Grocerys = Context.Grocerys.Include(x=> x.Category).OrderBy(m => m.Name).ToList();
            return View(Grocerys);

        }




        //GET: Grocery/ShowSearchForm
        public IActionResult ShowSearchForm()
        {
            return View();

        }

        //POST: Grocery/ShowSearchResults
        public IActionResult ShowSearchResults(String SearchPhrase)
        {
            return View("Index", Context.Grocerys.Include(x => x.Category).Where(m => m.Name.Contains(SearchPhrase)).ToList());

        }







    }
}