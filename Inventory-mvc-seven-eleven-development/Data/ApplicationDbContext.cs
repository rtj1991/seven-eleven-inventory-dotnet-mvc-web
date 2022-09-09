﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Inventory_mvc_seven_eleven.Models;

namespace Inventory_mvc_seven_eleven.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Item>? Items { get; set; }
    public DbSet<Location>? Locations { get; set; }
    public DbSet<Stock>? Stocks { get; set; }
    public DbSet<StockAdjustment>? StockAdjustments { get; set; }
    public DbSet<InvoiceHeader>? invoiceHeaders { get; set; }
    public DbSet<InvoiceDetails>? invoiceDetails { get; set; }
}
