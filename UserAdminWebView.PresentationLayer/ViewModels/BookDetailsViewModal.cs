using System.ComponentModel.DataAnnotations;

public class BookDetailsViewModal
{
    public int? bookid { get; set; }
    [Required(ErrorMessage = "Book Title is required")]
    public string bookname { get; set; }

    [Required(ErrorMessage = "Author name is required")]
    public string Authorname { get; set; }

    [Required(ErrorMessage = "ISBN no is required")]
    [RegularExpression(@"^(?=(?:[^0-9]*[0-9]){10}(?:(?:[^0-9]*[0-9]){3})?$)[\\d-]+$", ErrorMessage = "Phone number must be exactly 10 digits.")]
    public string ISBN { get; set; }

    public string publishedYear { get; set; }

    public bool bookstatus { get; set; }

    public List<BookDetails> bookList { get; set; } 
    public string email { get; set; }

    

}