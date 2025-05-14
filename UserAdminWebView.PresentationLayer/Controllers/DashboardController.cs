using Microsoft.AspNetCore.Mvc;

public class DashboardController : Controller
{
    public IUserDetailsService _userDetailsService;

    public DashboardController(IUserDetailsService userDetailsService){
        _userDetailsService = userDetailsService;
    }
    public IActionResult showDashBoard(string userRole,string email){
        ProfileDetailsViewModel model = new ProfileDetailsViewModel();
        if(userRole == "Admin"){
            model.userDetail = _userDetailsService.getUserDetails(email);
            model.allUsers = _userDetailsService.getAllUserDetails();
        }
        else{
            model.userDetail = _userDetailsService.getUserDetails(email);
        }
        return View("dashboard",model);
    }
}