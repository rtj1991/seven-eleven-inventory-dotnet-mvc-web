using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SevenEleven.Inventory.Mvc.Migrations
{
    public partial class _20220826_1InventoryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "invoiceHeaders",
                columns: table => new
                {
                    InvoiceNo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PurchaserName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    TotalAmount = table.Column<double>(type: "double precision", nullable: false),
                    PaidAmount = table.Column<double>(type: "double precision", nullable: false),
                    PaidStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created_by = table.Column<string>(type: "text", nullable: true),
                    InCreatedById = table.Column<string>(type: "text", nullable: true),
                    Loc_Id = table.Column<int>(type: "integer", nullable: true),
                    ILocIdId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoiceHeaders", x => x.InvoiceNo);
                    table.ForeignKey(
                        name: "FK_invoiceHeaders_AspNetUsers_InCreatedById",
                        column: x => x.InCreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_invoiceHeaders_Locations_ILocIdId",
                        column: x => x.ILocIdId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "invoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quentity = table.Column<double>(type: "double precision", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Item_Code = table.Column<int>(type: "integer", nullable: true),
                    ItemCodeId = table.Column<int>(type: "integer", nullable: true),
                    Inv_no = table.Column<int>(type: "integer", nullable: true),
                    Invoice_NoInvoiceNo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_invoiceDetails_invoiceHeaders_Invoice_NoInvoiceNo",
                        column: x => x.Invoice_NoInvoiceNo,
                        principalTable: "invoiceHeaders",
                        principalColumn: "InvoiceNo");
                    table.ForeignKey(
                        name: "FK_invoiceDetails_Items_ItemCodeId",
                        column: x => x.ItemCodeId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_invoiceDetails_Invoice_NoInvoiceNo",
                table: "invoiceDetails",
                column: "Invoice_NoInvoiceNo");

            migrationBuilder.CreateIndex(
                name: "IX_invoiceDetails_ItemCodeId",
                table: "invoiceDetails",
                column: "ItemCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_invoiceHeaders_ILocIdId",
                table: "invoiceHeaders",
                column: "ILocIdId");

            migrationBuilder.CreateIndex(
                name: "IX_invoiceHeaders_InCreatedById",
                table: "invoiceHeaders",
                column: "InCreatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoiceDetails");

            migrationBuilder.DropTable(
                name: "invoiceHeaders");
        }
    }
}
