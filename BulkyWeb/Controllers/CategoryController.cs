using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _dbContext.Category.OrderBy(o => o.DisplayOrder).ToList();
            return View(categoryList);
        }

        public IActionResult CreateCategory() 
        {
            return View();
        }
    }
}
