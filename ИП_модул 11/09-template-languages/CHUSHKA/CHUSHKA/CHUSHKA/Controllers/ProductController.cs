using CHUSHKA.Data.Models;
using CHUSHKA.Data.Models.Enums;
using CHUSHKA.Services.Interface;
using CHUSHKA.ViewModels;
using CHUSHKA.ViewModels.Order;
using CHUSHKA.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly UserManager<User> userManager;

        public ProductController(IProductService productService, UserManager<User> userManager)
        {
            this.productService = productService;
            this.userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CreateViewModel model)
        {
            this.productService.CreateProduct(model.Name, model.Price, model.Description, Enum.Parse<ProductType>(model.Type));
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult Details(int id)
        {
            var product = this.productService.GetProductById(id);
            var model = new DetailsViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Type = product.Type
            };

            return this.View(model);
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult Order(int id)
        {
            this.productService.ProductOrder(id, this.userManager.GetUserId(this.HttpContext.User));
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var product = this.productService.GetProductById(id);
            var model = new DetailsViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Type = product.Type
            };
            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(DetailsViewModel model)
        {
            this.productService.EditProduct(model.Id, model.Name, model.Price, model.Description, model.Type);
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var product = this.productService.GetProductById(id);
            var model = new DetailsViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Type = product.Type
            };
            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(DetailsViewModel model)
        {
            this.productService.DeleteProduct(model.Id);
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult All()
        {
            var orders = this.productService.GetAllOrders();
            var allOrders = new AllOrdersViewModel
            {
                AllOrders = orders
                    .Select(o => new OrderViewModel
                    {
                        Id = o.Id,
                        Customer = o.Client.UserName,
                        Product = o.Product.Name,
                        OrderedOn = o.OrderedOn.ToString("hh:mm dd/MM/yyyy", CultureInfo.InvariantCulture)
                    })
                    .ToList()
            };


            return this.View(allOrders);
        }
    }
}
