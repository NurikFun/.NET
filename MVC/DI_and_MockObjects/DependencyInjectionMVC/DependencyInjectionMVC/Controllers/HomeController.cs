using DependencyInjectionMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace DependencyInjectionMVC.Controllers
{
    public class HomeController : Controller
    {

        private Product[] products =
        {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };

        private IValueCalculator calc;

        public HomeController(IValueCalculator calculator)
        {
            calc = calculator;
        }

        public ActionResult Index()
        {
           
            ShoppingCart cart = new ShoppingCart(calc) { Products = products};
            decimal total = cart.CaculateProductTotal();
       
            return View(total);
        }

    }
}