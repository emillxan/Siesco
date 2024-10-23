using Task2.Interfaces;

namespace Task2.Entities;

public class Role : IRole
{
    public string Name { get; }
    public HashSet<Permission> Permissions { get; }

    public Role(string name, HashSet<Permission> permissions)
    {
        Name = name;
        Permissions = permissions;
    }
}
