using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
    public readonly ILogin _loginService;
    public readonly IJwtTokenGenService _jwtTokenGenService;
    public readonly ICookieService _cookieService;
    public LoginController(ILogin loginService,IJwtTokenGenService jwtTokenGenService,ICookieService cookieService){
        _loginService = loginService;
        _jwtTokenGenService = jwtTokenGenService;
        _cookieService = cookieService;
    }
    [HttpGet]
    public IActionResult Index(){
        return View("index");
    }
    [HttpPost]
    public IActionResult LoginTheUser(LoginDetailsModel model){
        Console.WriteLine("Ok");
        if(_loginService.checkUserInDb(model)){
            model =  _loginService.findUserRole(model);
            string token = _jwtTokenGenService.GenerateJwtToken(model);
            _cookieService.setInCookie(token,HttpContext.Response,"token",true);
             var principal = _jwtTokenGenService.ValidateToken(token);
             if (principal != null)
            {
                var role = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (role == "Admin")
                {
                      TempData["ToastrMessage"] = "Login successfully";
                      TempData["ToastrType"] = "success";
                    return RedirectToAction("showDashBoard","Dashboard",new{userRole = "Admin",email = model.email});
                }
                else
                {
                    TempData["ToastrMessage"] = "Login successfully";
                      TempData["ToastrType"] = "success";
                    return RedirectToAction("showDashBoard","Dashboard",new{userRole = "User",email = model.email});
                }
            }
            else{
                return RedirectToAction("index");
            }

        }
        else{
         TempData["ToastrMessage"] = "Invalid credentials";
        TempData["ToastrType"] = "error";
            return View("index");
        }
    }

    public IActionResult Logout(){
         HttpContext.Response.Cookies.Delete("token");
         TempData["ToastrMessage"] = "Logout successfully";
        TempData["ToastrType"] = "success";
         return RedirectToAction("index");
    }
}