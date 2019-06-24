using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoldersAndTestCases.API.Domain.Models;
using FoldersAndTestCases.API.Domain.Repositories;
using FoldersAndTestCases.API.Persistence.Contexts;

namespace FoldersAndTestCases.API.Persistence.Repositories
{
    public class FolderRepository : BaseRepository, IFolderRepository
    {
        public FolderRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Folder>> ListAsync()
        {
            return await _context.Folders.ToListAsync();
        }

        public async Task<Folder> FindByIdAsync(int id)
        {
            return await _context.Folders.FindAsync(id);
        }

        public async Task AddAsync(Folder folder)
        {
            await _context.Folders.AddAsync(folder);
        }

        public void Remove(Folder folder)
        {
            _context.Folders.Remove(folder);
        }
        
    }
}
