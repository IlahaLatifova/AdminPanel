using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DAL;
using WebApplication2.Models;
using WebApplication2.ViewModel;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            WorkVM workVM = new WorkVM()
            {
                Categories = await _context.Categories.ToListAsync()
            };
            return View(workVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {

            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");   
        }
        public IActionResult Update(int id)
        {
           Category category = _context.Categories.Find(id);
            if(category == null) { return NotFound(); }
            
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            Category existcategory = _context.Categories.Find(category.Id);
            if(existcategory == null) { return NotFound(); }

            existcategory.Name= category.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            if(category == null) { return NotFound();}

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
