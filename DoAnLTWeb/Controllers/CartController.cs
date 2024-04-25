using DoAnLTWeb.Models;
using DoAnLTWeb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DoAnLTWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly CsdlwebContext _context;
        private const string CartSession = "CartSession";
        public CartController(ICartRepository cartRepository, IProductRepository productRepository, CsdlwebContext context)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _context = context;
        }


        public async Task<IActionResult> Cart()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var cart = HttpContext.Session.GetString(CartSession);
            var cartItems = new List<CartItem>();
            if (!string.IsNullOrEmpty(cart))
            {
                cartItems = JsonConvert.DeserializeObject<List<CartItem>>(cart);
            }


            ViewBag.GetTotalQuantityInCart = GetTotalQuantityInCart();
            return View(cartItems);
        }


        [HttpGet]
        public async Task<IActionResult> Payment(string name)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var cart = HttpContext.Session.GetString(CartSession);
            var cartItems = new List<CartItem>();
            if (!string.IsNullOrEmpty(cart))
            {
                cartItems = JsonConvert.DeserializeObject<List<CartItem>>(cart);
            }

            return View(cartItems);
        }
        [HttpPost]
        public async Task<IActionResult> Payment(string phoneNumber, string address)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            string username = User.Identity.Name;
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Username == username);
            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            var invoice = new Invoice
            {
                Idcustomer = customer.Idcustomer,
                DateCreated = DateOnly.FromDateTime(DateTime.Now),
                Status = 1,
            };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            var cartItems = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Session.GetString(CartSession));
            foreach (var item in cartItems)
            {
                var detail = new Invoicedetail
                {
                    Idproduct = item.Product.Idproduct,
                    Idinvoice = invoice.Idinvoice,
                    TotalQuantity = item.Quantity,
                    Price = item.Product.Price
                };
                _context.Invoicedetails.Add(detail);
            }

            var deliveryNote = new DeliveryNote
            {
                Idinvoice = invoice.Idinvoice,
                DateCreated = DateOnly.FromDateTime(DateTime.Now),
                DeliveryAddress = address,
                RecipientPhone = phoneNumber,
                Status = 1,
            };

            _context.DeliveryNotes.Add(deliveryNote);
            await _context.SaveChangesAsync();

            HttpContext.Session.Remove(CartSession);

            return RedirectToAction("Success", "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("Login");
            }
            var temp = new CartItem();
            var product = _context.Products.Find(productId);
            var cart = HttpContext.Session.GetString(CartSession);
            if (!string.IsNullOrEmpty(cart))
            {
                var list = JsonConvert.DeserializeObject<List<CartItem>>(cart);
                if (list.Exists(x => x.Product.Idproduct == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.Idproduct == productId)
                        {

                            item.Quantity += quantity;
                            temp = item;
                            break;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    temp = item;

                    list.Add(item);
                }
                HttpContext.Session.SetString(CartSession, JsonConvert.SerializeObject(list));
                var warehousedetail = _context.Warehousedetails.FirstOrDefault(x => x.Idproduct == temp.Product.Idproduct);
                warehousedetail.QuantityInStock -= quantity;
                _context.Warehousedetails.Update(warehousedetail);
                _context.SaveChanges();
            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;

                var list = new List<CartItem>();
                list.Add(item);

                HttpContext.Session.SetString(CartSession, JsonConvert.SerializeObject(list));
                var warehousedetail = _context.Warehousedetails.FirstOrDefault(x => x.Idproduct == item.Product.Idproduct);
                warehousedetail.QuantityInStock -= quantity;
                _context.Warehousedetails.Update(warehousedetail);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCart(string cartModel)
        {
            var jsonCart = JsonConvert.DeserializeObject<List<CartItem>>(cartModel);

            var sessionCart = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Session.GetString(CartSession));

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.Idproduct == item.Product.Idproduct);

                if (jsonItem != null)
                {
                    var warehousedetail = _context.Warehousedetails.FirstOrDefault(x => x.Idproduct == item.Product.Idproduct);
                    warehousedetail.QuantityInStock = warehousedetail.QuantityInStock + item.Quantity - jsonItem.Quantity;
                    _context.Warehousedetails.Update(warehousedetail);
                    _context.SaveChanges();
                    item.Quantity = jsonItem.Quantity;
                    break;
                }
            }

            HttpContext.Session.SetString(CartSession, JsonConvert.SerializeObject(sessionCart));

            return Json(new
            {
                status = true
            });
        }

        private void UpdateWarehouseDetail(int productId, int quantityChange)
        {
            var warehouseDetail = _context.Warehousedetails.FirstOrDefault(x => x.Idproduct == productId);
            if (warehouseDetail != null)
            {
                warehouseDetail.QuantityInStock += quantityChange;
                _context.Warehousedetails.Update(warehouseDetail);
                _context.SaveChanges();
            }
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var sessionCart = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Session.GetString(CartSession));
            var removedItem = sessionCart.FirstOrDefault(x => x.Product.Idproduct == id);
            if (removedItem != null)
            {
                UpdateWarehouseDetail(removedItem.Product.Idproduct, removedItem.Quantity); // Cập nhật lại số lượng trong bảng Warehousedetail
                sessionCart.RemoveAll(x => x.Product.Idproduct == id);
                HttpContext.Session.SetString(CartSession, JsonConvert.SerializeObject(sessionCart));
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    message = "Product not found in cart."
                });
            }
        }

        public async Task<IActionResult> Success()
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Trả về lỗi nếu người dùng chưa đăng nhập
                return Unauthorized();
            }

            return View();
        }

        private int GetTotalQuantityInCart()
        {
            var cartItems = HttpContext.Session.GetString(CartSession);
            if (!string.IsNullOrEmpty(cartItems))
            {
                var items = JsonConvert.DeserializeObject<List<CartItem>>(cartItems);
                if (items != null)
                {
                    return items.Count;
                }
            }

            return 0;
        }









    }
}