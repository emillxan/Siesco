namespace Task3.Data.Entities;

public class File
{
    public int Id { get; set; }
    public string FileName { get; set; } 

    public int FolderId { get; set; }
    public virtual Folder Folder { get; set; }
}
