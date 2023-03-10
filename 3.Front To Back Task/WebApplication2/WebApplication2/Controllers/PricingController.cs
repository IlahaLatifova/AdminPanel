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
                .Include(p => p.Category)
                .ToListAsync()
            };
            return View(workVM);
        }

    }
}
