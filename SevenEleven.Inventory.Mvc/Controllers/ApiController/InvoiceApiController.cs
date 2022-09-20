using Microsoft.AspNetCore.Mvc;
using SevenEleven.Inventory.Mvc.Models;
using SevenEleven.Inventory.Mvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Authorization;
using SevenEleven.Inventory.Mvc.Dao;

namespace SevenEleven.Inventory.Mvc.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtSetting.AuthSchema)]
public class InvoiceApiController : Controller
{
    private readonly ILogger<InvoiceApiController> _logger;
    private readonly ApplicationDbContext _context;

    public InvoiceApiController(ILogger<InvoiceApiController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("GetItemByItemCode/{itemcode}/{loc_id}")]
    public async Task<IActionResult> GetItemByItemCode(int itemcode, int loc_id)
    {
        var stock = await _context.Stocks.Where(b => b.Item_code == itemcode && b.Location_id == loc_id).ToListAsync();

        return Ok(stock);
    }

    [HttpPost("InvoiceSale")]
    public async Task<IActionResult> InvoiceSale(InvoiceRequest invoiceRequest)
    {
        using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
        {
            try
            {

                var invoice = new InvoiceHeader();
                invoice.Address = invoiceRequest.Address;
                invoice.Description = invoiceRequest.Description;
                invoice.PurchaserName = invoiceRequest.PurchaserName;
                invoice.PaidAmount = invoiceRequest.PaidAmount;
                invoice.Loc_Id = invoiceRequest.Loc_Id;
                invoice.Created_by = invoiceRequest.Created_by;


                double total_amount = 0.0;

                foreach (var list in invoiceRequest.invoiceRequestDetails)
                {
                    double totalQty = 0.0;
                    var item = await _context.Items.FindAsync(list.item_code);
                    var invoiceDetail = new InvoiceDetails();
                    invoiceDetail.Quentity = list.quantity;
                    invoiceDetail.Item_Code = list.item_code;
                    invoiceDetail.Price = item.Price;
                    invoiceDetail.Inv_no = invoice.InvoiceNo;

                    _context.Add(invoiceDetail);
                    await this._context.SaveChangesAsync();

                    total_amount += item.Price;

                    var stock = await _context.Stocks.Where(b => b.Item_code == list.item_code && b.Location_id == invoiceRequest.Loc_Id && b.StockAvailable == true && b.Quantity > 0.0).OrderByDescending(b => b.ExpireDate).LastAsync();
                    var all_stock = await _context.Stocks.Where(b => b.Item_code == list.item_code && b.Location_id == invoiceRequest.Loc_Id && b.StockAvailable == true).ToListAsync();

                    double total_qty = 0.0;
                    foreach (var all_qty in all_stock)
                    {
                        total_qty += all_qty.Quantity;
                    }

                    var stockAdjust = await this._context.StockAdjustments.Where(s => s.Stock_Id == stock.Id).ToListAsync();
                    foreach (var adjust in stockAdjust)
                    {
                        totalQty += adjust.Quantity;
                    }

                    if (total_qty >= list.quantity)
                    {
                        if (stock.Quantity == 0)
                        {
                            stock.StockAvailable = false;
                            _context.Update(stock);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {

                            double restQty = list.quantity - stock.Quantity;

                            if (list.quantity > stock.Quantity)
                            {
                                stock.Quantity = totalQty - (list.quantity - restQty);
                                stock.StockAvailable = false;
                                _context.Update(stock);
                                await _context.SaveChangesAsync();

                                if (restQty > 0.0)
                                {
                                    var stock_rest = await _context.Stocks.Where(b => b.Item_code == list.item_code && b.Location_id == invoiceRequest.Loc_Id && b.StockAvailable == true && b.Quantity > 0.0).OrderByDescending(b => b.ExpireDate).LastAsync();
                                    stock_rest.Quantity = (totalQty - restQty);
                                    _context.Update(stock_rest);
                                    await _context.SaveChangesAsync();
                                }

                            }
                            else
                            {
                                stock.Quantity = stock.Quantity - list.quantity;
                                _context.Update(stock);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }

                }
                invoice.TotalAmount = total_amount;
                _context.Add(invoice);
                await this._context.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception)
            {

                transaction.Rollback();
            }
            return Ok(true);
        }

    }


}
