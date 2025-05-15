using System.ComponentModel.DataAnnotations.Schema;
public class UserDetails
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string phonenumber { get; set; }
    public virtual Roles role { get; set; }

    [ForeignKey("Roles")]
    public int Roleid { get; set; }
    public string? collegeName { get; set; }
    public DateTime? _createdDate;
    public DateTime? CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = DateTime.Now; }
    }
}