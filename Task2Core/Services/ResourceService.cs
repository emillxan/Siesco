using Task2.DataProvider.Entites;
using Task2.DataProvider.Interfaces;
using Task2Core.Interfaces;

namespace Task2Core.Services;

public class ResourceService : IResourceService
{
    private readonly IResourceRepository _resourceRepository;

    public ResourceService(IResourceRepository resourceRepository)
    {
        _resourceRepository = resourceRepository;
    }

    public async Task<IEnumerable<Resource>> GetAllResourcesAsync()
    {
        return await _resourceRepository.GetAllAsync();
    }

    public async Task<Resource> GetResourceByIdAsync(int id)
    {
        return await _resourceRepository.GetByIdAsync(id);
    }

    public async Task CreateResourceAsync(Resource resource)
    {
        await _resourceRepository.AddAsync(resource);
    }

    public async Task UpdateResourceAsync(Resource resource)
    {
        await _resourceRepository.UpdateAsync(resource);
    }

    public async Task DeleteResourceAsync(int id)
    {
        await _resourceRepository.DeleteAsync(id);
    }
}
