using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoldersAndTestCases.API.Domain.Models;

namespace FoldersAndTestCases.API.Persistence.Contexts
{
    public class TestCasesConfiguration : IEntityTypeConfiguration<TestCaseFile>
    {
        public void Configure(EntityTypeBuilder<TestCaseFile> builder)
        {
            // Set configuration for entity
            builder.ToTable("TestCases", "FoldersAndTestCaseFiles");

            // Set key for entity
            builder.HasKey(p => p.TestcaseId);
            builder.Property(p => p.TestcaseId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(p => p.Type).HasColumnType("int").IsRequired();
            builder.Property(p => p.StepCount).HasColumnType("int").IsRequired();
            builder.Property(p => p.FolderId).HasColumnType("int");

            builder.HasOne(p => p.Folder)
                .WithMany(b => b.TestCases)
                .IsRequired(false);

            builder.HasData
            (
                new TestCaseFile
                {
                    TestcaseId = 200,
                    Name = "MyVoice.MP3",
                    Type = TestCaseType.Voice,
                    StepCount = 2,
                    FolderId = 101,
                },
                new TestCaseFile
                {
                    TestcaseId = 201,
                    Name = "Email.txt",
                    Type = TestCaseType.Email,
                    StepCount = 5,
                    FolderId = null,
                }
            );
        }
        
    }
}
