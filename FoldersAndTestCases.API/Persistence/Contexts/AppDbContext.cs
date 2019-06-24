using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoldersAndTestCases.API.Domain.Models;

namespace FoldersAndTestCases.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Folder> Folders { get; set; }
        public DbSet<TestCaseFile> TestCases { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Apply configurations for entity

            modelBuilder
                .ApplyConfiguration(new FoldersConfiguration());
            modelBuilder
                .ApplyConfiguration(new TestCasesConfiguration());

            
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
