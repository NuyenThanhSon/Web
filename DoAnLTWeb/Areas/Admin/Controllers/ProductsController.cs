using DoAnLTWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DoAnLTWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        CsdlwebContext db = new CsdlwebContext();


        [HttpPost]
        public async Task<IActionResult> ProductUp(Product model)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var product = await db.Products.FindAsync(model.Idproduct);

                    if (product == null)
                    {
                        return NotFound("Product not found.");
                    }

                    // Update properties
                    product.ProductName = model.ProductName;
                    product.ProductDescription = model.ProductDescription;
                    product.IdproductType = model.IdproductType;
                    product.Idsupplier = model.Idsupplier;
                    product.Price = model.Price;
                    product.Sale = model.Sale;
                    product.Status = model.Status;

                    // Save changes
                    db.Products.Update(product);
                    await db.SaveChangesAsync();

                    // Commit the transaction
                    transaction.Commit();

                    // Redirect to a confirmation page or detail page
                    return RedirectToAction("Update", "Products", new { area = "Admin", id = model.Idproduct });
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    transaction.Rollback();
                    return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
            }
        }

        public IActionResult View()
        {
            var productList = db.Products.ToList();
            return View(productList);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int deleteimage, int idproduct)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var detailImageProduct = await db.ProductImagesDetails
                        .FirstOrDefaultAsync(p => p.Idimages == deleteimage && p.Idproduct == idproduct);

                    if (detailImageProduct == null)
                    {
                        return NotFound("Product image detail not found.");
                    }

                    // Xóa chi tiết ảnh sản phẩm
                    db.ProductImagesDetails.Remove(detailImageProduct);
                    await db.SaveChangesAsync();

                    // Tiếp tục xóa ảnh chính sau khi xóa chi tiết
                    var image = await db.Images.FirstOrDefaultAsync(p => p.Idimages == deleteimage);
                    if (image == null)
                    {
                        transaction.Rollback();
                        return NotFound("Image not found.");
                    }

                    db.Images.Remove(image);
                    await db.SaveChangesAsync();

                    // Hoàn tất quá trình xóa
                    transaction.Commit();
                    return RedirectToAction("Update", "Products", new { area = "Admin", id = idproduct });

                    // Chuyển đến trang xem danh sách sản phẩm hoặc một trang khác tùy bạn
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi và rollback transaction nếu có lỗi xảy ra
                    transaction.Rollback();
                    // Ghi log lỗi, ví dụ: _logger.LogError("Error deleting image: {Message}", ex.Message);
                    return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
            }
        }



        public IActionResult Add()
        {
            // Tạo một đối tượng Product mới để truyền cho view
            var product = new Product();

            // Lấy danh sách loại sản phẩm và nhà cung cấp từ cơ sở dữ liệu
            var productTypes = db.ProductTypes.ToList();
            var suppliers = db.Suppliers.ToList();

            // Gán danh sách loại sản phẩm và nhà cung cấp cho ViewBag để truyền sang view
            ViewBag.ProductTypes = productTypes;
            ViewBag.Suppliers = suppliers;

            // Trả về view với đối tượng Product mới
            return View(product);
        }


        public async Task<IActionResult> Update(int id)
        {
            var product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // Lấy ra toàn bộ danh sách ProductTypes từ cơ sở dữ liệu
            var productTypes = await db.ProductTypes.ToListAsync();

            // Tìm ProductType của sản phẩm hiện tại
            var selectedProductType = productTypes.FirstOrDefault(pt => pt.IdproductType == product.IdproductType);

            // Tạo SelectList chứa danh sách ProductTypes để sử dụng trong view
            var selectListItems = productTypes.Select(x => new SelectListItem
            {
                Value = x.IdproductType.ToString(),
                Text = x.ProductTypeName,
                Selected = (x == selectedProductType)  // Chọn ProductType tương ứng với sản phẩm hiện tại
            }).ToList();

            // Thêm một option trống vào đầu tiên để người dùng có thể chọn
            selectListItems.Insert(0, new SelectListItem { Value = "", Text = "-- Select --" });

            ViewBag.ProductTypes = selectListItems;

            var productImages = db.ProductImagesDetails.Where(p => p.Idproduct == id).ToList();
            var imageIds = productImages.Select(pi => pi.Idimages).ToList();
            var images = db.Images.Where(i => imageIds.Contains(i.Idimages)).ToList();

            ViewBag.imageResult = images;

            ViewBag.ProductTypeName = selectedProductType.ProductTypeName;

            // Lấy ra toàn bộ danh sách Suppliers từ cơ sở dữ liệu
            var suppliers = await db.Suppliers.ToListAsync();

            // Tìm Supplier của sản phẩm hiện tại
            var selectedSupplier = suppliers.FirstOrDefault(s => s.Idsupplier == product.Idsupplier);

            // Tạo SelectList chứa danh sách Suppliers để sử dụng trong view
            var selectListItems_1 = suppliers.Select(s => new SelectListItem
            {
                Value = s.Idsupplier.ToString(),
                Text = s.SupplierName,
                Selected = (s == selectedSupplier) // Chọn Supplier tương ứng với sản phẩm hiện tại
            }).ToList();

            // Thêm một option trống vào đầu tiên để người dùng có thể chọn
            selectListItems_1.Insert(0, new SelectListItem { Value = "", Text = "-- Select --" });

            ViewBag.Suppliers = selectListItems_1;




            return View(product);
        }






        [HttpPost]
        public async Task<IActionResult> CreateImage(int idproduct, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return NotFound("No file provided.");
            }

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Generate a new filename for the image to prevent overwriting existing files
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                    // Save the image file to the filesystem
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Create new image record
                    var newImage = new Image
                    {
                        NameImages = file.FileName, // Or any other logic to name the image
                        UrlImages = "/img/" + fileName
                    };

                    db.Images.Add(newImage);
                    await db.SaveChangesAsync();

                    // Create a link in ProductImagesDetail table
                    var productImageDetail = new ProductImagesDetail
                    {
                        Idproduct = idproduct,
                        Idimages = newImage.Idimages
                    };

                    db.ProductImagesDetails.Add(productImageDetail);
                    await db.SaveChangesAsync();

                    // Commit the transaction
                    transaction.Commit();

                    // Redirect to the update success page or detail page of the product
                    return RedirectToAction("Update", "Products", new { area = "Admin", id = idproduct });
                }
                catch (Exception ex)
                {
                    // If an error occurs, rollback the transaction and return an error view
                    transaction.Rollback();
                    Console.WriteLine(ex.Message); // Logging the exception
                    return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
            }
        }




        [HttpPost]
        public async Task<IActionResult> Update(int idproduct, int idimage, IFormFile file)
        {
            try
            {
                // Check if the product exists in the database
                var product = await db.Products.FindAsync(idproduct);
                if (product == null)
                {
                    return NotFound("Product not found.");
                }

                // Check if the image exists in the database
                var image = await db.Images.FindAsync(idimage);
                if (image == null)
                {
                    return NotFound("Image not found.");
                }

                // Handle the updating of the image's path for the product
                if (file != null && file.Length > 0)
                {
                    // Generate a new filename for the image to prevent overwriting existing files
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                    // Save the image file to the filesystem
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Update the database record with the new image path
                    image.UrlImages = "/img/" + fileName;  // Update the image URL in the database
                    db.Update(image);
                    await db.SaveChangesAsync();

                    // Redirect to the update success page or detail page of the product
                    return RedirectToAction("Update", "Products", new { area = "Admin", id = idproduct });
                }
                else
                {
                    return NotFound("File not found!");
                }
            }
            catch (Exception ex)
            {
                // Log error and display a user-friendly message
                Console.WriteLine(ex.Message); // Log the error (consider using a more robust logging solution in production)
                return RedirectToAction("UpdateFailed", new { message = ex.Message });
            }
        }







        [HttpPost]
        public async Task<IActionResult> Create(Product model)
        {
      

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Thêm sản phẩm vào cơ sở dữ liệu
                    db.Products.Add(model);
                    await db.SaveChangesAsync();

                    // Commit transaction
                    transaction.Commit();

                    // Redirect đến trang xem chi tiết sản phẩm hoặc trang khác tùy ý
                    return RedirectToAction("View", "Products", new { area = "Admin" });
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi xảy ra, rollback transaction và hiển thị trang lỗi
                    transaction.Rollback();
                    Console.WriteLine(ex.Message); // Logging lỗi
                    return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
            }
        }







        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int idproduct)
        {
            return NotFound(idproduct.ToString());
           
        }










    }
}
