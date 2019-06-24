using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoldersAndTestCases.API.Domain.Models;
using FoldersAndTestCases.API.Domain.Services.Communication;

namespace FoldersAndTestCases.API.Domain.Services
{
    public interface ITestCaseService
    {
        //asynchronously return an enumeration of TestCases.
        Task<IEnumerable<TestCaseFile>> LisTestCasesAsync(int? folderID);
        Task<TestCaseResponce> SaveAsync(TestCaseFile folder);
        Task<TestCaseResponce> DeleteAsync(int id);
    }
}
