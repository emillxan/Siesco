using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task3.Data; 
using Task3.Data.Entities;
using Task3.DTOs;

namespace Task3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoldersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FoldersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("hierarchy")]
        public async Task<IActionResult> GetFolderHierarchy()
        {
            var rootFolders = await _context.Folders
                .Include(f => f.ChildrenFolders)
                .ThenInclude(f => f.ChildrenFolders) 
                .Include(f => f.Files) 
                .Where(f => f.ParentId == null) 
                .ToListAsync();

            var folderDtos = rootFolders.Select(MapFolderToDto).ToList();

            return Ok(folderDtos);
        }

        [HttpPost("createFolder")]
        public async Task<IActionResult> CreateFolder([FromBody] CreateFolderDto folderDto)
        {
            if (string.IsNullOrEmpty(folderDto.Name))
            {
                return BadRequest("Folder name cannot be empty.");
            }

            var folder = new Folder
            {
                Name = folderDto.Name,
                ParentId = folderDto.ParentId
            };

            _context.Folders.Add(folder);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Folder created successfully.", Folder = folder });
        }

        [HttpPost("createFile")]
        public async Task<IActionResult> CreateFile([FromBody] CreateFileDto fileDto)
        {
            if (string.IsNullOrEmpty(fileDto.FileName))
            {
                return BadRequest("File name cannot be empty.");
            }

            var folder = await _context.Folders.FindAsync(fileDto.FolderId);
            if (folder == null)
            {
                return NotFound("Folder not found.");
            }

            var file = new Data.Entities.File
            {
                FileName = fileDto.FileName,
                FolderId = fileDto.FolderId
            };

            _context.Files.Add(file);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "File created successfully.", File = fileDto });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFolderById(int id)
        {
            var rootFolders = await _context.Folders
                .Include(f => f.ChildrenFolders)
                .ThenInclude(f => f.ChildrenFolders) 
                .Include(f => f.Files) 
                .Where(f => f.ParentId == id) 
                .ToListAsync();

            var folderDtos = rootFolders.Select(MapFolderToDto).ToList();

            return Ok(folderDtos);
        }

        private static FolderDto MapFolderToDto(Folder folder)
        {
            return new FolderDto
            {
                Id = folder.Id,
                Name = folder.Name,
                ChildrenFolders = folder.ChildrenFolders?.Select(MapFolderToDto).ToList() ?? new List<FolderDto>(), // Проверка на null
                Files = folder.Files?.Select(file => new FileDto
                {
                    Id = file.Id,
                    FileName = file.FileName,
                }).ToList() ?? new List<FileDto>() // Проверка на null
            };
        }

    }
}
