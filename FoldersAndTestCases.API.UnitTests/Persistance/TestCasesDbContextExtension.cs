using System;
using System.Collections.Generic;
using System.Text;
using FoldersAndTestCases.API.Domain.Models;
using FoldersAndTestCases.API.Persistence.Contexts;

namespace FoldersAndTestCases.API.UnitTests.Persistance
{
    public static class TestCasesDbContextExtension
    {
        public static void SeedTestCaseFilesContext(AppDbContext dbContext)
        {
            dbContext.TestCases.Add(new TestCaseFile
            {
                TestcaseId = 100,
                Name = "MyVoice.MP3",
                Type = TestCaseType.Voice,
                StepCount = 2,
                FolderId = null,
            });
            dbContext.TestCases.Add(new TestCaseFile
            {
                TestcaseId = 101,
                Name = "Email.txt",
                Type = TestCaseType.Email,
                StepCount = 5,
                FolderId = null
            });
        }
    }
}
