using Task2.Entities;
using Task2.Interfaces;

namespace Task2.Impelemntations;

public class PermissionChecker : IPermissionChecker
{
    public bool HasPermission(User user, Permission permission)
    {
        return user.Role.Permissions.Contains(permission);
    }
}
