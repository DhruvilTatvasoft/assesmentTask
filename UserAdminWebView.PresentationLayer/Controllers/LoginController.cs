using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
    public readonly ILogin _loginService;
    public readonly IJwtTokenGenService _jwtTokenGenService;
    public readonly ICookieService _cookieService;
    public readonly IUserDetailsService _userDetailsService;
    public LoginController(ILogin loginService, IJwtTokenGenService jwtTokenGenService, ICookieService cookieService)
    {
        _loginService = loginService;
        _jwtTokenGenService = jwtTokenGenService;
        _cookieService = cookieService;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View("index");
    }
    [HttpPost]
    public IActionResult LoginTheUser(LoginDetailsModel model)
    {
        Console.WriteLine("Ok");
        if (_loginService.checkUserInDb(model))
        {
            model = _loginService.findUserRole(model);
            string token = _jwtTokenGenService.GenerateJwtToken(model);
            _cookieService.setInCookie(token, HttpContext.Response, "token", true);
            var principal = _jwtTokenGenService.ValidateToken(token);
            if (principal != null)
            {
                var role = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (role == "Admin")
                {
                    TempData["ToastrMessage"] = "Login successfully";
                    TempData["ToastrType"] = "success";
                    // return RedirectToAction("showDashBoard", "Dashboard", new { userRole = "Admin", email = model.email });
                    return RedirectToAction("showBookManagementDashboard", "Dashboard", new { userRole = "Admin", email = model.email });
                }
                else
                {
                    TempData["ToastrMessage"] = "Login successfully";
                    TempData["ToastrType"] = "success";
                    // return RedirectToAction("showDashBoard", "Dashboard", new { userRole = "User", email = model.email });
                    return RedirectToAction("showBookManagementDashboard", "Dashboard", new { userRole = "User", email = model.email });
                }
            }
            else
            {
                return RedirectToAction("index");
                
            }

        }
        else
        {
            if (_loginService.checkPassword(model))
            {
                TempData["ToastrMessage"] = "Register first";
                TempData["ToastrType"] = "error";
                UserDetailsViewModel model1 = new UserDetailsViewModel();
                return View("registerUser", model1);
            }
            else
            {
                TempData["ToastrMessage"] = "invalid password";
                TempData["ToastrType"] = "error";
                return RedirectToAction("index",model);
                
            }
        }
    }

    public IActionResult RedirectToRegister()
    {
        UserDetailsViewModel model = new UserDetailsViewModel();
        return View("registerUser", model);
    }
    public IActionResult Logout()
    {
        HttpContext.Response.Cookies.Delete("token");
        TempData["ToastrMessage"] = "Logout successfully";
        TempData["ToastrType"] = "success";
        return RedirectToAction("index");
    }

    public IActionResult CreateNewUser(UserDetailsViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("registerUser", model);
        }
        else
        {
            if (_loginService.createNewUser(model))
            {
                TempData["ToastrMessage"] = "Register successfully";
                TempData["ToastrType"] = "success";
                return View("index", model);
            }
            else
            {
                TempData["ToastrMessage"] = "User Already Exist with this Email";
                TempData["ToastrType"] = "error";
                return View("registerUser", model);
            }
        }

    }
    public IActionResult getUserDetails(string email)
    {
        ProfileDetailsViewModel modal = new ProfileDetailsViewModel();
        var user = _userDetailsService.getUserDetails(email);
        modal.userDetail = user;
        return PartialView("_userDetailsModal", modal);
    }
}