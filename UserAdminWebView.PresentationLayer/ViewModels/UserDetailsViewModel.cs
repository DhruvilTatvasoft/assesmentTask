using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserDetailsViewModel
{
    public int id { get; set; }
    [Required(ErrorMessage = "User Name is Required")]
    public string name { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is Required")]
    public string email { get; set; }

    [Required(ErrorMessage = "Password is Required")]
    public string password { get; set; }

    [Required(ErrorMessage = "Phone number is Required")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]

    public string phonenumber { get; set; }
    public string? collegeName { get; set; }
}
//  why it gives me not valid every time