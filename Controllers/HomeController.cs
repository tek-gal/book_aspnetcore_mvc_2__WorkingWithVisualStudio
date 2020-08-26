using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Models;
using System.Linq;

namespace WorkingWithVisualStudio.Controllers {

    public class HomeController : Controller {
        
        public IRepository Repository { get; set; } = SimpleRepository.SharedRepository;

        public IActionResult Index() =>
            View(SimpleRepository.SharedRepository.Products);

        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product product) {
            Repository.AddProduct(product);
            return RedirectToAction("Index");
        }
    }
}