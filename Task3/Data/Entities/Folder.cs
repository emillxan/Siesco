namespace Task3.Data.Entities;

public class Folder
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; } 

    public virtual Folder? Parent { get; set; } 
    public virtual ICollection<Folder> ChildrenFolders { get; set; } 
    public virtual ICollection<File> Files { get; set; } 
}

