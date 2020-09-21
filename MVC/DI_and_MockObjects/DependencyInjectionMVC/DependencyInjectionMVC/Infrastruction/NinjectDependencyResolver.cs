using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using DependencyInjectionMVC.Models;

namespace DependencyInjectionMVC.Infrastruction
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType) // создание нового экземпляра класса
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) // Метод GetAll поддерживает несколько связок для одного типа.
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 50M); // мы можем использовать метод WithPropertyValue для установки 
            kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedExactlyInto<LinqValueCalculator>();                                                                                          //значения свойства DiscountSize в классе DefaultDiscountHelper
            
        }

    }
}