using System.ComponentModel.DataAnnotations.Schema;
using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models.Entities;

public abstract class Person
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Phone { get; private set; }
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