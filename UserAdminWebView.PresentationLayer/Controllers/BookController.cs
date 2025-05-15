using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

public class BookController : Controller
{
    private readonly IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    public IActionResult DeleteBook(int bookid)
    {
        _bookService.DeleteBook(bookid);
        return Json(new { success = "Book Deleted Successfully" });
    }

    public IActionResult openDeleteModal(int bookid)
    {
        BookDetailsViewModal model = new BookDetailsViewModal();
        model.bookid = bookid;
        return PartialView("_deleteModel", model);
    }

    [HttpPost]
    public IActionResult IssueBooks([FromBody] BookManagementViewModel model)
    {
        bool isAssigned = _bookService.IssueBooks(model.bookids, model.email);
        if (isAssigned == false)
        {
            int assignedBookCount = _bookService.getUserAssignedBookCount(model.email);
            int returnBookCount = model.bookids.Count() + assignedBookCount - 3;
            return Json(new { error = "you need to return " + returnBookCount + " books before issuing new books" });
        }
        else
        {
            return Json(new { success = "Books issued Successfully" });
        }
    }
    [HttpPost]
    public IActionResult getIssuedBooks(string email)
    {
        BookDetailsViewModal Booksmodel = new BookDetailsViewModal();
        List<BookDetails> books = _bookService.getIssuedBooksByUser(email);
        Booksmodel.bookList = books;
        Booksmodel.email = email;
        return PartialView("_issuedBooksModel", Booksmodel);
    }

    [HttpPost]
    public IActionResult AddOrEditBook(BookDetailsViewModal model)
    {
        _bookService.AddOrEditBook(model);
        if (model.bookid == 0 || model.bookid == null)
        {
            return Json(new { success = "Book created successfully" });
        }
        else
        {
            return Json(new { success = "Book updated successfully" });
        }
    }

    public IActionResult ReturnBooks([FromBody] BookManagementViewModel model)
    {
        bool isReturned = _bookService.returnBooks(model.email, model.bookids);
        if (isReturned)
        {
            return Json(new { success = "Books returned successfully" });
        }
        else
        { 
            return Json(new { success = "some error Occurred" });
            
        }
    }  
}
