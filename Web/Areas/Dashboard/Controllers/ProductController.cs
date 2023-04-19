using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Areas.Dashboard.ViewModels;
using Web.Data;
using Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = _context.Products.Include(x=>x.Category).ToList();
            return View(products);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories,"Id","CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            var myUrl = product.Name
                .ToLower()
                .Replace(" ", "-");
            product.SeoUrl = myUrl;
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.FirstOrDefault(x=>x.Id == id);
            var categories = _context.Categories.ToList();

            ProductEditViewModel vm = new()
            {
                Product = product,
                Categories = categories
            };
            return View(vm);
        }


        [HttpPost]
        public IActionResult Update(Product product, int id, int CategoryId)
        {
            var myUrl = product.Name
                .ToLower()
                .Replace(" ", "-");
            var updatedProduct = _context.Products.FirstOrDefault(x=>x.Id == id);
            updatedProduct.Name = product.Name;
            updatedProduct.Price = product.Price;
            updatedProduct.Discount = product.Discount;
            updatedProduct.Description = product.Description;
            updatedProduct.Quantity = product.Quantity;
            updatedProduct.PhotoUrl = product.PhotoUrl;
            updatedProduct.SeoUrl = myUrl;
            updatedProduct.CategoryId = CategoryId;

            _context.Products.Update(updatedProduct);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.SingleOrDefault(x=>x.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

