using Microsoft.AspNetCore.Mvc;

public class DashboardController : Controller
{
    public IUserDetailsService _userDetailsService;
    public IBookService _bookService;

    public DashboardController(IUserDetailsService userDetailsService,IBookService bookService)
    {
        _userDetailsService = userDetailsService;
        _bookService = bookService;
    }
    public IActionResult showDashBoard(string userRole, string email)
    {
        ProfileDetailsViewModel model = new ProfileDetailsViewModel();
        if (userRole == "Admin")
        {
            model.userDetail = _userDetailsService.getUserDetails(email);
            model.allUsers = _userDetailsService.getAllUserDetails();
            model.HighestSalary = _userDetailsService.getHighestSalary();

        }
        else
        {
            model.userDetail = _userDetailsService.getUserDetails(email);
        }
        return View("dashboard", model);
    }

    public IActionResult showBookManagementDashboard(string rolename, string email)
    {
        BookManagementViewModel model = new BookManagementViewModel();
        model.email = email;
        model.rolename = rolename;
        return View("bookManagementDashboard", model);
    }
    public IActionResult getAllBooks(string rolename)
    {
        BookDetailsViewModal model = new BookDetailsViewModal();
        if (rolename == "true")
        {
            rolename = "Admin";
        }
        else
        { 
            rolename = "User";
            
        }
        model.bookList = _bookService.getAllBooks(rolename);
        return PartialView("_booksTable", model);
    }
    public IActionResult openAddNewBookModel(int? bookid)
    {
            BookDetailsViewModal model = new BookDetailsViewModal();
        if (bookid != null && bookid != 0)
        {
            _bookService.getBookDetails(bookid,model);
        }
        return PartialView("_addEditBookModal",model);
    }
}