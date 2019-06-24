using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoldersAndTestCases.API.Domain.Models;

namespace FoldersAndTestCases.API.Domain.Repositories
{
    public interface IFolderRepository
    {
        Task<IEnumerable<Folder>> ListAsync();
        Task<Folder> FindByIdAsync(int id);
        Task AddAsync(Folder folder);
        void Remove(Folder folder);
    }
}
