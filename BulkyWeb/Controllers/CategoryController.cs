using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _unitOfWork.Category.GetAll().OrderBy(o => o.DisplayOrder).ToList();
            return View(categoryList);
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id.HasValue)
            {
                Category? category = _unitOfWork.Category.FirstOrDefault(g => g.Id == id.Value);
                if (category is not null)
                {
                    return View(category);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id > 0)
                {
                    _unitOfWork.Category.Update(category);
                    _unitOfWork.Save();
                    TempData["success"] = "Category updated successfully!";
                }
                else
                {
                    _unitOfWork.Category.Add(category);
                    _unitOfWork.Save();
                    TempData["success"] = "Category created successfully!";
                }
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Category category = _unitOfWork.Category.FirstOrDefault(g => g.Id == id.Value);
                if (category is not null && category.Id > 0)
                {
                    _unitOfWork.Category.Remove(category);
                    _unitOfWork.Save();
                    TempData["success"] = "Category deleted successfully!";
                }
            }
            return RedirectToAction("Index", "Category");
        }
    }
}
