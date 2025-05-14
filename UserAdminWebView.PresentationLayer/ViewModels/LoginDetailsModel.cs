using System.ComponentModel.DataAnnotations;

public class LoginDetailsModel
{
    [Required]
    [EmailAddress]
    public string email{get;set;}
    [Required]
    public string password{get;set;}
    public Roles? role{get;set;}
}