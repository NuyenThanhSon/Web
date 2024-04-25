using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;

namespace DoAnLTWeb.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(string name, string email, string phoneNumber, string message)
        {
            try
            {
                // Địa chỉ email và mật khẩu của bạn
                string fromAddress = "khanhchii741@gmail.com";
                string password = "hvda lwnj caiq yemu";

                // Địa chỉ email của bạn (nơi bạn muốn nhận thông tin từ form)
                string toAddress = "khanhchii741@gmail.com";

                // Tiêu đề email
                string subject = "Thông tin liên hệ từ " + name;

                // Nội dung email
                string body = $"Tên: {name}\nEmail: {email}\nSố điện thoại: {phoneNumber}\n\n{message}";

                // Tạo message
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("HyperZShop", fromAddress));
                emailMessage.To.Add(new MailboxAddress("", toAddress));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart("plain")
                {
                    Text = body
                };

                // Cấu hình SMTP client
                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true; // Cho phép kết nối SSL/TLS mà không cần kiểm tra chứng chỉ
                    client.Connect("smtp.gmail.com", 587, false); // Thay thế "smtp.example.com" bằng địa chỉ SMTP server của bạn
                    client.Authenticate(fromAddress, password);

                    // Gửi email
                    client.Send(emailMessage);
                    client.Disconnect(true);
                }

                // Trả về kết quả thành công
                ViewBag.SuccessMessage = "Email đã được gửi đi thành công!";
            }
            catch (Exception ex)
            {
                // Nếu có lỗi xảy ra, hiển thị thông báo lỗi
                ViewBag.ErrorMessage = "Có lỗi xảy ra khi gửi email. Vui lòng thử lại sau.";
            }

            // Chuyển hướng người dùng về trang liên hệ
            return RedirectToAction("Index");
        }
    }
}
