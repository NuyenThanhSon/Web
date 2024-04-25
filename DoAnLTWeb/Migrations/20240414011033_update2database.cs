using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnLTWeb.Migrations
{
    /// <inheritdoc />
    public partial class update2database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "footer",
                columns: table => new
                {
                    IDfooter = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_footer", x => x.IDfooter);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    IDImages = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameImages = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UrlImages = table.Column<string>(type: "nchar(120)", fixedLength: true, maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produc1Images", x => x.IDImages);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    IDProductType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.IDProductType);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    IdSkill = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSkill = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.IdSkill);
                });

            migrationBuilder.CreateTable(
                name: "StaffType",
                columns: table => new
                {
                    IDStaffType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffTypeName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffType", x => x.IDStaffType);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    IDSupplier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    PhoneSupplier = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: false),
                    SupplierAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailSupplier = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.IDSupplier);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", fixedLength: true, maxLength: 18, nullable: false),
                    Check = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_1", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    IDWarehouse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WarehouseAddress = table.Column<string>(type: "ntext", nullable: false),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.IDWarehouse);
                });

            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    IdBanner = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horizontal = table.Column<double>(type: "float", nullable: false),
                    Vertical = table.Column<double>(type: "float", nullable: false),
                    IDImages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.IdBanner);
                    table.ForeignKey(
                        name: "FK_Banner_Images",
                        column: x => x.IDImages,
                        principalTable: "Images",
                        principalColumn: "IDImages");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    IDProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductDescription = table.Column<string>(type: "ntext", nullable: true),
                    IDProductType = table.Column<int>(type: "int", nullable: false),
                    IDSupplier = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Sale = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.IDProduct);
                    table.ForeignKey(
                        name: "FK_Product_ProductType",
                        column: x => x.IDProductType,
                        principalTable: "ProductType",
                        principalColumn: "IDProductType");
                    table.ForeignKey(
                        name: "FK_Product_Supplier",
                        column: x => x.IDSupplier,
                        principalTable: "Supplier",
                        principalColumn: "IDSupplier");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    IDCustomer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    PhoneCustomer = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    CustomerAddress = table.Column<string>(type: "ntext", nullable: false),
                    CitizenIdentificationCode = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    IdImages = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.IDCustomer);
                    table.ForeignKey(
                        name: "FK_Customer_Images",
                        column: x => x.IdImages,
                        principalTable: "Images",
                        principalColumn: "IDImages");
                    table.ForeignKey(
                        name: "FK_Customer_User",
                        column: x => x.Username,
                        principalTable: "User",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    IDStaff = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Username = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    StaffAddress = table.Column<string>(type: "ntext", nullable: false),
                    PhoneStaff = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    CitizenIdentificationCode = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: false),
                    IDStaffType = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    IdImages = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.IDStaff);
                    table.ForeignKey(
                        name: "FK_Staff_Images",
                        column: x => x.IdImages,
                        principalTable: "Images",
                        principalColumn: "IDImages");
                    table.ForeignKey(
                        name: "FK_Staff_StaffType",
                        column: x => x.IDStaffType,
                        principalTable: "StaffType",
                        principalColumn: "IDStaffType");
                    table.ForeignKey(
                        name: "FK_Staff_User",
                        column: x => x.Username,
                        principalTable: "User",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "ProductImagesDetails",
                columns: table => new
                {
                    IDImages = table.Column<int>(type: "int", nullable: false),
                    IDProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImagesDetails", x => new { x.IDImages, x.IDProduct });
                    table.ForeignKey(
                        name: "FK_ProductImagesDetails_Images",
                        column: x => x.IDImages,
                        principalTable: "Images",
                        principalColumn: "IDImages");
                    table.ForeignKey(
                        name: "FK_ProductImagesDetails_Product",
                        column: x => x.IDProduct,
                        principalTable: "Product",
                        principalColumn: "IDProduct");
                });

            migrationBuilder.CreateTable(
                name: "Warehousedetails",
                columns: table => new
                {
                    IDWarehouse = table.Column<int>(type: "int", nullable: false),
                    IDProduct = table.Column<int>(type: "int", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehousedetails", x => new { x.IDWarehouse, x.IDProduct });
                    table.ForeignKey(
                        name: "FK_Warehousedetails_Product",
                        column: x => x.IDProduct,
                        principalTable: "Product",
                        principalColumn: "IDProduct");
                    table.ForeignKey(
                        name: "FK_Warehousedetails_Warehouse",
                        column: x => x.IDWarehouse,
                        principalTable: "Warehouse",
                        principalColumn: "IDWarehouse");
                });

            migrationBuilder.CreateTable(
                name: "Shopping cart",
                columns: table => new
                {
                    IDshoppingCart = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCustomer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping cart", x => x.IDshoppingCart);
                    table.ForeignKey(
                        name: "FK_Shopping cart_Customer",
                        column: x => x.IDCustomer,
                        principalTable: "Customer",
                        principalColumn: "IDCustomer");
                });

            migrationBuilder.CreateTable(
                name: "Imported Products",
                columns: table => new
                {
                    IDImportedProducts = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDStaff = table.Column<int>(type: "int", nullable: false),
                    IDWarehouse = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imported Products Detail", x => x.IDImportedProducts);
                    table.ForeignKey(
                        name: "FK_Imported Products Detail_Staff",
                        column: x => x.IDStaff,
                        principalTable: "Staff",
                        principalColumn: "IDStaff");
                    table.ForeignKey(
                        name: "FK_Imported Products Detail_Warehouse",
                        column: x => x.IDWarehouse,
                        principalTable: "Warehouse",
                        principalColumn: "IDWarehouse");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    IDInvoice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCustomer = table.Column<int>(type: "int", nullable: false),
                    IDStaff = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.IDInvoice);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer",
                        column: x => x.IDCustomer,
                        principalTable: "Customer",
                        principalColumn: "IDCustomer");
                    table.ForeignKey(
                        name: "FK_Invoice_Staff",
                        column: x => x.IDStaff,
                        principalTable: "Staff",
                        principalColumn: "IDStaff");
                });

            migrationBuilder.CreateTable(
                name: "SkillDetails",
                columns: table => new
                {
                    IdSkill = table.Column<int>(type: "int", nullable: false),
                    IDStaff = table.Column<int>(type: "int", nullable: false),
                    updateDay = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillDetails", x => new { x.IdSkill, x.IDStaff });
                    table.ForeignKey(
                        name: "FK_SkillDetails_Skill",
                        column: x => x.IdSkill,
                        principalTable: "Skill",
                        principalColumn: "IdSkill");
                    table.ForeignKey(
                        name: "FK_SkillDetails_Staff",
                        column: x => x.IDStaff,
                        principalTable: "Staff",
                        principalColumn: "IDStaff");
                });

            migrationBuilder.CreateTable(
                name: "shoppingCartDeltails",
                columns: table => new
                {
                    IDshoppingCart = table.Column<int>(type: "int", nullable: false),
                    IDProduct = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDshoppingCartDeltails", x => new { x.IDshoppingCart, x.IDProduct });
                    table.ForeignKey(
                        name: "FK_shoppingCartDeltails_Product",
                        column: x => x.IDProduct,
                        principalTable: "Product",
                        principalColumn: "IDProduct");
                    table.ForeignKey(
                        name: "FK_shoppingCartDeltails_Shopping cart",
                        column: x => x.IDshoppingCart,
                        principalTable: "Shopping cart",
                        principalColumn: "IDshoppingCart");
                });

            migrationBuilder.CreateTable(
                name: "ImportedProductsDetail",
                columns: table => new
                {
                    IDImportedProducts = table.Column<int>(type: "int", nullable: false),
                    IDProduct = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    InputPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportedProductsDetail", x => new { x.IDImportedProducts, x.IDProduct });
                    table.ForeignKey(
                        name: "FK_ImportedProductsDetail_Imported Products",
                        column: x => x.IDImportedProducts,
                        principalTable: "Imported Products",
                        principalColumn: "IDImportedProducts");
                    table.ForeignKey(
                        name: "FK_ImportedProductsDetail_Product",
                        column: x => x.IDProduct,
                        principalTable: "Product",
                        principalColumn: "IDProduct");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryNotes",
                columns: table => new
                {
                    IdDeliveryNotes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDInvoice = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "ntext", nullable: false),
                    RecipientPhone = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IDStaff = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryNotes", x => x.IdDeliveryNotes);
                    table.ForeignKey(
                        name: "FK_DeliveryNotes_Invoice",
                        column: x => x.IDInvoice,
                        principalTable: "Invoice",
                        principalColumn: "IDInvoice");
                    table.ForeignKey(
                        name: "FK_DeliveryNotes_Staff",
                        column: x => x.IDStaff,
                        principalTable: "Staff",
                        principalColumn: "IDStaff");
                });

            migrationBuilder.CreateTable(
                name: "Invoicedetails",
                columns: table => new
                {
                    IDInvoice = table.Column<int>(type: "int", nullable: false),
                    IDProduct = table.Column<int>(type: "int", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoicedetails", x => new { x.IDInvoice, x.IDProduct });
                    table.ForeignKey(
                        name: "FK_Invoicedetails_Invoice",
                        column: x => x.IDInvoice,
                        principalTable: "Invoice",
                        principalColumn: "IDInvoice");
                    table.ForeignKey(
                        name: "FK_Invoicedetails_Product",
                        column: x => x.IDProduct,
                        principalTable: "Product",
                        principalColumn: "IDProduct");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banner_IDImages",
                table: "Banner",
                column: "IDImages");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdImages",
                table: "Customer",
                column: "IdImages");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Username",
                table: "Customer",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNotes_IDInvoice",
                table: "DeliveryNotes",
                column: "IDInvoice");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNotes_IDStaff",
                table: "DeliveryNotes",
                column: "IDStaff");

            migrationBuilder.CreateIndex(
                name: "IX_Imported Products_IDStaff",
                table: "Imported Products",
                column: "IDStaff");

            migrationBuilder.CreateIndex(
                name: "IX_Imported Products_IDWarehouse",
                table: "Imported Products",
                column: "IDWarehouse");

            migrationBuilder.CreateIndex(
                name: "IX_ImportedProductsDetail_IDProduct",
                table: "ImportedProductsDetail",
                column: "IDProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_IDCustomer",
                table: "Invoice",
                column: "IDCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_IDStaff",
                table: "Invoice",
                column: "IDStaff");

            migrationBuilder.CreateIndex(
                name: "IX_Invoicedetails_IDProduct",
                table: "Invoicedetails",
                column: "IDProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IDProductType",
                table: "Product",
                column: "IDProductType");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IDSupplier",
                table: "Product",
                column: "IDSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImagesDetails_IDProduct",
                table: "ProductImagesDetails",
                column: "IDProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping cart_IDCustomer",
                table: "Shopping cart",
                column: "IDCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCartDeltails_IDProduct",
                table: "shoppingCartDeltails",
                column: "IDProduct");

            migrationBuilder.CreateIndex(
                name: "IX_SkillDetails_IDStaff",
                table: "SkillDetails",
                column: "IDStaff");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_IdImages",
                table: "Staff",
                column: "IdImages");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_IDStaffType",
                table: "Staff",
                column: "IDStaffType");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Username",
                table: "Staff",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Warehousedetails_IDProduct",
                table: "Warehousedetails",
                column: "IDProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.DropTable(
                name: "DeliveryNotes");

            migrationBuilder.DropTable(
                name: "footer");

            migrationBuilder.DropTable(
                name: "ImportedProductsDetail");

            migrationBuilder.DropTable(
                name: "Invoicedetails");

            migrationBuilder.DropTable(
                name: "ProductImagesDetails");

            migrationBuilder.DropTable(
                name: "shoppingCartDeltails");

            migrationBuilder.DropTable(
                name: "SkillDetails");

            migrationBuilder.DropTable(
                name: "Warehousedetails");

            migrationBuilder.DropTable(
                name: "Imported Products");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Shopping cart");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "StaffType");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
