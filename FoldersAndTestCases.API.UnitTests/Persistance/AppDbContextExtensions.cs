using FoldersAndTestCases.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoldersAndTestCases.API.UnitTests.Persistance
{
    public static class AppDbContextExtensions
    {
        public static void Seed(this AppDbContext dbContext)
        {
            FolderDbContextExtensions.SeedFolderContext(dbContext);
            TestCasesDbContextExtension.SeedTestCaseFilesContext(dbContext);
            dbContext.SaveChanges();
        }
    }
}
