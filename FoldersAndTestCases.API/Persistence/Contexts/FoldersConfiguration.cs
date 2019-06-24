
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoldersAndTestCases.API.Domain.Models;

namespace FoldersAndTestCases.API.Persistence.Contexts
{
    public class FoldersConfiguration : IEntityTypeConfiguration<Folder>
    {
        public void Configure(EntityTypeBuilder<Folder> builder)
        {
            // Set configuration for entity
            builder.ToTable("Folders", "FoldersAndTestCaseFiles");

            // Set key for entity
            builder.HasKey(p => p.FolderID);
            builder.Property(p => p.FolderID).IsRequired().ValueGeneratedOnAdd();
            // Set configuration for columns
            builder.Property(p => p.ParentFolderId).HasColumnType("int");
            builder.Property(p => p.Name).HasColumnType("nvarchar(100)").IsRequired();

            builder.HasMany(oj => oj.ChildFolders)
                .WithOne(j => j.ParentFolder)
                .HasForeignKey(j => j.ParentFolderId)
                .IsRequired(false);

            builder.HasData
            (
                new Folder { FolderID = 100, Name = "TestFolder1" }, // Id set manually due to in-memory provider
                new Folder { FolderID = 101, ParentFolderId = 100, Name = "TestFolder2" }
            );
        }
    }
}
