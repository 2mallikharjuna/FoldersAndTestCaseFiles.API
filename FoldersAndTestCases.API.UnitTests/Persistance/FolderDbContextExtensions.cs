using FoldersAndTestCases.API.Domain.Models;
using FoldersAndTestCases.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoldersAndTestCases.API.UnitTests.Persistance
{
    public static class FolderDbContextExtensions
    {
        public static void SeedFolderContext(AppDbContext dbContext)
        {
            // Add entities for DbContext instance

            dbContext.Folders.Add(new Folder { FolderID = 10, Name = "TestFolder10" }); // Id set manually due to in-memory provider
            dbContext.Folders.Add(new Folder { FolderID = 11, ParentFolderId = 10, Name = "TestFolder11" });
            dbContext.Folders.Add(new Folder { FolderID = 102, ParentFolderId = 10, Name = "TestFolder102" });
            dbContext.Folders.Add(new Folder { FolderID = 103, ParentFolderId = 102, Name = "TestFolder103" });
            dbContext.Folders.Add(new Folder { FolderID = 104, ParentFolderId = 101, Name = "TestFolder104" });
            dbContext.Folders.Add(new Folder { FolderID = 105, ParentFolderId = 102, Name = "TestFolder105" });
        }
    }
}
