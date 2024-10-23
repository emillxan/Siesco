using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.DataProvider.Entites;

namespace Task2Core.Interfaces;

public interface IUserService
{
    Task<User> GetUserByIdAsync(int id); 
    Task<IEnumerable<User>> GetAllUsersAsync(); 
    Task<User> GetUserByUsernameAsync(string username); 
    Task CreateUserAsync(User user); 
    Task UpdateUserAsync(User user); 
    Task DeleteUserAsync(int id); // Удалить пользователя по ID
}
