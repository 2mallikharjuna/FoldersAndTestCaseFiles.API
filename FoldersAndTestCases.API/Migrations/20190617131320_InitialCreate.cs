using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoldersAndTestCaseFiles.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FoldersAndTestCaseFiles");

            migrationBuilder.CreateTable(
                name: "Folders",
                schema: "FoldersAndTestCaseFiles",
                columns: table => new
                {
                    FolderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentFolderId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.FolderID);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_ParentFolderId",
                        column: x => x.ParentFolderId,
                        principalSchema: "FoldersAndTestCaseFiles",
                        principalTable: "Folders",
                        principalColumn: "FolderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestCases",
                schema: "FoldersAndTestCaseFiles",
                columns: table => new
                {
                    TestcaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    StepCount = table.Column<int>(type: "int", nullable: false),
                    FolderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCases", x => x.TestcaseId);
                    table.ForeignKey(
                        name: "FK_TestCases_Folders_FolderId",
                        column: x => x.FolderId,
                        principalSchema: "FoldersAndTestCaseFiles",
                        principalTable: "Folders",
                        principalColumn: "FolderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "FoldersAndTestCaseFiles",
                table: "Folders",
                columns: new[] { "FolderID", "Name", "ParentFolderId" },
                values: new object[] { 100, "TestFolder1", null });

            migrationBuilder.InsertData(
                schema: "FoldersAndTestCaseFiles",
                table: "TestCases",
                columns: new[] { "TestcaseId", "FolderId", "Name", "StepCount", "Type" },
                values: new object[] { 101, null, "Email.txt", 5, 3 });

            migrationBuilder.InsertData(
                schema: "FoldersAndTestCaseFiles",
                table: "Folders",
                columns: new[] { "FolderID", "Name", "ParentFolderId" },
                values: new object[] { 101, "TestFolder2", 100 });

            migrationBuilder.InsertData(
                schema: "FoldersAndTestCaseFiles",
                table: "TestCases",
                columns: new[] { "TestcaseId", "FolderId", "Name", "StepCount", "Type" },
                values: new object[] { 100, 101, "MyVoice.MP3", 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ParentFolderId",
                schema: "FoldersAndTestCaseFiles",
                table: "Folders",
                column: "ParentFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_FolderId",
                schema: "FoldersAndTestCaseFiles",
                table: "TestCases",
                column: "FolderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestCases",
                schema: "FoldersAndTestCaseFiles");

            migrationBuilder.DropTable(
                name: "Folders",
                schema: "FoldersAndTestCaseFiles");
        }
    }
}
