using System.ComponentModel.DataAnnotations.Schema;

public class UserBook
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [ForeignKey("UserDetails")]
    public int userid { get; set; }

    [ForeignKey("BookDetails")]
    public int bookid { get; set; }
    public DateTime issuedTime { get; set; }
    public bool? isDeleted { get; set; }
}