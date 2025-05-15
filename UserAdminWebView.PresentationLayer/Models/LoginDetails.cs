using System.ComponentModel.DataAnnotations.Schema;

public class LoginDetails
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string email{get;set;}
    public string password{get;set;}


}