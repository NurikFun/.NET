using DependencyInjectionMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DependencyInjectionMVC.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }

        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();
            myProduct.Name = "Kayak";
            string productName = myProduct.Name;
            return View("Result", (object)String.Format("Product name: {0}", productName));
        }

        public ViewResult UseExtension()
        {
            IEnumerable<Product> cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M}
                }
            };

            decimal cartTotal = cart.TotalPrices();
            return View("Result", (object)String.Format("Total : {0}", cartTotal));

        }


        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                     new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                     new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                     new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                     new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                }
            };


            decimal total = 0;
            foreach (Product prod in products.Filter(prod => prod.Category == "Soccer" || prod.Price == 20))
            {
                total += prod.Price;
            }

            return View("Result", (object)String.Format("Total : {0}", total));
        }



        public ViewResult FindProducts()
        {
            Product[] products = {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
             };

            var foundProducts = from match in products
                                orderby match.Price descending
                                select new
                                {
                                    match.Name,
                                    match.Price
                                };

            int count = 0;
            StringBuilder result = new StringBuilder();
            foreach(var p in foundProducts)
            {
                result.AppendFormat("Price : {0}", p.Price);
                if (++count == 3) break;

            }

            return View("Result", (object)result.ToString());

        }


    }
}