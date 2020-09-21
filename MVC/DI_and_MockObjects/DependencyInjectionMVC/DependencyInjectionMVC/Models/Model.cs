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

}