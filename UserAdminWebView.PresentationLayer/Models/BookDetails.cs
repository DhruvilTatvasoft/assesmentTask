using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

public class BookDetails
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    public string Title { get; set; }
    public string year { get; set; }

    public string ISBNNo { get; set; }

    public bool Status { get; set; }

    public string Author { get; set; }

    [DefaultValue(false)]
    public bool? isDeleted { get; set; }

}