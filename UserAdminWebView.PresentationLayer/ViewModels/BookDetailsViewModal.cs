using System.ComponentModel.DataAnnotations;

public class BookDetailsViewModal
{
    public int? bookid { get; set; }
    [Required(ErrorMessage = "Book Title is required")]
    public string bookname { get; set; }

    [Required(ErrorMessage = "Author name is required")]
    public string Authorname { get; set; }

    [Required(ErrorMessage = "ISBN no is required")]
    [MaxLength(13, ErrorMessage = "ISBN must be a maximum of 13 characters.")]
    [MinLength(10, ErrorMessage = "ISBN must be a minimum of 10 characters.")]
    public string ISBN { get; set; }

    [Required(ErrorMessage = "Publish year is required")]
    public string publishedYear { get; set; }

    public bool bookstatus { get; set; }

    public List<BookDetails> bookList { get; set; } 
    public string email { get; set; }

    

}