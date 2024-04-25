using DoAnLTWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DoAnLTWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        CsdlwebContext db = new CsdlwebContext();

        public async Task<IActionResult> Index(int? page)
        {
            var pageSize = 2; // Số lượng sản phẩm mỗi trang
            var pageNumber = page ?? 1; // Trang mặc định là trang 1 nếu không có giá trị page

            var users = db.Users.Where(p => p.Check == 1 || p.Check == 5).ToList();

            var pagedUsers = users.ToPagedList(pageNumber, pageSize);

            // Tạo một danh sách chứa thông tin nhân viên để sử dụng trong view
            var customer = db.Customers.ToList();

            // Gán danh sách nhân viên vào ViewBag để sử dụng trong view
            ViewBag.customer = customer;

            return View(pagedUsers);
        }

        // 2 dc truy cap
        // 4 ko đc truy cap


        [HttpPost]
        public async Task<IActionResult> Update(string username, int status)
        {
            // Loại bỏ khoảng trắng từ username trước khi sử dụng
            var trimmedUsername = username.Trim();

            // Bắt đầu một transaction
            using (var transaction = await db.Database.BeginTransactionAsync())
            {
                try
                {
                    // Lấy thông tin người dùng từ database bằng username đã được loại bỏ khoảng trắng
                    var user = await db.Users.FirstOrDefaultAsync(u => u.Username == trimmedUsername);
                    if (user == null)
                    {
                        return NotFound();
                    }

                    // Cập nhật trạng thái của người dùng
                    user.Check = status;
                    // Lưu thay đổi vào database
                    db.Users.Update(user);
                    await db.SaveChangesAsync();

                    // Hoàn thành transaction
                    await transaction.CommitAsync();

                    // Chuyển hướng về trang Index
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    // Nếu có lỗi xảy ra, hủy bỏ transaction và xử lý lỗi
                    await transaction.RollbackAsync();
                    throw; // hoặc xử lý lỗi tại đây
                }
            }
        }


    }
}
