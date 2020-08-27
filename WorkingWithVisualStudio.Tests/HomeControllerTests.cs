using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;
using Moq;

namespace WorkingWithVisualStudio.Tests {

    public class HomeControllerTests {

        class ModelCompleteFakeRepository : IRepository {

            public IEnumerable<Product> Products { get; set; }

            public void AddProduct (Product p) {
                //
            }

        }

        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete (Product[] products) {

            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController { Repository = mock.Object };

            var model = (controller.Index () as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            Assert.Equal (
                controller.Repository.Products,
                model,
                Comparer.Get<Product> ((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price)
            );
        }

        [Fact]
        public void RepositoryCalledOnce() {
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(
                new[] {
                    new Product { Name = "P1", Price = 100 }
                }
            );
            var controller = new HomeController { Repository = mock.Object };

            var result = controller.Index();

            mock.VerifyGet(m => m.Products, Times.Once);
        }

    }

}