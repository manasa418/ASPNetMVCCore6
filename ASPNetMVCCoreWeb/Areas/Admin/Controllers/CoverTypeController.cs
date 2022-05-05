using Bulkybook.DataAccess;
using Bulkybook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetMVCCoreWeb.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
       
        private readonly IunitOfWork _unitOfWork;

        public CoverTypeController(IunitOfWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }
        public IActionResult Index()
        {
            //var objCategoryList = _db.Categories.ToList();
            IEnumerable<CoverType> objCovertypeList = _unitOfWork.CoverType.GetAll();
            return View(objCovertypeList);
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }

            //POST
     [HttpPost]
     [ValidateAntiForgeryToken]
     public IActionResult Create(CoverType obj)
        {
            //custom validation
            if (obj.CoverTypeName == obj.CoverTypeName.ToString())
            {
                ModelState.AddModelError("CustomError", "The Display order cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                
                
            }
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            { 
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var coverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(x => x.CoverTypeId == id);
            //var categoryFromDb = _db.Categories.FirstOrDefault(u => u.Id == id);
            if (coverTypeFromDb == null)
            {
                return NotFound();
            }


                return View(coverTypeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            //custom validation
            if (obj.CoverTypeName == obj.CoverTypeName.ToString())
            {
                ModelState.AddModelError("CustomError", "The Display order cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();


            }
            return RedirectToAction("Index");

        }
    }
}
