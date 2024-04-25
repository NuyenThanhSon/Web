using DoAnLTWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnLTWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypeController : Controller
    {
        CsdlwebContext db = new CsdlwebContext();
        public IActionResult Index()
        {
            var productTypeList = db.ProductTypes.ToList();
            return View(productTypeList);
        }


        public IActionResult Create()
        {
            var productTypeList = db.ProductTypes.ToList();
            return View(productTypeList);
        }

        [HttpPost]
        public async Task<IActionResult> Createpost(string nameProductType)
        {
            if (ModelState.IsValid)
            {
                var productType = new ProductType
                {
                    ProductTypeName = nameProductType
                };

                db.ProductTypes.Add(productType);
                await db.SaveChangesAsync();

                return RedirectToAction("Index", "ProductType"); // Chuyển hướng đến action Index trong controller ProductType sau khi tạo thành công
            }

            return View("NotFound"); // Trả về view nếu model không hợp lệ
        }


        public IActionResult Update(int id)
        {
            // Truy vấn dữ liệu của mục cần chỉnh sửa từ cơ sở dữ liệu
            var ProductType = db.ProductTypes.FirstOrDefault(p => p.IdproductType == id);

            // Kiểm tra xem mục cần chỉnh sửa có tồn tại không
            if (ProductType == null)
            {
                // Nếu mục không tồn tại, trả về NotFound()
                return NotFound();
            }
            // Trả về view chứa form để cập nhật thông tin của Supplier
            return View(ProductType);
        }


        [HttpPost]
        public IActionResult Update(int IdproductType, string ProductTypeName)
        {
            try
            {
                // Tìm kiếm ProductType cần cập nhật trong cơ sở dữ liệu
                var productTypeToUpdate = db.ProductTypes.FirstOrDefault(p => p.IdproductType == IdproductType);

                // Kiểm tra xem ProductType có tồn tại không
                if (productTypeToUpdate == null)
                {
                    return NotFound();
                }

                // Cập nhật tên của ProductType
                productTypeToUpdate.ProductTypeName = ProductTypeName;

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();

                // Chuyển hướng người dùng về trang Index hoặc trang chủ
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Xử lý nếu có lỗi xảy ra trong quá trình cập nhật
                ModelState.AddModelError("", $"Error updating product type: {ex.Message}");
                return View();
            }
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Tìm kiếm sản phẩm theo id
            var productType = db.ProductTypes.FirstOrDefault(p => p.IdproductType == id);

            if (productType == null)
            {
                // Trả về NotFound nếu không tìm thấy sản phẩm
                return NotFound(id);
            }

            try
            {
                // Xóa sản phẩm khỏi cơ sở dữ liệu
                db.ProductTypes.Remove(productType);
                db.SaveChanges();

                // Trả về Ok nếu xóa thành công
                return RedirectToAction("Index", "ProductType");
            }
            catch (Exception ex)
            {
                // Xử lý nếu có lỗi xảy ra
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
