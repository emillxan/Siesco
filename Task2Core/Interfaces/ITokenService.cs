using Task2.DataProvider.Entites;

namespace Task2Core.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}
