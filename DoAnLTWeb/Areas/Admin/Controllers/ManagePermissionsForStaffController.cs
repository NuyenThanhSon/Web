using DoAnLTWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DoAnLTWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManagePermissionsForStaffController : Controller
    {
        private readonly CsdlwebContext _context; // Sử dụng đối tượng WebContext

        public ManagePermissionsForStaffController(CsdlwebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var staff = await _context.Staff.Where(p => p.IdstaffType != 1).ToListAsync();
            var pageNumber = page ?? 1; // Trang mặc định là trang 1 nếu không có giá trị page
            var pageSize = 2; // Số lượng sản phẩm mỗi trang
            var pagedstaff = staff.ToPagedList(pageNumber, pageSize);
            return View(pagedstaff);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateForm(int id, [Bind("Idstaff, StaffName, StaffAddress, PhoneStaff, CitizenIdentificationCode, IdstaffType, DateOfBirth, Sex")] Staff staff)
        {
            if (id != staff.Idstaff)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        // Tìm nhân viên trong cơ sở dữ liệu
                        var existingStaff = await _context.Staff.FindAsync(id);
                        if (existingStaff == null)
                        {
                            return NotFound();
                        }

                        // Cập nhật thông tin nhân viên từ dữ liệu gửi lên
                        existingStaff.StaffName = staff.StaffName;
                        existingStaff.StaffAddress = staff.StaffAddress;
                        existingStaff.PhoneStaff = staff.PhoneStaff;
                        existingStaff.CitizenIdentificationCode = staff.CitizenIdentificationCode;
                        existingStaff.IdstaffType = staff.IdstaffType;
                        existingStaff.DateOfBirth = staff.DateOfBirth;
                        existingStaff.Sex = staff.Sex;

                        // Lưu thay đổi vào cơ sở dữ liệu
                        _context.Staff.Update(existingStaff);
                        await _context.SaveChangesAsync();

                        // Commit transaction
                        await transaction.CommitAsync();

                        return RedirectToAction("Index", "ManagePermissionsForStaff"
                            , new { area = "Admin", id = existingStaff.Idstaff });
                    }
                    catch (Exception)
                    {
                        // Nếu có lỗi, rollback transaction
                        await transaction.RollbackAsync();
                        throw; // Bạn có thể xử lý hoặc ghi log lỗi ở đây
                    }
                }
            }

            // Nếu ModelState không hợp lệ, hiển thị lại form với thông tin đã nhập và thông báo lỗi
            return View(staff);
        }


        // Xử lý cập nhật nhân viên
        [HttpGet]
        public async Task<IActionResult> Update(int id, [Bind("Idstaff,StaffName,Username,StaffAddress,PhoneStaff,CitizenIdentificationCode,IdstaffType,DateOfBirth,Sex,IdImages,OtherProperties")] Staff staff)
        {
            var existingStaff = await _context.Staff.FindAsync(id);
            if (existingStaff == null)
            {
                return NotFound();
            }


            // Gán dữ liệu từ existingStaff vào staff để hiển thị trên view
            staff.Idstaff = existingStaff.Idstaff;
            staff.StaffName = existingStaff.StaffName;
            staff.Username = existingStaff.Username;
            staff.StaffAddress = existingStaff.StaffAddress;
            staff.PhoneStaff = existingStaff.PhoneStaff;
            staff.CitizenIdentificationCode = existingStaff.CitizenIdentificationCode;
            staff.IdstaffType = existingStaff.IdstaffType;
            staff.DateOfBirth = existingStaff.DateOfBirth;
            staff.Sex = existingStaff.Sex;
            staff.IdImages = existingStaff.IdImages;



            // Lấy danh sách các loại nhân viên từ cơ sở dữ liệu
            var staffTypes = await _context.StaffTypes.ToListAsync();

            // Đưa danh sách staffTypes vào ViewBag để sử dụng trong view
            ViewBag.StaffTypes = new SelectList(staffTypes, "IdstaffType", "StaffTypeName", existingStaff.IdstaffType);



            return View(existingStaff);

        }





    }
}
