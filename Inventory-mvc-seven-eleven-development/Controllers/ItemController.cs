using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory_mvc_seven_eleven.Data;
using Inventory_mvc_seven_eleven.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Inventory_mvc_seven_eleven.Dao;

namespace Inventory_mvc_seven_eleven.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ItemController> _logger;

        public ItemController(ApplicationDbContext context, ILogger<ItemController> logger)
        {
            _context = context;
            _logger = logger;
            logger.LogInformation("ItemController has been constructed");
        }

        // GET: Item
        public ActionResult Index()
        {
            _logger.LogInformation("Redirect To The Item Main Page");
            var itemView = from i in _context.Items
                           join u in _context.Users on i.Created_by equals u.Id into st2
                           from u in st2.DefaultIfEmpty()
                           select new ItemView { item = i, user = u };


            return View(itemView);
        }

        // GET: Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Items == null)
            {
                _logger.LogError("Item Table Not Found In Database !");
                return NotFound();
            }

            var item = await _context.Items
                .FindAsync(id);
            if (item == null)
            {
                _logger.LogError("Item Not Found !");
                return NotFound();
            }
            _logger.LogError("Item Founded !");
            return View(item);
        }

        // GET: Item/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price")] Item item)
        {
            try
            {
                _logger.LogInformation("Create Item Detected !");
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (ModelState.IsValid)
                {
                    item.Created_by = userId;
                    item.Status = Constants.AVAILABLE;
                    _context.Add(item);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Item Saved Successful " + item.Name);
                    return RedirectToAction(nameof(Index));
                }
                return View(item);
            }
            catch (ArgumentNullException e)
            {

                _logger.LogInformation("Item Data Null Argument Detected " + e.Message);
                throw new ArgumentNullException("Getting Error while Argument Pass !");
            }

        }

        // GET: Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Items == null)
            {
                _logger.LogError("Item Table Not Found In Database !");
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                _logger.LogError("Item Not Found !");
                return NotFound();
            }
            return View(item);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Status,CreatedDate,Created_by")] Item item)
        {
            try
            {
                if (id != item.Id)
                {
                    _logger.LogError("Item Not Found !");
                    return NotFound();
                }
                if (!ItemExists(item.Id))
                {
                    _logger.LogError("Item Not Found !");
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                    _logger.LogError("Item Updated !" + item.Name);

                    return RedirectToAction(nameof(Index));
                }
                return View(item);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception();
            }
        }

        // GET: Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Items == null)
            {
                _logger.LogError("Item Table Not Found In Database !");
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                _logger.LogError("Item Not Found !");
                return NotFound();
            }

            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.Items == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Items'  is null.");
                }
                var item = await _context.Items.FindAsync(id);
                if (item != null)
                {
                    item.Status = Constants.DELETE;
                    _context.Update(item);
                    _logger.LogError("Item DEleted !" + item.Name);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentNullException e)
            {
                _logger.LogInformation("Item Data Null Argument Detected " + e.Message);
                throw new ArgumentNullException("Getting Error while Argument Pass !");
            }

        }

        private bool ItemExists(int id)
        {
            return (_context.Items?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
