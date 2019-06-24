using FoldersAndTestCases.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoldersAndTestCases.API.Domain.Repositories;

namespace FoldersAndTestCases.API.Persistence.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;
        

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
