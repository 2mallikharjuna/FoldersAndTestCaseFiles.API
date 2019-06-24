using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoldersAndTestCases.API.Domain.Models;
using FoldersAndTestCases.API.Domain.Services;
using FoldersAndTestCases.API.Domain.Services.Communication;
using FoldersAndTestCases.API.Extensions;
using FoldersAndTestCases.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FoldersAndTestCases.API.Controllers
{
    [Route("/api/[controller]")]
    public class TestCaseFilesController: Controller
    {
        private readonly ITestCaseService _testCasesService;
        private readonly IMapper _mapper;
        protected readonly ILogger Logger;
        public TestCaseFilesController(ITestCaseService testCasesService, IMapper mapper, ILogger<TestCaseFilesController> logger)
        {
            _testCasesService = testCasesService;
            _mapper = mapper;
            Logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddTestCaserAsync([FromBody] SaveTestCaseResource resource)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(AddTestCaserAsync));
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var testCase = _mapper.Map<SaveTestCaseResource, TestCaseFile>(resource);

            var result = await _testCasesService.SaveAsync(testCase);

            if (!result.Success)
                return BadRequest(result.Message);

            var testCaseResource = _mapper.Map<TestCaseFile, TestCaseResource>(result.Folder);
            Logger?.LogInformation("The TestCase file has been added successfully.");
            return Ok(testCaseResource);
        }

        [HttpGet]
        public async Task<IEnumerable<TestCaseResource>> ListAsync(int? FolderID)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(ListAsync));
            var testCases = await _testCasesService.LisTestCasesAsync(FolderID);
            var tcResources = _mapper.Map<IEnumerable<TestCaseFile>, IEnumerable<TestCaseResource>>(testCases);
            Logger?.LogInformation("The TestCaseFiles are listed successfully.");
            return tcResources;
        }

        [HttpDelete("{TestCaseId}")]
        public async Task<IActionResult> DeleteTestCaseFileAsync(int TestCaseId)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(DeleteTestCaseFileAsync));
            var result = await _testCasesService.DeleteAsync(TestCaseId);

            if (!result.Success)
                return BadRequest(result.Message);

            var tcResource = _mapper.Map<TestCaseFile, TestCaseResource>(result.Folder);
            Logger?.LogInformation("The TestCaseFile has been deleted successfully.");
            return Ok(tcResource);
        }
    }
}
