using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FolderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 1, "Root", null });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "FileName", "FolderId" },
                values: new object[,]
                {
                    { 1, "resume.docx", 1 },
                    { 2, "budget.xlsx", 1 },
                    { 3, "song.mp3", 1 },
                    { 4, "cover.jpg", 1 }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 2, "Documents", 1 },
                    { 3, "Music", 1 },
                    { 4, "Pictures", 1 }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "FileName", "FolderId" },
                values: new object[,]
                {
                    { 5, "project1.docx", 2 },
                    { 6, "project2.docx", 2 },
                    { 8, "vacation2.jpg", 3 },
                    { 9, "old_song.mp3", 4 }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 5, "Work", 2 },
                    { 6, "Personal", 2 },
                    { 8, "Old Music", 3 },
                    { 9, "Vacation", 4 }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "FileName", "FolderId" },
                values: new object[] { 7, "vacation1.jpg", 5 });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 7, "Projects", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Files_FolderId",
                table: "Files",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ParentId",
                table: "Folders",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Folders");
        }
    }
}
