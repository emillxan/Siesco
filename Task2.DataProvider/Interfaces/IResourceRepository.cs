using Task2.DataProvider.Entites;

namespace Task2.DataProvider.Interfaces;

public interface IResourceRepository
{
    Task<Resource> GetByIdAsync(int id); 
    Task<IEnumerable<Resource>> GetAllAsync(); 
    Task AddAsync(Resource resource); 
    Task UpdateAsync(Resource resource); 
    Task DeleteAsync(int id);
}
