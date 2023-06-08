using System.ComponentModel.DataAnnotations.Schema;
using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models.Entities;

public abstract class Person
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string? Introduction { get; set; }
    public List<Role> Roles { get; set; }
    protected Person(string name, string email, string password, string phone, string? introduction = null)
    {
        Name = name;
        Email = email;
        Password = password;
        Phone = phone;
        Introduction = introduction;
        Roles = new List<Role>();
    }
}