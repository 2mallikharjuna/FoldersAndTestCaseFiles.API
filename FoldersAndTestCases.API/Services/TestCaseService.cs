using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoldersAndTestCases.API.Domain.Models;
using FoldersAndTestCases.API.Domain.Repositories;
using FoldersAndTestCases.API.Domain.Services;
using FoldersAndTestCases.API.Domain.Services.Communication;
using FoldersAndTestCases.API.Resources;
using Microsoft.Extensions.Logging;

namespace FoldersAndTestCases.API.Services
{
    public class TestCaseService : ITestCaseService
    {
        private readonly ITestCaseRepository _testCaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        private readonly IEnumerable<int> _enumValues = Enum.GetValues(typeof(TestCaseType))
            .OfType<TestCaseType>()
            .Select(s => (int)s);

        public TestCaseService(ITestCaseRepository testCaseRepository, IUnitOfWork unitOfWork, ILogger<FolderService> logger)
        {
            this._testCaseRepository = testCaseRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<IEnumerable<TestCaseFile>> LisTestCasesAsync(int? folderId)
        {
            return  await _testCaseRepository.ListAsync(folderId);
        }
        public async Task<TestCaseResponce> DeleteAsync(int id)
        {
            var existingtestCase = await _testCaseRepository.FindByIdAsync(id);

            if (existingtestCase == null)
                return new TestCaseResponce("Testcase not found.");

            try
            {
                _testCaseRepository.Remove(existingtestCase);
                await _unitOfWork.CompleteAsync();

                return new TestCaseResponce(existingtestCase);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(DeleteAsync), ex);
                return new TestCaseResponce($"An error occurred when deleting the folder: {ex.Message}");
            }
        }

        public async Task<TestCaseResponce> SaveAsync(TestCaseFile testCase)
        {
            if ((int)testCase.Type == 0)
                return new TestCaseResponce("Invalid input Test case file type, should be 1 - 5");
            try
            { 
                await _testCaseRepository.AddAsync(testCase);
                await _unitOfWork.CompleteAsync();

                return new TestCaseResponce(testCase);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(SaveAsync), ex);
                // Do some logging stuff
                return new TestCaseResponce($"An error occurred when saving the testcase: {ex.Message}");
            }
        }
    }
}
