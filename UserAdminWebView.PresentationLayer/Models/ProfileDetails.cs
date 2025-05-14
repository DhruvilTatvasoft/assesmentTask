using System.ComponentModel.DataAnnotations.Schema;

public class ProfileDetails
{
    public int id{get;set;}
    public string firstname{get;set;}
    public string lastname{get;set;}
    public string email{get;set;}
    public string username{get;set;} 
    public string address{get;set;}
    public DateTime birthDate{get;set;}
    public string phonenumber{get;set;}
    public int age{get;set;}
    public string position{get;set;}
    public string introduction{get;set;}
    public DateTime joinedAt{get;set;}
    public decimal currentSalary{get;set;}

    public virtual Roles role{get;set;}

    [ForeignKey("Roles")]
    public int Roleid{get;set;}


}