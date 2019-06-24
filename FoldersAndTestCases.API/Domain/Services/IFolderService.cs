using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoldersAndTestCases.API.Domain.Models;
using FoldersAndTestCases.API.Domain.Services.Communication;

namespace FoldersAndTestCases.API.Domain.Services
{
    public interface IFolderService
    {
        //asynchronously return an enumeration of Folders.
        Task<IEnumerable<Folder>> ListAsync();
        Task<FolderResponse> SaveAsync(Folder folder);
        Task<FolderResponse> DeleteAsync(int id);
    }
}
