using Bulkybook.DataAccess;
using Bulkybook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging.Signing;
using System.Collections.Generic;

namespace ASPNetMVCCoreWeb.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IunitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IunitOfWork unitofWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitofWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<CoverType> objCovertypeList = _unitOfWork.CoverType.GetAll();
            return View();
        }

        //GET
        [HttpGet]
        public IActionResult Upsert(int? id)
        {

            ProductViewmodel productViewmodel = new()
            {
                product = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()

                }),
            };



            if (id == null || id == 0)
            {
                //create product
                //ViewBag.CategoryList = CategoryList;
                //ViewData["Covertypelist"] = CovertypeList;
                return View(productViewmodel);
            }
            else
            {
                //update product
            }

            return View(productViewmodel);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductViewmodel obj, IFormFile file)
        {
            //string wwwRootPath = _webHostEnvironment.WebRootPath;
            //if (file != null)
            //{ 
            //    string fileName = Guid.NewGuid().ToString();
            //    var uploads = Path.Combine(wwwRootPath, @"images\products");
            //    var extensions = Path.GetExtension(file.FileName);
            //    using(var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension),FileMode.Create))
            //    {
            //        file.CopyTo(fileStreams);
            //    }

            //    obj.product.ImageUrl = @"\images\products\" + fileName + extension;

            //}
            if (ModelState.IsValid)
            {

                _unitOfWork.product.Add(obj.product);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);


        }

    }
}
