using DoAnLTWeb.Models;
using DoAnLTWeb.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using X.PagedList;


namespace DoAnLTWeb.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly ISupplierRepository _SupplierRepository;
        private readonly IWarehousedetailRepository _WarehousedetailRepository;

        private readonly CsdlwebContext _context;

        public ShopController(CsdlwebContext context, IProductRepository productRepository, IProductTypeRepository productTypeRepository, ISupplierRepository supplierRepository, IWarehousedetailRepository warehousedetailRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _SupplierRepository = supplierRepository;
            _WarehousedetailRepository = warehousedetailRepository;
        }
        // Hiển thị danh sách sản phẩm
        public async Task<IActionResult> Index(int? page)
        {
            var products = await _productRepository.GetAllAsync();
            var pageNumber = page ?? 1; // Trang mặc định là trang 1 nếu không có giá trị page
            var pageSize = 12; // Số lượng sản phẩm mỗi trang

            var l = new List<Product>();
            var l1 = new List<Product>();
            var l2 = new List<Product>();
            int k = 0;
            if (_context.Warehousedetails.ToList() != null)
            {
                foreach (var product in _context.Warehousedetails.ToList())
                {
                    foreach (var pro in products)
                    {
                        if (pro.Idproduct == product.Idproduct)
                        {
                            if (product.QuantityInStock > 0)
                            {
                                if (l.Count == 0)
                                {
                                    l.Add(pro);
                                    l2.Add(pro);
                                }
                                else
                                {
                                    k = 0;
                                    foreach (var ktr in l)
                                    {
                                        if (ktr.Idproduct == pro.Idproduct)
                                        {
                                            k += 1;
                                        }
                                    }
                                    if (k == 0)
                                    {
                                        l.Add(pro);
                                        l2.Add(pro);

                                    }
                                }
                            }
                            else
                            {
                                if (l1.Count == 0)
                                {
                                    l1.Add(pro);
                                    l2.Add(pro);

                                }
                                else
                                {
                                    k = 0;
                                    foreach (var ktr in l1)
                                    {
                                        if (ktr.Idproduct == pro.Idproduct)
                                        {
                                            k += 1;
                                        }
                                    }
                                    if (l != null)
                                    {
                                        foreach (var ktr in l)
                                        {
                                            foreach (var kt in l1)
                                                if (ktr.Idproduct == kt.Idproduct)
                                                {
                                                    k += 1;
                                                }
                                        }
                                    }
                                    else
                                    {
                                        if (k == 0)
                                        {
                                            l1.Add(pro);
                                            l2.Add(pro);
                                        }
                                    }
                                }
                            }

                        }
                    }
                }

            }

            l2 = l2.Where(x => x.Status != 2).ToList();

            var pagedProducts = l2.ToPagedList(pageNumber, pageSize);
            var warehousedetail = await _WarehousedetailRepository.GetAllAsync();
            ViewBag.warehousedetail = warehousedetail;
            ViewBag.ProductType = _context.ProductTypes.ToList();
            return View(pagedProducts);
        }
        public async Task<IActionResult> IndexSale(int? page)
        {
            var products = await _productRepository.GetAllSale();
            var pageNumber = page ?? 1; // Trang mặc định là trang 1 nếu không có giá trị page
            var pageSize = 12; // Số lượng sản phẩm mỗi trang
            var l = new List<Product>();
            int k = 0;
            if (_context.Warehousedetails.ToList() != null)
            {
                foreach (var product in _context.Warehousedetails.ToList())
                {
                    foreach (var pro in products)
                    {
                        if (pro.Idproduct == product.Idproduct)
                        {
                            if (l.Count == 0)
                            {
                                l.Add(pro);
                            }
                            else
                            {
                                k = 0;
                                foreach (var ktr in l)
                                {
                                    if (ktr.Idproduct == pro.Idproduct)
                                    {
                                        k += 1;
                                    }
                                }
                                if (k == 0)
                                {
                                    l.Add(pro);
                                }
                            }
                        }
                    }
                }

            }
            l = l.Where(x => x.Status != 2).ToList();

            var pagedProducts = l.ToPagedList(pageNumber, pageSize);
            var warehousedetail = await _WarehousedetailRepository.GetAllAsync();
            ViewBag.warehousedetail = warehousedetail;
            ViewBag.ProductType = _context.ProductTypes.ToList();
            return View(pagedProducts);
        }
        public async Task<IActionResult> Indexproducttype(int? page, int idproducttype)
        {
            var products = _context.Products.Where(p => p.IdproductType == idproducttype).ToList();
            var pageNumber = page ?? 1; // Trang mặc định là trang 1 nếu không có giá trị page
            var pageSize = 12; // Số lượng sản phẩm mỗi trang
            var l = new List<Product>();
            var l1 = new List<Product>();
            var l2 = new List<Product>();
            int k = 0;
            if (_context.Warehousedetails.ToList() != null)
            {
                foreach (var product in _context.Warehousedetails.ToList())
                {
                    foreach (var pro in products)
                    {
                        if (pro.Idproduct == product.Idproduct)
                        {
                            if (product.QuantityInStock > 0)
                            {
                                if (l.Count == 0)
                                {
                                    l.Add(pro);
                                    l2.Add(pro);
                                }
                                else
                                {
                                    k = 0;
                                    foreach (var ktr in l)
                                    {
                                        if (ktr.Idproduct == pro.Idproduct)
                                        {
                                            k += 1;
                                        }
                                    }
                                    if (k == 0)
                                    {
                                        l.Add(pro);
                                        l2.Add(pro);

                                    }
                                }
                            }
                            else
                            {
                                if (l1.Count == 0)
                                {
                                    l1.Add(pro);
                                    l2.Add(pro);

                                }
                                else
                                {
                                    k = 0;
                                    foreach (var ktr in l1)
                                    {
                                        if (ktr.Idproduct == pro.Idproduct)
                                        {
                                            k += 1;
                                        }
                                    }
                                    if (l != null)
                                    {
                                        foreach (var ktr in l)
                                        {
                                            foreach (var kt in l1)
                                                if (ktr.Idproduct == kt.Idproduct)
                                                {
                                                    k += 1;
                                                }
                                        }
                                    }
                                    else
                                    {
                                        if (k == 0)
                                        {
                                            l1.Add(pro);
                                            l2.Add(pro);
                                        }
                                    }
                                }
                            }

                        }
                    }
                }

            }
            l2 = l2.Where(x => x.Status != 2).ToList();
            var pagedProducts = l2.ToPagedList(pageNumber, pageSize);
            var warehousedetail = await _WarehousedetailRepository.GetAllAsync();
            ViewBag.warehousedetail = warehousedetail;
            ViewBag.ProductType = _context.ProductTypes.ToList();
            return View(pagedProducts);
        }
        public async Task<IActionResult> Detailproduct(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            var otherProducts = await _productRepository.GetAllAsync();

            var random = new Random();
            var randomProducts = otherProducts.OrderBy(p => random.Next()).Take(6).ToList();
            if (product == null)
            {
                return NotFound();
            }

            var supplier = await _SupplierRepository.GetByIdAsync(product.Idsupplier);
            if (supplier == null)
            {
                return NotFound();
            }
            var warehousedetail = await _WarehousedetailRepository.GetAllAsync();
            ViewBag.warehousedetail = warehousedetail;
            ViewBag.Product = product;
            ViewBag.Supplier = supplier;
            ViewBag.OtherProducts = randomProducts;

            return View();
        }
    }
}

