
public interface IBookService
{
    public void AddOrEditBook(BookDetailsViewModal modal);
    void DeleteBook(int bookid);
    List<BookDetails> getAllBooks(string bookname);
    BookDetailsViewModal getBookDetails(int? bookid, BookDetailsViewModal model);
    List<BookDetails> getIssuedBooksByUser(string? email);
    int getUserAssignedBookCount(string email);
    bool IssueBooks(List<string>? bookids,string email);
    bool returnBooks(string? email, List<string>? bookids);
}