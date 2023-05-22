namespace BikeServiceAPI.Models;

public abstract class Person
{
    public long Id { get; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Phone { get; private set; }
    public string? Introduction { get; set; }

    protected Person(long id, string name, string email, string password, string phone, string? introduction = null)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        Phone = phone;
        Introduction = introduction;
    }
}