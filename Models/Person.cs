using System.ComponentModel.DataAnnotations.Schema;

namespace BikeServiceAPI.Models;

public abstract class Person
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public string Phone { get; private set; } = null!;
    public string? Introduction { get; set; }

    // protected Person(long id, string name, string email, string password, string phone, string? introduction = null)
    // {
    //     Id = id;
    //     Name = name;
    //     Email = email;
    //     Password = password;
    //     Phone = phone;
    //     Introduction = introduction;
    // }
}