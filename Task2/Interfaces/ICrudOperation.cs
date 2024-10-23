using Task2.Entities;

namespace Task2.Interfaces;

public interface ICrudOperation
{
    void PerformOperation(User user, Permission permission);
}
