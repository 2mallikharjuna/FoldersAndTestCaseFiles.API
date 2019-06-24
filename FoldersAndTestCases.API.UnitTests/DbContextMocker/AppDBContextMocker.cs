using System;
using System.Collections.Generic;
using System.Text;
using FoldersAndTestCases.API.Persistence.Contexts;
using FoldersAndTestCases.API.UnitTests.Persistance;
using Microsoft.EntityFrameworkCore;

namespace FoldersAndTestCases.API.UnitTests.DbContextMocker
{
    public static class AppDBContextMocker
    {
        public static AppDbContext GetAppDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
            // Create instance of DbContext
            var dbContext = new AppDbContext(options);
            // Add entities in memory
            dbContext.Seed();
            dbContext.SaveChanges();
            return dbContext;
        }
    }
}
