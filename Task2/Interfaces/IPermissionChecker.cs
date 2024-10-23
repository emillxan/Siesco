using Task2.Entities;

namespace Task2.Interfaces;

public interface IPermissionChecker
{
    bool HasPermission(User user, Permission permission);
}
