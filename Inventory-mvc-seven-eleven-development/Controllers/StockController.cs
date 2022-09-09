using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory_mvc_seven_eleven.Data;
using Inventory_mvc_seven_eleven.Models;
using System.Security.Claims;
using Inventory_mvc_seven_eleven.Dao;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Authorization;

namespace Inventory_mvc_seven_eleven.Controllers
{
    public class StockController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<StockController> _logger;

        public StockController(ApplicationDbContext context, ILogger<StockController> logger)
        {
            _context = context;
            _logger = logger;
            logger.LogInformation("StockController has been constructed");

        }

        // GET: Stock
        [Authorize(Roles = "Admin,Operator,Manager")]

        public async Task<IActionResult> Index()
        {
            List<StockView> stockViews = new List<StockView>();
            _logger.LogInformation("Redirect To The Stock Main Page");
            var stock = await _context.Stocks.ToListAsync();
            foreach (var list in stock)
            {
                double totalQty = 0.0;

                StockView stockItem = new StockView();
                stockItem.Id = list.Id;
                stockItem.Description = list.Description;
                stockItem.Status = list.Status;
                stockItem.StockAvailable = list.StockAvailable;
                stockItem.CreatedDate = list.CreatedDate;
                stockItem.ExpireDate = list.ExpireDate;

                var itemcode = await _context.Items.FindAsync(list.Item_code);
                stockItem.item = itemcode;
                var locationcode = await _context.Locations.FindAsync(list.Location_id);
                stockItem.location = locationcode;
                var usercode = await _context.Users.FindAsync(list.Created_by);
                stockItem.user = usercode;

                // await _context.StockAdjustments.FirstAsync(list.id);
                var stockAdjust = await this._context.StockAdjustments.Where(s => s.Stock_Id == list.Id).ToListAsync();
                foreach (var adjust in stockAdjust)
                {
                    totalQty += adjust.Quantity;
                }
                stockItem.Qty = totalQty;
                stockViews.Add(stockItem);
                // Console.WriteLine("");
            }


            return _context.Stocks != null ?
                        View(stockViews) :
                        Problem("Entity set 'ApplicationDbContext.Stocks'  is null.");
        }

        // GET: Stock/Details/5
        [Authorize(Roles = "Admin,Operator,Manager")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stocks == null)
            {
                _logger.LogError("Stock Table Not Found In Database !");
                return NotFound();
            }

            var stock = await _context.Stocks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stock == null)
            {
                _logger.LogError("Stock Not Found !");
                return NotFound();
            }
            _logger.LogInformation("Stcok Founded !");
            return View(stock);
        }

        // GET: Stock/Create
        [Authorize(Roles = "Admin,Operator,Manager")]
        public async Task<IActionResult> Create()
        {
            try
            {
                _logger.LogInformation("Stcok Creating Conducted !");
                LocationStockModel model = new LocationStockModel();
                model.Locations = await this._context.Locations.Where(l => l.Status == Constants.AVAILABLE).ToListAsync();
                model.Items = await this._context.Items.Where(i => i.Status == Constants.AVAILABLE).ToListAsync();
                model.Stocks = new Stock();

                return View(model);
            }
            catch (Exception e)
            {
                _logger.LogError("Stcok Creating Conducted !" + e.Message);
                throw new Exception(e.Message);
            }

        }

        // POST: Stock/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Operator,Manager")]
        public async Task<IActionResult> Create([Bind("Description,Quantity,ExpireDate,Item_code,Location_id")] Stock stock)
        {
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _logger.LogInformation("Create Stock Detected !");

                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var stockadjusment = new StockAdjustment();

                    if (ModelState.IsValid)
                    {
                        stock.Created_by = userId;
                        stock.StockAvailable = (stock.Quantity != 0) ? true : false;

                        _context.Add(stock);
                        await _context.SaveChangesAsync();

                        stockadjusment.Description = stock.Description;
                        stockadjusment.Quantity = stock.Quantity;
                        stockadjusment.Item_code = stock.Item_code;
                        stockadjusment.Location_id = stock.Location_id;
                        stockadjusment.Status = Constants.FIRST_STOCK_ADD;
                        stockadjusment.Stock_Id = stock.Id;
                        _context.Add(stockadjusment);
                        await _context.SaveChangesAsync();
                        _logger.LogInformation("Stock Saved Successful " + stock.Description);

                        transaction.Commit();
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch (Exception)
                {
                    _logger.LogError("Stock Unsuccessfully ! ");
                    transaction.Rollback();
                }
                return View(stock);
            }


        }

        // GET: Stock/Edit/5
        [Authorize(Roles = "Admin,Operator,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stocks == null)
            {
                _logger.LogError("Stocks Table Not Found In Database !");
                return NotFound();
            }

            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                _logger.LogError("Stock Not Found !");
                return NotFound();
            }
            return View(stock);
        }

        // POST: Stock/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Operator,Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("AdjustDescription,Qty,Item_code,Location_id,Stock_Id")] StockAdjustmentDao stockAdjustmentDao)
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var stock = StockAdjustmentToStock(id);
            var stockAdjustment = new StockAdjustment();

            if (id != stock.Id)
            {
                _logger.LogError("Stock Not Found !");
                return NotFound();
            }
            if (!StockExists(stock.Id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (stock.Quantity <= stockAdjustmentDao.Qty * (-1))
                    {
                        stockAdjustment.Quantity = (stock.Quantity * (-1));
                        stock.Quantity = 0;
                    }
                    else
                    {
                        stock.Quantity = (stock.Quantity + stockAdjustmentDao.Qty);
                        stockAdjustment.Quantity = stockAdjustmentDao.Qty;
                    }

                    _context.Update(stock);
                    await _context.SaveChangesAsync();
                    _logger.LogError("Stock Saved Successfully !");

                    stockAdjustment.Description = stockAdjustmentDao.AdjustDescription;

                    stockAdjustment.Status = Constants.STOCK_ADJUSTMENT;
                    stockAdjustment.Item_code = stockAdjustmentDao.Item_code;
                    stockAdjustment.Location_id = stockAdjustmentDao.Location_id;
                    stockAdjustment.Created_by = userId;
                    stockAdjustment.Stock_Id = stockAdjustmentDao.Stock_Id;

                    _context.Add(stockAdjustment);
                    await _context.SaveChangesAsync();
                    _logger.LogError("Stock Adjustment Saved Successfully !");

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw new Exception();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        // GET: Stock/Delete/5
        [Authorize(Roles = "Admin,Operator,Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stocks == null)
            {
                _logger.LogError("Stock Table Not Found In Database !");
                return NotFound();
            }

            var stock = await _context.Stocks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stock == null)
            {
                _logger.LogError("Item Not Found !");
                return NotFound();
            }

            return View(stock);
        }

        // POST: Stock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Operator,Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.Stocks == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Stocks'  is null.");
                }
                var stock = await _context.Stocks.FindAsync(id);
                if (stock != null)
                {
                    stock.Status = Constants.DELETE;
                    _context.Update(stock);
                    _logger.LogError("Stock DEleted !" + stock.Description);
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

        [Authorize(Roles = "Admin,Operator,Manager")]
        private bool StockExists(int id)
        {
            return (_context.Stocks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        [Authorize(Roles = "Admin,Operator,Manager")]
        private Stock StockAdjustmentToStock(int stock) => (this._context.Stocks?.FirstOrDefault(e => e.Id == stock));
    }
}
