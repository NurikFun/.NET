using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DependencyInjectionMVC.Models;

namespace DependencyInjectionMVC.Models
{
    public class LinqValueCalculator : IValueCalculator
    {
        private IDiscountHelper discounter;
        public LinqValueCalculator(IDiscountHelper discount)
        {
            discounter = discount;
        }
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return discounter.ApplyDiscount(products.Sum( p => p.Price));
        }

    }
}