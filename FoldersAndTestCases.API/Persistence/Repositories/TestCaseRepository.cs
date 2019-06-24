using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoldersAndTestCases.API.Domain.Models;
using FoldersAndTestCases.API.Domain.Repositories;
using FoldersAndTestCases.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FoldersAndTestCases.API.Persistence.Repositories
{
    public class TestCaseRepository : BaseRepository, ITestCaseRepository{
        
        public TestCaseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TestCaseFile>> ListAsync(int? folderId)
        {
            return await _context.TestCases.Where(tc => tc.FolderId == folderId).ToListAsync();
        }
        public async Task<TestCaseFile> FindByIdAsync(int id)
        {
            return await _context.TestCases.FindAsync(id);
        }

        public async Task AddAsync(TestCaseFile testCase)
        {
            
            
            await _context.TestCases.AddAsync(testCase);
        }

        public void Remove(TestCaseFile testCase)
        {
            _context.TestCases.Remove(testCase);
        }
    }
}
