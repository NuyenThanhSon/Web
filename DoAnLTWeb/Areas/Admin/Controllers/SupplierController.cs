using DoAnLTWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnLTWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplierController : Controller
    {
        CsdlwebContext db = new CsdlwebContext();
        public IActionResult Index()
        {
            var SuppliersList = db.Suppliers.ToList();
            return View(SuppliersList);
        }


        public IActionResult Create()
        {
            var SuppliersList = db.Suppliers.ToList();
            return View(SuppliersList);
        }





        [HttpPost]
        public async Task<IActionResult> Createpost(string SupplierName, string PhoneSupplier, string SupplierAddress, string EmailSupplier)
        {
            if (ModelState.IsValid)
            {
                var supplier = new Supplier
                {
                    SupplierName = SupplierName,
                    PhoneSupplier = PhoneSupplier,
                    SupplierAddress = SupplierAddress,
                    EmailSupplier = EmailSupplier
                };

                db.Suppliers.Add(supplier);
                await db.SaveChangesAsync();

                return RedirectToAction("Index", "Supplier"); // Chuyển hướng đến action Index trong controller Supplier sau khi tạo thành công
            }

            return View("NotFound"); // Trả về view nếu model không hợp lệ
        }




        [HttpPost]
        public async Task<IActionResult> Update(Supplier model)
        {
            if (ModelState.IsValid)
            {
                // Tìm Supplier cần cập nhật trong cơ sở dữ liệu
                var supplierToUpdate = await db.Suppliers.FirstOrDefaultAsync(p => p.Idsupplier == model.Idsupplier);

                if (supplierToUpdate != null)
                {
                    // Cập nhật thông tin của Supplier
                    supplierToUpdate.SupplierName = model.SupplierName;
                    supplierToUpdate.PhoneSupplier = model.PhoneSupplier;
                    supplierToUpdate.SupplierAddress = model.SupplierAddress;
                    supplierToUpdate.EmailSupplier = model.EmailSupplier;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    await db.SaveChangesAsync();

                    // Chuyển hướng người dùng đến action Index của controller Supplier sau khi cập nhật thành công
                    return RedirectToAction("Index", "Supplier");
                }
                else
                {
                    // Trả về NotFound nếu không tìm thấy Supplier cần cập nhật
                    return NotFound();
                }
            }

            // Trả về view chứa form với dữ liệu người dùng đã nhập nếu ModelState không hợp lệ
            return View(model);
        }







        public IActionResult Update(int id)
        {
            // Truy vấn dữ liệu của mục cần chỉnh sửa từ cơ sở dữ liệu
            var SuppliersList = db.Suppliers.FirstOrDefault(p => p.Idsupplier == id);

            // Kiểm tra xem mục cần chỉnh sửa có tồn tại không
            if (SuppliersList == null)
            {
                // Xử lý nếu mục không tồn tại, ví dụ: trả về NotFound()
                return NotFound(id);
            }

            // Truyền dữ liệu của mục cần chỉnh sửa qua view
            return View(SuppliersList);
        }







        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            // Truy vấn Supplier cần xóa từ cơ sở dữ liệu
            var supplierToDelete = await db.Suppliers.FindAsync(id);

            // Kiểm tra xem Supplier có tồn tại không
            if (supplierToDelete == null)
            {
                // Nếu không tìm thấy Supplier, trả về NotFound()
                return NotFound();
            }

            try
            {
                // Xóa Supplier từ cơ sở dữ liệu
                db.Suppliers.Remove(supplierToDelete);
                await db.SaveChangesAsync();
                // Chuyển hướng người dùng đến action Index của controller Supplier sau khi xóa thành công
                return RedirectToAction("Index", "Supplier");
            }
            catch (Exception)
            {
                // Xử lý lỗi nếu có
                // Ví dụ: Trả về một view thông báo lỗi
                return View("Error");
            }
        }









    }
}
