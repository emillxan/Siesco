using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task2.DataProvider.Entites;
using Task2Core.Interfaces;

namespace Task2Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ResourceController : ControllerBase
{
    private readonly IResourceService _resourceService;

    public ResourceController(IResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllResources()
    {
        var resources = await _resourceService.GetAllResourcesAsync();
        return Ok(resources);
    }


    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")] 
    public async Task<IActionResult> GetResourceById(int id)
    {
        var resource = await _resourceService.GetResourceByIdAsync(id);
        if (resource == null)
        {
            return NotFound();
        }
        return Ok(resource);
    }


    [HttpPost]
    [Authorize(Roles = "Admin")] 
    public async Task<IActionResult> CreateResource([FromBody] Resource resource)
    {
        if (resource == null)
        {
            return BadRequest("Resource is null.");
        }

        await _resourceService.CreateResourceAsync(resource);
        return CreatedAtAction(nameof(GetResourceById), new { id = resource.Id }, resource);
    }

    // Обновить существующий ресурс
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")] // Доступ только для администраторов
    public async Task<IActionResult> UpdateResource(int id, [FromBody] Resource resource)
    {
        if (id != resource.Id)
        {
            return BadRequest("Resource ID mismatch.");
        }

        var existingResource = await _resourceService.GetResourceByIdAsync(id);
        if (existingResource == null)
        {
            return NotFound();
        }

        await _resourceService.UpdateResourceAsync(resource);
        return NoContent(); // Возвращает 204 при успешном обновлении
    }

    // Удалить ресурс
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")] // Доступ только для администраторов
    public async Task<IActionResult> DeleteResource(int id)
    {
        var resource = await _resourceService.GetResourceByIdAsync(id);
        if (resource == null)
        {
            return NotFound();
        }

        await _resourceService.DeleteResourceAsync(id);
        return NoContent(); // Возвращает 204 при успешном удалении
    }
}
