using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests {
    public class ProductTests {

        [Fact]
        public void CanChangeProductName () {

            // Arrange
            var p = new Product { Name = "Test", Price = 100M };

            // Act
            p.Name = "New Name";

            // Assert
            Assert.Equal ("New Name", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice () {
            var p = new Product { Name = "Test", Price = 100M };
            p.Price = 150M;
            Assert.Equal(150M, p.Price);
        }

    }
}