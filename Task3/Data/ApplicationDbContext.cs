using Microsoft.EntityFrameworkCore;
using Task3.Data.Entities;

namespace Task3.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Entities.File> Files { get; set; }
    public DbSet<Folder> Folders { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Folder>()
            .HasOne(f => f.Parent)
            .WithMany(f => f.ChildrenFolders)
            .HasForeignKey(f => f.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Entities.File>()
            .HasOne(f => f.Folder)
            .WithMany(f => f.Files)
            .HasForeignKey(f => f.FolderId)
            .OnDelete(DeleteBehavior.Cascade); 


        modelBuilder.Entity<Folder>().HasData(
            new Folder { Id = 1, Name = "Root", ParentId = null },
            new Folder { Id = 2, Name = "Documents", ParentId = 1 },
            new Folder { Id = 3, Name = "Music", ParentId = 1 },
            new Folder { Id = 4, Name = "Pictures", ParentId = 1 },
            new Folder { Id = 5, Name = "Work", ParentId = 2 },
            new Folder { Id = 6, Name = "Personal", ParentId = 2 },
            new Folder { Id = 7, Name = "Projects", ParentId = 5 },
            new Folder { Id = 8, Name = "Old Music", ParentId = 3 },
            new Folder { Id = 9, Name = "Vacation", ParentId = 4 }
        );

        modelBuilder.Entity<Entities.File>().HasData(
            new Entities.File { Id = 1, FileName = "resume.docx"  , FolderId = 1 },
            new Entities.File { Id = 2, FileName = "budget.xlsx"  , FolderId = 1 },
            new Entities.File { Id = 3, FileName = "song.mp3"     , FolderId = 1 },
            new Entities.File { Id = 4, FileName = "cover.jpg"    , FolderId = 1 },
            new Entities.File { Id = 5, FileName = "project1.docx", FolderId = 2 },
            new Entities.File { Id = 6, FileName = "project2.docx", FolderId = 2 },
            new Entities.File { Id = 7, FileName = "vacation1.jpg", FolderId = 5 },
            new Entities.File { Id = 8, FileName = "vacation2.jpg", FolderId = 3 },
            new Entities.File { Id = 9, FileName = "old_song.mp3" , FolderId = 4 }
        );

        base.OnModelCreating(modelBuilder);

    }
}
