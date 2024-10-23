using Task2.Entities;
using Task2.Interfaces;

namespace Task2.Impelemntations;

public class CrudOperation : ICrudOperation
{
    private readonly IPermissionChecker _permissionChecker;

    public CrudOperation(IPermissionChecker permissionChecker)
    {
        _permissionChecker = permissionChecker;
    }

    public void PerformOperation(User user, Permission permission)
    {
        if (_permissionChecker.HasPermission(user, permission))
        {
            Console.WriteLine($"{user.Name} выполнил операцию: {permission.Name}");
        }
        else
        {
            Console.WriteLine($"Ошибка: {user.Name} не имеет разрешения на операцию: {permission.Name}");
        }
    }
}
