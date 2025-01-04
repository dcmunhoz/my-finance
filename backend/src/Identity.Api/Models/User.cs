namespace Identity.Api.Models;

public class User
{
    public User(string username, string name, string email)
    {
        Id = Guid.NewGuid();
        Username = username;
        Name = name;
        Email = email;
    }

    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }

}