using Microsoft.EntityFrameworkCore;
using Task2.DataProvider.Context;
using Task2.DataProvider.Entites;
using Task2.DataProvider.Interfaces;

namespace Task2.DataProvider.Repositories;

public class ResourceRepository : IResourceRepository
{
    private readonly ApplicationContext _context;

    public ResourceRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Resource> GetByIdAsync(int id)
    {
        return await _context.Resources.FindAsync(id);
    }

    public async Task<IEnumerable<Resource>> GetAllAsync()
    {
        return await _context.Resources.ToListAsync();
    }

    public async Task AddAsync(Resource resource)
    {
        await _context.Resources.AddAsync(resource);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Resource resource)
    {
        _context.Resources.Update(resource);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var resource = await _context.Resources.FindAsync(id);
        if (resource != null)
        {
            _context.Resources.Remove(resource);
            await _context.SaveChangesAsync();
        }
    }
}
