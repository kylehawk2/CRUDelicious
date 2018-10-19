using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private CRUDContext dbContext;

        public HomeController (CRUDContext context)
        {
            dbContext = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Meal> AllDishes = dbContext.Dishes.ToList();
            ViewBag.allDishes = AllDishes;
            return View();
        }

        [HttpGet]
        [Route("New")]
        public IActionResult New()
        {

            return View("New");
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create (Meal dish)
        {
            if(ModelState.IsValid)
            {
                Meal newDish = new Meal
                {
                    Name = dish.Name,
                    Chef = dish.Chef,
                    Tastiness = dish.Tastiness,
                    Calories = dish.Calories,
                    Description = dish.Description
                };
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction ("Index");
            }
            else
            {
                
                return View("New");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ViewResult DishId (int id)
        {
            List <Meal> AllDishes = dbContext.Dishes.Where(dish => dish.DishId == id).ToList();
            ViewBag.AllDishes = AllDishes;
            ViewBag.DishId = id;
            return View("ViewDish");
        }
        [HttpGet]
        [Route("{id}/ShowDish")]
        public ViewResult ShowDish(int id, Meal editdish)
        {
            Meal AllDishes = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == id); 
            ViewBag.OneDish = AllDishes;
            return View("EditDish");
        }
        [HttpGet]
        [Route("{id}/EditDish")]
        public IActionResult EditDish(int id, Meal editdish)
        {
            Meal AllDishes = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == id);
            ViewBag.OneDish = AllDishes;
            if(ModelState.IsValid)
            {
                AllDishes.Name = editdish.Name;
                AllDishes.Chef = editdish.Chef;
                AllDishes.Tastiness = editdish.Tastiness;
                AllDishes.Calories = editdish.Calories;
                AllDishes.Description = editdish.Description;

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditDish");
            }
        }
    }
}
