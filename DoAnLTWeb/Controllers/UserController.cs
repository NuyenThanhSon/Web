using DoAnLTWeb.Models;
using DoAnLTWeb.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static System.Collections.Specialized.BitVector32;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace DoAnLTWeb.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly CsdlwebContext _context;

        private static User _loggedInUser;
        public UserController(IUserRepository userRepository, ICustomerRepository customerRepository, CsdlwebContext context)
        {
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userRepository.FindByUsernameAsync(user.Username);
                if (existingUser != null)
                {
                    ViewBag.ErrorMessage = "Tên đăng nhập đã tồn tại.";
                    return View();
                }

                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                if (user.Check == 3)
                {
                    // Thêm User vào database
                    await _userRepository.AddAsync(user);

                    // Tạo Customer từ User và thêm vào database
                    Customer customer = new Customer
                    {
                        Username = user.Username,
                        // Gán các giá trị mặc định hoặc null cho các trường cần thiết trong Customer
                    };
                    await _customerRepository.AddAsync(customer); // Đảm bảo phương thức AddCustomerAsync trong IUserRepository thêm Customer vào database
                }
                else if (user.Check == 4)
                {
                    // Thêm User vào database
                    await _userRepository.AddAsync(user);
                }
                else
                {
                    ModelState.AddModelError("", "Loại người dùng không hợp lệ.");
                    return View(user);
                }

                return RedirectToAction("Login", "User");
            }

            return View(user);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
            {
                user.Password = user.Password.Trim();
                var existingUser = await _userRepository.FindByUsernameAsync(user.Username);
                if (existingUser != null && BCrypt.Net.BCrypt.Verify(user.Password, existingUser.Password))
                {
                    // Tạo các claim
                    string userCheckValue = "1"; // Giả sử mặc định là "1" cho người dùng thông thường
                 
                    if (existingUser.Check == 1)
                    {
                        userCheckValue = "1"; 
                    }
                    else if (existingUser.Check == 2)
                    {
                        userCheckValue = "2"; 
                    }
                    else if (existingUser.Check == 3)
                    {
                        userCheckValue = "3";
                    }
                    else if (existingUser.Check == 4)
                    {
                        userCheckValue = "1";
                    }
                    else if (existingUser.Check == 5)
                    {
                        userCheckValue = "1";
                    }


                    // Tạo các claim
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, existingUser.Username),
                new Claim("Check", userCheckValue)
            };

                    // Tạo symmetric security key từ chuỗi secret key
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key-here-should-be-at-least-16-characters-long"));

                    // Tạo các thông số cần thiết cho JWT
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.AddHours(1), // Thời gian hết hạn của token
                        SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                    };

                    // Tạo JWT bằng token handler
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    // Lưu JWT vào một cookie
                    Response.Cookies.Append("AuthToken", tokenHandler.WriteToken(token));


                    // cach 2

                    var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    // cach 3

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                    return View();
                }
            }

            // Trả về view với dữ liệu đầu vào để người dùng có thể thử lại
            return View(user);
        }




        public async Task<IActionResult> Logout()
        {
            // Sign out the user from the cookie authentication scheme
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Check if the "AuthToken" cookie exists and delete it
            if (HttpContext.Request.Cookies.ContainsKey("AuthToken"))
            {
                HttpContext.Response.Cookies.Delete("AuthToken");
            }

            // Redirect the user to the Home controller's Index action
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> EditUser()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var loggedInUsername = User.Identity.Name;

            var customer = await _customerRepository.FindByUsernameAsync(loggedInUsername);
            if (customer == null)
            {
                return NotFound();
            }

            // Truy vấn và lấy thông tin đơn hàng từ bảng Invoicedetail dựa trên tên người dùng
            ViewBag.Invoices = _context.Invoices.Where(p => p.Idcustomer == customer.Idcustomer && p.Status == 1).ToList();
            ViewBag.Invoices1 = _context.Invoices.Where(p => p.Idcustomer == customer.Idcustomer && p.Status == 2).ToList();
            ViewBag.Invoices2 = _context.Invoices.Where(p => p.Idcustomer == customer.Idcustomer && p.Status == 3).ToList();
            ViewBag.Invoicedetail = _context.Invoicedetails.ToList();
            ViewBag.Product = _context.Products.ToList();
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(Customer model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            // Bắt đầu một transaction
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var existingCustomer = await _customerRepository.FindByUsernameAsync(User.Identity.Name);

                    if (existingCustomer != null)
                    {
                        existingCustomer.CustomerName = model.CustomerName;
                        existingCustomer.PhoneCustomer = model.PhoneCustomer;
                        existingCustomer.CustomerAddress = model.CustomerAddress;
                        existingCustomer.CitizenIdentificationCode = model.CitizenIdentificationCode;
                        existingCustomer.DateOfBirth = model.DateOfBirth;
                        existingCustomer.Sex = model.Sex;

                        await _customerRepository.UpdateAsync(existingCustomer);

                        // Commit transaction khi mọi thứ diễn ra thành công
                        await transaction.CommitAsync();

                        return RedirectToAction("EditUser", "User");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Không tìm thấy thông tin khách hàng.";
                        return View(model);
                    }
                }
                catch (Exception ex)
                {
                    // Rollback transaction nếu có lỗi xảy ra
                    await transaction.RollbackAsync();

                    ViewBag.ErrorMessage = "Có lỗi xảy ra, vui lòng thử lại.";
                    return View(model);
                }
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword, string confirmNewPassword)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmNewPassword))
            {
                ModelState.AddModelError("", "All fields are required.");
                return View();
            }

            if (newPassword != confirmNewPassword)
            {
                ModelState.AddModelError("", "The new password and confirmation password do not match.");
                return View();
            }

            var user = await _userRepository.FindByUsernameAsync(User.Identity.Name);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found.");
                return View();
            }

            if (!BCrypt.Net.BCrypt.Verify(currentPassword, user.Password))
            {
                ModelState.AddModelError("", "Current password is incorrect.");
                return View();
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _userRepository.UpdateAsync(user);

            return RedirectToAction("Index", "Home", new { Message = "Your password has been changed successfully." });
        }
        [HttpPost]
        public IActionResult Removeproduct(int Idinvoice, int idproduct)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var invoicedetail = _context.Invoicedetails.FirstOrDefault(p => p.Idinvoice == Idinvoice && p.Idproduct == idproduct);
                    var invoice = _context.Invoices.FirstOrDefault(p => p.Idinvoice == Idinvoice);
                    if (invoice.Status == 1)
                    {
                        if (invoicedetail != null)
                        {
                            _context.Invoicedetails.Remove(invoicedetail);
                            _context.SaveChanges(); // Lưu thay đổi trước khi kiểm tra xem hóa đơn có bị xóa hết không

                            // Kiểm tra xem hóa đơn còn sản phẩm không
                            var invoiceDetailsCount = _context.Invoicedetails.Count(p => p.Idinvoice == Idinvoice);
                            if (invoiceDetailsCount == 0)
                            {
                                var deliverynote = _context.DeliveryNotes.FirstOrDefault(p => p.Idinvoice == Idinvoice);
                                if (deliverynote != null)
                                {
                                    _context.DeliveryNotes.Remove(deliverynote);
                                }
                                _context.Invoices.Remove(invoice);
                            }
                            _context.SaveChanges(); // Lưu lại sau khi thực hiện xóa (nếu cần)
                            transaction.Commit(); // Commit transaction
                        }

                        else
                        {
                            // Không tìm thấy chi tiết hóa đơn tương ứng với sản phẩm cần xóa
                            return NotFound();
                        }
                    }
                    else
                    {
                        return RedirectToAction("EditUser", "User");

                    }
                }

                catch (Exception ex)
                {
                    // Xảy ra lỗi, rollback transaction
                    transaction.Rollback();
                    // Xử lý hoặc ghi log về lỗi
                    return StatusCode(500, "Internal server error: " + ex.Message);
                }
            }

            return RedirectToAction("EditUser", "User");
        }

        [HttpPost]
        public IActionResult RemoveInvoice(int Idinvoice)
        {
            var invoice = _context.Invoices.FirstOrDefault(p => p.Idinvoice == Idinvoice);
            if (invoice.Status == 1)
            {
                var invoicedetail = _context.Invoicedetails.Where(p => p.Idinvoice == Idinvoice).ToList();
                var deliverynote = _context.DeliveryNotes.FirstOrDefault(p => p.Idinvoice == Idinvoice);
                _context.DeliveryNotes.Remove(deliverynote);
                foreach (var item in invoicedetail)
                {
                    _context.Invoicedetails.Remove(item);
                }
                _context.SaveChanges();
                _context.Invoices.Remove(invoice);
                _context.SaveChanges();
                return RedirectToAction("EditUser", "User");
            }
            else
            {
                return RedirectToAction("EditUser", "User");

            }
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userRepository.FindByEmailAsync(email);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Email chưa được người dùng đăng ký.";
                return View();
            }
            string newPassword = GenerateRandomPassword(10);
            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _userRepository.UpdateAsync(user);
            try
            {
                // Địa chỉ email và mật khẩu của bạn
                string fromAddress = "khanhchii741@gmail.com";
                string password = "hvda lwnj caiq yemu";

                // Địa chỉ email của bạn (nơi bạn muốn nhận thông tin từ form)
                string toAddress = email;

                string subject = "Đặt lại mật khẩu";
                string body = $"Mật khảu mới của bạn là: {newPassword}";

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
                ViewBag.SuccessMessage = "Đã đặt lại mật khẩu của bạn Vui lòng kiểm tra Email!";
            }
            catch (Exception ex)
            {
                // Nếu có lỗi xảy ra, hiển thị thông báo lỗi
                ViewBag.ErrorMessage = "Có lỗi xảy ra khi gửi email. Vui lòng thử lại sau.";
            }

            // Chuyển hướng người dùng về trang liên hệ
            return View();
        }

        private string GenerateRandomPassword(int length)
        {
            Random _random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }

    }


}


