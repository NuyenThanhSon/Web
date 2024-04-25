using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DoAnLTWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Retrieve the authentication token from cookies
            var authToken = Request.Cookies["AuthToken"];
            if (string.IsNullOrEmpty(authToken))
            {
                return RedirectToAction("Login", "User", new { area = "" });
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key-here-should-be-at-least-16-characters-long")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };

                // Validate the token and extract the principal
                var principal = tokenHandler.ValidateToken(authToken, validationParameters, out SecurityToken validatedToken);

                // Check for token expiration
                if (validatedToken.ValidTo < DateTime.UtcNow)
                {
                    // If the token has expired, redirect to the login page
                    return RedirectToAction("Login", "User", new { area = "" });
                }

                // Check the 'Check' claim to determine user access
                var checkClaim = principal.FindFirst("Check")?.Value;
                if (string.IsNullOrEmpty(checkClaim))
                {
                    // If the 'Check' claim is missing, deny permission
                    return RedirectToAction("PermissionDenied", "HandleError");
                }

                // Attempt to parse the 'Check' claim
                if (int.TryParse(checkClaim, out int userCheck))
                {
                    if (userCheck == 1)
                    {
                        
                        // If userCheck is 1, permission is denied
                        return RedirectToAction("PermissionDenied", "HandleError");
                    }
                    else if (userCheck == 2 || userCheck == 4)
                    {
                        // If userCheck is 2 or 4, grant access to the Admin page
                        return View();
                    }
                }

                // If the 'Check' claim is not an integer or an unexpected value, deny access
                return RedirectToAction("PermissionDenied", "HandleError");
            }
            catch (Exception ex)
            {
                // Log the exception here as needed
                // Redirect to a generic error handling page
                return RedirectToAction("PermissionDenied", "HandleError");
            }

            // As a fallback, handle any other unhandled cases
            return NotFound("Resource not found");
        }
    }
}
