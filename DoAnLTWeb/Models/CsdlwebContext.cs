using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DoAnLTWeb.Models;

public partial class CsdlwebContext : DbContext
{
    public CsdlwebContext()
    {
    }

    public CsdlwebContext(DbContextOptions<CsdlwebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DeliveryNote> DeliveryNotes { get; set; }

    public virtual DbSet<Footer> Footers { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<ImportedProduct> ImportedProducts { get; set; }

    public virtual DbSet<ImportedProductsDetail> ImportedProductsDetails { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Invoicedetail> Invoicedetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImagesDetail> ProductImagesDetails { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public virtual DbSet<ShoppingCartDeltail> ShoppingCartDeltails { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillDetail> SkillDetails { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffType> StaffTypes { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<Warehousedetail> Warehousedetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=THANHSON\\THANHSON;Initial Catalog=daweb4;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.IdBanner);

            entity.ToTable("Banner");

            entity.Property(e => e.Idimages).HasColumnName("IDImages");

            entity.HasOne(d => d.IdimagesNavigation).WithMany(p => p.Banners)
                .HasForeignKey(d => d.Idimages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Banner_Images");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Idcustomer);

            entity.ToTable("Customer");

            entity.Property(e => e.Idcustomer).HasColumnName("IDCustomer");
            entity.Property(e => e.CitizenIdentificationCode)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.CustomerAddress).HasColumnType("ntext");
            entity.Property(e => e.CustomerName).HasMaxLength(35);
            entity.Property(e => e.PhoneCustomer)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsFixedLength();

            entity.HasOne(d => d.IdImagesNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.IdImages)
                .HasConstraintName("FK_Customer_Images");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.Username)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_User");
        });

        modelBuilder.Entity<DeliveryNote>(entity =>
        {
            entity.HasKey(e => e.IdDeliveryNotes);

            entity.Property(e => e.DeliveryAddress).HasColumnType("ntext");
            entity.Property(e => e.Idinvoice).HasColumnName("IDInvoice");
            entity.Property(e => e.Idstaff).HasColumnName("IDStaff");
            entity.Property(e => e.RecipientPhone)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdinvoiceNavigation).WithMany(p => p.DeliveryNotes)
                .HasForeignKey(d => d.Idinvoice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeliveryNotes_Invoice");

            entity.HasOne(d => d.IdstaffNavigation).WithMany(p => p.DeliveryNotes)
                .HasForeignKey(d => d.Idstaff)
                .HasConstraintName("FK_DeliveryNotes_Staff");
        });

        modelBuilder.Entity<Footer>(entity =>
        {
            entity.HasKey(e => e.Idfooter);

            entity.ToTable("Footer");

            entity.Property(e => e.Idfooter).HasColumnName("IDfooter");
            entity.Property(e => e.Content).HasColumnType("ntext");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Idimages).HasName("PK_Produc1Images");

            entity.Property(e => e.Idimages).HasColumnName("IDImages");
            entity.Property(e => e.NameImages).HasMaxLength(50);
            entity.Property(e => e.UrlImages)
                .HasMaxLength(120)
                .IsFixedLength();
        });

        modelBuilder.Entity<ImportedProduct>(entity =>
        {
            entity.HasKey(e => e.IdimportedProducts).HasName("PK_Imported Products Detail");

            entity.ToTable("Imported Products");

            entity.Property(e => e.IdimportedProducts).HasColumnName("IDImportedProducts");
            entity.Property(e => e.Idstaff).HasColumnName("IDStaff");
            entity.Property(e => e.Idwarehouse).HasColumnName("IDWarehouse");

            entity.HasOne(d => d.IdstaffNavigation).WithMany(p => p.ImportedProducts)
                .HasForeignKey(d => d.Idstaff)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Imported Products Detail_Staff");

            entity.HasOne(d => d.IdwarehouseNavigation).WithMany(p => p.ImportedProducts)
                .HasForeignKey(d => d.Idwarehouse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Imported Products Detail_Warehouse");
        });

        modelBuilder.Entity<ImportedProductsDetail>(entity =>
        {
            entity.HasKey(e => new { e.IdimportedProducts, e.Idproduct });

            entity.ToTable("ImportedProductsDetail");

            entity.Property(e => e.IdimportedProducts).HasColumnName("IDImportedProducts");
            entity.Property(e => e.Idproduct).HasColumnName("IDProduct");

            entity.HasOne(d => d.IdimportedProductsNavigation).WithMany(p => p.ImportedProductsDetails)
                .HasForeignKey(d => d.IdimportedProducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImportedProductsDetail_Imported Products");

            entity.HasOne(d => d.IdproductNavigation).WithMany(p => p.ImportedProductsDetails)
                .HasForeignKey(d => d.Idproduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImportedProductsDetail_Product");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Idinvoice).HasName("PK_Bill");

            entity.ToTable("Invoice");

            entity.Property(e => e.Idinvoice).HasColumnName("IDInvoice");
            entity.Property(e => e.Idcustomer).HasColumnName("IDCustomer");
            entity.Property(e => e.Idstaff).HasColumnName("IDStaff");

            entity.HasOne(d => d.IdcustomerNavigation).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Idcustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Customer");

            entity.HasOne(d => d.IdstaffNavigation).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Idstaff)
                .HasConstraintName("FK_Invoice_Staff");
        });

        modelBuilder.Entity<Invoicedetail>(entity =>
        {
            entity.HasKey(e => new { e.Idinvoice, e.Idproduct });

            entity.Property(e => e.Idinvoice).HasColumnName("IDInvoice");
            entity.Property(e => e.Idproduct).HasColumnName("IDProduct");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdinvoiceNavigation).WithMany(p => p.Invoicedetails)
                .HasForeignKey(d => d.Idinvoice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoicedetails_Invoice");

            entity.HasOne(d => d.IdproductNavigation).WithMany(p => p.Invoicedetails)
                .HasForeignKey(d => d.Idproduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoicedetails_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Idproduct);

            entity.ToTable("Product");

            entity.Property(e => e.Idproduct).HasColumnName("IDProduct");
            entity.Property(e => e.IdproductType).HasColumnName("IDProductType");
            entity.Property(e => e.Idsupplier).HasColumnName("IDSupplier");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductDescription).HasColumnType("ntext");
            entity.Property(e => e.ProductName).HasMaxLength(50);

            entity.HasOne(d => d.IdproductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdproductType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductType");

            entity.HasOne(d => d.IdsupplierNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Idsupplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Supplier");
        });

        modelBuilder.Entity<ProductImagesDetail>(entity =>
        {
            entity.HasKey(e => new { e.Idimages, e.Idproduct });

            entity.Property(e => e.Idimages).HasColumnName("IDImages");
            entity.Property(e => e.Idproduct).HasColumnName("IDProduct");
            entity.Property(e => e.Ngaycapnhat).HasColumnName("ngaycapnhat");

            entity.HasOne(d => d.IdimagesNavigation).WithMany(p => p.ProductImagesDetails)
                .HasForeignKey(d => d.Idimages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductImagesDetails_Images");

            entity.HasOne(d => d.IdproductNavigation).WithMany(p => p.ProductImagesDetails)
                .HasForeignKey(d => d.Idproduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductImagesDetails_Product");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.IdproductType);

            entity.ToTable("ProductType");

            entity.Property(e => e.IdproductType).HasColumnName("IDProductType");
            entity.Property(e => e.ProductTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.HasKey(e => e.IdshoppingCart);

            entity.ToTable("Shopping cart");

            entity.Property(e => e.IdshoppingCart).HasColumnName("IDshoppingCart");
            entity.Property(e => e.Idcustomer).HasColumnName("IDCustomer");

            entity.HasOne(d => d.IdcustomerNavigation).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.Idcustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shopping cart_Customer");
        });

        modelBuilder.Entity<ShoppingCartDeltail>(entity =>
        {
            entity.HasKey(e => new { e.IdshoppingCart, e.Idproduct }).HasName("PK_IDshoppingCartDeltails");

            entity.ToTable("shoppingCartDeltails");

            entity.Property(e => e.IdshoppingCart).HasColumnName("IDshoppingCart");
            entity.Property(e => e.Idproduct).HasColumnName("IDProduct");

            entity.HasOne(d => d.IdproductNavigation).WithMany(p => p.ShoppingCartDeltails)
                .HasForeignKey(d => d.Idproduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_shoppingCartDeltails_Product");

            entity.HasOne(d => d.IdshoppingCartNavigation).WithMany(p => p.ShoppingCartDeltails)
                .HasForeignKey(d => d.IdshoppingCart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_shoppingCartDeltails_Shopping cart");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.IdSkill);

            entity.ToTable("Skill");

            entity.Property(e => e.NameSkill).HasMaxLength(50);
        });

        modelBuilder.Entity<SkillDetail>(entity =>
        {
            entity.HasKey(e => new { e.IdSkill, e.Idstaff });

            entity.Property(e => e.Idstaff).HasColumnName("IDStaff");
            entity.Property(e => e.UpdateDay)
                .HasColumnType("datetime")
                .HasColumnName("updateDay");

            entity.HasOne(d => d.IdSkillNavigation).WithMany(p => p.SkillDetails)
                .HasForeignKey(d => d.IdSkill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SkillDetails_Skill");

            entity.HasOne(d => d.IdstaffNavigation).WithMany(p => p.SkillDetails)
                .HasForeignKey(d => d.Idstaff)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SkillDetails_Staff");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Idstaff);

            entity.Property(e => e.Idstaff).HasColumnName("IDStaff");
            entity.Property(e => e.CitizenIdentificationCode)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.IdstaffType).HasColumnName("IDStaffType");
            entity.Property(e => e.PhoneStaff)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.StaffAddress).HasColumnType("ntext");
            entity.Property(e => e.StaffName).HasMaxLength(35);
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsFixedLength();

            entity.HasOne(d => d.IdImagesNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.IdImages)
                .HasConstraintName("FK_Staff_Images");

            entity.HasOne(d => d.IdstaffTypeNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.IdstaffType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Staff_StaffType");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.Username)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Staff_User");
        });

        modelBuilder.Entity<StaffType>(entity =>
        {
            entity.HasKey(e => e.IdstaffType);

            entity.ToTable("StaffType");

            entity.Property(e => e.IdstaffType).HasColumnName("IDStaffType");
            entity.Property(e => e.StaffTypeName).HasMaxLength(35);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Idsupplier);

            entity.ToTable("Supplier");

            entity.Property(e => e.Idsupplier).HasColumnName("IDSupplier");
            entity.Property(e => e.EmailSupplier)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.PhoneSupplier)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.SupplierName).HasMaxLength(35);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK_User_1");

            entity.ToTable("User");

            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Idwarehouse);

            entity.ToTable("Warehouse");

            entity.Property(e => e.Idwarehouse).HasColumnName("IDWarehouse");
            entity.Property(e => e.WarehouseAddress).HasColumnType("ntext");
            entity.Property(e => e.WarehouseName).HasMaxLength(50);
        });

        modelBuilder.Entity<Warehousedetail>(entity =>
        {
            entity.HasKey(e => new { e.Idwarehouse, e.Idproduct });

            entity.Property(e => e.Idwarehouse).HasColumnName("IDWarehouse");
            entity.Property(e => e.Idproduct).HasColumnName("IDProduct");

            entity.HasOne(d => d.IdproductNavigation).WithMany(p => p.Warehousedetails)
                .HasForeignKey(d => d.Idproduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehousedetails_Product");

            entity.HasOne(d => d.IdwarehouseNavigation).WithMany(p => p.Warehousedetails)
                .HasForeignKey(d => d.Idwarehouse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehousedetails_Warehouse");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
