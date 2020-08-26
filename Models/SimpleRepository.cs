using System.Collections.Generic;

namespace WorkingWithVisualStudio.Models {
    public class SimpleRepository : IRepository {

        private static SimpleRepository sharedRepository = new SimpleRepository();
        private Dictionary<string, Product> products = new Dictionary<string, Product>();

        public static SimpleRepository SharedRepository => sharedRepository;

        public SimpleRepository() {
            var initializations = new[] {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 18.90M },
                new Product { Name = "Corner flag", Price = 34.95M },
            };

            foreach (var p in initializations) {
                AddProduct(p);
            }
        }

        public IEnumerable<Product> Products => products.Values;
        public void AddProduct(Product p) => products.Add(p.Name, p);
    }
}