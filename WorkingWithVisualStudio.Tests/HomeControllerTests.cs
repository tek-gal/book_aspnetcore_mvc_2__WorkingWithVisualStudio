using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests {

    public class HomeControllerTests {

        class ModelCompleteFakeRepository : IRepository {

            public IEnumerable<Product> Products { get; } = new Product[] {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 18.90M },
                new Product { Name = "Corner flag", Price = 34.95M },
            };

            public void AddProduct (Product p) {
                //
            }

        }

        [Fact]
        public void IndexActionModelIsComplete () {

            HomeController controller = new HomeController ();
            controller.Repository = new ModelCompleteFakeRepository();

            var model = (controller.Index () as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            Assert.Equal (
                controller.Repository.Products,
                model,
                Comparer.Get<Product> ((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price)
            );

        }

    }

}