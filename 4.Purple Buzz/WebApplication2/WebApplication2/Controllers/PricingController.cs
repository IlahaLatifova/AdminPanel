using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DAL;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class PricingController : Controller
    {
        private readonly AppDbContext _context;
        public PricingController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            WorkVM workVM = new WorkVM()
            {
                Categories = await _context.Categories.ToListAsync(),
                Products = await _context.Products
                .Take(4)
                .Include(p => p.Category)
                .ToListAsync()
            };
            return View(workVM);
        }
        public IActionResult LoadMore()
        {
            int count = 0;

            var services = _context.Products
             .Skip(count)
             .Take(4)
             .Include(p => p.Category)
             .ToList();

            count += 4;
            return PartialView("_WorkCategoryPartialView", services);
        }
    }
}
