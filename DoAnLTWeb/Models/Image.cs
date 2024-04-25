using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class Image
{
    public int Idimages { get; set; }

    public string NameImages { get; set; } = null!;

    public string? UrlImages { get; set; }

    public virtual ICollection<Banner> Banners { get; set; } = new List<Banner>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<ProductImagesDetail> ProductImagesDetails { get; set; } = new List<ProductImagesDetail>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
