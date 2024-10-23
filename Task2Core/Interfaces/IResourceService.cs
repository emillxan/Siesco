using Task2.DataProvider.Entites;

namespace Task2Core.Interfaces;

public interface IResourceService
{
    Task<IEnumerable<Resource>> GetAllResourcesAsync();
    Task<Resource> GetResourceByIdAsync(int id);
    Task CreateResourceAsync(Resource resource);
    Task UpdateResourceAsync(Resource resource);
    Task DeleteResourceAsync(int id);
}
