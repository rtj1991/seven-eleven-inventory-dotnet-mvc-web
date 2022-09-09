using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory_mvc_seven_eleven.Data;
using Microsoft.AspNetCore.Authorization;

namespace Inventory_mvc_seven_eleven.Controllers
{
    public class StockAdjustmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StockAdjustmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StockAdjustment
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Index()
        {
            return _context.StockAdjustments != null ?
                        View(await _context.StockAdjustments.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.StockAdjustments'  is null.");
        }

        // GET: StockAdjustment/Details/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StockAdjustments == null)
            {
                return NotFound();
            }

            var stockAdjustment = await _context.StockAdjustments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockAdjustment == null)
            {
                return NotFound();
            }

            return View(stockAdjustment);
        }
    }
}
