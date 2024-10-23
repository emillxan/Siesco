using Task2.Interfaces;

namespace Task2.Entities;

public class User
{
    public string Name { get; }
    public IRole Role { get; }

    public User(string name, IRole role)
    {
        Name = name;
        Role = role;
    }
}
