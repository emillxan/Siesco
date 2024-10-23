using Task2.Entities;

namespace Task2.Interfaces;

public interface IRole
{
    string Name { get; }
    HashSet<Permission> Permissions { get; }
}
