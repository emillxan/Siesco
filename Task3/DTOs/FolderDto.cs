namespace Task3.DTOs;

public class FolderDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<FolderDto> ChildrenFolders { get; set; } = new List<FolderDto>();
    public List<FileDto> Files { get; set; } = new List<FileDto>();
}
