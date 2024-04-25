using DoAnLTWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnLTWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InvoiceController : Controller
    {
        CsdlwebContext db = new CsdlwebContext();
        public IActionResult Index()
        {
            var listInvoice = db.Invoices.ToList();
            ViewBag.StaffList = db.Staff.Where(x=>x.IdstaffType==4).ToList(); // Lấy danh sách Staff và truyền vào ViewBag
            return View(listInvoice);
        }

        public IActionResult deltail(int id)
        {
            var listInvoice = db.Invoicedetails.Where(x=>x.Idinvoice== id).ToList();
            ViewBag.idinvoice = id;
            var product= db.Products.ToList();
            ViewBag.product = product;
            return View(listInvoice);
        }
        [HttpPost]
        public IActionResult UpdateStatus(int idAdmin, int idInvoice, int selectedStaff )
        {
      
            // Sử dụng dữ liệu idInvoice và selectedStaff tại đây
            // Ví dụ:
            var invoice= db.Invoices.FirstOrDefault(x=>x.Idinvoice==idInvoice);
            if(invoice!=null)
            {
                invoice.Idstaff = idAdmin;
                invoice.Status = 2;
                db.SaveChanges();
            }
            var deliveryNote = db.DeliveryNotes.FirstOrDefault(x=>x.Idinvoice==invoice.Idinvoice);
            if (deliveryNote != null)
            {
                deliveryNote.Idstaff = selectedStaff;
                deliveryNote.Status = 2;
                db.SaveChanges();
            }

            // Thực hiện các thao tác xử lý dữ liệu tại đây

            // Redirect hoặc trả về một phản hồi
            return RedirectToAction("Index"); // Ví dụ: chuyển hướng về action Index
        }



    }
}
