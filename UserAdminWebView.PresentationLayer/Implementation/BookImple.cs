
public class BookImple : IBookService
{
    public readonly UserAdminWebViewContext _context;

    public BookImple(UserAdminWebViewContext context)
    {
        _context = context;
    }
    public void AddOrEditBook(BookDetailsViewModal model)
    {
        BookDetails book = new BookDetails();
        if (model.bookid == 0 || model.bookid == null)
        {
            book.Title = model.bookname;
            book.Author = model.Authorname;
            book.ISBNNo = model.ISBN;
            book.Status = true;
            book.isDeleted = false;
            book.year = model.publishedYear;
            _context.BookDetails.Add(book);
        }
        else
        {
            book = _context.BookDetails.FirstOrDefault(book => book.id == model.bookid);
            book.Title = model.bookname;
            book.Author = model.Authorname;
            book.ISBNNo = model.ISBN;
            book.Status = true;
            book.isDeleted = false;
            book.year = model.publishedYear;
            _context.BookDetails.Update(book);
        }
        _context.SaveChanges();
    }

    public void DeleteBook(int bookid)
    {
        BookDetails bookDetails = _context.BookDetails.FirstOrDefault(book => book.id == bookid);
        bookDetails.isDeleted = true;
        _context.BookDetails.Update(bookDetails);
        _context.SaveChanges();
    }

    public List<BookDetails> getAllBooks(string rolename)
    {
        if (rolename == "Admin")
        {
            return _context.BookDetails.Where(book => book.isDeleted == false).ToList();
        }
        else
        {
            return _context.BookDetails.Where(book => book.isDeleted == false && book.Status == true).ToList();
        }
    }

    public BookDetailsViewModal getBookDetails(int? bookid, BookDetailsViewModal model)
    {
        BookDetails book = _context.BookDetails.FirstOrDefault(book => book.id == bookid);
        model.bookid = book.id;
        model.bookname = book.Title;
        model.bookstatus = book.Status;
        model.Authorname = book.Author;
        model.ISBN = book.ISBNNo;
        model.publishedYear = book.year;
        return model;
    }

    public List<BookDetails> getIssuedBooksByUser(string? email)
    {
        int userid = _context.UserDetails.FirstOrDefault(user => user.email == email).id;
        List<int> bookids = _context.UserBooks.Where(book => book.userid == userid && book.isDeleted == false).Select(book => book.bookid).ToList();
        return _context.BookDetails.Where(book => bookids.Contains(book.id)).ToList();
    }

    public int getUserAssignedBookCount(string email)
    {
        int userid = _context.UserDetails.FirstOrDefault(user => user.email == email).id;
        return _context.UserBooks.Where(book => book.userid == userid && book.isDeleted == false).Count();
    }

    public bool IssueBooks(List<string>? bookids, string email)
    {
        try
        {

            int userid = _context.UserDetails.FirstOrDefault(user => user.email == email).id;
            int userBookCount = _context.UserBooks.Where(userbook => userbook.userid == userid && userbook.isDeleted == false).Count();
            if (userBookCount >= 3)
            {
                return false;
            }
            else
            {
                foreach (var id in bookids)
                {
                    int bookid = int.Parse(id);
                    BookDetails book = _context.BookDetails.FirstOrDefault(book => book.id == bookid);
                    book.Status = false;
                    _context.BookDetails.Update(book);
                    UserBook userBook = new UserBook();
                    if (_context.UserBooks.FirstOrDefault(book => book.bookid == bookid && book.userid == userid) != null)
                    {
                        userBook = _context.UserBooks.FirstOrDefault(book => book.bookid == bookid && book.userid == userid);
                        userBook.isDeleted = false;
                        _context.UserBooks.Update(userBook);
                    }
                    else
                    {
                        userBook.bookid = bookid;
                        userBook.isDeleted = false;
                        userBook.userid = _context.UserDetails.FirstOrDefault(user => user.email == email).id;
                        _context.UserBooks.Add(userBook);
                    }
                    _context.SaveChanges();
                }
                return true;
            }
        }
        catch (Exception e)
        { 
            return false;
        }

    }

    public bool returnBooks(string? email, List<string>? bookids)
    {
        int userid = _context.UserDetails.FirstOrDefault(user => user.email == email).id;
        try
        {
            foreach (var id in bookids)
            {
                UserBook userbook = _context.UserBooks.FirstOrDefault(book => book.userid == userid && book.bookid == int.Parse(id) && book.isDeleted == false);
                userbook.isDeleted = true;
                BookDetails book = _context.BookDetails.FirstOrDefault(book => book.id == int.Parse(id));
                book.Status = true;
                _context.BookDetails.Update(book);
                _context.UserBooks.Update(userbook);
                _context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            return false;
        }
        return true;
    }
}