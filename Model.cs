using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjectionMVC.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int ProductID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }
    }


    public class ShoppingCart : IEnumerable<Product>
    {
        public List<Product> Products { get; set; }


        public IEnumerator<Product> GetEnumerator()
        {
            return Products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class MyExtensionClass
    {
        public static decimal TotalPrices(this IEnumerable<Product> cartParam)
        {   
                decimal total = 0;
                foreach (var value in cartParam)
                {
                    total += value.Price;
                }
            return total;
        }  

        public static IEnumerable<Product> FilterByCategory(this IEnumerable<Product> productEnum, string categoryParam)
        {
            foreach(Product product in productEnum)
            {
                if(product.Category == categoryParam)
                {
                    yield return product;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum, Func<Product, bool> selectorParam)
        {
            foreach (Product prod in productEnum)
            {
                if (selectorParam(prod))
                {
                    yield return prod;
                }
            }
        } 

    }

}