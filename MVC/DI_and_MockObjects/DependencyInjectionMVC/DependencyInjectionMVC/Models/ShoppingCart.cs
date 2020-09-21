﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjectionMVC.Models
{
    public class ShoppingCart
    {
        private IValueCalculator calc;
        public ShoppingCart(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal CaculateProductTotal()
        {
            return calc.ValueProducts(Products);
        }

    }
}