using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoldersAndTestCases.API.Domain.Models;
using FoldersAndTestCases.API.Domain.Repositories;
using FoldersAndTestCases.API.Domain.Services;
using FoldersAndTestCases.API.Domain.Services.Communication;
using Microsoft.Extensions.Logging;

namespace FoldersAndTestCases.API.Services
{
    public class FolderService : IFolderService
    {
        private readonly IFolderRepository _folderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public FolderService(IFolderRepository folderRepository, IUnitOfWork unitOfWork, ILogger<FolderService> logger)
        {
            this._folderRepository = folderRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<FolderResponse> DeleteAsync(int id)
        {
            var existingFolder = await _folderRepository.FindByIdAsync(id);

            if (existingFolder == null)
                return new FolderResponse("folder not found.");

            try
            {
                _folderRepository.Remove(existingFolder);
                await _unitOfWork.CompleteAsync();

                return new FolderResponse(existingFolder);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(DeleteAsync), ex);
                // Do some logging stuff
                return new FolderResponse($"An error occurred when deleting the folder: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Folder>> ListAsync()
        {
            return await _folderRepository.ListAsync();
        }

        public async Task<FolderResponse> SaveAsync(Folder folder)
        {
            if (folder.ParentFolderId != null)
            {
                var existingFolder = await _folderRepository.FindByIdAsync(folder.ParentFolderId.Value);
                if (existingFolder == null)
                    return new FolderResponse("parent folder not found.");
                else
                {
                    folder.ParentFolder = existingFolder;
                }
            }
            try
            {
                await _folderRepository.AddAsync(folder);
                await _unitOfWork.CompleteAsync();

                return new FolderResponse(folder);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(SaveAsync), ex);
                // Do some logging stuff
                return new FolderResponse($"An error occurred when saving the folder: {ex.Message}");
            }
        }
    }
}
