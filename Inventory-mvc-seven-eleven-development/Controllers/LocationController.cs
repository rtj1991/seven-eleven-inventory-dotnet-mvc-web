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
    public class LocationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LocationController> _logger;

        public LocationController(ApplicationDbContext context, ILogger<LocationController> logger)
        {
            _context = context;
            _logger = logger;
            logger.LogInformation("LocationController has been constructed");
        }

        // GET: Location
        public IActionResult Index()
        {
            _logger.LogInformation("Redirect To The Location Main Page");
            var itemView = from l in _context.Locations
                           join u in _context.Users on l.Created_by equals u.Id into st2
                           from u in st2.DefaultIfEmpty()
                           select new LocationView { location = l, user = u };
            return View(itemView);
        }

        // GET: Location/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Locations == null)
            {
                _logger.LogError("Location Table Not Found In Database !");
                return NotFound();
            }

            var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (location == null)
            {
                _logger.LogError("Location Not Found !");
                return NotFound();
            }
            _logger.LogError("Location Founded !");
            return View(location);
        }

        // GET: Location/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Status")] Location location)
        {
            try
            {
                _logger.LogInformation("Create Location Detected !");
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (ModelState.IsValid)
                {
                    location.Created_by = userId;
                    location.Status = Constants.AVAILABLE;
                    _context.Add(location);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Location Saved Successful " + location.Name);
                    return RedirectToAction(nameof(Index));
                }
                return View(location);
            }
            catch (ArgumentNullException e)
            {
                _logger.LogInformation("Location Data Null Argument Detected " + e.Message);
                throw new ArgumentNullException("Getting Error while Argument Pass !");
            }

        }

        // GET: Location/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Locations == null)
            {
                _logger.LogError("Location Table Not Found In Database !");
                return NotFound();
            }

            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                _logger.LogError("Location Not Found !");
                return NotFound();
            }
            return View(location);
        }

        // POST: Location/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LocName,Description,Status,CreatedDate,Created_by")] Location location)
        {
            try
            {
                if (id != location.Id)
                {
                    _logger.LogError("Location Not Found !");
                    return NotFound();
                }
                if (!LocationExists(location.Id))
                {
                    _logger.LogError("Location Not Found !");
                    return NotFound();
                }

                if (ModelState.IsValid)
                {

                    _context.Update(location);
                    await _context.SaveChangesAsync();
                    _logger.LogError("Item Updated !" + location.Name);


                    return RedirectToAction(nameof(Index));
                }
                return View(location);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw new Exception();

            }

        }

        // GET: Location/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Locations == null)
            {
                _logger.LogError("Location Table Not Found In Database !");
                return NotFound();
            }

            var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (location == null)
            {
                _logger.LogError("Location Not Found !");
                return NotFound();
            }

            return View(location);
        }

        // POST: Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.Locations == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Locations'  is null.");
                }
                var location = await _context.Locations.FindAsync(id);
                if (location != null)
                {
                    location.Status = Constants.DELETE;
                    _context.Update(location);
                    _logger.LogError("Location Deleted !" + location.Name);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentNullException e)
            {
                _logger.LogInformation("Location Data Null Argument Detected " + e.Message);
                throw new ArgumentNullException("Getting Error while Argument Pass !");
            }

        }

        private bool LocationExists(int id)
        {
            return (_context.Locations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
