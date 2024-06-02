using Microsoft.AspNetCore.Mvc;
using Toys.DataAccess.Repository.IRepository;
using Toys.Models;
using Toys.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic; // Add this namespace for List<>
using System.Collections; // Add this namespace for IEnumerable

namespace ToysWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var productList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return View(productList);
        }

        public IActionResult Upsert(int? id)
        {
            // Retrieve the categories from the database and map them to SelectListItem objects
            var categories = _unitOfWork.Category.GetAll().Select(c => new Toys.Models.ViewModels.SelectListItem
            {
                Text = c.Title,
                Value = c.Id.ToString()
            }).ToList();

            // Initialize a new ProductVM object
            ProductVM productVM = new ProductVM
            {
                // Assign the list of categories to the CategoryList property
                CategoryList = categories,
                // Set the Product property based on whether an ID is provided
                Product = id.HasValue ? _unitOfWork.Product.Get(id.Value) : new Product()
            };

            // Return the Upsert view with the populated ProductVM object
            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Add this attribute to prevent CSRF attacks
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload if a file is provided
                if (file != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if (!Directory.Exists(productPath))
                    {
                        Directory.CreateDirectory(productPath);
                    }

                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    productVM.Product.ImageUrl = @"\images\product\" + fileName;
                }

                // Check if the product ID is 0 (indicating a new product) and add it to the database, otherwise update it
                if (productVM.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productVM.Product);
                }
                else
                {

                    _unitOfWork.Product.Update(productVM.Product);

                }

                // Save changes to the database
                _unitOfWork.Save();
                TempData["success"] = "Product Upserted Successfully";
                return RedirectToAction("Index");
            }

            // If ModelState is not valid, re-populate the CategoryList and return the view
            var categories = _unitOfWork.Category.GetAll().Select(c => new Toys.Models.ViewModels.SelectListItem
            {
                Text = c.Title,
                Value = c.Id.ToString()
            }).ToList();

            productVM.CategoryList = categories;

            return View(productVM);
        }

    }
}
