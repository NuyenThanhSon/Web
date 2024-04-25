using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class Product
{
    public int Idproduct { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductDescription { get; set; }

    public int IdproductType { get; set; }

    public int Idsupplier { get; set; }

    public decimal Price { get; set; }

    public double? Sale { get; set; }

    public int? Status { get; set; }

    public virtual ProductType IdproductTypeNavigation { get; set; } = null!;

    public virtual Supplier IdsupplierNavigation { get; set; } = null!;

    public virtual ICollection<ImportedProductsDetail> ImportedProductsDetails { get; set; } = new List<ImportedProductsDetail>();

    public virtual ICollection<Invoicedetail> Invoicedetails { get; set; } = new List<Invoicedetail>();

    public virtual ICollection<ProductImagesDetail> ProductImagesDetails { get; set; } = new List<ProductImagesDetail>();

    public virtual ICollection<ShoppingCartDeltail> ShoppingCartDeltails { get; set; } = new List<ShoppingCartDeltail>();

    public virtual ICollection<Warehousedetail> Warehousedetails { get; set; } = new List<Warehousedetail>();
}
