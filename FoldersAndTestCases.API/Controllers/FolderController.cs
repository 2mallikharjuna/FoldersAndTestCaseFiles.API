using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FoldersAndTestCases.API.Domain.Models;
using FoldersAndTestCases.API.Domain.Services;
using FoldersAndTestCases.API.Extensions;
using FoldersAndTestCases.API.Resources;
using Microsoft.Extensions.Logging;

namespace FoldersAndTestCases.API.Controllers
{
    [Route("/api/[controller]")]
    public class FoldersController : Controller
    {
        private readonly IFolderService _folderService;
        private readonly IMapper _mapper;
        protected readonly ILogger Logger;

        public FoldersController(IFolderService folderService, IMapper mapper, ILogger<FoldersController> logger)
        {
            _folderService = folderService;
            _mapper = mapper;
            Logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddFolderAsync([FromBody] SaveFolderResource resource)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(AddFolderAsync));

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var folder = _mapper.Map<SaveFolderResource, Folder>(resource);
            var result = await _folderService.SaveAsync(folder);

            if (!result.Success)
                return BadRequest(result.Message);

            var folderResource = _mapper.Map<Folder, FolderResource>(result.Folder);
            Logger?.LogInformation("The folder has been added successfully.");
            return Ok(folderResource);
        }
    }
}

